
namespace SearchAndSort.Sort
{
    public class InsertionSort
    {
        public static List<T> Sort<T>(List<T> list) where T : IComparable<T>
        {
            for (int i = 1; i < list.Count; i++)
            {
                T key = list[i];
                int j = i - 1;

                while (j >= 0 && list[j].CompareTo(key) > 0)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = key;
            }

            return list;
        }
    }
}
