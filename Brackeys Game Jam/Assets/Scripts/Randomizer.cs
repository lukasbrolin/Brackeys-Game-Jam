using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Randomizer
{
    public string[] Randomize(string[] arrayList)
    {
        string[] tempArray = new string[arrayList.Length];
        foreach (string key in arrayList)
        {

            while (!tempArray.Contains(key))
            {
                Random random = new Random();
                int number = random.Next(0, arrayList.Length);
                if (tempArray[number] == null)
                {
                    tempArray[number] = key;
                    break;
                }
            }
        }
        return tempArray;
    }
}
