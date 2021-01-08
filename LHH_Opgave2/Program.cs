using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace LHH_Opgave2
{
    class Program
    {
        // Generate a random string.
        private static string RandomStringGenerator(int length, Random random)
        {
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            
            string randomString = "";

            for (int i = 0; i < length; i++)
            {
                randomString += letters[random.Next(0, letters.Length)].ToString();
            }

            return randomString;
        }

        // Compare two string objects.
        private static int CompareStrings(string s1, string s2)
        {
            int result = 0;

            int i = 0;
            int j = 0;

            while (i < s1.Length && j < s2.Length)
            {
                int compareResult = s1[i].CompareTo(s2[j]);

                if (compareResult < 0)
                {
                    result = -1;
                    break;
                }
                else if (compareResult > 0)
                {
                    result = 1;
                    break;
                }
                else
                {
                    i++;
                    j++;
                }
            }
            return result;
        }

        // Generate a list of random strings.
        static List<String> ListOfRandomStringsGenerator(int numStrs, int strLength, Random random)
        {
            List<String> randomStrings = new List<String>();

            int i = 0;

            while (i < numStrs)
            {
                randomStrings.Add(RandomStringGenerator(strLength, random));
                i++;
            }

            return randomStrings;
        }

        // Generate a StringCollection of random strings.
        static StringCollection StringCollectionOfRandomStringsGenerator(int numStrs, int strLength, Random random)
        {
            StringCollection randomStrings = new StringCollection();

            int i = 0;

            while (i < numStrs)
            {
                randomStrings.Add(RandomStringGenerator(strLength, random));
                i++;
            }

            return randomStrings;
        }

        // Generate an array of random strings
        static String[] ArrayOfRandomStringsGenerator(int numStrs, int stringLength, Random random)
        {
            String[] randomStrings = new String[numStrs];

            int i = 0;

            while (i < numStrs)
            {
                randomStrings[i] = RandomStringGenerator(stringLength, random);
                i++;
            }

            return randomStrings;
        }

        // BubbleSort list of strings.
        static void BubbleSortStrings(List<String> list)
        {
            if (list.Count <= 1)
            {
                // List is sorted.
            }
            else
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (CompareStrings(list[i], list[j]) > 0)
                        {
                            Swap(list, i, j);
                        }
                    }
                }
            }
        }

        // Helper for BubbleSort list of strings.
        private static void Swap(List<String> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        // BubbleSort stringcollection of strings.
        static void BubbleSortStrings(StringCollection collection)
        {
            if (collection.Count <= 1)
            {
                // Collection is sorted.
            }
            else
            {
                for (int i = 0; i < collection.Count - 1; i++)
                {
                    for (int j = i + 1; j < collection.Count; j++)
                    {
                        if (CompareStrings(collection[i], collection[j]) > 0)
                        {
                            Swap(collection, i, j);
                        }
                    }
                }
            }
        }

        // Helper for BubbleSort stringcollection of strings.
        private static void Swap(StringCollection collection, int i, int j)
        {
            var temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }

        // BubbleSort array of strings.
        static void BubbleSortStrings(String[] array)
        {
            if (array.Length <= 1)
            {
                // Array is sorted.
            }
            else
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (CompareStrings(array[i], array[j]) > 0)
                        {
                            Swap(array, i, j);
                        }
                    }
                }
            }
        }

        // Helper for BubbleSort array of strings.
        private static void Swap(String[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        // MergeSort list of strings.
        static List<String> MergeSortStrings(List<String> unsortedList)
        {
            if (unsortedList.Count <= 1)
            {
                //List is sorted.
                return unsortedList;
            }
            else
            {
                List<String> left = new List<String>();
                List<String> right = new List<String>();

                int middle = unsortedList.Count / 2;

                for (int i = 0; i < middle; i++)
                {
                    left.Add(unsortedList[i]);
                }

                for (int i = middle; i < unsortedList.Count; i++)
                {
                    right.Add(unsortedList[i]);
                }

                left = MergeSortStrings(left);
                right = MergeSortStrings(right);
                return MergeStringLists(left, right);
            }
        }

        // Helper for MergeSort list of strings.
        private static List<String> MergeStringLists(List<String> left, List<String> right)
        {
            List<String> sortedList = new List<String>();

            if (left.Count == 1 && right.Count == 1)
            {
                if (CompareStrings(left[0], right[0]) <= 0)
                {
                    sortedList.Add(left[0]);
                    sortedList.Add(right[0]);
                }
                else
                {
                    sortedList.Add(right[0]);
                    sortedList.Add(left[0]);
                }
            }
            else
            {
                int left_i = 0;
                int right_i = 0;

                while (left_i < left.Count && right_i < right.Count)
                {
                    if (CompareStrings(left[left_i], right[right_i]) <= 0)
                    {
                        sortedList.Add(left[left_i]);
                        left_i++;
                    }
                    else
                    {
                        sortedList.Add(right[right_i]);
                        right_i++;
                    }
                }

                if (left_i < left.Count)
                {
                    while (left_i < left.Count)
                    {
                        sortedList.Add(left[left_i]);
                        left_i++;
                    }
                }

                if (right_i < right.Count)
                {
                    while (right_i < right.Count)
                    {
                        sortedList.Add(right[right_i]);
                        right_i++;
                    }
                }
            }

            return sortedList;
        }

        // MergeSort stringcollection of strings.
        static StringCollection MergeSortStrings(StringCollection unsortedCollection)
        {
            if (unsortedCollection.Count <= 1)
            {
                // Collection is sorted.
                return unsortedCollection;
            }
            else
            {
                StringCollection left = new StringCollection();
                StringCollection right = new StringCollection();

                int middle = unsortedCollection.Count / 2;

                for (int i = 0; i < middle; i++)
                {
                    left.Add(unsortedCollection[i]);
                }

                for (int i = middle; i < unsortedCollection.Count; i++)
                {
                    right.Add(unsortedCollection[i]);
                }

                left = MergeSortStrings(left);
                right = MergeSortStrings(right);
                return MergeStringCollections(left, right);
            }
        }

        // Helper for MergeSort stringcollection of strings.
        private static StringCollection MergeStringCollections(StringCollection left, StringCollection right)
        {
            StringCollection sortedCollection = new StringCollection();

            if (left.Count == 1 && right.Count == 1)
            {
                if (CompareStrings(left[0], right[0]) <= 0)
                {
                    sortedCollection.Add(left[0]);
                    sortedCollection.Add(right[0]);
                }
                else
                {
                    sortedCollection.Add(right[0]);
                    sortedCollection.Add(left[0]);
                }
            }
            else
            {
                int left_i = 0;
                int right_i = 0;

                while (left_i < left.Count && right_i < right.Count)
                {
                    if (CompareStrings(left[left_i], right[right_i]) <= 0)
                    {
                        sortedCollection.Add(left[left_i]);
                        left_i++;
                    }
                    else
                    {
                        sortedCollection.Add(right[right_i]);
                        right_i++;
                    }
                }

                if (left_i < left.Count)
                {
                    while (left_i < left.Count)
                    {
                        sortedCollection.Add(left[left_i]);
                        left_i++;
                    }
                }

                if (right_i < right.Count)
                {
                    while (right_i < right.Count)
                    {
                        sortedCollection.Add(right[right_i]);
                        right_i++;
                    }
                }
            }

            return sortedCollection;
        }

        // MergeSort array of strings.
        static String[] MergeSortStrings(String[] unsortedArray)
        {
            if (unsortedArray.Length <= 1)
            {
                // Array is sorted.
                return unsortedArray;
            }
            else
            {
                int middle = unsortedArray.Length / 2;

                String[] left = unsortedArray.Take(middle).ToArray();
                String[] right = unsortedArray.Skip(middle).ToArray();
   
                left = MergeSortStrings(left);
                right = MergeSortStrings(right);
                return MergeStringArrays(left, right);
            }
        }

        // Helper for MergeSort array of strings.
        private static String[] MergeStringArrays(String[] left, String[] right)
        {
            String[] sortedArray = new String[left.Length + right.Length];

            if (left.Length == 1 && right.Length == 1)
            {
                if (CompareStrings(left[0], right[0]) <= 0)
                {
                    sortedArray[0] = left[0];
                    sortedArray[1] = right[0];
                }
                else
                {
                    sortedArray[0] = right[0];
                    sortedArray[1] = left[0];
                }
            }
            else
            {
                int left_i = 0;
                int right_i = 0;

                while (left_i < left.Length && right_i < right.Length)
                {
                    int index = Array.IndexOf(sortedArray, null);

                    if (CompareStrings(left[left_i], right[right_i]) <= 0)
                    {
                        sortedArray[index] = left[left_i];
                        left_i++;
                    }
                    else
                    {
                        sortedArray[index] = right[right_i];
                        right_i++;
                    }
                }

                if (left_i < left.Length)
                {
                    while (left_i < left.Length)
                    {
                        int index = Array.IndexOf(sortedArray, null);
                        sortedArray[index] = left[left_i];
                        left_i++;
                    }
                }

                if (right_i < right.Length)
                {
                    while (right_i < right.Length)
                    {
                        int index = Array.IndexOf(sortedArray, null);
                        sortedArray[index] = right[right_i];
                        right_i++;
                    }
                }
            }

            return sortedArray;
        }
        
        // Display a list of strings.
        static void DisplayList(List<String> list)
        {
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
        }

        // Display a StringCollection of strings.
        static void DisplayStringCollection(StringCollection collection)
        {
            foreach (string s in collection)
            {
                Console.WriteLine(s);
            }
        }

        // Display an array of strings.
        static void DisplayArray(String[] array)
        {
            foreach (string s in array)
            {
                Console.WriteLine(s);
            }
        }

        static void Main(string[] args)
        {
            Random r = new Random();
            Stopwatch timer = new Stopwatch();
            int numStrs = 20000; // Number of strings in the structures.

            // ---------- Making the first list of random strings ----------------------------------------

            Console.WriteLine($"Generating the first list with {numStrs} random strings...");

            List<String> randomStringsList = ListOfRandomStringsGenerator(numStrs, 20, r);

            Console.WriteLine($"A new list of {numStrs} random strings has been generated.");
            /*
            Console.WriteLine("\nFirst list of random strings:");
            DisplayList(randomStringsList);
            //Console.ReadLine();
            */
            // ---------- Sorting the first list of random strings with BubbleSort -----------------------

            Console.WriteLine($"\nSorting with BubbleSort the first list of strings containing {numStrs} elements...");

            timer.Start();

            BubbleSortStrings(randomStringsList);

            timer.Stop();

            TimeSpan bubbleSortListTs = timer.Elapsed;

            string bubbleSortListElapsedTime = String.Format(@"{0:00}:{1:00}:{2:00}.{3:00}",
                bubbleSortListTs.Hours, bubbleSortListTs.Minutes, bubbleSortListTs.Seconds, 
                bubbleSortListTs.Milliseconds / 10);

            Console.WriteLine("BubbleSort list running time: " + bubbleSortListElapsedTime);
            /*
            Console.WriteLine("\nFirst list of random strings sorted with BubbleSort:");
            DisplayList(randomStringsList);
            //Console.ReadLine();
            */
            // ---------- Making the second list of random strings ---------------------------------------
            
            Console.WriteLine($"\nGenerating the second list with {numStrs} random strings...");

            List<String> randomsList = ListOfRandomStringsGenerator(numStrs, 20, r);

            Console.WriteLine($"A new list of {numStrs} random strings has been generated.");
            /*
            Console.WriteLine("\nSecond list of random strings:");
            DisplayList(randomsList);
            //Console.ReadLine();
            */
            // ---------- Sorting the second list of random strings with MergeSort -----------------------

            timer.Reset();
            
            Console.WriteLine($"\nSorting with MergeSort the second list of strings containing {numStrs} elements...");

            timer.Start();

            randomsList = MergeSortStrings(randomsList);

            timer.Stop();

            TimeSpan mergeSortListTs = timer.Elapsed;

            string mergeSortListElapsedTime = String.Format(@"{0:00}:{1:00}:{2:00}.{3:00}",
                mergeSortListTs.Hours, mergeSortListTs.Minutes, mergeSortListTs.Seconds, mergeSortListTs.Milliseconds / 10);

            Console.WriteLine("MergeSort list running time: " + mergeSortListElapsedTime);
            /*
            Console.WriteLine("\nSecond list of random strings sorted with MergeSort:");
            DisplayList(randomsList);
            //Console.ReadLine();
            */
            // ---------- Making the third list of random strings ----------------------------------------

            Console.WriteLine($"\nGenerating the third list with {numStrs} random strings...");

            List<String> randomsStringList = ListOfRandomStringsGenerator(numStrs, 20, r);

            Console.WriteLine($"A new list of {numStrs} random strings has been generated.");
            /*
            Console.WriteLine("\nThird list of random strings:");
            DisplayList(randomsStringList);
            //Console.ReadLine();
            */
            // ---------- Sorting the third list of random strings with Sort -----------------------------

            Console.WriteLine($"\nSorting with Sort the third list of strings containing {numStrs} elements...");

            timer.Start();

            randomsStringList.Sort();

            timer.Stop();

            TimeSpan SortListTs = timer.Elapsed;

            string SortListElapsedTime = String.Format(@"{0:00}:{1:00}:{2:00}.{3:00}",
                SortListTs.Hours, SortListTs.Minutes, SortListTs.Seconds, SortListTs.Milliseconds / 10);

            Console.WriteLine("Sort list running time: " + SortListElapsedTime);
            /*
            Console.WriteLine("\nThird list of random strings sorted with Sort:");
            DisplayList(randomsStringList);
            //Console.ReadLine();
            */
            // ---------- Making the first stringcollection of random strings ----------------------------

            Console.WriteLine($"\nGenerating the first stringcollection with {numStrs} random strings...");

            StringCollection randomStringsCollection = StringCollectionOfRandomStringsGenerator(numStrs, 20, r);

            Console.WriteLine($"A new stringcollection of {numStrs} random strings has been generated.");
            /*
            Console.WriteLine("\nFirst stringcollection of random strings:");
            DisplayStringCollection(randomStringsCollection);
            //Console.ReadLine();
            */
            // ---------- Sorting the first stringcollection of random strings with BubbleSort -----------

            Console.WriteLine($"\nSorting with BubbleSort the first stringcollection of strings containing {numStrs} elements...");

            timer.Start();

            BubbleSortStrings(randomStringsCollection);

            timer.Stop();

            TimeSpan bubbleSortStringCollectionTs = timer.Elapsed;

            string bubbleSortStringCollectionElapsedTime = String.Format(@"{0:00}:{1:00}:{2:00}.{3:00}",
                bubbleSortStringCollectionTs.Hours, bubbleSortStringCollectionTs.Minutes, bubbleSortStringCollectionTs.Seconds, 
                bubbleSortStringCollectionTs.Milliseconds / 10);

            Console.WriteLine("BubbleSort stringcollection running time: " + bubbleSortStringCollectionElapsedTime);
            /*
            Console.WriteLine("\nFirst stringcollection of random strings sorted with BubbleSort:");
            DisplayStringCollection(randomStringsCollection);
            //Console.ReadLine();
            */
            // ---------- Making the second stringcollection of random strings ---------------------------
            
            Console.WriteLine($"\nGenerating the second stringcollection with {numStrs} random strings...");

            StringCollection randomsStringCollection = StringCollectionOfRandomStringsGenerator(numStrs, 20, r);

            Console.WriteLine($"A new stringcollection of {numStrs} random strings has been generated.");
            /*
            Console.WriteLine("\nSecond stringcollection of random strings:");
            DisplayStringCollection(randomsStringCollection);
            //Console.ReadLine();
            */
            // ---------- Sorting the second stringcollection of random strings with MergeSort -----------

            timer.Reset();
            
            Console.WriteLine($"\nSorting with MergeSort the second stringcollection of strings containing {numStrs} elements...");

            timer.Start();

            randomsStringCollection = MergeSortStrings(randomsStringCollection);

            timer.Stop();

            TimeSpan mergeSortStringCollectionTs = timer.Elapsed;

            string mergeSortStringCollectionElapsedTime = String.Format(@"{0:00}:{1:00}:{2:00}.{3:00}",
                mergeSortStringCollectionTs.Hours, mergeSortStringCollectionTs.Minutes, 
                mergeSortStringCollectionTs.Seconds, mergeSortStringCollectionTs.Milliseconds / 10);

            Console.WriteLine("MergeSort stringcollection running time: " + mergeSortStringCollectionElapsedTime);
            /*
            Console.WriteLine("\nSecond stringcollection of random strings sorted with MergeSort:");
            DisplayStringCollection(randomsStringCollection);
            //Console.ReadLine();
            */
            // ---------- Making the first array of random strings ---------------------------------------

            Console.WriteLine($"\nGenerating the first array with {numStrs} random strings...");

            String[] randomStringsArray = ArrayOfRandomStringsGenerator(numStrs, 20, r);

            Console.WriteLine($"A new array of {numStrs} random strings has been generated.");
            /*
            Console.WriteLine("\nFirst array of random strings:");
            DisplayArray(randomStringsArray);
            //Console.ReadLine();
            */
            // ---------- Sorting the first array of random strings with BubbleSort ----------------------

            timer.Reset();

            Console.WriteLine($"\nSorting with BubbleSort the first array of strings containing {numStrs} elements...");

            timer.Start();

            BubbleSortStrings(randomStringsArray);

            timer.Stop();

            TimeSpan bubbleSortArrayTs = timer.Elapsed;

            string bubbleSortArrayElapsedTime = String.Format(@"{0:00}:{1:00}:{2:00}.{3:00}",
                bubbleSortArrayTs.Hours, bubbleSortArrayTs.Minutes, bubbleSortArrayTs.Seconds, 
                bubbleSortArrayTs.Milliseconds / 10);

            Console.WriteLine("BubbleSort array running time: " + bubbleSortArrayElapsedTime);
            /*
            Console.WriteLine("\nFirst array of random strings sorted with BubbleSort:");
            DisplayArray(randomStringsArray);
            //Console.ReadLine();
            */
            // ---------- Making the second array of random strings --------------------------------------
            
            Console.WriteLine($"\nGenerating the second array with {numStrs} random strings...");

            String[] randomsArray = ArrayOfRandomStringsGenerator(numStrs, 20, r);

            Console.WriteLine($"A new array of {numStrs} random strings has been generated.");
            /*
            Console.WriteLine("\nSecond array of random strings:");
            DisplayArray(randomsArray);
            //Console.ReadLine();
            */
            // ---------- Sorting the second array of random strings with MergeSort ----------------------
            
            timer.Reset();

            Console.WriteLine($"\nSorting with MergeSort the second array of strings containing {numStrs} elements...");

            timer.Start();

            randomsArray = MergeSortStrings(randomsArray);

            timer.Stop();

            TimeSpan mergeSortArrayTs = timer.Elapsed;

            string mergeSortArrayElapsedTime = String.Format(@"{0:00}:{1:00}:{2:00}.{3:00}",
                mergeSortArrayTs.Hours, mergeSortArrayTs.Minutes, mergeSortArrayTs.Seconds, 
                mergeSortArrayTs.Milliseconds / 10);

            Console.WriteLine("MergeSort array running time: " + mergeSortArrayElapsedTime);
           /*
            Console.WriteLine("\nSecond array of random strings sorted with MergeSort:");
            DisplayArray(randomsArray);
            //Console.ReadLine();
            */
            // ---------- Making the third array of random strings ---------------------------------------

            Console.WriteLine($"\nGenerating the third array with {numStrs} random strings...");

            String[] randomStringsArr = ArrayOfRandomStringsGenerator(numStrs, 20, r);

            Console.WriteLine($"A new array of {numStrs} random strings has been generated.");
            /*
            Console.WriteLine("\nThird array of random strings:");
            DisplayArray(randomStringsArr);
            //Console.ReadLine();
            */
            // ---------- Sorting the third array of random strings with Array.Sort ----------------------

            timer.Reset();

            Console.WriteLine($"\nSorting with Array.Sort the third array of strings containing {numStrs} elements...");

            timer.Start();

            Array.Sort(randomStringsArr);

            timer.Stop();

            TimeSpan arraySortArrayTs = timer.Elapsed;

            string arraySortArrayElapsedTime = String.Format(@"{0:00}:{1:00}:{2:00}.{3:00}",
                arraySortArrayTs.Hours, arraySortArrayTs.Minutes, arraySortArrayTs.Seconds, 
                arraySortArrayTs.Milliseconds / 10);

            Console.WriteLine("Array.Sort array running time: " + arraySortArrayElapsedTime);
            /*
            Console.WriteLine("\nThird array of random strings sorted with Array.Sort:");
            DisplayArray(randomStringsArr);*/
            //Console.ReadLine();

            // -------------------------------------------------------------------------------------------

            int numOfStrs = 2000000; // Number of strings generated for the searching tests.

            // ---- Picking randomly a random string from a list of random strings, then searching for it in the list ----

            timer.Reset();

            Console.WriteLine($"\nGenerating and sorting with MergeSort a list with {numOfStrs} random strings...");

            List<String> largeRandomList = ListOfRandomStringsGenerator(numOfStrs, 20, r);
            largeRandomList = MergeSortStrings(largeRandomList);
            
            Console.WriteLine($"A new list of {numOfStrs} random strings has been generated and sorted.");

            string randomRandomStringFromList = largeRandomList[r.Next(0, largeRandomList.Count)];
            Console.WriteLine("\nRandomly picked random string from a list of {0} elements = \"{1}\"", 
                numOfStrs, randomRandomStringFromList);
            Console.WriteLine("Searching for a match of \"{0}\" in the list with {1} String elements...", 
                randomRandomStringFromList, numOfStrs);

            timer.Start();
            
            Console.WriteLine("Search has {0}", largeRandomList.Contains(randomRandomStringFromList) 
                ? "succeeded! The string was found!" : "failed. The string was not found.");
            
            int resultIndex = largeRandomList.BinarySearch(randomRandomStringFromList);

            timer.Stop();

            if (resultIndex > 0)
            {
                Console.WriteLine("The string was found at index {0} in the list.", resultIndex);
            }

            TimeSpan searchListTs = timer.Elapsed;

            Console.WriteLine("Search list running time: " + searchListTs);
            //Console.ReadLine();

            // ---- Picking randomly a random string from stringcollection of random strings, then searching for it in the stringcollection ----

            timer.Reset();

            Console.WriteLine($"\nGenerating and sorting with MergeSort a stringcollection with {numOfStrs} random strings...");

            StringCollection largeRandomStringCollection = StringCollectionOfRandomStringsGenerator(numOfStrs, 20, r);
            largeRandomStringCollection = MergeSortStrings(largeRandomStringCollection);

            Console.WriteLine($"A new stringcollection of {numOfStrs} random strings has been generated and sorted.");

            string randomRandomStringFromStringCollection = largeRandomStringCollection[r.Next(0, largeRandomStringCollection.Count)];
            Console.WriteLine("\nRandomly picked random string from the stringcollection of {0} elements = \"{1}\"", 
                numOfStrs, randomRandomStringFromStringCollection);
            Console.WriteLine("Searching for a match of \"{0}\" in the stringcollection with {1} String elements...", 
                randomRandomStringFromStringCollection, numOfStrs);

            timer.Start();

            Console.WriteLine("Search has {0}", largeRandomStringCollection.Contains(randomRandomStringFromStringCollection) 
                ? "succeeded! The string was found!" : "failed. The string was not found.");

            int resIndex = largeRandomStringCollection.IndexOf(randomRandomStringFromStringCollection);

            timer.Stop();

            if (resIndex > 0)
            {
                Console.WriteLine("The string was found at index {0} in the stringcollection.", resIndex);
            }

            TimeSpan searchStringCollectionTs = timer.Elapsed;

            Console.WriteLine("Search stringcollection running time: " + searchStringCollectionTs);
            //Console.ReadLine();

            // ---- Picking randomly a random string from the first array of random strings, then searching for it in the array ----

            timer.Reset();

            Console.WriteLine($"\nGenerating and sorting with Array.Sort an array with {numOfStrs} random strings...");

            String[] largeRandomArray = ArrayOfRandomStringsGenerator(numOfStrs, 20, r);
             Array.Sort(largeRandomArray);

            Console.WriteLine($"A new array of {numOfStrs} random strings has been generated and sorted.");

            string randomRandomStringFromArray = largeRandomArray[r.Next(0, largeRandomArray.Length)];
            Console.WriteLine("\nRandomly picked random string from the array of {0} elements = \"{1}\"", 
                numOfStrs, randomRandomStringFromArray);
            Console.WriteLine("Searching for a match of \"{0}\" in the first array with {1} String elements...", 
                randomRandomStringFromArray, numOfStrs);

            timer.Start();

            Console.WriteLine("Search has {0}", Array.Exists(largeRandomArray, element => 
            element.Equals(randomRandomStringFromArray)) 
                ? "succeeded! The string was found!" : "failed. The string was not found.");

            int index = Array.BinarySearch(largeRandomArray, randomRandomStringFromArray);

            timer.Stop();

            if (index > 0)
            {
                Console.WriteLine("The string was found at index {0} in the array.", index);
            }

            TimeSpan searchArrayTs = timer.Elapsed;

            Console.WriteLine("Search array running time: " + searchArrayTs);
            Console.ReadLine();
            
        }
    }
}
