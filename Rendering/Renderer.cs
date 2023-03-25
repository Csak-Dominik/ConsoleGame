namespace ConsoleGame.Rendering
{
    public struct Bounds
    {
        public int x;
        public int y;
        public int width;
        public int height;
    }

    public class Renderer
    {
        private Bounds bounds;
        public Bounds Bounds
        {
            get
            {
                return bounds;
            }
            set
            {
                bounds = value;
            }
        }

        private ScreenTile[,] screenTiles;

        public Renderer(int x, int y, int width, int height)
        {
            bounds.x = x;
            bounds.y = y;
            bounds.width = width;
            bounds.height = height;

            screenTiles = new ScreenTile[width, height];

            for (int cy = 0; cy < bounds.height; cy++)
            {
                for (int cx = 0; cx < bounds.width; cx++)
                {
                    screenTiles[cx, cy] = new ScreenTile("\\/");
                }
            }
        }

        public void Render()
        {
            for (int y = 0; y < bounds.height; y++)
            {
                for (int x = 0; x < bounds.width; x++)
                {
                    Console.Write(screenTiles[x, y].Characters);
                }
                Console.WriteLine();
            }
        }
    }
}