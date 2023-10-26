using Substrate;
using Substrate.Core;

namespace minecraft_castle
{
    public class OuterWallCorner : Entity
    {
        public Direction[] Directions;

        public OuterWallCorner(Position Position, params Direction[] direction) : base(Position)
        {
            this.Directions = direction;
        }

        public override void Render(IBlockManager blockManager)
        {
            new Cube(Position.Offset(-3, 0, -3), 7, 5, 1, BlockType.STONE).Render(blockManager);
            new Cube(Position.Offset(-3, 0, -3), 1, 5, 7, BlockType.STONE).Render(blockManager);
            new Cube(Position.Offset(3, 0, -3), 1, 5, 7, BlockType.STONE).Render(blockManager);
            new Cube(Position.Offset(-3, 0, 3), 7, 5, 1, BlockType.STONE).Render(blockManager);

            new Cube(Position.Offset(-2, 4, -2), 5, 1, 5, BlockType.WOOD_PLANK).Render(blockManager);

            new Battlements(Position.Offset(-3, 5, -3), 7, Direction.EAST).Render(blockManager);
            new Battlements(Position.Offset(-3, 5, -3), 7, Direction.NORTH).Render(blockManager);
            new Battlements(Position.Offset(-3, 5, 3), 7, Direction.EAST).Render(blockManager);
            new Battlements(Position.Offset(3, 5, -3), 7, Direction.NORTH).Render(blockManager);

            foreach (Direction d in Directions)
            {
                switch (d)
                {
                    case Direction.NORTH:
                        blockManager.SetBlock(Position.X, Position.Y + 5, Position.Z - 3, new AlphaBlock(BlockType.AIR));
                        blockManager.SetBlock(Position.X, Position.Y + 4, Position.Z - 3, new AlphaBlock(BlockType.WOOD_PLANK));
                        break;
                    case Direction.EAST:
                        blockManager.SetBlock(Position.X - 3, Position.Y + 5, Position.Z, new AlphaBlock(BlockType.AIR));
                        blockManager.SetBlock(Position.X - 3, Position.Y + 4, Position.Z, new AlphaBlock(BlockType.WOOD_PLANK));
                        break;
                    case Direction.SOUTH:
                        blockManager.SetBlock(Position.X, Position.Y + 5, Position.Z + 3, new AlphaBlock(BlockType.AIR));
                        blockManager.SetBlock(Position.X, Position.Y + 4, Position.Z + 3, new AlphaBlock(BlockType.WOOD_PLANK));
                        break;
                    case Direction.WEST:
                        blockManager.SetBlock(Position.X + 3, Position.Y + 5, Position.Z, new AlphaBlock(BlockType.AIR));
                        blockManager.SetBlock(Position.X + 3, Position.Y + 4, Position.Z, new AlphaBlock(BlockType.WOOD_PLANK));
                        break;
                }
            }
        }
    }
}