using ConsoleGame.Vectors;

namespace ConsoleGame.Rendering
{
    public class ScreenTile
    {
        public class TooManyCharactersException : Exception { }

        private char leftChar;
        private char rightChar;

        public char LeftChar
        {
            get => leftChar;
            set => leftChar = value;
        }

        public char RightChar
        {
            get => rightChar;
            set => rightChar = value;
        }

        public string Characters
        {
            get => leftChar + "" + rightChar;
            set
            {
                if (value.Length > 2) throw new TooManyCharactersException();

                if (value.Length == 2)
                {
                    leftChar = value[0];
                    rightChar = value[1];
                }
                else
                {
                    leftChar = value[0];
                    rightChar = value[0];
                }
            }
        }

        private ConsoleColor leftFrontColor;
        public ConsoleColor LeftFrontColor { get { return leftFrontColor; } set { leftFrontColor = value; } }
        private ConsoleColor rightFrontColor;
        public ConsoleColor RightFrontColor { get { return rightFrontColor; } set { rightFrontColor = value; } }

        private ConsoleColor leftBackColor;
        public ConsoleColor LeftBackColor { get { return leftBackColor; } set { leftBackColor = value; } }
        private ConsoleColor rightBackColor;
        public ConsoleColor RightBackColor { get { return rightBackColor; } set { rightBackColor = value; } }

        /// <summary>
        /// Creates a <see cref="ScreenTile"/> with the given <paramref name="x"/> and <paramref name="y"/> position.
        /// The <paramref name="str"/> parameter initializes the characters of the tile.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="str"></param>
        public ScreenTile(string str)
        {
            Characters = str;
        }

        public static bool SameFrontColors(ScreenTile a, ScreenTile b)
        {
            return a.leftFrontColor == b.leftFrontColor && a.rightFrontColor == b.rightFrontColor;
        }

        public static bool SameBackColors(ScreenTile a, ScreenTile b)
        {
            return a.leftBackColor == b.leftBackColor && a.rightBackColor == b.rightBackColor;
        }

        public static bool SameColors(ScreenTile a, ScreenTile b)
        {
            return SameFrontColors(a, b) && SameBackColors(a, b);
        }
    }
}
