using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingFormApp
{
    public class Settings
    {

        public static int[] GenerateArray(int width, int height)
        {
            int[] myArray = new int[width];
            Random rng = new Random();
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = rng.Next(1, height);
            }
            return myArray;
        }

        public static void BubbleSort(int[] myArray, int speed)
        {
            int temp = 0;
            for (int i = 0; i < myArray.Length - 1; i++)
            {
                for (int j = 0; j < myArray.Length - 1; j++)
                {
                    if (myArray[j] > myArray[j + 1])
                    {
                        temp = myArray[j + 1];
                        myArray[j + 1] = myArray[j];
                        myArray[j] = temp;
                        Thread.Sleep(speed);
                        Form1.SwapElements(j, j + 1);

                    }
                }
            }
        }

        public static void SelectionSort(int[] myArray, int speed)
        {
            int temp, smallestNum;
            for (int i = 0; i < myArray.Length - 1; i++)
            {
                smallestNum = i;
                for (int j = i + 1; j < myArray.Length; j++)
                {
                    if (myArray[j] < myArray[smallestNum]) smallestNum = j;
                }
                if (smallestNum != i)
                {
                    temp = myArray[i];
                    myArray[i] = myArray[smallestNum];
                    myArray[smallestNum] = temp;
                    Thread.Sleep(speed);
                    Form1.SwapElements(i, smallestNum);
                }
            }
        }
        public static void MergeSortStart(int[] myArray, int speed)
        {
            MergeSortStart(myArray, speed);
        }
        public void MergeSort(int[] myArray, int speed)
        {
            if (myArray.Length < 2) return;
            int[] left, right;
            int midPoint = myArray.Length / 2;
            left = new int[midPoint];
            if (Array.MaxLength % 2 == 0) right = new int[midPoint];
            else right = new int[midPoint + 1];
            for(int i = 0; i < midPoint; i++)
            {
                left[i] = myArray[i];
            }
            int j = 0;
            for(int i = midPoint; i < myArray.Length; i++)
            {
                right[j++] = myArray[i];

            }
            MergeSort(left, speed);
            MergeSort(right, speed);
            Merge(left, right, speed);
        }
        public static void Merge(int[] myLeftArray, int[] myRightArray, int speed)
        {
            int[] result = new int[myLeftArray.Length + myRightArray.Length];
            int i = 0, j = 0, k = 0;
            while(i < myLeftArray.Length || j < myRightArray.Length)
            {
                if(i < myLeftArray.Length && j < myRightArray.Length)
                {
                    if (myLeftArray[i] <= myRightArray[j])
                    {
                        result[k] = myLeftArray[i];
                        Form1.SwapElements(i, k);
                        k++;
                        i++;
                    }
                    else
                    {
                        result[k] = myRightArray[j];
                        Form1.SwapElements(myLeftArray.Length + j, k);
                        k++;
                        j++;
                    }
                }
                else if(i < myLeftArray.Length){
                    result[k] = myLeftArray[i];
                    Form1.SwapElements(i, k);
                    k++;
                    i++;
                }
                else if(j < myRightArray.Length)
                {
                    result[k] = myRightArray[j];
                    Form1.SwapElements(myLeftArray.Length + j, k);
                    k++;
                    j++;
                }
            }
        }
    }
}
