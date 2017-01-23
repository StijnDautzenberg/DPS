﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Engine
{
    class Weapon : TexturedObject
    {
        private int _damage;
        private Character _owner;

        public int Damage
        {
            set { _damage = value; }
        }

        public Weapon(string id, Object parent, SpriteSheet spriteSheet, Character owner, int damage) : base(id, parent, spriteSheet)
        {
            _damage = damage;
            _owner = owner;
            CanCollide = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //as long as object doesnt move, make sure it is positioned according to its owner position
        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            if (collider != _owner && collider is Character)
            {
                DealDamage(collider as Character);
            }
            if (collider != _owner && collider is DestructableObject)
            {
                DealDamage(collider as DestructableObject);
            }
        }

        protected void DealDamage(Character character)
        {
            //deal damage
            character.Health -= _damage;
            //if its health < 0, remove it cause it is death
            if (character.Health <= 0)
            {
                character.Death = true;
            }

            //get vector from player to character
            int x = 200;
            if(World.Player.GlobalPosition.X - character.GlobalPosition.X > 0)
            {
                x = -x;
            }
            character.Velocity += new Vector2(x, -100);
        }

        protected void DealDamage(DestructableObject block)
        {
            block.Visible = false;
            block.CanCollide = false;
            World.Remove(block);
        }
    }
}