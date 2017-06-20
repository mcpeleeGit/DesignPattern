using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList studentRecords = new SortedList();
            
            studentRecords.SetSortStrategy(new BubbleSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new SelectionSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new InsertionSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();

            Console.ReadKey();
        }
    }

    abstract class SortStrategy
    {
        public abstract void Sort(List<int> list);
    }
    class BubbleSort : SortStrategy
    {
        public override void Sort(List<int> list)
        {
            Console.Write("   BubbleSorted list ");
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        var tmp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = tmp;
                    }

                }
            }
        }
    }

    class SelectionSort : SortStrategy
    {
        public override void Sort(List<int> list)
        {
            Console.Write("SelectionSorted list ");
            int minValue = 0;
            for (int i = 0; i < list.Count -1; i++)
            {
                minValue = i;
                for (int j = i+1; j < list.Count; j++)
                {
                    if (list[j] < list[minValue]) minValue = j;
                }
                var tmp = list[i];
                list[i] = list[minValue];
                list[minValue] = tmp;
            }
        }
    }

    class InsertionSort : SortStrategy
    {
        public override void Sort(List<int> list)
        {
            Console.Write("InsertionSorted list ");
            int j;
            int tmp;
            for(int i = 0; i < list.Count; i++)
            {
                j = i;
                while (j>0 && list[j] < list[j-1])
                {
                    tmp = list[j];
                    list[j] = list[j - 1];
                    list[j - 1] = tmp;
                    j--;
                }
            }
        }
    }

    class QuickSort : SortStrategy
    {
        public override void Sort(List<int> list)
        {
            quicksort(list, 0, list.Count - 1);
            Console.Write("    QuickSorted list ");
        }
        public void quicksort(List<int> list, int left, int right)
        {
            int i = left, j = right;
            int pivot = list[(left + right) / 2];

            while (i <= j)
            {
                while (list[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (list[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = list[i];
                    list[i] = list[j];
                    list[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                quicksort(list, left, j);
            }

            if (i < right)
            {
                quicksort(list, i, right);
            }
        }
    }

    class ShellSort : SortStrategy
    {
        public override void Sort(List<int> list)
        {
            for(int k = 0; k < list.Count; k++)
            {
                if (k >= list.Count)
                    continue;

                for (int i = 0; i + k < list.Count; i++)
                {
                    int j = i;
                    while (shellSort(list, j, j + k))
                    {
                        j -= k;
                        if (j < 0)
                            break;
                    }
                }
            }
            Console.Write("    ShellSorted list ");
        }

        private bool shellSort(List<int> list, int ind1, int ind2)
        {
            if (list[ind2] < list[ind1])
            {
                int temp = list[ind2];
                list[ind2] = list[ind1];
                list[ind1] = temp;
                return true;
            }
            return false;
        }
    }

    class MergeSort : SortStrategy
    {
        public override void Sort(List<int> list)
        {
            mergeSort(list, 0, list.Count);
            Console.Write("    MergeSorted list ");
        }

        private void mergeSort(List<int> list, int low, int high)
        {

            int N = high - low;
            if (N <= 1)
                return;

            int mid = low + N / 2;

            mergeSort(list, low, mid);
            mergeSort(list, mid, high);

            List<int> aux = new List<int>();
            for (int k = 0; k < N; k++) aux.Add(0);

            int i = low, j = mid;
            for (int k = 0; k < N; k++)
            {
                if (i == mid) aux[k] = list[j++];
                else if (j == high) aux[k] = list[i++];
                else if (list[j].CompareTo(list[i]) < 0) aux[k] = list[j++];
                else aux[k] = list[i++];
            }

            for (int k = 0; k < N; k++)
            {
                list[low + k] = aux[k];
            }
        }
    }

    class SortedList
    {
        private List<int> _list = new List<int>();
        private SortStrategy _sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            Reset();
            this._sortstrategy = sortstrategy;
        }
        private void Reset()
        {
            _list.Clear();
            _list.Add(5);
            _list.Add(2);
            _list.Add(4);
            _list.Add(9);
            _list.Add(119);
            _list.Add(113);
            _list.Add(118);
            _list.Add(115);
            _list.Add(112);
            _list.Add(114);
            _list.Add(1119);
            _list.Add(1113);
            _list.Add(3);
            _list.Add(8);
            _list.Add(15);
            _list.Add(12);
            _list.Add(14);
            _list.Add(19);
            _list.Add(13);
            _list.Add(18);
            _list.Add(11);
            _list.Add(1);
        }
        public void Clear()
        {
            _list.Clear();
        }
        public void Add(int cnt)
        {
            _list.Add(cnt);
        }

        public void Sort()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            _sortstrategy.Sort(_list);
            watch.Stop();
            var elapsedMs = watch.Elapsed;
            
            foreach (int cnt in _list)
            {
                Console.Write(" " + cnt);
            }
            Console.WriteLine(elapsedMs);
        }
    }
}
