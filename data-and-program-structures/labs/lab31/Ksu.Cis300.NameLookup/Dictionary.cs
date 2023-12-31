﻿/* Dictionary.cs
 * Author: Rod Howell
 * Edited: Joe Webster
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ksu.Cis300.LinkedListLibrary;

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// A generic dictionary implemented using a hash table.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    public class Dictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        /// <summary>
        /// The initial size of the table.
        /// </summary>
        private const int _initialTableSize = 5;

        /// <summary>
        /// The allowable table sizes.
        /// </summary>
        private int[] _tableSizes =
        {
            _initialTableSize, 11, 23, 47, 97, 197, 397, 797, 1597, 3203, 6421, 12853, 25717,
            51437, 102877, 205759, 411527, 823117, 1646237, 3292489, 6584983,
            13169977, 26339969, 52679969, 105359939, 210719881, 421439783,
            842879579, 1685759167
        };

        /// <summary>
        /// The number of keys stored in the dictionary.
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// The location in _tableSizes containing the current table size.
        /// </summary>
        private int _sizeIndex = 0;

        /// <summary>
        /// A hash table storing the keys and their associated values.
        /// </summary>
        private LinkedListCell<KeyValuePair<TKey, TValue>>[] _table = new LinkedListCell<KeyValuePair<TKey, TValue>>[_initialTableSize];

        /// <summary>
        /// Determines whether the given key is null. If so, throws an ArgumentNullException.
        /// </summary>
        /// <param name="k">The key to check.</param>
        private void CheckKey(TKey k)
        {
            if (k == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Gets the table location in which to store the given key.
        /// </summary>
        /// <param name="k">The key.</param>
        /// <returns>The table location where k belongs.</returns>
        private int GetLocation(TKey k)
        {
            return (k.GetHashCode() & 0x7fffffff) % _table.Length;
        }

        /// <summary>
        /// Gets the cell containing the given key in the given linked list, or null if no cell in the list contains the key.
        /// </summary>
        /// <param name="k">The key to look for.</param>
        /// <param name="list">The linked list to search.</param>
        /// <returns>The cell containing k, or null if there is no such cell in the list.</returns>
        private LinkedListCell<KeyValuePair<TKey, TValue>> GetCell(TKey k, LinkedListCell<KeyValuePair<TKey, TValue>> list)
        {
            for (LinkedListCell<KeyValuePair<TKey, TValue>> p = list; p != null; p = p.Next)
            {
                if (k.Equals(p.Data.Key))
                {
                    return p;
                }
            }
            return null;
        }

        /// <summary>
        /// Inserts the given cell into the beginning of the linked list at the given location of the hash table.
        /// </summary>
        /// <param name="cell">The cell to insert.</param>
        /// <param name="loc">The table location at which to insert the cell.</param>
        private void Insert(LinkedListCell<KeyValuePair<TKey, TValue>> cell, int loc)
        {
            cell.Next = _table[loc];
            _table[loc] = cell;
        }

        /// <summary>
        /// Inserts a cell containing the given key and value into the beginning of the linked list at the given
        /// location of the hash table.
        /// </summary>
        /// <param name="k">The key to insert.</param>
        /// <param name="v">The value associated with the key.</param>
        /// <param name="loc">The table location at which to insert the key and value.</param>
        private void Insert(TKey k, TValue v, int loc)
        {
            LinkedListCell<KeyValuePair<TKey, TValue>> cell = new LinkedListCell<KeyValuePair<TKey, TValue>>();
            cell.Data = new KeyValuePair<TKey, TValue>(k, v);
            Insert(cell, loc);
            _count++;
            if (_count > _table.Length && _sizeIndex < _tableSizes.Length - 1)
            {
                LinkedListCell<KeyValuePair<TKey, TValue>>[] t = _table;
                _sizeIndex++;
                _table = new LinkedListCell<KeyValuePair<TKey, TValue>>[_tableSizes[_sizeIndex]];
                for (int i = 0; i < t.Length; i++)
                {
                    while (t[i] != null)
                    {
                        cell = t[i];
                        t[i] = cell.Next;
                        Insert(cell, GetLocation(cell.Data.Key));
                    }
                }
            }
        }

        /// <summary>
        /// Tries to get the value associated with the given key.
        /// </summary>
        /// <param name="k">The key to look for.</param>
        /// <param name="v">The value associated with k, or the default value if k is not in the dictionary.</param>
        /// <returns>Whether k was found.</returns>
        public bool TryGetValue(TKey k, out TValue v)
        {
            CheckKey(k);
            LinkedListCell<KeyValuePair<TKey, TValue>> cell = GetCell(k, _table[GetLocation(k)]);
            if (cell == null)
            {
                v = default(TValue);
                return false;
            }
            else
            {
                v = cell.Data.Value;
                return true;
            }
        }

        /// <summary>
        /// Adds the given key and value to the dictionary. 
        /// If the key is already there, throws an ArgumentException.
        /// </summary>
        /// <param name="k">The key to add.</param>
        /// <param name="v">The value to add.</param>
        public void Add(TKey k, TValue v)
        {
            CheckKey(k);
            int loc = GetLocation(k);
            if (GetCell(k, _table[loc]) == null)
            {
                Insert(k, v, loc);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Gets an enumerator for the key-value-pairs in this dictionary.
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return new MyEnum(_table);
        }

        /// <summary>
        /// Gets an enumerator for the key-value-pairs in this dictionary.
        /// </summary>
        /// <returns>The enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region Public Class implementing IEnumerator

        /// <summary>
        /// Class implementing IEnumerator
        /// </summary>
        public class MyEnum : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            /// <summary>
            /// The current array index
            /// </summary>
            private int _currentIndex = -1;

            /// <summary>
            /// The current linkedlistcell
            /// </summary>
            private LinkedListCell<KeyValuePair<TKey, TValue>> _currentCell = new LinkedListCell<KeyValuePair<TKey, TValue>>();

            /// <summary>
            /// The hashtable
            /// </summary>
            private LinkedListCell<KeyValuePair<TKey, TValue>>[] _hashTable;

            /// <summary>
            /// Public constructor
            /// </summary>
            public MyEnum(LinkedListCell<KeyValuePair<TKey, TValue>>[] table)
            {
                _hashTable = table;
            }

            /// <summary>
            /// Gets the currentCells data
            /// </summary>
            public KeyValuePair<TKey, TValue> Current
            {
                get
                {
                    if (_currentIndex == -1 || _currentIndex == _hashTable.Length)
                    {
                        throw new InvalidOperationException();
                    }
                    return _currentCell.Data;
                }
            }

            /// <summary>
            /// Gets the key-value pair at the current position
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            /// <summary>
            /// Disposes any unmanaged resources
            /// </summary>
            public void Dispose()
            {
                
            }

            /// <summary>
            /// Method returning true if we can move next
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                if(_hashTable.Length == _currentIndex)
                {
                    return false;
                }
                else
                {
                    _currentCell = _currentCell.Next;
                    while (_currentCell == null)
                    {
                        _currentIndex++;
                        if (_hashTable.Length == _currentIndex)
                        {
                            return false;
                        }
                        else
                        {
                            _currentCell = _hashTable[_currentIndex];
                        }
                    }
                    return true;
                }
            }

            /// <summary>
            /// Resets, but not implemented
            /// </summary>
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}
