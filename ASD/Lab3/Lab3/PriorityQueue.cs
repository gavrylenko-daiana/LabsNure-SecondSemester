namespace Lab3;

public class PriorityQueue : Collection
{
    private readonly (int priority, int value)[] _data;
    private int _count;

    public PriorityQueue(int size)
    {
        _data = new (int priority, int value)[size];
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

    public void Enqueue(int priority, int value)
    {
        if (IsFull())
            throw new InvalidOperationException("Queue is full");

        _data[_count++] = (priority, value);
        int i = _count - 1;

        while (i != 0 && _data[(i - 1) / 2].priority < _data[i].priority)
        {
            (_data[i], _data[(i - 1) / 2]) = (_data[(i - 1) / 2], _data[i]);
            i = (i - 1) / 2;
        }
    }

    public (int priority, int value) DequeueMax()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");

        (int priority, int value) root = _data[0];
        _data[0] = _data[_count - 1];
        _count--;
        Heapify(0);

        return root;
    }

    private void Heapify(int i)
    {
        int leftChildIndex = 2 * i + 1;
        int rightChildIndex = leftChildIndex + 1;
        int largestIndex = i;

        if (leftChildIndex < _count && _data[leftChildIndex].priority > _data[largestIndex].priority)
            largestIndex = leftChildIndex;

        if (rightChildIndex < _count && _data[rightChildIndex].priority > _data[largestIndex].priority)
            largestIndex = rightChildIndex;

        if (largestIndex != i)
        {
            (_data[i], _data[largestIndex]) = (_data[largestIndex], _data[i]);
            Heapify(largestIndex);
        }
    }

    public void PrintQueue()
    {
        for (int i = 0; i < _count; i++)
        {
            Console.Write($"({_data[i].priority}, {_data[i].value}) ");
        }

        Console.WriteLine();
    }
}