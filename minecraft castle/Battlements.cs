using Substrate;
using Substrate.Core;

namespace minecraft_castle
{
    public class Battlements : Entity
    {
        public int Length;
        public Direction Direction;

        public Battlements(Position position, int length, Direction direction) : base(position)
        {
            Length = length;

            if (Direction == Direction.SOUTH)
            {
                position.Z -= length;
                Direction = Direction.NORTH;
            }
            else if (Direction == Direction.WEST)
            {
                position.X -= length;
                Direction = Direction.EAST;
            }
            else
            {
                Direction = direction;
            }
        }

        public override void Render(IBlockManager blockManager)
        {
            if (Direction == Direction.EAST)
            {
                for (int x = 0; x < Length; x += 2)
                {
                    blockManager.SetBlock(Position.X + x, Position.Y, Position.Z, new AlphaBlock(BlockType.STONE));
                }

                for (int x = 1; x < Length; x += 2)
                {
                    blockManager.SetBlock(Position.X + x, Position.Y, Position.Z, new AlphaBlock(BlockType.FENCE));
                    blockManager.SetBlock(Position.X + x, Position.Y + 1, Position.Z, new AlphaBlock(BlockType.TORCH, 5));
                }
            }
            else
            {
                for (int x = 0; x < Length; x += 2)
                {
                    blockManager.SetBlock(Position.X, Position.Y, Position.Z + x, new AlphaBlock(BlockType.STONE));
                }

                for (int x = 1; x < Length; x += 2)
                {
                    blockManager.SetBlock(Position.X, Position.Y, Position.Z + x, new AlphaBlock(BlockType.FENCE));
                    blockManager.SetBlock(Position.X, Position.Y + 1, Position.Z + x, new AlphaBlock(BlockType.TORCH, 5));
                }
            }
        }
    }
}
