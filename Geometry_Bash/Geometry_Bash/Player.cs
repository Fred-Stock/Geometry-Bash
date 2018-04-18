﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

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

        protected int moveSpeed;

        protected Projectile proj1;

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

        public Projectile Proj1
        {
            get { return proj1; }
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
                temp.X += moveSpeed;
            }
            if (keys.IsKeyDown(keyLeft))
            {
                temp.X -= moveSpeed;
            }

            if (keys.IsKeyDown(keyUp))
            {
                temp.Y -= moveSpeed;
            }

            if (keys.IsKeyDown(keyDown))
            {
                temp.Y += moveSpeed;
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


        public virtual void Attack(Player player1, Player player2, KeyboardState kbState, double currentTime)
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
        /// <summary>
        /// method to handle a player colliding with the wall of the object
        /// </summary>
        /// <param name="player"></param>
        /// <param name="direction">integer value for which directiong the wall is from the player 0 - 3,
        /// 0 being up, 1 being right, 2 being below, 3 being left </param>
        public void WallCollision(Player player, int direction)
        {
            Rectangle temp = player.HitBox;

            if(direction == 0)
            {                                                //     0
                temp.Y -= 1;                                 //   3   1
            }                                                //     2
            if (direction == 1)
            {
                temp.X -= 1;
            }
            if (direction == 2)
            {
                temp.Y += 1;
            }
            if (direction == 3)
            {
                temp.X += 1;
            }
            player.HitBox = temp;
        }

        public virtual void Step(Player player1, Player player2, KeyboardState kbState, double currentTime)
        {
            return;
        }
        
    }
}
