using System;
using System.Collections.Generic;

namespace Kattis
{
    public class ProblemB
    {
        public static void Main(String[] args)
        {
            String line;
            var mat = new List<Int32>();
            int i = 0;

            while ((line = Console.ReadLine()) != null)
            {
                if (line != String.Empty)
                {
                    var l = line.Split(' ');

                    mat.Add(Int32.Parse(l[0]));
                    mat.Add(Int32.Parse(l[1]));
                }
                else
                {
                    CalculateMatrixInverse(++i, mat[0], mat[1], mat[2], mat[3]);
                    mat.Clear();
                }
            }
        }

        public static void CalculateMatrixInverse(Int32 i, Int32 a, Int32 b, Int32 c, Int32 d)
        {
            var det = 1 / (a * d - b * c);

            var inv = new[]
            {
                det * d, det * -1 * b,
                det * -1 * c, det * a
            };

            Console.WriteLine("Case {0}:\r\n{1} {2}\r\n{3} {4}", i, inv[0], inv[1], inv[2], inv[3]);
        }
    }
}
