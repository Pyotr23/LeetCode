﻿using System;
using System.Collections.Generic;

namespace Medium
{
    class Medium_718_length_of_repeated_subarray
    {
        static void Main(string[] args)
        {
            int[] firstArray = new int[] { 0, 0, 0, 0, 1 };
            int[] secondArray = new int[] { 1, 0, 0, 0, 0 };
            //int[] firstArray = new int[] { 1, 2, 3, 2, 1 };
            //int[] secondArray = new int[] { 3, 2, 1, 4, 7 };
            //int[] firstArray = new int[] { 3, 2, 4, 2, 5, 8 };
            //int[] secondArray = new int[] { 8, 5, 2, 5, 8 };
            int answear = FindLength(firstArray, secondArray);
            Console.WriteLine(answear);
            Console.ReadKey();
        }

        static int FindLength(int[] A, int[] B)
        {
            int answear = 0;
            Dictionary<int, List<int>> dictionaryB = new Dictionary<int, List<int>>();
            for (int i = 0; i < B.Length; i++)
            {
                if (!dictionaryB.ContainsKey(B[i]))
                    dictionaryB.Add(B[i], new List<int> { i });
                else
                {
                    List<int> currentList = dictionaryB[B[i]];
                    currentList.Add(i);
                    dictionaryB[B[i]] = currentList;
                }                    
            }
            //int[] startStop = new int[2];
            for (int i = 0; i < A.Length; i++)
            {
                if (!dictionaryB.ContainsKey(A[i]))
                    continue;
                List<int> indexesList = dictionaryB[A[i]];
                for (int j = 0; j < indexesList.Count; j++)
                {
                    int startIndexInB = indexesList[j];
                    int currentLength = 0;
                    while (((i + currentLength) < A.Length)
                        && ((startIndexInB + currentLength) < B.Length)
                        && (A[i + currentLength] == B[startIndexInB + currentLength]))
                    {
                        currentLength++;
                        //if (currentLength > answear)
                        //{
                        //    startStop[0] = startIndexInB;
                        //    startStop[1] = currentLength - 1;
                        //    answear = currentLength;
                        //}
                        answear = Math.Max(answear, currentLength);
                    }
                }                               
            }
            return answear;
        }

        static int FindLengthBruteForce(int[] A, int[] B)
        {
            int answear = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    int currentLength = 0;
                    while (((i + currentLength) < A.Length) 
                        && ((j + currentLength) < B.Length)
                        && (A[i + currentLength] == B[j + currentLength]))
                    {
                        currentLength++;
                        answear = Math.Max(answear, currentLength);
                    }                        
                }
            }
            return answear;
        }
    }
}
