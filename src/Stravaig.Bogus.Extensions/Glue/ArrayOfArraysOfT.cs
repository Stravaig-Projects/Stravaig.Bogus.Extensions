using System;
using System.Collections;
using System.Collections.Generic;

namespace Stravaig.Bogus.Extensions;


public class ArrayOfArrays<T>: IReadOnlyList<T>
{
    private static class EmptyArrayOfArrays<TItem>
    {
        internal static readonly ArrayOfArrays<TItem> Value = new();
    }

    [Serializable]
    public struct ArrayOfArraysEnumerator : IEnumerator<T>
    {
        private readonly ArrayOfArrays<T> _arrayOfArrays;
        private int _arrayIndex;
        private int _index;
        private T[] _currentArray;
        private T _current;

        internal ArrayOfArraysEnumerator(ArrayOfArrays<T> arrayOfArrays)
        {
            var a = Array.Empty<T>();
            _arrayOfArrays = arrayOfArrays;
            Reset();
        }

        /// <inheritdoc />
        public void Dispose() { }

        /// <inheritdoc />
        public bool MoveNext()
        {
            if (_arrayOfArrays._totalLength == 0)
                return false;
            
            _currentArray = _arrayOfArrays._data[_arrayIndex];
            _current = _currentArray[_index];

            _index++;
            if (_index >= _currentArray.Length)
            {
                _arrayIndex++;
                _index = 0;
            }

            if (_arrayIndex >= _arrayOfArrays._data.Length)
                return false;

            return true;
        }


        /// <inheritdoc />
        public T Current
        {
            get  => _current;
        }

        Object IEnumerator.Current
        {
            get => Current!;
        }

        /// <inheritdoc />
        public void Reset() {
            _arrayIndex = 0;
            _index = 0;
            _currentArray = Array.Empty<T>();
            _current = default;
        }

    }
    
    internal static ArrayOfArrays<T> Empty()
    {
        return EmptyArrayOfArrays<T>.Value;
    }
    
    private T[][] _data;
    private int _totalLength;
    
    public ArrayOfArrays(params T[][] data)
    {
        _data = data ?? throw new ArgumentNullException(nameof(data));
        _totalLength = 0;
        for (int i = 0; i < data.Length; i++)
        {
            var array = data[i] ?? throw new ArgumentException($"Item at index {i} is null", nameof(data));
            _totalLength += array.Length;
        }
    }

    public T this[int index]
    {
        get
        {
            ThrowIfIndexOutOfRange(index);
            int localIndex = index;
            
            // ReSharper disable once ForCanBeConvertedToForeach
            for (int i = 0; i < _data.Length; i++)
            {
                var innerArray = _data[i];
                if (localIndex < innerArray.Length)
                    return innerArray[localIndex];
                localIndex -= innerArray.Length;
            }
            
            // Should never get here
            throw new InvalidOperationException(
                $"Should never reach this line of code. Requested index:{index}; localIndex:{localIndex}");
        }
    }

    private void ThrowIfIndexOutOfRange(int index)
    {
        if (index < 0 || index >= _totalLength)
        {
            throw new IndexOutOfRangeException(
                $"The index {index} is out of range. Index must be between 0 and {_totalLength - 1}.");
        }
    }

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
    {
        return new ArrayOfArraysEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <inheritdoc />
    public int Count { get => _totalLength; }
    
    public int MaxIndex { get => _totalLength - 1; }
    
    public bool IsEmpty { get => _totalLength == 0; }
    
    public bool HasContent { get => _totalLength > 0; }
}