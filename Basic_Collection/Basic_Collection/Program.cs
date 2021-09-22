using System;
using System.Collections.Generic;

/*
 * System.Collections.Generic Classes
 *  - Dictionary<TKey,TValue>, List<T>, Queue<T>, SortedList<TKey,TValue>, Stack<T>
 * System.Collections
 *  - ArrayList, HashTable, Stack, Queue
 */

namespace Basic_Collection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LinkedList<string> cacbaohoc = new LinkedList<string>();
            var bh1 = cacbaohoc.AddFirst("bai hoc 1");
            var bh3 = cacbaohoc.AddLast("bai hoc 3");
            LinkedListNode<string> bh2 = cacbaohoc.AddAfter(bh1, "bai hoc 2");
            var bh4 = cacbaohoc.AddFirst("bai hoc 4");
            var bh5 = cacbaohoc.AddFirst("bai hoc 5");
            var node = bh2;
            Console.WriteLine(node.Value);
            node = node.Next;
            Console.WriteLine(node.Value);
        }
    }
}