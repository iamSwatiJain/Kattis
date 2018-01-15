using System;

namespace Kattis
{
    public class ProblemA
    {
        public static void Main(string[] args)
        {
            var line = Console.ReadLine();

            Int32 samples;
            if (Int32.TryParse(line, out samples))
            {
                for (int i = 0; i < samples; i++)
                {
                    var str1 = Console.ReadLine();
                    var str2 = Console.ReadLine();

                    Console.WriteLine(str1);
                    Console.WriteLine(str2);
                    Console.WriteLine(CompareStrings(str1, str2) + "\r\n");
                }
            }
        }

        public static String CompareStrings(String str1, String str2)
        {
            var res = String.Empty;
            for (int i = 0; i < str1.Length; i++)
            {
                res += str1[i] == str2[i] ? "." : "*";
            }

            return res;
        }
    }


}
