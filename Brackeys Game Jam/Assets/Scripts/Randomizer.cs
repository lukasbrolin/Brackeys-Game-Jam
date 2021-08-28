using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Randomizer
{
    public string[] Randomize(string[] arrayList)
    {
        /*string[] tempArray = new string[arrayList.Length];
        Random random = new Random();
        foreach (string key in arrayList)
        {
            int number = random.Next(0, arrayList.Length);
            if (tempArray[number] == null)
            {
                tempArray[number] = key;
            }
        }
        if (tempArray.All(x => string.IsNullOrEmpty(x))){

            int[] newArray = tempArray.Select((s, i) => new { i, s })
                .Where(t => t.s == null)
                .Select(t => t.i).ToArray();
            foreach(int key in newArray)
            {
                tempArray[key] = tempArray[0];
            }
        };
        return tempArray;*/
        string[] tempArray = new string[arrayList.Length];
        arrayList.CopyTo(tempArray,0);
        Random random = new Random();
        Enumerable.Range(0, 9).OrderBy(c => random.Next()).ToArray();
        for (int i = tempArray.Length - 1; i > 0; i--)
        {
            int randomIndex = random.Next(0, i + 1);

            string temp = tempArray[i];
            tempArray[i] = tempArray[randomIndex];
            tempArray[randomIndex] = temp;
        }
        return tempArray;
    }
}
