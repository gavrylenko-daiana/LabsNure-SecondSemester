namespace Lab3;

public class List : Collection
{
    private readonly int[] _data;
    private int _count;

    public List(int size)
    {
        _data = new int[size];
        _count = 0;
    }

    public override bool IsFull()
    {
        return _count == _data.Length;
    }
    
    public bool IsEmpty()
    {
        return _count == 0;
    }
    
    public int Size()
    {
        return _count;
    }
    
    public void PrintList()
    {
        for (int i = 0; i < _count; i++)
        {
            Console.Write(_data[i] + " ");
        }

        Console.WriteLine();
    }

    public void HeapSort(bool ascending = true, int startPosition = 0)
    {
        for (int i = _count / 2 - 1; i >= startPosition; i--) Heapify(_count, i, ascending);

        for (int i = _count - 1; i >= startPosition; i--)
        {
            (_data[startPosition], _data[i]) = (_data[i], _data[startPosition]);

            Heapify(i, startPosition, ascending);
        }
    }

    private void Heapify(int n, int i, bool ascending)
    {
        int largest = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;

        if (l < n && ((ascending && _data[l] > _data[largest]) || (!ascending && _data[l] < _data[largest]))) largest = l;

        if (r < n && ((ascending && _data[r] > _data[largest]) || (!ascending && _data[r] < _data[largest]))) largest = r;

        if (largest != i)
        {
            (_data[i], _data[largest]) = (_data[largest], _data[i]);

            Heapify(n, largest, ascending);
        }
    }

    public void Add(int item)
    {
        if (IsFull()) throw new InvalidOperationException("List is full");

        _data[_count++] = item;
    }
}
