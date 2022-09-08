using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Learning_Algos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            int[] a = { 6, 7, 3, 2, 9, 5, 0, 7, 3 };
            //Console.WriteLine("array before sort");
            //printArray(a);
            //selectionSort(a);
            //Console.WriteLine("\n array after sorting");
            //printArray(a);
            // toh(2, 10, 11, 12);
            //da(new int[] { 4, 5, 6, 7, 3, 4 }, 0);
            // int maxOfArray = maxOffArray(new int[] { 55, 1 }, 0);
            // Console.WriteLine(maxOfArray);
            //Console.WriteLine(lastIndex(a, 0, 3));
            ////da(allIndices(a, 0,7, 0),0);
            //List<string> b = findAllStairPaths(4);
            //foreach (string s in b)
            //{
            //    Console.WriteLine(s);
            //}

            //  printPermutations("abc", "");
           // TargetSumSubset(new int[] { 10, 20, 30,40,50,60 },70,0,0,"");
            ArrayList arr = new ArrayList() {3,8,90,2,55,70,4,7 };
            ArrayList sorted = mergeSort(arr, 0, arr.Count - 1);
            foreach(var item in sorted)
            {
                Console.WriteLine(item);
            }
           //int[,] arr = new int[4,4];
            //PlaceNQueens(arr, 0, "");
        }

        public static void printArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ,");
            }
        }

        #region sorting
        public static void bubbleSort(int[] a)
        {
            int temp;
            bool isSorted = false;
            //loops for passes
            for (int i = 0; i <= a.Length - 1; i++)
            {
                isSorted = true;
                //loops for comparisons
                for (int j = 0; j < a.Length - i - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        isSorted = false;
                    }
                }
                if (isSorted)
                {
                    return;
                }
            }

        }

        public static void insertionSort(int[] a)
        {
            int key, j;
            for (int i = 0; i <= a.Length - 1; i++)
            {
                key = a[i];
                j = i - 1;
                while (j >= 0 && a[j] > key)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = key;
            }
        }

        public static void selectionSort(int[] a)
        {
            int minIndex, temp;
            for (int i = 0; i <= a.Length - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j <= a.Length - 1; j++)
                {
                    if (a[j] < a[minIndex])
                    {
                        minIndex = j;
                    }

                }
                temp = a[i];
                a[i] = a[minIndex];
                a[minIndex] = temp;
            }
        }

        public static ArrayList mergeSort(ArrayList array,int start,int end)
        {
            if (start > end)
            {
                return new ArrayList { };
            }
            if (start == end)
            {
                return new ArrayList { array[start] };
            }
            int mid = start + (end - start)/2;

            ArrayList a = mergeSort(array, start, mid);
            ArrayList b = mergeSort(array, mid +1, end);

            ArrayList requiredArray = mergeArray(a, b);
            return requiredArray;
        }
        public static ArrayList mergeArray(ArrayList a, ArrayList b)
        {
            int sizeA = a.Count;
            int sizeB = b.Count;
            int i = 0;
            int j = 0;
            ArrayList ans = new ArrayList { };
            while (i < sizeA && j<sizeB)
            {
                if ((int)a[i] < (int)b[j])
                {
                    ans.Add(a[i]);
                    i = i + 1;
                }
                else
                {
                    ans.Add((int)b[j]);
                    j = j + 1;
                }
            }
            while (i < sizeA)
            {
                ans.Add(a[i]);
                i = i + 1;
            }
            while (j < sizeB)
            {
                ans.Add(b[j]);
                j = j + 1;
            }
            return ans;
        }

        #endregion

        #region recursion
        //tower of hanoi
        public static void toh(int n, int a, int b, int c)
        {
            if (n == 0)
            {
                return;
            }
            toh(n - 1, a, c, b);
            Console.WriteLine(n + "[ {0} -> {1} ]", a, b);
            toh(n - 1, c, b, a);
        }

        //display array from given index without using iteration
        public static void da(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                return;
            }
            Console.Write(arr[index] + " ,");
            da(arr, index + 1);
        }

        //find max of array using recursion
        public static int maxOffArray(int[] arr, int index)
        {
            if (index >= arr.Length-1)
            {
                return arr[index]; 
            }
            int maxN = maxOffArray(arr, index + 1);
            if (arr[index] < maxN)
            {
                return maxN;
            }
            return arr[index];

        }

        //find first occurence of a number
        public static int firstIndex(int[] arr, int index, int number)
        {
            if (index >= arr.Length)
            {
                return -1;
            }
            if (arr[index] == number)
            {
                return index;
            }
            else
            {
                int fi = firstIndex(arr, index + 1, number);
                return fi;
            }

        }

        public static int lastIndex(int[] arr, int index, int number)
        {
            if (index >= arr.Length)
            {
                return -1;
            }
            int fi = lastIndex(arr, index + 1, number);
            if (fi > -1)
            {
                return fi;
            }
            else if (arr[index] == number)
            {
                return index;
            }
            return fi;
        }

        //find all indexes of a number in a array
        public static int[] allIndices(int[] arr, int index, int number, int fsf)
        {
            if (index >= arr.Length)
            {
                return new int[fsf];
            }
            if (arr[index] == number)
            {
                int[] result = allIndices(arr, index + 1, number, fsf + 1);
                result[fsf] = index;
                return result;
            }
            else
            {
                int[] result = allIndices(arr, index + 1, number, fsf);
                return result;
            }
        }

        //find subsequence of a string
        public static List<string> subSequence(string input)
        {
            if (input.Length == 0)
            {
                List<string> eres = new List<string>();
                eres.Add("");
                return eres;
            }

            char c = input.ToCharArray()[0];
            string ros = input.Substring(1);
            List<string> result = subSequence(ros);
            List<string> mresult = new List<string>();
            foreach (string s in result)
            {
                mresult.Add("" + s);
            }
            foreach (string s in result)
            {
                mresult.Add(c + s);
            }
            return mresult;

        }

        //find all paths from top of the stairs to bottom when steps taken can be 1 2 3 
        public static List<string> findAllStairPaths(int n)
        {
            if (n == 0)
            {
                return new List<string>() { "" };
            }
            else if (n < 0)
            {
                return new List<string>();
            }

            List<string> paths1 = findAllStairPaths(n - 1);
            List<string> paths2 = findAllStairPaths(n - 2);
            List<string> paths3 = findAllStairPaths(n - 3);
            List<string> paths = new List<string>();

            foreach (string s in paths1)
            {
                paths.Add(1 + s);
            }
            foreach (string s in paths2)
            {
                paths.Add(2 + s);
            }
            foreach (string s in paths3)
            {
                paths.Add(3 + s);
            }
            return paths;
        }

        public static List<string> findAllMazePaths(int sc, int sr, int dc, int dr)
        {
            if (sc == dc && sr == dr)
            {
                return new List<string>() { "" };
            }

            List<string> hpaths = new List<string>();
            List<string> vpaths = new List<string>();
            if (sc < dc)
                hpaths = findAllMazePaths(sc + 1, sr, dc, dr);
            
            if (sr < dr)
                vpaths = findAllMazePaths(sc, sr + 1, dc, dr);
            List<string> fpaths = new List<string>();
            foreach (string s in hpaths)
            {
                fpaths.Add("h" + s);
            }
            foreach (string s in vpaths)
            {
                fpaths.Add("v" + s);
            }
            return fpaths;

        }

        public static void printPermutations(string input,string asf)
        {
            if(input.Length == 0)
            {
                Console.WriteLine(asf);
            }
            for(int i = 0; i < input.Length; i++)
            {
                char ch = input.ToCharArray()[i];
                string leftPart = input.Substring(0,i);
                string rightPart =input.Substring(i+1);
                string roq = leftPart + rightPart;
                printPermutations(roq, asf + ch);
            }
        }

        public static void TargetSumSubset(int[] arr,int targetSum,int index,int sos,string set)
        {
            if(index == arr.Length)
            {
                if (sos == targetSum)
                {
                    Console.WriteLine(set);
                }
                return;
            }
          TargetSumSubset(arr,targetSum,index+1,sos + arr[index],set + arr[index] + " ,");
          TargetSumSubset(arr,targetSum,index+1,sos ,set);
        }




        #endregion

        public static void PlaceNQueens(int[,] chess, int row, string qsf)
        {
            if (row == chess.GetLength(0))
            {
                Console.WriteLine(qsf);
                return;
            }
            for (int col = 0; col < chess.GetLength(0); col++)
            {
                if (IsSafeForQueenToPlace(chess, row, col))
                {
                    chess[row, col] = 1;
                    PlaceNQueens(chess, row + 1, qsf + row + "-" + col + ",");
                    chess[row, col] = 0;
                }
            }
        }
        public static bool IsSafeForQueenToPlace(int[,] chess,int row, int col)
        {
            for(int i = row-1,j=col; i >= 0; i--)
            {
                if(chess[i,j] == 1)
                {
                    return false;
                }
            }
            for(int i = row - 1, j = col - 1; i >= 0 && j>=0; i--, j--)
            {
                if (chess[i, j] == 1)
                {
                    return false;
                }
            }
            for (int i = row - 1, j = col +1; i >= 0 && j <chess.GetLength(0); i--, j++)
            {
                if (chess[i, j] == 1)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
