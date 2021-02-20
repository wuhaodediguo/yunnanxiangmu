using System;
using System.Collections.Generic;

namespace MojoCube.Api.Math
{
    public class Array
    {
        public static int[] iSortArray(int[] arr1)
        {
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                int num = i + 1;
                while (true)
                {
                    if (arr1[i] > arr1[num])
                    {
                        int num2 = arr1[i];
                        arr1[i] = arr1[num];
                        arr1[num] = num2;
                    }
                    else
                    {
                        if (num >= arr1.Length - 1)
                        {
                            break;
                        }
                        num++;
                    }
                }
            }
            return arr1;
        }

        public static int intCount(int[] intList)
        {
            int num = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < intList.Length; i++)
            {
                int num2 = intList[i];
                if (!dictionary.ContainsKey(num2))
                {
                    dictionary.Add(num2, 1);
                }
                else
                {
                    Dictionary<int, int> dictionary2;
                    int key;
                    (dictionary2 = dictionary)[key = num2] = dictionary2[key] + 1;
                }
            }
            foreach (int current in dictionary.Keys)
            {
                num++;
            }
            return num;
        }

        public static string[] MergeArray(string[] arr)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                string item = arr[i];
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }
    }
}
