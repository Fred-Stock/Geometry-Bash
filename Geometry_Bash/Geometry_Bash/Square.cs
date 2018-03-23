using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Geometry_Bash
{
    class Square : Player
    {
        

        double timer = 0;

        public Square(int player, Rectangle sAP, Texture2D texture, int windowWidth, int windowHeight) : base(texture, sAP, windowWidth, windowHeight)
        {
            //set movespeed
            moveSpeed = 5;
            //set health
            health = 10;


            //check if it is player one or two and then set the correct keybindings
            if (player == 1)
            {
                keyUp = Keys.W;
                keyDown = Keys.S;
                keyLeft = Keys.A;
                keyRight = Keys.D;
                
                keyAttack1 = Keys.Q;
                keyAttack2 = Keys.E;

            }

           if (player == 2)
           {
                keyUp = Keys.I;
                keyDown = Keys.K;
                keyLeft = Keys.J;
                keyRight = Keys.L;

                keyAttack1 = Keys.U;
                keyAttack2 = Keys.O;
           }

          
        }

        public override void Attack(Player player1, Player player2, KeyboardState kbState)
        {
            Square player = (Square)player1;
            bool hit = false;//boolean to prevent exseive hits




            if (kbState.IsKeyDown(player.keyAttack1) && !(prevKbState.IsKeyDown(player.keyAttack1)))
            {
                Rectangle temp = player1.HitBox;
                Rectangle temp2 = player2.HitBox;

                if (kbState.IsKeyDown(player.keyRight))
                {
                    temp.X += 75;
                    player1.HitBox = temp;

                    if (player1.Collision(player1, player2) && !hit)
                    {
                        player2.Health -= 3;

                        hit = true;

                        //knockback
                        temp2.X += 150;
                        player2.HitBox = temp2;
                    }
                }
            
                if (kbState.IsKeyDown(player.keyLeft))
                {
                    temp.X -= 75;
                    player1.HitBox = temp;

                    if (player1.Collision(player1, player2) && !hit)
                    {
                        player2.Health -= 3;

                        hit = true;

                        //knockback
                        temp2.X -= 150;
                        player2.HitBox = temp2;
                    }
                }
                if (kbState.IsKeyDown(player.keyUp))
                {
                    temp.Y -= 75;
                    player1.HitBox = temp;

                    if (player1.Collision(player1, player2) && !hit)
                    {
                        player2.Health -= 3;

                        hit = true;

                        //knockback
                        temp2.Y -= 150;
                        player2.HitBox = temp2;
                    }
                }
                if (kbState.IsKeyDown(player.keyDown))
                {
                    temp.Y += 75;
                    player1.HitBox = temp;

                    if (player1.Collision(player1, player2) && !hit)
                    {
                        player2.Health -= 3;

                        hit = true;

                        //knockback
                        temp2.Y += 150;
                        player2.HitBox = temp2;
                    }
                }



                

                
            }

            prevKbState = kbState;
        }

        public override void Attack2(Player player1, Player player2, KeyboardState kbstate)
        {
            
            Square player = (Square)player1;

            bool hit = false;

            if (kbstate.IsKeyDown(player.keyAttack2) && !(prevKbState.IsKeyDown(player.keyAttack2)))
            {
                Rectangle temp = player1.HitBox;
                for (int i = 0; i < 300; i ++)
                player1.Rotation += 6;

            }
        }
    }
}
