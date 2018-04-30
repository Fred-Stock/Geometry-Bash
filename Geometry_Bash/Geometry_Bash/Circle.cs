using System;
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
    class Circle : Player
    {
        //boolean to control double hitting
        bool hit;
        int player;
        int attackSpd;
        bool attacking;
        public Circle(int player, Rectangle sAP, Texture2D texture, int windowWidth, int windowHeight, int[] stats) : base(texture, sAP, windowWidth, windowHeight)
        {
            // stats loads in H/D/S
            health = stats[0];
            damage = stats[1];
            moveSpeed = stats[2]; 
            hit = false;
            this.player = player;
            attackSpd = (int)stats[2]/2; 
            attacking = false;
            //check if it is player one or two and then set the correct keybindings
            if (player == 1)
            {
                keyUp = Keys.W;
                keyDown = Keys.S;
                keyLeft = Keys.A;
                keyRight = Keys.D;

                keyAttack1 = Keys.Q;
                keyAttack2 = Keys.E;

                down = Buttons.DPadDown;
                up = Buttons.DPadUp;
                left = Buttons.DPadLeft;
                right = Buttons.DPadRight;

                attack = Buttons.X;
            }

            if (player == 2)
            {
                keyUp = Keys.I;
                keyDown = Keys.K;
                keyLeft = Keys.J;
                keyRight = Keys.L;

                keyAttack1 = Keys.U;
                keyAttack2 = Keys.O;

                down = Buttons.DPadDown;
                up = Buttons.DPadUp;
                left = Buttons.DPadLeft;
                right = Buttons.DPadRight;

                attack = Buttons.X;
            }

        }


        public override void Attack(Player player1, Player player2, KeyboardState kbState, GamePadState gpState, int playerNum, double currenttime)
        {
            Circle player =  (Circle)player1;

            if (kbState.IsKeyDown(player.keyAttack1))
            {

                if (!prevKbState.IsKeyDown(player.keyAttack1))
                {
                    hit = false;
                    attacking = true;
                }

                if (player1.HitBox.Intersects(player2.HitBox) && !hit)
                {
                    player2.Health -= damage;
                    hit = true;
                }
                else if (!player1.HitBox.Intersects(player2.HitBox))
                {
                    hit = false;
                }

            }
            else attacking = false;
             
            if ((GamePad.GetState(PlayerIndex.One).IsConnected || GamePad.GetState(PlayerIndex.Two).IsConnected))
            {
                //check which player has a controller connected
                if (GamePad.GetState(PlayerIndex.One).IsConnected && playerNum == 1)
                {
                    gpState = GamePad.GetState(PlayerIndex.One);
                }
                if (GamePad.GetState(PlayerIndex.Two).IsConnected && playerNum == 2)
                {
                    gpState = GamePad.GetState(PlayerIndex.Two);
                }
                if (gpState.IsButtonDown(attack))
                {
                    attacking = true;
                    if (!prevGpState.IsButtonDown(attack))
                    {
                        hit = false;

                    }

                    if (player1.HitBox.Intersects(player2.HitBox) && !hit)
                    {
                        player2.Health -= damage;
                        hit = true;
                    }
                    else if (!player1.HitBox.Intersects(player2.HitBox))
                    {
                        hit = false;
                    }
                }
                else { attacking = false; }
            }
            prevKbState = kbState;
            prevGpState = gpState;
        }

        public override void Move(KeyboardState keys, GamePadState gpState)
        {
            //create a new temp rectangle to modify the position of the player
            Rectangle temp = hitBox;

            keys = Keyboard.GetState();
            int tempMoveSpeed;
            if (attacking)
            {
                tempMoveSpeed = attackSpd;
            }
            else
                tempMoveSpeed = moveSpeed;

            //check if a controller is connected 
            if ((GamePad.GetState(PlayerIndex.One).IsConnected || GamePad.GetState(PlayerIndex.Two).IsConnected))
            {
                //check which player has a controller connected
                if (GamePad.GetState(PlayerIndex.One).IsConnected && player == 1)
                {
                    gpState = GamePad.GetState(PlayerIndex.One);
                }
                if (GamePad.GetState(PlayerIndex.Two).IsConnected && player == 2)
                {
                    gpState = GamePad.GetState(PlayerIndex.Two);
                }
            }



            if (gpState.IsButtonDown(right))
            {
                temp.X += tempMoveSpeed;
            }
            if (gpState.IsButtonDown(left))
            {
                temp.X -= tempMoveSpeed;
            }

            if (gpState.IsButtonDown(up))
            {
                temp.Y -= tempMoveSpeed;
            }

            if (gpState.IsButtonDown(down))
            {
                temp.Y += tempMoveSpeed;
            }






            if (keys.IsKeyDown(keyRight))
            {
                temp.X += tempMoveSpeed;
            }
            if (keys.IsKeyDown(keyLeft))
            {
                temp.X -= tempMoveSpeed;
            }

            if (keys.IsKeyDown(keyUp))
            {
                temp.Y -= tempMoveSpeed;
            }

            if (keys.IsKeyDown(keyDown))
            {
                temp.Y += tempMoveSpeed;
            }
            hitBox = temp;
        }

    }
}
