﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Geometry_Bash
{
    abstract class Player : GameObject
    {


        //add a keyboard state refrence so key presses can be monitored
        protected KeyboardState prevKbState;

        protected Keys keyUp;      //key bindings
        protected Keys keyDown;
        protected Keys keyLeft;
        protected Keys keyRight;

        protected Keys keyAttack1;
        protected Keys keyAttack2;

        protected Texture2D sprite;
        protected Rectangle hitBox;

        protected double health;

        protected int windowWidth;
        protected int windowHeight;
        protected float rotation;
        public double Health
        {
            get { return health; }
            set { health = value; }
        }

        public Rectangle HitBox
        {
            get { return hitBox; }
            set { hitBox = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }

        }

        public Player(Texture2D texture,  Rectangle sAP, int windowWidth, int windowHeight) : base(texture, sAP)
        {
            hitBox = sAP;
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
        }

        

        public void Move(KeyboardState keys)
        {

            //create a new temp rectangle to modify the posotion of the player
            Rectangle temp = hitBox;

            keys = Keyboard.GetState();

            if (keys.IsKeyDown(keyRight))
            {
                temp.X += 5;
            }
            if (keys.IsKeyDown(keyLeft))
            {
                temp.X -= 5;
            }

            if (keys.IsKeyDown(keyUp))
            {
                temp.Y -= 5;
            }

            if (keys.IsKeyDown(keyDown))
            {
                temp.Y += 5;
            }
            hitBox = temp;
        }

        //method to check collision of players
        public bool Collision(Player player1, Player player2)
        {
            //check if object1's x collides with object2's
            if (player1.HitBox.X + player1.HitBox.Width > player2.HitBox.X &&
               player1.HitBox.X < player2.HitBox.X + player2.HitBox.Width)
            {
                //check if object1's y collided with object2's
                if (player1.HitBox.Y + player1.HitBox.Height > player2.HitBox.Y &&
                   player1.HitBox.Y < player2.HitBox.Y + player2.HitBox.Height)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public virtual void Attack(Player player1, Player player2, KeyboardState kbState)
        {
           
            if (kbState.IsKeyDown(player1.keyAttack1) && prevKbState.IsKeyUp(player1.keyAttack1))
            {
                if(player1.Collision(player1, player2))
                {
                    
                    player2.health--;
                }
            }

            prevKbState = kbState;
        }

        public virtual void Attack2(Player player1, Player player2, KeyboardState kbState)
        {

            if (kbState.IsKeyDown(player1.keyAttack2) && prevKbState.IsKeyUp(player1.keyAttack2))
            {
                if (player1.Collision(player1, player2))
                {

                    player2.health--;
                }
            }

            prevKbState = kbState;
        }


        public void OutsideCollision(Player player)
        {
            Rectangle temp = player.HitBox;
            if (player.HitBox.X > windowWidth - player.HitBox.Width)
            {
                temp.X -= 4;
                player.HitBox = temp;
            }
            if(player.HitBox.Y > windowHeight - player.HitBox.Height)
            {
                temp.Y -= 4;
                player.HitBox = temp;
            }
            if (player.HitBox.X < 0)
            {
                temp.X += 4;
                player.HitBox = temp;
            }
            if (player.HitBox.Y < 0)
            {
                temp.Y += 4;
                player.HitBox = temp;
            }
        }
        
    }
}
