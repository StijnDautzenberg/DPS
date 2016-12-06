﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class Object : ILoopObject
    {
        private string _id;
        private bool _visible;
        private bool _canCollide;
        private ObjectList _parent;
        private Vector2 _position;
        private Vector2 _velocity;
        private Rectangle _boundingBox;

        public string Id
        {
            get { return _id; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public bool CanCollide
        {
            get { return _canCollide; }
            set
            {
                _canCollide = value;
                if(_parent is Map)
                {
                    Map m = _parent as Map;
                    m.UpdateCollisionMap(this);
                }
            }
        }

        public ObjectList Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Rectangle BoundingBox
        {
            get { return _boundingBox; }
            set { _boundingBox = value; }
        }

        public int Width
        {
            get { return BoundingBox.Width; }
        }

        public int Height
        {
            get { return BoundingBox.Height; }
        }

        public Object(string id)
        {
            _id = id;
            _position = Vector2.Zero;
            _velocity = Vector2.Zero;
            _visible = true;
            _canCollide = false;
            _boundingBox = new Rectangle((int)Position.X, (int)Position.Y, 0, 0);
        }

        public virtual void Update(GameTime gameTime)
        {
            Position += Velocity;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public virtual void Reset()
        {

        }
    }
}