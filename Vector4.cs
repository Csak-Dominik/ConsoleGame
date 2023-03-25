namespace ConsoleGame.Vectors
{
    public class Vector4
    {
        public double x = 0, y = 0, z = 0, w = 0;

        public static Vector4 Zero => new Vector4(0, 0, 0, 0);
        public static Vector4 One => new Vector4(1, 1, 1, 1);
        public static Vector4 Up => new Vector4(0, 1, 0, 0);
        public static Vector4 Right => new Vector4(1, 0, 0, 0);
        public static Vector4 Forward => new Vector4(0, 0, 1, 0);
        public static Vector4 Dir4 => new Vector4(0, 0, 0, 1);

        public double Mag => Math.Sqrt(MagSq);
        public double MagSq => (x * x) + (y * y) + (z * z) + (w * w);

        /// <summary>
        /// Makes a <see cref="Vector4"/> vector with the given <paramref name="x"/>, <paramref name="y"/>, <paramref name="z"/>, and <paramref name="w"/> values.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public Vector4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        /// <summary>
        /// Makes a <see cref="Vector4"/> with the given <paramref name="x"/>, <paramref name="y"/>, and <paramref name="z"/> values, and a w value of 0.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector4(double x, double y, double z) : this(x, y, z, 0) { }
        /// <summary>
        /// Makes a <see cref="Vector4"/> with the given <paramref name="x"/> and <paramref name="y"/> values, and w, z values of 0.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector4(double x, double y) : this(x, y, 0, 0) { }
        /// <summary>
        /// Makes a <see cref="Vector4"/> with the given <paramref name="x"/> value, and y, z, w values of 0.
        /// </summary>
        /// <param name="x"></param>
        public Vector4(double x) : this(x, 0, 0, 0) { }
        /// <summary>
        /// Makes a <see cref="Vector4"/> with all values set to 0.
        /// </summary>
        public Vector4() : this(0, 0, 0, 0) { }
        /// <summary>
        /// Makes a <see cref="Vector4"/> with the given x, y and z values of <see cref="Vector3"/> <paramref name="v"/>, and a w value of 0.
        /// </summary>
        /// <param name="v"></param>
        public Vector4(Vector3 v) : this(v.x, v.y, v.z, 0) { }
        /// <summary>
        /// Makes a <see cref="Vector4"/> with the given x, y and z values of <see cref="Vector3"/> <paramref name="v"/>, and a w value of <paramref name="w"/>.
        /// </summary>
        /// <param name="v"></param>
        public Vector4(Vector3 v, double w) : this(v.x, v.y, v.z, w) { }
        /// <summary>
        /// Makes a <see cref="Vector4"/> with the given x, y values of <see cref="Vector2"/> <paramref name="v"/>, and z, w values of 0.
        /// </summary>
        /// <param name="v"></param>
        public Vector4(Vector2 v) : this(v.x, v.y, 0, 0) { }
        /// <summary>
        /// Makes a <see cref="Vector4"/> with the given x, y values of <see cref="Vector2"/> <paramref name="v"/>, and z, w values of <paramref name="z"/> and <paramref name="w"/>.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public Vector4(Vector2 v, double z, double w) : this(v.x, v.y, z, w) { }
        /// <summary>
        /// Makes a <see cref="Vector4"/> with the given x, y values of <see cref="Vector2"/> <paramref name="v"/>, and z, w values of <see cref="Vector2"/> <paramref name="v2"/>.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="v2"></param>
        public Vector4(Vector2 v, Vector2 v2) : this(v.x, v.y, v2.x, v2.y) { }

        /// <summary>
        /// Indexer for the <see cref="Vector4"/>. Returns the x, y, z, and w values in that order.
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
                    case 3:
                        return w;
                    default:
                        throw new IndexOutOfRangeException($"Vector4 index out of range! {nameof(i)} is out of bounds: 0-3.");
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
                    case 3:
                        w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException($"Vector4 index out of range! {nameof(i)} is out of bounds: 0-3.");
                }
            }
        }

        public static implicit operator Vector4(Vector3 v)
        {
            return new Vector4(v);
        }

        public static implicit operator Vector4(Vector2 v)
        {
            return new Vector4(v);
        }

        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }

        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }

        public static Vector4 operator *(Vector4 a, double b)
        {
            return new Vector4(a.x * b, a.y * b, a.z * b, a.w * b);
        }

        public static Vector4 operator /(Vector4 a, double b)
        {
            return new Vector4(a.x / b, a.y / b, a.z / b, a.w / b);
        }

        public static Vector4 operator -(Vector4 a)
        {
            return new Vector4(-a.x, -a.y, -a.z, -a.w);
        }

        public static bool operator ==(Vector4 a, Vector4 b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
        }

        public static bool operator !=(Vector4 a, Vector4 b)
        {
            return a.x != b.x || a.y != b.y || a.z != b.z || a.w != b.w;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Vector4)
            {
                Vector4 v = (Vector4)obj;
                return x == v.x && y == v.y && z == v.z && w == v.w;
            }
            return false;
        }

        /// <summary>
        /// Returns the vector as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2}, {3})", x, y, z, w);
        }

        /// <summary>
        /// Swizzles the components of the vector based on the given <paramref name="swizzle"/> string.
        /// </summary>
        /// <param name="swizzle"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Vector4 Swizzle(string swizzle)
        {
            if (swizzle.Length != 4) throw new ArgumentException("The swizzle parameter needs to be 4 characters long.");

            if (swizzle.Any(c => c != 'x' && c != 'y' && c != 'z' && c != 'w')) throw new ArgumentException("The swizzle parameter can only contain 'x', 'y', 'z' and 'w'.");

            return new Vector4(this[swizzle[0] - 'x'], this[swizzle[1] - 'x'], this[swizzle[2] - 'x'], this[swizzle[3] - 'x']);
        }

        /// <summary>
        /// Calculates the dot product of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Dot(Vector4 a, Vector4 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }
    }
}
