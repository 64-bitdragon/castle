using Substrate;
using Substrate.Core;
using Substrate.Nbt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace minecraft_castle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NbtWorld world = GenerateWorld();
            FlattenWorld(world, 4);

            var blockManager = world.GetBlockManager();

            new OuterWall(new Position(7, 4, 3), 63, Direction.EAST)
                .IncludeEntrance(true)
                .Render(blockManager);

            new OuterWall(new Position(3, 4, 7), 63, Direction.NORTH)
                .Render(blockManager);

            new OuterWall(new Position(7, 4, 73), 63, Direction.EAST)
                .Render(blockManager);

            new OuterWall(new Position(73, 4, 7), 63, Direction.NORTH)
                .Render(blockManager);

            new OuterWallCorner(new Position(3, 4, 3), Direction.SOUTH, Direction.WEST)
                .Render(blockManager);

            new OuterWallCorner(new Position(3, 4, 73), Direction.NORTH, Direction.WEST)
                .Render(blockManager);

            new OuterWallCorner(new Position(73, 4, 73), Direction.NORTH, Direction.EAST)
                .Render(blockManager);

            new OuterWallCorner(new Position(73, 4, 3), Direction.SOUTH, Direction.EAST)
                .Render(blockManager);

            new InnerWall(new Position(20, 4, 20), 37, Direction.EAST)
                .IncludeEntrance(true)
                .Render(blockManager);
            new InnerWall(new Position(20, 4, 20), 37, Direction.NORTH)
                .Render(blockManager);
            new InnerWall(new Position(20, 4, 56), 37, Direction.EAST)
                .Render(blockManager);
            new InnerWall(new Position(56, 4, 20), 37, Direction.NORTH)
                .Render(blockManager);

            new CenterRoom(new Position(26, 4, 26))
                .Render(blockManager);

            world.Save();
        }

        static void FlattenWorld(NbtWorld world, int height)
        {
            IChunkManager cm = world.GetChunkManager();
            for (int xi = -1; xi < 5; xi++)
            {
                for (int zi = -1; zi < 5; zi++)
                {
                    ChunkRef chunk = cm.CreateChunk(xi, zi);
                    chunk.IsTerrainPopulated = true;
                    chunk.Blocks.AutoLight = false;

                    FlattenChunk(chunk, height);

                    chunk.Blocks.RebuildHeightMap();
                    chunk.Blocks.RebuildBlockLight();
                    chunk.Blocks.RebuildSkyLight();

                    cm.Save();
                }
            }
        }

        static void FlattenChunk(ChunkRef chunk, int height)
        {
            for (int x = 0; x < 16; x++)
            {
                for (int z = 0; z < 16; z++)
                {
                    // Create bedrock
                    for (int y = 0; y < 1; y++)
                    {
                        chunk.Blocks.SetID(x, y, z, (int)BlockType.BEDROCK);
                    }

                    // Create stone
                    for (int y = 1; y < height - 5; y++)
                    {
                        chunk.Blocks.SetID(x, y, z, (int)BlockType.STONE);
                    }

                    // Create dirt
                    for (int y = Math.Max(1, height - 5); y < height - 1; y++)
                    {
                        chunk.Blocks.SetID(x, y, z, (int)BlockType.DIRT);
                    }

                    // Create grass
                    for (int y = height - 1; y < height; y++)
                    {
                        chunk.Blocks.SetID(x, y, z, (int)BlockType.GRASS);
                    }
                }
            }
        }

        static NbtWorld GenerateWorld()
        {
            string saveFolder = @"C:\Users\Home\AppData\Roaming\.minecraft\saves\" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            Directory.CreateDirectory(saveFolder);

            NbtWorld world = AnvilWorld.Create(saveFolder);
            world.Level.RandomSeed = 0;
            world.Level.LevelName = "Castle";
            world.Level.GameType = GameType.CREATIVE;
            world.Level.GeneratorName = "flat";
            world.Level.AllowCommands = true;
            world.Level.Player = new Player();
            world.Level.GameRules.DoMobSpawning = false;
            world.Level.Player.Position = new Vector3
            {
                X = 1.308,
                Y = 11.42,
                Z = 0.562
            };
            world.Level.Player.IsOnGround = false;
            world.Level.Player.Abilities.Flying = true;
            world.Level.Player.Rotation = new Orientation
            {
                Yaw = -45.4,
                Pitch = 35.2
            };

            return world;
        }
    }
}
