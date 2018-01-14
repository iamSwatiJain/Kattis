using System;

namespace Kattis
{
    public class Vector
    {
        public Double X { get; }
        public Double Y { get; }

        public Vector(Double x, Double y)
        {
            X = x;
            Y = y;
        }

        public Vector Subtract(Vector by)
        {
            return new Vector(X - by.X, Y - by.Y);
        }

        public Double Magnitude
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }

        public Vector Scale(Double by)
        {
            return new Vector(by * X, by * Y);
        }

        public Double DotProduct(Vector by)
        {
            return X * by.X + Y * by.Y;
        }

        public Boolean DoesCollide(Vector v1, Vector v2, Int32 radius)
        {
            v1 = v1.Subtract(this);
            v2 = v2.Subtract(this);

            var projection = v1.Scale(v1.DotProduct(v2) / v1.DotProduct(v1));

            if (projection.DotProduct(v1) < 0)
            {
                return false;
            }

            if (v1.Subtract(projection).DotProduct(v1) < 0)
            {
                return false;
            }

            return v2.Subtract(projection).Magnitude < 2 * radius;
        }

        public Vector GetHitVector(Vector to, Int32 radius)
        {
            var v = to.Subtract(this);
            return Subtract(v.Scale(2 * radius / v.Magnitude));
        }
    }
}
