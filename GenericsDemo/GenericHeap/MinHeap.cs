using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericHeap
{

    //what is a heap?
    //heap property - each "node" has 2 children,
    //each child is (less for maxheap/greater for minheap) than the parent
    //  therefore top-most node is largest/smallest, respectively


    //parents & children in an array/list

    //                  0
    //       1                    2
    //    3     4              5    6
    //   7 8   9 X

    // LeftChildIndex( int parentIndex ) => parentIndex * 2 + 1;
    // RightChildIndex( int parentIndex ) => parentIndex * 2 + 2;
    // ParentIndex( int childIndex ) => (childIndex - 1) / 2;


    //https://en.wikipedia.org/wiki/Binary_heap
    public class MinHeap<T> where T : IComparable<T> 
    { 

        //every incoming object will implement IComparable<T>
        //CompareTo semantics:

        //this.CompareTo( that )
        //  -  this comes "before" that or this < that
        //  0  this == that
        //  +  this comes "after" that or this > that

        private class MinHeapNode
        {
            public T Value { get; set; }
            public MinHeapNode Next { get; set; }
        }

        List<T> _allElements = new List<T>();

        //private class MinHeapEnumerator : IEnumerator<T>
        //{
        //    public MinHeapNode RootNode { get; set; }
        //    public MinHeapNode CurrNode { get; set; }

        //    public T Current => CurrNode?.Value;

        //    object IEnumerator.Current => Current;

        //    public void Dispose()
        //    {
                
        //    }

        //    public bool MoveNext()
        //    {
        //        if (CurrNode == null)
        //        {
        //            CurrNode = RootNode;
        //        }
        //        else
        //        {
        //            CurrNode = CurrNode.Next;
        //        }
        //        return CurrNode != null;
        //    }

        //    public void Reset()
        //    {
        //        CurrNode = null;
        //    }
        //}

        public void Add( T toAdd)
        {
            _allElements.Add(toAdd);
            SiftUp(_allElements.Count - 1);
        }

        public void Remove( T toRemove)
        {
            //we're looking for a CompareTo() == 0
            for(int i = 0; i < _allElements.Count; i++)
            {
                if (toRemove.CompareTo(_allElements[i]) == 0)
                {
                    _allElements.RemoveAt(i);
                }
                Heapify();
            }
            
            
        }

        public T Peek()
        {
            if (_allElements.Count > 0) return _allElements[0];
            return default(T);
        }

        public T Pop()
        {
            T toReturn = default(T);
            if (_allElements.Count > 0) toReturn = _allElements[0];
         
            //todo: actually remove the top node
            //swap with the last element
            _allElements[0] = _allElements[_allElements.Count - 1];
            //remove the last element
            _allElements.RemoveAt(_allElements.Count - 1);
            //heapify()
            Heapify();

            return toReturn;
        }



        private void SiftUp(int index)
        {
            int parentIndex;
            T temp;
            if (index != 0)
            {
                parentIndex = (index - 1)/2;
                if (index > 0 && _allElements[index].CompareTo(_allElements[parentIndex]) == -1)
                {
                    temp = _allElements[parentIndex];
                    _allElements[parentIndex] = _allElements[index];
                    _allElements[index] = temp;
                    SiftUp(parentIndex);
                }
            }
        }


        private void Heapify()
        {
            int curr = 0;
            while (curr < _allElements.Count)
            {
                int min = curr;
                int leftChild = 2 * curr + 1;
                int rightChild = 2 * curr + 2;

                if (leftChild < _allElements.Count && _allElements[leftChild].CompareTo(_allElements[min]) == -1) min = leftChild;

                if (rightChild < _allElements.Count && _allElements[rightChild].CompareTo(_allElements[min]) == -1) min = rightChild;
                
                if (min == curr) break;

                else
                {
                    T swap = _allElements[curr];
                    _allElements[curr] = _allElements[min];
                    _allElements[min] = swap;
                    curr = min;
                }
            }
        }
    }
}
