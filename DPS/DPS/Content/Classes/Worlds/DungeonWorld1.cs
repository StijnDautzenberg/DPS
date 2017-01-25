﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class DungeonWorld1 : Engine.World
    {
        public DungeonWorld1(string id, int width, int height) : base(id, width, height)
        {

        }

        public override void Setup(GameMode gameMode)
        {
            base.Setup(gameMode);
            IsTopDown = false;

            var zombie = new EnemyZombie("zombie", this, new SpriteSheetZombie("Textures/Characters/IceZombie"), "zombieNormal", "Sound Effects - Zombie scream");
            zombie.Position = new Microsoft.Xna.Framework.Vector2(35808, 16704);
            Add(zombie);
            var zombie1 = new EnemyZombie("zombie", this, new SpriteSheetZombie("Textures/Characters/IceZombie"), "zombieNormal", "Sound Effects - Zombie scream");
            zombie1.Position = new Microsoft.Xna.Framework.Vector2(32256, 16992);
            Add(zombie1);
            var zombie2 = new EnemyZombie("zombie", this, new SpriteSheetZombie("Textures/Characters/IceZombie"), "zombieNormal", "Sound Effects - Zombie scream");
            zombie2.Position = new Microsoft.Xna.Framework.Vector2(35436, 18624);
            Add(zombie2);

            var snowman = new EnemySnowMan("snowman", this, new SpriteSheetSnowMan("Textures/Characters/SnowmanThrower"));
            snowman.Position = new Microsoft.Xna.Framework.Vector2(32836, 16064);
            Add(snowman);
            var snowman1 = new EnemySnowMan("snowman", this, new SpriteSheetSnowMan("Textures/Characters/SnowmanThrower"));
            snowman1.Position = new Microsoft.Xna.Framework.Vector2(34176, 16992);
            Add(snowman1);
            var snowman2 = new EnemySnowMan("snowman", this, new SpriteSheetSnowMan("Textures/Characters/SnowmanThrower"));
            snowman2.Position = new Microsoft.Xna.Framework.Vector2(29856, 17280);
            Add(snowman2);
            var snowman3 = new EnemySnowMan("snowman", this, new SpriteSheetSnowMan("Textures/Characters/SnowmanThrower"));
            snowman3.Position = new Microsoft.Xna.Framework.Vector2(35136, 18624);
            Add(snowman3);
            var snowman4 = new EnemySnowMan("snowman", this, new SpriteSheetSnowMan("Textures/Characters/SnowmanThrower"));
            snowman4.Position = new Microsoft.Xna.Framework.Vector2(35636, 18624);
            Add(snowman4);

            Teleporter teleporterOverworld = new Teleporter("teleporter", this, "MainWorld", new Vector2(600, 400));
            teleporterOverworld.Position = new Vector2(40992, 11616);
            teleporterOverworld.BoundingBox = new Rectangle(0, 0, 96, 96);

            //Items to progress in the Dungeon
            Pickup SnowShoes = new Pickup("SnowShoes", World, new SpriteSheet("Textures/Items/SnowShoes"), "Capable of walking on Ice");
            Add(SnowShoes);

            Pickup Key1 = new Pickup("Hallowed_Key", World, new SpriteSheet("Textures/Items/Hallowed_Key"), "First key in the Dungeon");
            Add(Key1);

            Pickup Key2 = new Pickup("Frozen_Key", World, new SpriteSheet("Textures/Items/Frozen_Key"), "Second key in the Dungeon");
            Add(Key2);

            Pickup Key3 = new Pickup("SkeletonKey", World, new SpriteSheet("Textures/Items/SkeletonKey"), "Final key in the Dungeon");
            Add(Key3);

            Pickup Presents = new Pickup("BluePresent", World, new SpriteSheet("Textures/Items/BluePresent"), "Present to break certain blocks");
            Add(Presents);

            UpgradePickup RocketCape = new UpgradePickup("Rocketcape", this, new SpriteSheet("Textures/Items/Rocketcape"), "Cape making high jumps possible");
            RocketCape.Position = new Vector2(41280, 18800);
            RocketCape.CanCollide = true;
            Add(RocketCape);

            //Setup LevelGrid
            ObjectGrid levelGrid = new ObjectGrid("levelGrid", this, 49, 29, 1920, 960);

            #region Grid
            string[,] grid = new string[49, 29];
            grid[21, 12] = "1";
            grid[21, 13] = "2";
            grid[21, 14] = "3";
            grid[21, 15] = "4";
            grid[21, 16] = "5";
            grid[21, 17] = "6";
            grid[21, 18] = "7";
            grid[21, 19] = "8";
            grid[17, 6] = "9";
            grid[14, 5] = "10";
            grid[12, 6] = "11";
            grid[13, 6] = "12";
            grid[16, 7] = "13";
            grid[16, 8] = "14";
            grid[17, 8] = "15";
            grid[18, 7] = "16";
            grid[14, 8] = "17";
            grid[15, 8] = "18";
            grid[13, 8] = "19";
            grid[13, 9] = "20";
            grid[13, 10] = "21";
            grid[14, 10] = "22";
            grid[15, 10] = "23";
            grid[16, 10] = "24";
            grid[17, 10] = "25";
            grid[16, 11] = "26";
            grid[16, 12] = "27";
            grid[17, 12] = "28";
            grid[18, 12] = "29";
            grid[18, 13] = "30";
            grid[19, 13] = "31";
            grid[20, 13] = "32";
            grid[16, 19] = "33";
            grid[17, 19] = "34";
            grid[18, 19] = "35";
            grid[19, 19] = "36";
            grid[20, 19] = "37";
            grid[15, 17] = "38";
            grid[15, 18] = "39";
            grid[15, 19] = "40";
            grid[15, 20] = "41";
            grid[15, 21] = "42";
            grid[16, 17] = "43";
            grid[17, 17] = "44";
            grid[18, 16] = "45";
            grid[18, 17] = "46";
            grid[17, 16] = "47";
            grid[19, 16] = "48";
            grid[20, 16] = "49";
            grid[15, 12] = "50";
            grid[15, 13] = "51";
            grid[15, 14] = "52";
            grid[13, 14] = "53";
            grid[14, 14] = "54";
            grid[12, 14] = "55";
            grid[12, 15] = "56";
            grid[12, 16] = "57";
            grid[10, 16] = "58";
            grid[11, 16] = "59";
            grid[7, 14] = "60";
            grid[6, 14] = "61";
            grid[6, 16] = "62";
            grid[6, 17] = "63";
            grid[6, 18] = "64";
            grid[6, 19] = "65";
            grid[5, 19] = "66";
            grid[2, 17] = "67";
            grid[1, 19] = "68";
            grid[0, 19] = "69";
            grid[0, 20] = "70";
            grid[0, 21] = "71";
            grid[0, 22] = "72";
            grid[1, 22] = "73";
            grid[2, 21] = "74";
            grid[2, 22] = "75";
            grid[3, 21] = "76";
            grid[4, 21] = "77";
            grid[5, 21] = "78";
            grid[5, 22] = "79";
            grid[6, 22] = "80";
            grid[7, 21] = "81";
            grid[7, 22] = "82";
            grid[8, 21] = "83";
            grid[9, 21] = "84";
            grid[10, 20] = "85";
            grid[13, 21] = "86";
            grid[14, 21] = "87";
            grid[15, 1] = "88";
            grid[15, 2] = "89";
            grid[15, 3] = "90";
            grid[15, 4] = "91";
            grid[15, 0] = "92";
            #endregion

            //create randomDungeonGenerator
            RandomDungeonGenerator dungeonGenerator = new RandomDungeonGenerator();

            for (int i = 1; i < 93; i++)
            {
                GridDungeon room = new GridDungeon("level1", levelGrid, i.ToString(), 96);
                for (int x = 0; x < 49; x++)
                {
                    for (int y = 0; y < 29; y++)
                    {
                        if (grid[x, y] != null && int.Parse(grid[x, y]) == i)
                        {
                            room.PositionX = x * 20 * 96;
                            room.PositionY = y * 10 * 96;
                            levelGrid.setTile(x, y, room);
                        }
                    }
                }
                room.CanCollide = true;
            }
            levelGrid.CanCollide = true;
            Add(levelGrid);
        }
    }
}