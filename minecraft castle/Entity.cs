using Substrate.Core;

namespace minecraft_castle
{
    public abstract class Entity
    {
        public Position Position;

        protected Entity(Position position)
        {
            Position = position;
        }

        public abstract void Render(IBlockManager blockManager);
    }
}
