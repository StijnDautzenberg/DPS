﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    abstract partial class World : ObjectList
    {
        public virtual void Load(string assetName)
        {
            ReadTiles(ReadFile(assetName));
        }

        private List<string> ReadFile(string assetName)
        {
            StreamReader stream = new StreamReader(assetName);
            List<string> lines = new List<string>();


            //read lines from file
            string line = stream.ReadLine();
            while (line != null)
            {
                lines.Add(line);
                line = stream.ReadLine();
            }
            return lines;
        }

        private void ReadTiles(List<string> lines)
        {
            for (int y = 0; y < lines.Count; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    AddTile(FindType(lines[y][x]), lines[y][x], x, y);
                }
            }
        }

        protected virtual Object FindType(char type)
        {
            return null;
        }

        private void AddTile(Object tile, char type, int x, int y)
        {
            if (tile != null)
            {
                tile.Position = new Vector2(x * tileWidth, y * tileHeight);
                Add(tile);
            }
            else
            {
                throw new Exception("tile type: " + type + "was not found");
            }
        }
    }
}
