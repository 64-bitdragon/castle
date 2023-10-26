namespace minecraft_castle
{
    public class Position
    {
        public int X;
        public int Y;
        public int Z;

        public Position(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Position Offset(int x, int y, int z)
        {
            return new Position(X + x, Y + y, Z + z);
        }
    }
}