using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndSort.Search
{
    public class BinarySearch<T> where T : IComparable<T>
    {
        public int Search(T[] array, T target)
        {
            return Search(array, target, 0, array.Length - 1);
        }

        public int Search(T[] array, T target, int left, int right)
        {
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                int comparison = target.CompareTo(array[mid]);

                if (comparison == 0)
                    return mid;
                if (comparison < 0)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1;
        }
    }
}
