﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class SpriteSheet
    {
        private Dictionary<string, Sprite> _sprites;
        private Texture2D _spriteSheet;
        private Sprite _sprite;
        private int _currentFrame, _elapsedTime, _maxIndex;
        private bool _isAnimated, _mirrored, _canUpdate;

        public struct Sprite
        {
            public string name;
            public int index, frames, frameTime, frameWidth, width;
            public bool loop;

            public Sprite(string Name, int Index, int Frames, int FrameTime, int Width, int Height, bool Loop)
            {
                name = Name;
                index = Index;
                frames = Frames;
                frameTime = FrameTime;
                width = Width;
                frameWidth = Width / frames;
                loop = Loop;
            }
        }

        protected Sprite CurrentSprite
        {
            get { return _sprite; }
        }

        public bool IsAnimated
        {
            get { return _isAnimated; }
            set { _isAnimated = value; }
        }

        public bool Mirrored
        {
            get { return _mirrored; }
            set { _mirrored = value; }
        }

        protected int CurrentFrame
        {
            set { _currentFrame = value; }
        }

        protected Texture2D spriteSheet
        {
            get { return _spriteSheet; }
        }

        public int Width
        {
            get { return _spriteSheet.Width; }
        }

        public int Height
        {
            get { return _spriteSheet.Height; }
        }

        protected bool CanUpdate
        {
            set { _canUpdate = value; }
        }

        public SpriteSheet(string assetName)
        {
            _spriteSheet = GameInstance.AssetManager.GetTexture(assetName);
            _canUpdate = true;
            _maxIndex = 1;
            _sprites = new Dictionary<string, Sprite>();
        }

        protected void Add(string id, int index, int frames, int frameTime, int width, bool loop)
        {
            _sprites.Add(id, new Sprite(id, index, frames, frameTime, width, _spriteSheet.Height, loop));
            _maxIndex = _sprites.Count;
        }

        public virtual void Update(GameTime gameTime, Object obj)
        {
            if(IsAnimated)
            {
                UpdateAnimation(gameTime.ElapsedGameTime.Milliseconds, obj);
                if (_canUpdate)
                {
                    if (obj is Player)
                    {
                        if ((obj as Player).InAir)
                        {
                            int x = 0;
                        }
                    }
                    string anim = UpdateAnimationState(obj);
                    if(anim != CurrentSprite.name)
                    {
                        SwitchTo(anim);
                    }
                }
            }
        }

        private void UpdateAnimation(int elapsedTime, Object obj)
        {
            _elapsedTime += elapsedTime;
            if (_elapsedTime > _sprite.frameTime)
            {
                _currentFrame++;
                _elapsedTime = 0;
                if (_currentFrame > _sprite.frames - 1)
                {
                    AfterLastFrame(obj);
                    _currentFrame = 0;
                }
            }
        }

        protected virtual string UpdateAnimationState(Object o)
        {
            return "";
        }
       
        protected virtual void SwitchTo(string id)
        {
            if (CurrentSprite.name != id)
            {
                _sprite = _sprites[id];
                _currentFrame = 0;
                _canUpdate = CurrentSprite.loop;
                _elapsedTime = 0;
            }
        }

        protected virtual void AfterLastFrame(Object obj)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            SpriteEffects effect = SpriteEffects.None;
            if(_mirrored)
            {
                //drawFrame = (_frames - _currentFrame - 1) * Width;
                effect = SpriteEffects.FlipHorizontally;
            }
            if (IsAnimated)
            {
                spriteBatch.Draw(_spriteSheet, position, new Rectangle(_currentFrame * CurrentSprite.frameWidth, CurrentSprite.index * (Height / _maxIndex), _sprite.frameWidth, Height / _maxIndex), Color.White, 0, Vector2.Zero, 1, effect, 0);
            }
            else
            {
                spriteBatch.Draw(_spriteSheet, position);
            }
        }
    }
}