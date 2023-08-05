using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class AsimetricalList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection, IList
{
    private const int DefaultCapacity = 1;

    private T[] _array;
    private uint _positionLeft;
    private uint _positionRight;

    private bool _isReadOnly;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index + _positionLeft >= _positionRight)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return _array[index];
        }
        set
        {
            if (index < 0 || index + _positionLeft >= _positionRight)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            _array[index] = value;
        }
    }
    object? IList.this[int index]
    {
        get => this[index];
        set
        {
            if (typeof(T).IsValueType && value == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                this[index] = (T) value!;
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException();
            }
        }
    }

    public int Count => (int) (_positionRight - _positionLeft);

    public bool IsReadOnly => _isReadOnly;

    public bool IsSynchronized => throw new NotImplementedException();

    public object SyncRoot => throw new NotImplementedException();

    public bool IsFixedSize => throw new NotImplementedException();

    public void Add(T item)
    {
        if (_positionRight >= _array.Length)
        {
            AddWithResizeRight(item);
        }
        else
        {
            _array[_positionRight] = item;
            _positionRight++;
        }

    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void AddWithResizeRight(T item)
    {
        Debug.Assert(_positionRight - _positionLeft == _array.Length);
        uint size = _positionRight - _positionLeft;
        GrowRight((int) size + 1);
        _array[_positionRight++] = item;
    }

    private void AddWithResizeLeft(T item)
    {
        Debug.Assert(_positionRight - _positionLeft == _array.Length);
        uint size = _positionRight - _positionLeft;
        GrowLeft((int) size + 1);
        _array[--_positionLeft] = item;
    }

    public int Add(object? value)
    {
        throw new NotImplementedException();
    }

    public void AddFirst(T item)
    {
        if(_positionLeft != 0)
        {
            _array[--_positionLeft] = item;
            return;
        }

        AddWithResizeLeft(item);
    }

    public void Clear()
    {
        _array = new T[0];
        _positionLeft = 0;
        _positionRight = 0;
    }

    public bool Contains(T item)
    {
        return _positionRight - _positionLeft != 0 && IndexOf(item) >= 0;
    }

    bool IList.Contains(object? item)
    {
        if (IsCompatibleObject(item))
        {
            return Contains((T) item!);
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    private void GrowRight(int capacity)
    {
        Debug.Assert(_array.Length < capacity);

        int newcapacity = _array.Length == 0 ? DefaultCapacity : 2 * _array.Length;

        // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
        // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
        if ((uint) newcapacity > Array.MaxLength)
            newcapacity = Array.MaxLength;

        // If the computed capacity is still less than specified, set to the original argument.
        // Capacities exceeding Array.MaxLength will be surfaced as OutOfMemoryException by Array.Resize.
        if (newcapacity < capacity)
            newcapacity = capacity;

        T[] newItems = new T[newcapacity];

        if (_positionLeft != _positionRight)
        {
            for(uint i = _positionLeft;i < _positionRight; i++)
            {
                newItems[i] = _array[i];
            }
        }

        _array = newItems;
    }

    private void GrowLeft(int capacity)
    {
        Debug.Assert(_array.Length < capacity);

        int newcapacity = _array.Length == 0 ? DefaultCapacity : 2 * _array.Length;

        // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
        // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
        if ((uint) newcapacity > Array.MaxLength)
            newcapacity = Array.MaxLength;

        // If the computed capacity is still less than specified, set to the original argument.
        // Capacities exceeding Array.MaxLength will be surfaced as OutOfMemoryException by Array.Resize.
        if (newcapacity < capacity)
            newcapacity = capacity;

        int increase = newcapacity - _array.Length;

        T[] newItems = new T[newcapacity];

        if (_positionLeft != _positionRight)
        {
            for (uint i = _positionLeft; i < _positionRight; i++)
            {
                newItems[i + increase] = _array[i];
            }
        }

        _positionLeft += increase;
        _positionRight += increase;

        _array = newItems;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public int IndexOf(object? value)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, object? value)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void Remove(object? value)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
