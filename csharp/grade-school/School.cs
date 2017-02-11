using System.Collections.Generic;
using System.Linq;

public class School
{
	public RosterClass Roster = new RosterClass();

	public void Add(string name, int grade)
	{
		Roster.Add(name, grade);
	}

	public List<string> Grade(int grade)
	{
		return Roster[grade];
	}

	public class RosterClass
	{
		private Dictionary<int, List<string>> roster = new Dictionary<int,List<string>>();
		
		public List<string> this[int grade]
		{
			get
			{
				return roster.ContainsKey(grade) ? roster[grade].OrderBy(x => x).ToList() : new List<string>();
			}
		}

		public void Add(string name, int grade)
		{
			if (!roster.ContainsKey(grade)) roster[grade] = new List<string>();
			roster[grade].Add(name);
		}

		public int Count { get { return roster.Count; } }
	}
}
