# Data Structures

## Big O Notation (Time and Space Complexity)
Given an algorithm, we use various notations to analyze the cost of running that algorithm
Big O notation, expressed as O(x) is interested in analyzing the worst case scenario given a very large input
Time Complexity : How many instructions it takes to run the algorithm
Space Complexity : How much memory does it take to run the algorithm
We care more about time complexity than the space complexity because it's possible to get more memory
O(1)
    - declaring a variable
    - Arithmetic operation
    - Boolean operation

O(log n)
    - Binary Search

O(n)
    - Looping over an array or list of size n

O(n log n)
    - Divide and Conquer algorithms
    - Merge Sort, Quick Sort, Heap Sort

O(n^2)
    - naive sorts
    - Bubble Sort, Insertion Sort, Cocktail Shaker Sort, Selection Sort,
    - In general, when you have 2 loops nested together, they take O(n^2)

O(n^3)
    - triple nested loops

O(2^n)

O(n!)
    - The brute force Traveling Salesman
    - Calculating all permutation
## Data Structures
- What They Are
- What do they excel at
- What are they horrible at

### Array
    - Sequential data structure occupying contiguous memory space
    - Good at:
        - Index based access: O(1)
        - Adding to the back of the array if there is space: O(1)
    - Bad at:
        - Resizing: O(n)
        - Inserting: O(n)
        - Deleting from the front or middle: O(n)
        - Sequential Searching: O(n)

### List 
    - Basically automatic resizing array
    - Still array under the hood
    - Still the same benefit and drawback of the array

### Linked List
    A collection of ordered nodes
    - Not next to each other in memory
    - Head reference to know where the beginning of the structure is
    - each node has next reference pointing to their next item
    - If nodes only have next reference, singly linked list
    - If nodes have next and prev reference, doubly linked list
    - Sometimes we even have reference to the end of the list, which we call it tail

    - Good At
        - Inserting at the head : O(1)
        - Deleting from the head : O(1)
        - No resizing
    - Bad At
        - getting n-th element : O(n)
        - if singly linked and has no tail ref, adding at the back: O(n)

    - UseCases
        - Good for data that changes size a lot
        - A List where you want to remove from front/middle and not always from the back
        - Creating a list from already existing collection (ie playlist from a big collection of music library)

### Stack
    - LIFO (Last In First Out) data structure
        - Stack of books, pancakes, jenga stack, etc.
    - Not meant for searching/looking into the middle of the ds
    - implemented using backing data structure, such as array or linked list
    - Can implement using LinkedList, where we add new elements to the head, and remove from the head O(1)
    - Can implement using Array, where we add to the back and remove from the back (only issue would be the resizing cost)
    - Operations:
        - Add
        - Pop (to remove from stack)
        - Size
        - Peek (to look at the next elem without removing)
    - use cases: 
        - Finding symmetrical parentheses
        - can use where you are not concerned about the order of the data set, but the order they've been added to the ds
        - when the relation between data is more important than the data itself

### Queue
    - FIFO (First In First Out) data structure
        - Bank/Bus/DMV queue, "first come, first served"
    - Not meant for searching/looking into the middle of the ds
    - implemented using backing data structure, such as array or linked list 
    - can implement using array which makes adding O(1) but removing O(n) (if you want to always pull from 0-th index)
    - can implement using circular array which makes adding and removing O(1)

    - Operations:
        - Enqueue (to add to the queue)
        - Dequeue (to remove from the queue)
        - Size
        - Peek
    - use cases:
        - ticketing system
        - representing real life lines

### Dictionary (HashMap in java)
    - Is an Unordered collection of Key, Value Pair
    - Keys must be unique, but values can be duplicates
    - Getting the value for a known key is O(1) operation
    - We use this often for Lookup Table

    - UseCase:
        - Counting Frequencies of appearance
        - When you want to identify collection of elements by a complex key
        - phone book
    - When Not to use
        - not for sorting*

### HashSet
    - An unordered collection of unique values (no duplicates)
    - Good for determining if something is in the set or not
    - Also good for set operations (intersection, union, etc.)
    - Very obvious use case:
        - removing duplicates
    - Operation
        - Add
        - Remove
        - Contains

## Collection namespaces in C#
### System.Collections.Generic namespace
    Contains Generic collections
    - Generic Collections are Strongly Typed collection, which means when you declare them, you have to specify what you plan on storing in it.
    - ex: List<T>
        - List<int>
        - List<string>
        - List<List<int>>
    - This also means that you have to store the same type of data for a given data structure
        - ie. Dictionary<string, int>
        - Dictionary<int, Person>
    - So, what if you want to store more than one type of object in a collection?
        - List<Object>
### System.Collections namespace
    Contains Non-generic data structures - no strong typing or type safety
    These exist, and you should know they exist, but the recommendation is to stick with generic data structures


## Relevant LeetCode Problems (just a sampler, feel free to look for more if you want)
- [Two Sum](https://leetcode.com/problems/two-sum/)
- [Contains Duplicate](https://leetcode.com/problems/contains-duplicate)
- [First Unique Character in a String](https://leetcode.com/problems/first-unique-character-in-a-string)
- [Merge Sorted Array](https://leetcode.com/problems/merge-sorted-array)
- [Valid Parentheses](https://leetcode.com/problems/valid-parentheses)