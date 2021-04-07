using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    // A weighted string is a string of lowercase English letters where each
    // letter has a weight. Character weights are 1 to 26 from a to z.

    // Complete the weightedUniformStrings function below.
    static string[] weightedUniformStrings(string s, int[] queries)
    {
        string[] results = new string[queries.Length];
        int[] counts = new int[26];

        if (s.Length > 0)
        {
            char last = s[0];
            int count = 0;

            // Get the counts
            foreach (char c in s)
            {
                if (c == last)
                    count++;
                else
                {
                    if (counts[last - 'a'] < count)
                        counts[last - 'a'] = count;

                    last = c;
                    count = 1;
                }
            }

            if (counts[last - 'a'] < count)
                counts[last - 'a'] = count;
        }

        // Now check the queries
        for (int qidx = 0; qidx < queries.Length; qidx++)
        {
            results[qidx] = "No";
            for (int cidx = 0; cidx < counts.Length && cidx + 1 <= queries[qidx]; cidx++)
            {
                if (queries[qidx] % (cidx + 1) == 0 &&          // Evenly divisible?
                    queries[qidx] / (cidx + 1) <= counts[cidx]) // Less than or equal to count
                    results[qidx] = "Yes";
            }
        }

        return results;
    }

    static void Main(string[] args)
    {

        string s = "abbcccdddd";

        int[] queries = new int[]
        {
            1,7,5,4,15
        };

        string[] result = weightedUniformStrings(s, queries);

        Console.WriteLine(string.Join("\n", result));
    }
}
