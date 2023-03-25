using System.Security.Cryptography.X509Certificates;

namespace ConsoleGame.Vectors
{
    /// <summary>
    /// A 2D vector.
    /// </summary>
    public class Vector2
    {
        public double x = 0, y = 0;

        /// <summary>
        /// A <see cref="Vector2"/> with all values set to 0.
        /// </summary>
        public static Vector2 Zero => new Vector2(0, 0);
        /// <summary>
        /// A <see cref="Vector2"/> with all values set to 1.
        /// </summary>
        public static Vector2 One => new Vector2(1, 1);
        /// <summary>
        /// A <see cref="Vector2"/> with the x value set to 0, and the y value set to -1.
        /// </summary>
        public static Vector2 Up => new Vector2(0, 1);
        /// <summary>
        /// A <see cref="Vector2"/> with the x value set to 1, and the y value set to 0.
        /// </summary>
        public static Vector2 Right => new Vector2(1, 0);

        /// <summary>
        /// Returns the magnitude of the vector.
        /// </summary>
        public double Mag => Math.Sqrt(x * x + y * y);
        /// <summary>
        /// Returns the magnitude squared of the vector.
        /// </summary>
        public double MagSq => (x * x) + (y * y);
        /// <summary>
        /// Returns the angle of the vector in radians.
        /// </summary>
        public double Angle => Math.Atan2(y, x);

        /// <summary>
        /// Makes a <see cref="Vector2"/> vector with the given <paramref name="x"/> and <paramref name="y"/> values.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Makes a <see cref="Vector2"/> with the given <paramref name="x"/> value, and a y value of 0.
        /// </summary>
        /// <param name="x"></param>
        public Vector2(double x) : this(x, 0) { }
        /// <summary>
        /// Makes a <see cref="Vector2"/> with all values set to 0.
        /// </summary>
        public Vector2() : this(0, 0) { }

        /// <summary>
        /// Casts a <see cref="Vector2"/> <paramref name="v"/> to a <see cref="Vector3"/>, with a z value of 0.
        /// </summary>
        /// <param name="v"></param>
        public static implicit operator Vector3(Vector2 v)
        {
            return new Vector3(v.x, v.y);
        }

        /// <summary>
        /// Indexer for the <see cref="Vector2"/>. Returns the x and y values in that order.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        throw new IndexOutOfRangeException($"Vector2 index out of range! {nameof(i)} is out of bounds: 0-1.");
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException($"Vector2 index out of range! {nameof(i)} is out of bounds: 0-1.");
                }
            }
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator *(Vector2 a, double b)
        {
            return new Vector2(a.x * b, a.y * b);
        }

        public static Vector2 operator /(Vector2 a, double b)
        {
            return new Vector2(a.x / b, a.y / b);
        }

        public static Vector2 operator +(Vector2 a)
        {
            return a;
        }

        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(-a.x, -a.y);
        }

        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return a.x != b.x || a.y != b.y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Vector2)
            {
                return this == (Vector2)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns the vector as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({x}, {y})";
        }

        /// <summary>
        /// Swizzles the components of the vector based on the given <paramref name="swizzle"/> string.
        /// </summary>
        /// <param name="swizzle">Can only contain 'x' and 'y'</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Vector2 Swizzle(string swizzle)
        {
            if (swizzle.Length != 2) throw new ArgumentException("The swizzle paramter need to be 2 characters long.");

            if (swizzle.Any(c => c != 'x' && c != 'y')) throw new ArgumentException("The swizzle parameter can only contain 'x' and 'y'.");

            return new Vector2(this[swizzle[0] - 'x'], this[swizzle[1] - 'x']);
        }

        /// <summary>
        /// Calculates the dot product of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Dot(Vector2 a, Vector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }


    }
}
