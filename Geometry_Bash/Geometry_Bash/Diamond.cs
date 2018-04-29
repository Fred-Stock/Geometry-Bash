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
    class Diamond : Player
    {


        Random rng;
        int count;
        int player;

        public Diamond(int player, Rectangle sAP, Texture2D texture, int windowWidth, int windowHeight, int[] stats) : base(texture, sAP, windowWidth, windowHeight)
        {
            // stats loads in H/D/S
            health = stats[0];
            damage = stats[1];
            moveSpeed = stats[2];
            
            //initilize the list and count variable
            projList = new List<Projectile>();
            count = 2;
            this.player = player;

            rng = new Random();
            //check if it is player one or two and then set the correct keybindings
            if (player == 1)
            {
               


                keyUp = Keys.W;
                keyDown = Keys.S;
                keyLeft = Keys.A;
                keyRight = Keys.D;
                up = Buttons.DPadUp;

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
                up = Buttons.A;

                keyAttack1 = Keys.U;
                keyAttack2 = Keys.O;

                down = Buttons.DPadDown;
                up = Buttons.DPadUp;
                left = Buttons.DPadLeft;
                right = Buttons.DPadRight;

                attack = Buttons.X;
            }
        }
        public override void Attack(Player player1, Player player2, KeyboardState kbState, GamePadState gpState, int playerNum, double currentTime)
        {
            
            
            //proj1.HitBox.X = player1.HitBox.X + player1.HitBox.Width / 2;
            Diamond player = (Diamond)player1;

            
            //attack method
            if (kbState.IsKeyDown(player.keyAttack1) && !(prevKbState.IsKeyDown(player.keyAttack1)))
            {
                //shoot a projectile in the direction the player is moving if stationary just send it in a random direction

                //conditional to limit the amount of projectiles to four 
                //if(projList.Count >= 8)
                //{
                //    projList.Clear();
                //    for(int i = 0; i < 8; i++)
                //    {
                //        projList.Add(new Projectile(7, 5, 3, i));
                //        projList[i].HitBox = new Rectangle(player1.HitBox.X - player1.HitBox.Width/4 - 4, player1.HitBox.Y - player1.HitBox.Height / 2,
                //                    player1.HitBox.Width/2, player1.HitBox.Height/2);
                //    }
                //}
                //else
                //{
                //    for (int i = 0; i < 8; i++)
                //    {
                //        projList.Add(new Projectile(7, 5, 3, i));
                //        projList[i].HitBox = new Rectangle(player1.HitBox.X - player1.HitBox.Width / 4 - 4, player1.HitBox.Y - player1.HitBox.Height / 2,
                //                    player1.HitBox.Width/2, player1.HitBox.Height/2);
                //    }
                //}
                if (count > 1)
                {

                    Projectile proj;
                    if (kbState.IsKeyDown(keyRight))
                    {
                        proj = (new Projectile(7, 0));
                        count = 0;
                    }
                    else if (kbState.IsKeyDown(keyDown))
                    {
                        proj = (new Projectile(7, 1));
                        count = 0;
                    }
                    else if (kbState.IsKeyDown(keyLeft))
                    {
                        proj = (new Projectile(7, 2));
                        count = 0;
                    }
                    else if (kbState.IsKeyDown(keyUp))
                    {
                        proj = (new Projectile(7, 3));
                        count = 0;
                    }
                    else
                    {
                        proj = (new Projectile(7, rng.Next(0, 4)));
                        count = 0;
                    }
                    //if(projList.Count >= 2)
                    //{
                    //    projList.RemoveAt(0);
                    //}
                    proj.HitBox = new Rectangle(player1.HitBox.X + player1.HitBox.Width / 4, player1.HitBox.Y + player1.HitBox.Height / 4,
                                            player1.HitBox.Width/2, player1.HitBox.Height/2);
                    projList.Add(proj);

                }

                
                count++;
            }


            //controller
                //shoot a projectile in the direction the player is moving if stationary just send it in a random direction

                //conditional to limit the amount of projectiles to four 
                //if(projList.Count >= 8)
                //{
                //    projList.Clear();
                //    for(int i = 0; i < 8; i++)
                //    {
                //        projList.Add(new Projectile(7, 5, 3, i));
                //        projList[i].HitBox = new Rectangle(player1.HitBox.X - player1.HitBox.Width/4 - 4, player1.HitBox.Y - player1.HitBox.Height / 2,
                //                    player1.HitBox.Width/2, player1.HitBox.Height/2);
                //    }
                //}
                //else
                //{
                //    for (int i = 0; i < 8; i++)
                //    {
                //        projList.Add(new Projectile(7, 5, 3, i));
                //        projList[i].HitBox = new Rectangle(player1.HitBox.X - player1.HitBox.Width / 4 - 4, player1.HitBox.Y - player1.HitBox.Height / 2,
                //                    player1.HitBox.Width/2, player1.HitBox.Height/2);
                //    }
                //}
            
            //check if a controller is connected 
           
           
                if ((GamePad.GetState(PlayerIndex.One).IsConnected || GamePad.GetState(PlayerIndex.Two).IsConnected))
                {
                    //check which player has a controller connected
                    if(GamePad.GetState(PlayerIndex.One).IsConnected && playerNum == 1)
                    {
                        gpState = GamePad.GetState(PlayerIndex.One);
                    }
                    if (GamePad.GetState(PlayerIndex.Two).IsConnected && playerNum == 2)
                    {
                        gpState = GamePad.GetState(PlayerIndex.Two);
                    }

                    if (gpState.IsButtonDown(attack) && !(prevGpState.IsButtonDown(attack)))
                    {
                        if (count > 1)
                        {

                            Projectile proj;
                            if (gpState.IsButtonDown(right))
                            {
                                proj = (new Projectile(7, 0));
                                count = 0;
                            }
                            else if (gpState.IsButtonDown(down))
                            {
                                proj = (new Projectile(7, 1));
                                count = 0;
                            }
                            else if (gpState.IsButtonDown(left))
                            {
                                proj = (new Projectile(7, 2));
                                count = 0;
                            }
                            else if (gpState.IsButtonDown(up))
                            {
                                proj = (new Projectile(7, 3));
                                count = 0;
                            }
                            else
                            {
                                proj = (new Projectile(7, rng.Next(0, 4)));
                                count = 0;
                            }
                            //if(projList.Count >= 2)
                            //{
                            //    projList.RemoveAt(0);
                            //}
                            proj.HitBox = new Rectangle(player1.HitBox.X + player1.HitBox.Width / 4, player1.HitBox.Y + player1.HitBox.Height / 4,
                                                    player1.HitBox.Width / 2, player1.HitBox.Height / 2);
                            projList.Add(proj);

                        }

                        count++;
                    }
                    
                }
            


            for (int i = 0; i < projList.Count(); i++)
            {
                Projectile temp = projList[i];
            
                if(temp.Active && temp.HitBox.Intersects(player2.HitBox))
                {
                    projList[i].Active = false;
                    player2.Health -= damage;
                    projList.RemoveAt(i);
                }

            }
            prevGpState = gpState;
            prevKbState = kbState;
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
