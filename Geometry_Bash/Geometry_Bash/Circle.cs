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

        public Circle(int player, Rectangle sAP, Texture2D texture, int windowWidth, int windowHeight, int[] stats) : base(texture, sAP, windowWidth, windowHeight)
        {
            // stats loads in H/D/S
            health = stats[0];
            damage = stats[1];
            moveSpeed = stats[2];
            hit = false;
            this.player = player;

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
                    

                }
                
                if(player1.HitBox.Intersects(player2.HitBox) && !hit)
                {
                    player2.Health -= damage;
                    hit = true;
                }
                else if(!player1.HitBox.Intersects(player2.HitBox))
                {
                    hit = false;
                }
                
            }
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
            }
            prevKbState = kbState;
            prevGpState = gpState;
        }

        public override void Move(KeyboardState keys, GamePadState gpState)
        {
            //create a new temp rectangle to modify the position of the player
            Rectangle temp = hitBox;

            keys = Keyboard.GetState();


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
                temp.X += moveSpeed;
            }
            if (gpState.IsButtonDown(left))
            {
                temp.X -= moveSpeed;
            }

            if (gpState.IsButtonDown(up))
            {
                temp.Y -= moveSpeed;
            }

            if (gpState.IsButtonDown(down))
            {
                temp.Y += moveSpeed;
            }






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

    }
}
