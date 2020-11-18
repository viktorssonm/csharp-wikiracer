using System;
using System.Collections.Generic;

public class PriorityQueue<T> where T : IComparable<T>
{
    public PriorityQueue()
    {
        elements = new List<T>();
    }

    public void Enqueue(T data)
    {
        elements.Add(data);
        BubbleUp(numberOfItems);
        numberOfItems++;
    }

    public T Dequeue()
    {
        // Check if there is any items in the array;
        if (numberOfItems < 1)
        {
            throw new IndexOutOfRangeException("No more items in array");
        }

        T rootElement = elements[0];

        if (numberOfItems == 1)
        {
            numberOfItems--;
            elements.RemoveAt(0);
            return rootElement;
        }

        elements[0] = elements[numberOfItems - 1];
        elements.RemoveAt(numberOfItems - 1);
        numberOfItems--;
        BubbleDown(0);

        return rootElement;

    }

    private void BubbleDown(int root)
    {
        T rootElement = elements[root];
        int leftChildIndex = GetLeftChild(root);
        int rightChildIndex = GetRightChild(root);
        int endOfList = numberOfItems - 1;

        // Check if no childs exists.
        if ((leftChildIndex > endOfList) && (rightChildIndex > endOfList))
        {
            return;
        }

        // Check if only left child exists.
        if ((leftChildIndex <= endOfList) && (rightChildIndex > endOfList))
        {
            T leftElement = elements[leftChildIndex];
            if (rootElement.CompareTo(leftElement) > 0)
            {
                swap(root, leftChildIndex);
                BubbleDown(leftChildIndex);
                return;
            }
        }

        // Check if only right child exists.
        if ((leftChildIndex > endOfList) && (rightChildIndex <= endOfList))
        {
            T rightElement = elements[rightChildIndex];
            if (rootElement.CompareTo(rightElement) > 0)
            {
                swap(root, rightChildIndex);
                BubbleDown(rightChildIndex);
                return;
            }
        }

        // If both child exists, pick the smallest and check.
        if ((leftChildIndex <= endOfList) && rightChildIndex <= endOfList)
        {
            T leftElement = elements[leftChildIndex];
            T rightElement = elements[rightChildIndex];

            // If leftElement is smaller than rightElement
            if (leftElement.CompareTo(rightElement) < 0)
            {
                // If rootElement is larger han left perform swap.
                if (rootElement.CompareTo(leftElement) > 0)
                {
                    swap(root, leftChildIndex);
                    BubbleDown(leftChildIndex);
                    return;
                }

                // In this case Right index is larger han left.
            }
            else
            {   // If rootelement is larger than right perform swap.
                if (rootElement.CompareTo(rightElement) > 0)
                {
                    swap(root, rightChildIndex);
                    BubbleDown(rightChildIndex);
                    return;
                }
            }

        }
        return;

    }

    // Test method to validate three.
    public bool validateElements(int root)
    {
        T rootElement = elements[root];
        int leftChildIndex = GetLeftChild(root);
        int rightChildIndex = GetRightChild(root);

        // If left child exists
        if (leftChildIndex < numberOfItems - 1)
        {
            T leftChildElement = elements[leftChildIndex];
            if (rootElement.CompareTo(leftChildElement) > 0)
            {
                return false;
            }
            validateElements(leftChildIndex);
        }

        // If right child exists
        if (rightChildIndex < numberOfItems - 1)
        {
            T rightChildElement = elements[rightChildIndex];
            if (rootElement.CompareTo(rightChildElement) > 0)
            {
                return false;
            }
            validateElements(rightChildIndex);
        }


        return true;
    }

    private void BubbleUp(int position)
    {
        if (position == 0)
        {
            return;
        }
        T parentItem = elements[GetParent(position)];
        T childItem = elements[position];

        if (parentItem.CompareTo(childItem) > 0)
        {
            elements[GetParent(position)] = childItem;
            elements[position] = parentItem;
            BubbleUp(GetParent(position));
        }
    }



    // Helper functions to get index of data
    private int GetLeftChild(int value)
    {
        return 2 * value + 1;
    }

    private int GetRightChild(int value)
    {
        return 2 * value + 2;
    }

    private int GetParent(int value)
    {
        return (value - 1) / 2;
    }

    // Helper swap function
    private void swap(int firstIndex, int secondIndex)
    {
        if ((firstIndex > numberOfItems - 1) || (secondIndex > numberOfItems - 1))
        {
            throw new IndexOutOfRangeException("Trying to swap something out of bouds.");
        }
        T temp = elements[firstIndex];
        elements[firstIndex] = elements[secondIndex];
        elements[secondIndex] = temp;
    }


    private List<T> elements;
    private int numberOfItems = 0;

    public int count
    {
        get
        {
            return numberOfItems;
        }
    }

}

/*
Parent i
Left child = 2 * i + 1
Right child = 2 * i + 2

Child i 
Parent = (i - 1 ) / 2 
(Works due to integer division)


peek() Return element with highest priority

enqueue(e)
- Put at first available slot. heap[heapsize] = newElement
- Bubble up
- Loop at the newly added element and it's parent. Do they have a proper min-heap relationship?
    -If yes, we-re done.
    -If not, SWAP the newly added element with it's parent.
    -Continue until done or newly added element is root of heap.

dequeue()
-Remove the root of the three.
-Replace with the last element in our three, farthest right.
-Bubble down to regain heap property.
    -Compare the moved element to its new children.
    -Of one of the two children is smaller, swap with that child.
    -IF both of the children are smallen, swap with the one that's smaller.
    -Repeat until you no longer bubble down or there are no more children to compare against.

peek() - Look at the root of the three = index 0
*/