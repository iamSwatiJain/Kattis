using System;

namespace Kattis
{
    /// <summary>
    /// https://www.mathsisfun.com/sine-cosine-tangent.html
    /// https://www.wikihow.com/Find-the-Angle-Between-Two-Vectors
    /// </summary>
    /*
     You want to place Q ball and shoot it such that it hits B1, which then hits B3 which goes to top right hole, and then Q hits B2 which goes into top left hole. You want to solve this with the following simplified rules and physics:

    1. there are no walls (so no bouncing off walls)
    2. when moving ball collides stationary ball, the moving ball follows angle of incidence = angle of reflection, and the stationary ball moves perpendicular to plane of collision
    3. ball hits hole iff center of ball hits center of hole

    Solution
    The solution is to "back trace" the balls to start. In other words, you do the following:
    1. Find where B1 has to be to hit B3 for B3 to go to top-right corner (this involves drawing a line from top right corner to B3, and then extending it by 2*radius)
    2. Find where Q has to be to hit B1 to get B1 to hit B3 correctly (call this position C1)
    3. Find where Q has to be to hit B2 to get B2 to go into top left corner (call this position C2)
    4. Find initial position of Q by "reflecting" the path of C2-C1 according to the line C1-B1.

    Pitfalls:
    1. Check if any of the path intersect any stationary balls.
    2. It's possible that B1 = C1, and C1 = C2, make sure you don't divide by zero, and handle them specially.
    3. The Q ball has to start completely inside the rectangle, not just the center inside.
    4. Use epsilons.
     */
    public class ProblemC
    {
        public static void Main(String[] args)
        {
            var line1 = Console.ReadLine().Split(' ');
            var line2 = Console.ReadLine().Split(' ');

            var w = Double.Parse(line1[0]);
            var l = Double.Parse(line1[1]);
            var r = Int32.Parse(line2[0]);
            var x1 = Double.Parse(line2[1]);
            var y1 = Double.Parse(line2[2]);
            var x2 = Double.Parse(line2[3]);
            var y2 = Double.Parse(line2[4]);
            var x3 = Double.Parse(line2[5]);
            var y3 = Double.Parse(line2[6]);
            var h = Double.Parse(line2[7]);

            var left = new Vector(0, l);
            var right = new Vector(w, l);
            var b1 = new Vector(x1, y1);
            var b2 = new Vector(x2, y2);
            var b3 = new Vector(x3, y3);

            var v2 = b2.GetHitVector(left, r);
            var v3 = b3.GetHitVector(right, r);
            var v1 = b1.GetHitVector(v3, r);

            var mirror = v3.Subtract(b1);
            var reflection = v2.Subtract(v1);

            var result = mirror.Scale(2 * mirror.DotProduct(reflection) / mirror.DotProduct(mirror)).Subtract(reflection);
            result = result.Scale(1 / result.Magnitude);

            var d = v1.X - ((v1.Y - h) / result.Y * result.X);
            var theta = 180 + 180 / Math.PI * Math.Atan2(result.Y, result.X);

            var cue = new Vector(d, h);
            if (IsImpossibleShot(w, l, r, b1, b2, b3, v2, v3, v1, result, d, theta, cue))
            {
                Console.Write("impossible");
            }
            else
            {
                Console.Write("{0:0.00} {1:N2}", d, theta);
            }
        }

        private static Boolean IsImpossibleShot(double w, double l, int r, Vector b1, Vector b2, Vector b3, Vector v2, Vector v3, Vector v1, Vector result, double d, double theta, Vector cue)
        {
            if (d < r || d > w - r)
            {
                return true;
            }
            else if (result.Subtract(v1).DotProduct(b1.Subtract(v1)) >= 0)
            {
                return true;
            }
            else if (v1.Subtract(v2).DotProduct(b2.Subtract(v2)) >= 0)
            {
                return true;
            }
            else if (b1.Subtract(v3).DotProduct(b3.Subtract(v3)) >= 0)
            {
                return true;
            }
            else if (cue.DoesCollide(v1, b2, r))
            {
                return true;
            }
            else if (cue.DoesCollide(v1, b3, r))
            {
                return true;
            }
            else if (v1.DoesCollide(v2, b3, r))
            {
                return true;
            }
            else if (b1.DoesCollide(v3, b2, r))
            {
                return true;
            }
            else if (v1.X < r || v1.X > w - r || v1.Y < r || v1.Y > l - r)
            {
                return true;
            }
            else if (v2.X < r || v2.X > w - r || v2.Y < r || v2.Y > l - r)
            {
                return true;
            }
            else if (v3.X < r || v3.X > w - r || v3.Y < r || v3.Y > l - r)
            {
                return true;
            }

            return false;
        }
    }
}
