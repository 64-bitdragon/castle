using Substrate;
using Substrate.Core;

namespace minecraft_castle
{
    public class OuterWall : Entity
    {
        public int Length;
        public Direction Direction;
        private bool _includeEntrance = false;

        public OuterWall(Position position, int length, Direction direction) : base(position)
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

        public OuterWall IncludeEntrance(bool includeEntrance)
        {
            _includeEntrance = includeEntrance;
            return this;
        }

        public override void Render(IBlockManager blockManager)
        {
            if (Direction == Direction.EAST)
            {
                new Cube(Position.Offset(0, 0, -1), Length, 5, 3, BlockType.STONE).Render(blockManager);
                new Cube(Position.Offset(0, 4, 0), Length, 1, 1, BlockType.WOOD_PLANK).Render(blockManager);
                new Battlements(Position.Offset(0, 5, 1), Length, Direction).Render(blockManager);
                new Battlements(Position.Offset(0, 5, -1), Length, Direction).Render(blockManager);

                if (_includeEntrance)
                {
                    var center = Position.Offset(Length / 2, 0, 0);
                    new Cube(center.Offset(-2, 0, -1), 5, 3, 3, BlockType.AIR).Render(blockManager);
                    new Cube(center.Offset(-2, 2, 0), 5, 1, 1, BlockType.FENCE).Render(blockManager);
                    new Cube(center.Offset(-2, 0, 0), 1, 3, 1, BlockType.FENCE).Render(blockManager);
                    new Cube(center.Offset(2, 0, 0), 1, 3, 1, BlockType.FENCE).Render(blockManager);
                }
            }
            else
            {
                new Cube(Position.Offset(-1, 0, 0), 3, 5, Length, BlockType.STONE).Render(blockManager);
                new Cube(Position.Offset(0, 4, 0), 1, 1, Length, BlockType.WOOD_PLANK).Render(blockManager);
                new Battlements(Position.Offset(1, 5, 0), Length, Direction).Render(blockManager);
                new Battlements(Position.Offset(-1, 5, 0), Length, Direction).Render(blockManager);

                if (_includeEntrance)
                {
                    var center = Position.Offset(0, 0, Length / 2);
                    new Cube(center.Offset(-1, 0, -2), 3, 3, 5, BlockType.AIR).Render(blockManager);
                    new Cube(center.Offset(0, 2, -2), 1, 1, 5, BlockType.FENCE).Render(blockManager);
                    new Cube(center.Offset(0, 0, -2), 1, 3, 1, BlockType.FENCE).Render(blockManager);
                    new Cube(center.Offset(0, 0, 2), 1, 3, 1, BlockType.FENCE).Render(blockManager);
                }
            }
        }
    }
}
