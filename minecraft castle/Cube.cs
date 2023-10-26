using Substrate;
using Substrate.Core;

namespace minecraft_castle
{
    public class Cube : Entity
    {
        public int Width;
        public int Depth;
        public int Height;
        public int BlockType;

        public Cube(Position position, int width, int height, int depth, int blockType) : base(position)
        {
            this.Width = width;
            this.Depth = depth;
            this.Height = height;
            this.BlockType = blockType;
        }

        public override void Render(IBlockManager blockManager)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    for (int k = 0; k < Depth; k++)
                    {
                        blockManager.SetBlock(Position.X + i, Position.Y + j, Position.Z + k, new AlphaBlock(BlockType));
                    }
                }
            }
        }
    }
}