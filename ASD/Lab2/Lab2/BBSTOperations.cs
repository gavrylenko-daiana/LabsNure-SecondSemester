namespace Lab2;

class BBSTOperations
{
    public void Insert(BBST tree, int value)
    {
        if (value < tree.Data)
        {
            if (tree.Left == null)
                tree.Left = new BBST(value);
            else
                Insert(tree.Left, value);
        }
        else
        {
            if (tree.Right == null)
                tree.Right = new BBST(value);
            else
                Insert(tree.Right, value);
        }
    }

    public void PrintPostOrder(BBST tree)
    {
        if (tree == null)
            return;
        PrintPostOrder(tree.Left);
        PrintPostOrder(tree.Right);
        Console.Write(tree.Data + " ");
    }

    public void PrintInOrder(BBST tree)
    {
        if (tree?.Left != null)
            PrintInOrder(tree.Left);
        Console.Write($"{tree?.Data} ");
        if (tree?.Right != null)
            PrintInOrder(tree.Right);
    }

    public void PrintPreOrder(BBST tree)
    {
        if (tree == null)
            return;
        Console.Write(tree.Data + " ");
        PrintPreOrder(tree.Left);
        PrintPreOrder(tree.Right);
    }

    public bool Search(BBST tree, int value)
    {
        if (tree == null)
            return false;
        if (value == tree.Data)
            return true;
        if (value < tree.Data)
            return Search(tree.Left, value);
        else
            return Search(tree.Right, value);
    }

    public int MinValue(BBST tree)
    {
        if (tree.Left == null)
            return tree.Data;

        return MinValue(tree.Left);
    }

    public void Remove(BBST tree, BBST parent, int value)
    {
        if (tree == null)
            return;
        if (value < tree.Data)
            Remove(tree.Left, tree, value);
        else if (value > tree.Data)
            Remove(tree.Right, tree, value);
        else
        {
            if (tree.Left == null && tree.Right == null)
            {
                if (parent.Left == tree)
                    parent.Left = null!;
                else
                    parent.Right = null!;
            }
            else if (tree.Left == null)
            {
                if (parent.Left == tree)
                    parent.Left = tree.Right;
                else
                    parent.Right = tree.Right;
            }
            else if (tree.Right == null)
            {
                if (parent.Left == tree)
                    parent.Left = tree.Left;
                else
                    parent.Right = tree.Left;
            }
            else
            {
                int minValue = MinValue(tree.Right);
                tree.Data = minValue;
                Remove(tree.Right, tree, minValue);
            }
        }
    }

    public int Count(BBST tree)
    {
        if (tree == null)
            return 0;
        return 1 + Count(tree.Left) + Count(tree.Right);
    }

    public int Height(BBST tree)
    {
        if (tree == null)
            return 0;
        return 1 + Math.Max(Height(tree.Left), Height(tree.Right));
    }

    public BBST Balance(BBST tree)
    {
        List<int> values = new List<int>();
        InOrderTraversal(tree, values);
        return BuildBalancedTree(values, 0, values.Count - 1);
    }

    private void InOrderTraversal(BBST tree, List<int> values)
    {
        if (tree == null)
            return;
        InOrderTraversal(tree.Left, values);
        values.Add(tree.Data);
        InOrderTraversal(tree.Right, values);
    }

    private BBST BuildBalancedTree(List<int> values, int start, int end)
    {
        if (start > end)
            return null!;
        int mid = start + (end - start) / 2;
        BBST tree = new BBST(values[mid]);
        tree.Left = BuildBalancedTree(values, start, mid - 1);
        tree.Right = BuildBalancedTree(values, mid + 1, end);
        return tree;
    }

    public BBST DeleteEven(BBST tree)
    {
        if (tree == null)
            return null!;
        tree.Left = DeleteEven(tree.Left);
        tree.Right = DeleteEven(tree.Right);
        if (tree.Data % 2 == 0)
            return Merge(tree.Left, tree.Right);
        return tree;
    }

    private BBST Merge(BBST left, BBST right)
    {
        if (left == null)
            return right;
        if (right == null)
            return left;
        if (left.Data < right.Data)
        {
            left.Right = Merge(left.Right, right);
            return left;
        }
        else
        {
            right.Left = Merge(left, right.Left);
            return right;
        }
    }

    public void Print(BBST tree)
    {
        List<List<string>> lines = new List<List<string>>();

        List<BBST> level = new List<BBST>();
        List<BBST> next = new List<BBST>();

        level.Add(tree);
        int nn = 1;

        int widest = 0;

        while (nn != 0)
        {
            List<string> line = new List<string>();

            nn = 0;

            for (int i = 0; i < level.Count; i++)
            {
                if (level[i] == null)
                {
                    line.Add(null);

                    next.Add(null);
                    next.Add(null);
                }
                else
                {
                    string aa = level[i].Data.ToString();
                    line.Add(aa);
                    if (aa.Length > widest) widest = aa.Length;

                    next.Add(level[i].Left);
                    next.Add(level[i].Right);

                    if (level[i].Left != null) nn++;
                    if (level[i].Right != null) nn++;
                }
            }

            if (widest % 2 == 1) widest++;

            lines.Add(line);

            (level, next) = (next, level);
            next.Clear();
        }

        int perpiece = lines[lines.Count - 1].Count * (widest + 4);
        for (int i = 0; i < lines.Count; i++)
        {
            List<string> line = lines[i];
            int hpw = (int)Math.Floor(perpiece / 2f) - 1;

            if (i > 0)
            {
                for (int j = 0; j < line.Count; j++)
                {
                    // split node
                    char c = ' ';
                    if (j % 2 == 1)
                    {
                        if (line[j - 1] != null)
                        {
                            c = (line[j] != null) ? '┴' : '┘';
                        }
                        else
                        {
                            if (j < line.Count && line[j] != null) c = '└';
                        }
                    }

                    Console.Write(c);

                    // lines and spaces
                    if (line[j] == null)
                    {
                        for (int k = 0; k < perpiece - 1; k++)
                        {
                            Console.Write(" ");
                        }
                    }
                    else
                    {
                        for (int k = 0; k < hpw; k++)
                        {
                            Console.Write(j % 2 == 0 ? " " : "─");
                        }

                        Console.Write(j % 2 == 0 ? "┌" : "┐");
                        for (int k = 0; k < hpw; k++)
                        {
                            Console.Write(j % 2 == 0 ? "─" : " ");
                        }
                    }
                }

                Console.WriteLine();
            }

            // print line of numbers
            for (int j = 0; j < line.Count; j++)
            {
                string f = line[j];
                if (f == null) f = "";
                int gap1 = (int)Math.Ceiling(perpiece / 2f - f.Length / 2f);
                int gap2 = (int)Math.Floor(perpiece / 2f - f.Length / 2f);

                // a number
                for (int k = 0; k < gap1; k++)
                {
                    Console.Write(" ");
                }

                Console.Write(f);
                for (int k = 0; k < gap2; k++)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();

            perpiece /= 2;
        }
    }
}