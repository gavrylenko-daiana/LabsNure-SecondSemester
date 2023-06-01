namespace Lab1;

public class OrderedLinkedList
{
    private Element? _firstElement;

    public OrderedLinkedList()
    {
        _firstElement = null;
    }

    public void AddElement(int newValue)
    {
        Element newElement = new Element
        {
            Value = newValue,
            NextElement = null
        };

        if (_firstElement == null || _firstElement.Value >= newElement.Value)
        {
            newElement.NextElement = _firstElement;
            _firstElement = newElement;
        }
        else
        {
            Element? currentElement = _firstElement;
            while (currentElement.NextElement != null && currentElement.NextElement.Value < newElement.Value)
            {
                currentElement = currentElement.NextElement;
            }

            newElement.NextElement = currentElement.NextElement;
            currentElement.NextElement = newElement;
        }
    }

    public void DeleteByIndex(int index)
    {
        if (_firstElement == null)
            return;

        Element? temp = _firstElement;

        if (index == 0)
        {
            _firstElement = temp.NextElement;
            return;
        }

        for (int i = 0; temp != null && i < index - 1; i++)
            temp = temp.NextElement;

        if (temp == null || temp.NextElement == null)
            return;

        Element? next = temp.NextElement.NextElement;

        temp.NextElement = next;
    }

    public void DeleteByValue(int value)
    {
        Element? temp = _firstElement, prev = null;

        if (temp != null && temp.Value == value)
        {
            _firstElement = temp.NextElement;
            return;
        }

        while (temp != null && temp.Value != value)
        {
            prev = temp;
            temp = temp.NextElement;
        }

        if (temp == null) return;

        prev!.NextElement = temp.NextElement;
    }

    public void DisplayElements()
    {
        Element? elementPointer = _firstElement;
        while (elementPointer != null)
        {
            Console.Write(elementPointer.Value + " ");
            elementPointer = elementPointer.NextElement;
        }
    }
    
    public bool ListEqual(OrderedLinkedList otherList)
    {
        Element? currentA = _firstElement;
        Element? currentB = otherList._firstElement;

        while (currentA != null && currentB != null)
        {
            if (currentA.Value != currentB.Value)
                return false;

            currentA = currentA.NextElement;
            currentB = currentB.NextElement;
        }

        return currentA == null && currentB == null;
    }
}