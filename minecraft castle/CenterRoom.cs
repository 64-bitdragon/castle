using Substrate;
using Substrate.Core;

namespace minecraft_castle
{
    public class CenterRoom : Entity
    {
        public CenterRoom(Position position) : base(position)
        {

        }

        private static void RenderLayer(IBlockManager blockManager, Position position, int width)
        {
            new Cube(position, width, 8, 1, BlockType.STONE).Render(blockManager);
            new Cube(position.Offset(0, 0, 1), 1, 8, width, BlockType.STONE).Render(blockManager);
            new Cube(position.Offset(1, 0, width), width, 8, 1, BlockType.STONE).Render(blockManager);
            new Cube(position.Offset(width, 0, 0), 1, 8, width, BlockType.STONE).Render(blockManager);

            new Battlements(position.Offset(0, 8, 0), width + 1, Direction.EAST).Render(blockManager);
            new Battlements(position.Offset(0, 8, 0), width + 1, Direction.NORTH).Render(blockManager);
            new Battlements(position.Offset(0, 8, width), width + 1, Direction.EAST).Render(blockManager);
            new Battlements(position.Offset(width, 8, 0), width + 1, Direction.NORTH).Render(blockManager);

            new Cube(position.Offset(1, -1, 1), width - 1, 1, width - 1, BlockType.WOOD_PLANK).Render(blockManager);
            new Cube(position.Offset(1, 7, 1), width - 1, 1, width - 1, BlockType.WOOD_PLANK).Render(blockManager);

            var center = position.Offset(width / 2, 0, 0);
            new Cube(center.Offset(-2, 0, 0), 5, 3, 1, BlockType.AIR).Render(blockManager);
            new Cube(center.Offset(-2, 2, 0), 5, 1, 1, BlockType.FENCE).Render(blockManager);
            new Cube(center.Offset(-2, 0, 0), 1, 3, 1, BlockType.FENCE).Render(blockManager);
            new Cube(center.Offset(2, 0, 0), 1, 3, 1, BlockType.FENCE).Render(blockManager);
        }

        public override void Render(IBlockManager blockManager)
        {
            for (int i = 0; i < 5;i++)
            {
                RenderLayer(blockManager, Position.Offset(i * 2, i * 8, i * 2), 24 - i * 4);
            }
        }
    }
}
