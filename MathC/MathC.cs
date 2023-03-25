using ConsoleGame.Vectors;

namespace ConsoleGame.MathC
{
    /// <summary>
    /// A class containing math functions.
    /// </summary>
    public static class MathC
    {
        /// <summary>
        /// Linear interpolation between <paramref name="a"/> and <paramref name="b"/>. Ratio is defined by <paramref name="t"/>.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static double Lerp(double a, double b, double t)
        {
            return a + (b - a) * t;
        }
        /// <inheritdoc cref="Lerp(double, double, double)"/>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }
        /// <inheritdoc cref="Lerp(double, double, double)"/>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2 Lerp(Vector2 a, Vector2 b, double t)
        {
            return a + (b - a) * t;
        }
        /// <inheritdoc cref="Lerp(double, double, double)"/>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector3 Lerp(Vector3 a, Vector3 b, double t)
        {
            return a + (b - a) * t;
        }
        /// <inheritdoc cref="Lerp(double, double, double)"/>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector4 Lerp(Vector4 a, Vector4 b, double t)
        {
            return a + (b - a) * t;
        }
    }
}
