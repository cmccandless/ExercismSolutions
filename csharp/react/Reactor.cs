using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.react
{
	public delegate void ChangedEventHandler(object sender, int value);
	public class Reactor
	{
		private Dictionary<Cell, HashSet<Cell>> cells = new Dictionary<Cell, HashSet<Cell>>();
		public Cell CreateInputCell(int value)
		{
			var cell = new Cell { Value = value };
			cell.Changed += CellChanged;
			cells.Add(cell, new HashSet<Cell>());
			return cell;
		}
		public Cell CreateComputeCell(Cell[] inputs, Func<int[], int> lambda)
		{
			var cell = new Cell { Updater = lambda, Dependencies = new HashSet<Cell>(inputs) };
			cells.Add(cell.Update(), new HashSet<Cell>());
			foreach (var input in inputs) cells[input].Add(cell);
			return cell;
		}
		private void CellChanged(object sender, int value)
		{
			var cell = sender as Cell;
			if (cell == null) return;
			var updated = new HashSet<Cell>();
			updated.Add(cell);
			var toUpdate = new HashSet<Cell>(cells[cell]);
			while (toUpdate.Any())
			{
				cell = toUpdate.OrderBy(c => c.Index).First();
				toUpdate.Remove(cell);
				var deps = cell.Dependencies.Except(updated).ToArray();
				if (deps.Any())
				{
					foreach (var dep in deps) toUpdate.Add(dep);
					toUpdate.Add(cell);
				}
				else
				{
					updated.Add(cell.Update());
					foreach (var other in cells[cell]) toUpdate.Add(other);
				}
			}
		}
	}
	public class Cell
	{
		public ChangedEventHandler Changed;
		private static int counter = 0;
		public readonly int Index;
		private int _value;
		public Func<int[], int> Updater = null;
		public HashSet<Cell> Dependencies = new HashSet<Cell>();
		public int Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (_value != value)
				{
					_value = value;
					if (this.Changed != null) this.Changed(this, value);
				}
			}
		}
		public Cell() { Index = counter++; }
		public Cell Update()
		{
			if (Updater != null) this.Value = Updater(Dependencies.Select(c => c.Value).ToArray());
			return this;
		}
		public override string ToString() { return Index.ToString(); }
	}
}
