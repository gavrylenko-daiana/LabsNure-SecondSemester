namespace secondLab;

class RList
{
    private int? _info;
    private RList? _next;

    // 1 Конструктор з одним параметром (число); 
    public RList(int? info)
    {
        _info = info;
    }

    // 3 Конструктор копіювання;
    public RList(RList other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));

        _info = other._info;
        _next = other._next;
    }

    // 4 Метод додавання нового елементу першим у список;
    public void AddFirst(int item)
    {
        if (item <= 0) throw new ArgumentOutOfRangeException(nameof(item));

        RList newNode = new RList(_info);
        newNode._next = _next;
        _info = item;
        _next = newNode;
    }

    // 8 Рекурсивний метод додавання нового елемента n-ним у список;
    public void AddNewElementByIndex(int i, int n)
    {
        if (n < 0)
        {
            AddFirst(i);
            return;
        }

        if (n == 0)
        {
            AddFirst(i);
            return;
        }

        if (_next == null)
            _next = new RList(i);
        else
            _next.AddNewElementByIndex(i, n - 1);
    }
    
    public void AddBeforeByValue(int data, int byValue)
    {
        RList newNode = new RList(data);
        var current = this;
        if (current == null) return;

        if (current._info == byValue)
        {
            newNode = new RList(current);
            current._info = data;
            current._next = newNode;
            current = current._next;
        }
        
        while (current._next != null)
        {
            if (current._next._info == byValue)
            {
                newNode = new RList(data);
                newNode._next = current._next;
                current._next = newNode;
                current = newNode._next;
            }
            else
            {
                current = current._next;
            }
        }
    }

    // 18 Метод видалення елемента із заданим значенням (першого з кількох);
    public void Remove(int i)
    {
        if (_info == i)
        {
            _info = _next?._info;
            _next = _next?._next;
            return;
        }

        _next?.Remove(i);
    }

    // 25 Метод видалення всіх елементів списку;
    public void Clear()
    {
        _info = null;
        _next = null;
    }

    // 29 Не рекурсивний метод друку елементів списку у зворотному порядку у стовпець;
    public void PrintReverse()
    {
        int count = 0;
        RList? current = this;
        while (current != null)
        {
            count++;
            current = current._next;
        }

        for (int i = count; i > 0; i--)
        {
            current = this;
            for (int j = 1; j < i; j++)
            {
                current = current?._next;
            }

            Console.WriteLine(current?._info);
        }
    }

    // 41 Метод пошуку елемента із заданим значенням (результат - номер знайденого елемента у списку);
    public int Find(int i)
    {
        int index = 0;
        RList? current = this;
        while (current != null)
        {
            if (current._info == i) return index;
            index++;
            current = current._next;
        }

        return -1;
    }

    // 51 Властивість Last для зчитування та установки значення останнього елемента в списку;
    public int? Last
    {
        get
        {
            if (_next == null) return _info;
            RList? current = this;
            while (current._next != null) current = current._next;
            return current._info;
        }
        set
        {
            if (_next == null) _info = value;
            RList? current = this;
            while (current._next != null) current = current._next;
            current._info = value;
        }
    }

    // 66 Перевизначити для списку  операцію ++
    public static RList operator ++(RList list)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        if (list._next == null) throw new InvalidOperationException();
        RList? current = list;
        while (current != null)
        {
            current._info++;
            current = current._next;
        }

        return list;
    }

    // 79 Перевизначити для списку будь-яку операцію
    public static RList? operator +(RList list, int value)
    {
        if (list._info == null) throw new ArgumentNullException(nameof(list));
        if (value == 0) return list;

        RList? current = list;

        while (current != null)
        {
            current._info = (current._info + value);
            current = current._next;
        }
        return list;
    }

    public void PrintList()
    {
        Console.Write($"{_info} ");
        _next?.PrintList();
    }
}