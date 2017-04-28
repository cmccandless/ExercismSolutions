using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree
{
    public int Value { get; }
    public BinarySearchTree Parent { get; set; } = null;
    private BinarySearchTree[] children = new BinarySearchTree[2];
    public BinarySearchTree Left
    {
        get => children[0];
        set => children[0] = value;
    }
    public BinarySearchTree Right
    {
        get => children[1];
        set => children[1] = value;
    }

    public IEnumerable<int> AsEnumerable()
    {
        if (Left != null)
            foreach (var value in Left.AsEnumerable()) yield return value;
        yield return Value;
        if (Right != null)
            foreach (var value in Right.AsEnumerable()) yield return value;
    }

    public BinarySearchTree(params int[] values)
    {
        Value = values[0];
        foreach (var v in values.Skip(1)) Add(v);
    }

    public BinarySearchTree Add(int x)
    {
        var index = x <= Value ? 0 : 1;
        if (children[index] == null) children[index] = new BinarySearchTree(x) { Parent = this };
        else children[index].Add(x);
        return this;
    }
}
