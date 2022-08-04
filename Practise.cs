using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
    class Practise
    { 
        public void BubbleSort(IList<int> list)
        {
            for(int i=list.Count-1; i>0;i--)
            {
                for(int j=0;j<i;j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        Swap(list, j, j + 1);
                    }
                }
            }
        }

        private void Swap(IList<int> list,int leftIndex,int rightIndex)
        {
           
            int temp = list[leftIndex];
            list[leftIndex] = list[rightIndex];
            list[rightIndex] = temp;
        }

        public void MergeSort(IList<int> list,int left,int right)
        {
            int middle = (right - left)/2;
            MergeSort(list, left, middle);
            MergeSort(list, middle + 1, right);
            Merge(list, left, right,middle);
        }

        private void Merge(IList<int> list,int left,int right,int middle)
        {
            int length = right - left + 1;
            int[] tempList = new int[length];

            int k = 0;

            for(int i=left,j=middle+1; ;)
            {
                if(i>middle && j>right)
                {
                    break;
                }

                if(j>right)
                {
                    tempList[k] = list[i];
                    k++;
                    i++;
                    continue;
                }

                if(i>middle)
                {
                    tempList[k] = list[j];
                    k++;
                    j++;
                    continue;
                }

                if(list[i]<=list[j])
                {
                    tempList[k] = list[i];
                    k++;
                    i++;
                }

                else
                {
                    tempList[k] = list[j];
                    j++;
                    k++;
                }
            }

            k = 0;
            for(int index=left;index<=right;index++)
            {
                list[index] = list[k];
                k++;
            }
        }
    
    
        public void QuickSort(IList<int> list, int left, int right)
        {
            int temp = list[left];
            int low = left;
            int high = right;

            while(low<high)
            {
                while(low<high)
                {
                    if(list[high]>=temp)
                    {
                        high--;
                    }
                    else
                    {
                        break;
                    }
                }

                while(low<high)
                {
                    if(list[low]<=temp)
                    {
                        low++;
                    }
                    else
                    {
                        break;
                    }
                }

                if(list[low]>temp && list[high]<temp)
                {
                    int middleValue = list[low];
                    list[low] = list[high];
                    list[high] = middleValue;
                }
            }

            list[left] = list[low];
            list[low] = temp;

            QuickSort(list, left, low - 1);
            QuickSort(list, low + 1, right);
        }
    
        public void SelectionSort(IList<int> list,int left,int right)
        {
            for(int i=0;i<list.Count-1;i++)
            {
                for(int j=i+1;j<list.Count;j++)
                {
                    if(list[j]<list[i])
                    {
                        Swap(list, i, j);
                    }
                }
            }
        }

        public void InsertSort(IList<int> list)
        {
            for(int i=0;i<list.Count;i++)
            {
                for(int j=i;j>0;j--)
                {
                    if(list[j]<list[j-1])
                    {
                        Swap(list, j-1, j);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }

    public class NumberExample
    {
        public void TryBigInteger()
        {
            byte[] byteArray = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            BigInteger newBigInt = new BigInteger(byteArray);
            Console.WriteLine("The value of newBigInt is {0} (or 0x{0:x}).", newBigInt);
            Console.ReadKey();
        }
    }
}
