namespace ConsoleGame.Vectors
{
    /// <summary>
    /// A 3D vector.
    /// </summary>
    public class Vector3
    {
        public double x = 0, y = 0, z = 0;

        /// <summary>
        /// A <see cref="Vector3"/> with all values set to 0.
        /// </summary>
        public static Vector3 Zero => new Vector3(0, 0, 0);
        /// <summary>
        /// A <see cref="Vector3"/> with all values set to 1.
        /// </summary>
        public static Vector3 One => new Vector3(1, 1, 1);
        /// <summary>
        /// A <see cref="Vector3"/> with the x value set to 0, the y value set to -1, and the z value set to 0.
        /// </summary>
        public static Vector3 Up => new Vector3(0, 1, 0);
        /// <summary>
        /// A <see cref="Vector3"/> with the x value set to 1, the y value set to 0, and the z value set to 0.
        /// </summary>
        public static Vector3 Right => new Vector3(1, 0, 0);
        /// <summary>
        /// A <see cref="Vector3"/> with the x value set to 0, the y value set to 0, and the z value set to 1.
        /// </summary>
        public static Vector3 Forward => new Vector3(0, 0, 1);

        /// <summary>
        /// The magnitude of the vector.
        /// </summary>
        public double Mag => Math.Sqrt(MagSq);
        /// <summary>
        /// The magnitude squared of the vector.
        /// </summary>
        public double MagSq => (x * x) + (y * y) + (z * z);

        /// <summary>
        /// Makes a <see cref="Vector3"/> with the given <paramref name="x"/>, <paramref name="y"/>, and <paramref name="z"/> values.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        /// <summary>
        /// Makes a <see cref="Vector3"></see> with the given <paramref name="x"/> and <paramref name="y"/> values, and a z value of 0.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector3(double x, double y) : this(x, y, 0) { }
        /// <summary>
        /// Makes a <see cref="Vector3"/> with the given <paramref name="x"/> value, and y and z values of 0.
        /// </summary>
        /// <param name="x"></param>
        public Vector3(double x) : this(x, 0, 0) { }
        /// <summary>
        /// Makes a <see cref="Vector3"/> with all values set to 0.
        /// </summary>
        public Vector3() : this(0, 0, 0) { }
        /// <summary>
        /// Makes a <see cref="Vector3"/> with the given x and y values of <see cref="Vector2"/> <paramref name="v"/>, and z value of 0.
        /// </summary>
        /// <param name="v"></param>
        public Vector3(Vector2 v) : this(v.x, v.y, 0) { }
        /// <summary>
        /// Makes a <see cref="Vector3"/> with the x and y values of the given <see cref="Vector2"/>, and a z value of <paramref name="z"/>.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        public Vector3(Vector2 v, double z) : this(v.x, v.y, z) { }

        /// <summary>
        /// Indexer for the <see cref="Vector3"/>. Returns the x, y, and z values in that order.
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
                    case 2:
                        return z;
                    default:
                        throw new IndexOutOfRangeException($"Vector3 index out of range! {nameof(i)} is out of bounds: 0-2.");
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
                    case 2:
                        z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException($"Vector3 index out of range! {nameof(i)} is out of bounds: 0-2.");
                }
            }
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator *(Vector3 a, double b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }

        public static Vector3 operator /(Vector3 a, double b)
        {
            return new Vector3(a.x / b, a.y / b, a.z / b);
        }

        public static Vector3 operator +(Vector3 a)
        {
            return a;
        }

        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a.x, -a.y, -a.z);
        }

        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }

        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return a.x != b.x || a.y != b.y || a.z != b.z;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Vector3)
            {
                return this == (Vector3)obj;
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
            return $"({x}, {y}, {z})";
        }

        /// <summary>
        /// Swizzles the components of the vector based on the given <paramref name="swizzle"/> string.
        /// </summary>
        /// <param name="swizzle">Can only contain 'x', 'y' and 'z'</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Vector3 Swizzle(string swizzle)
        {
            if (swizzle.Length != 3) throw new ArgumentException("The swizzle parameter needs to be 3 characters long.");

            if (swizzle.Any(c => c != 'x' && c != 'y' && c != 'z')) throw new ArgumentException("The swizzle parameter can only contain 'x', 'y' and 'z'.");

            return new Vector3(this[swizzle[0] - 'x'], this[swizzle[1] - 'x'], this[swizzle[2] - 'x']);
        }

        /// <summary>
        /// Calculates the dot product of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Dot(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        /// <summary>
        /// Calculates the cross product of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }
    }
}
