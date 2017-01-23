﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    partial class World : ObjectList
    {
        private bool _isTopDown;
        private List<Object> _collisionObjects, _objectsToAdd, _objectsToRemove;
        private List<Player> _characters;
        private Vector2 _cameraPosition;
        private int _tileSize;
        private Player _player;
        private GameMode _gameMode;
        private bool _canUpdate;

        //physics
        private float _gravity;

        public bool IsTopDown
        {
            get { return _isTopDown; }
            set { _isTopDown = value; }
        }

        public Vector2 CameraPosition
        {
            set { _cameraPosition = value; }
            get { return _cameraPosition; }
        }

        public List<Player> Characters
        {
            get { return _characters; }
        }

        public int TileSize
        {
            get { return _tileSize; }
            set { _tileSize = value; }
        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public bool CanUpdate
        {
            set { _canUpdate = value; }
        }

        public List<Object> CollisionObjects
        {
            get { return _collisionObjects; }
        }

        public GameMode GameMode
        {
            get { return _gameMode; }
        }

        //phyics
        public float Gravity
        {
            get { return _gravity; }
            set { _gravity = value; }
        }

        public World(string id, int width, int height, GameMode gameMode) : base(id, null)
        {
            setBoundingBoxDimensions(width, height);
            _isTopDown = true;
            _collisionObjects = new List<Object>();
            _characters = new List<Player>();
            _objectsToAdd = new List<Object>();
            _objectsToRemove = new List<Object>();
            _cameraPosition = Vector2.Zero;
            _gameMode = gameMode;
            _tileSize = 60;
            _gravity = 350f;
            _canUpdate = true;
        }

        public void HandleInput(GameTime gameTime)
        {
            foreach(Player c in _characters)
            {
                c.HandleInput(gameTime);
            }
        }

        public override void Add(Object o)
        {
            if(o is Player)
            {
                _characters.Add(o as Player);
            }
            _objectsToAdd.Add(o);
        }

        public override void Remove(Object o)
        {
            if(o is Player)
            {
                _characters.Remove(o as Player);
            }
            _objectsToRemove.Add(o);
            o = null;
        }

        public override void Reset()
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Object o in Objects)
            {
                if (!(o.GlobalPosition.X + o.Width < CameraPosition.X || o.GlobalPosition.X > CameraPosition.X + GameInstance.GraphicsDeviceManager.PreferredBackBufferWidth || o.GlobalPosition.Y + o.Height < CameraPosition.Y || o.GlobalPosition.Y > CameraPosition.Y + GameInstance.GraphicsDeviceManager.PreferredBackBufferHeight))               
                {
                    o.Draw(gameTime, spriteBatch);
                }
            }
        }
    }
}