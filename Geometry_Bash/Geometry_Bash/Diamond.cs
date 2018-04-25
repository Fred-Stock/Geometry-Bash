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




        public Diamond(int player, Rectangle sAP, Texture2D texture, int windowWidth, int windowHeight, int[] stats) : base(texture, sAP, windowWidth, windowHeight)
        {
            // stats loads in H/D/S
            health = stats[0];
            moveSpeed = stats[2];

            rng = new Random();

            projList = new List<Projectile>();
            
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
        public override void Attack(Player player1, Player player2, KeyboardState kbState, double currentTime)
        {
            

            //proj1.HitBox.X = player1.HitBox.X + player1.HitBox.Width / 2;
            Diamond player = (Diamond)player1;

            //attack method
            if (kbState.IsKeyDown(player.keyAttack1) && !(prevKbState.IsKeyDown(player.keyAttack1)))
            {
                Projectile proj = new Projectile(7, 5, 5, rng.Next(0,4));
                //shoot a projectile in the direction the player is moving if stationary just send it in a random direction
                if (kbState.IsKeyDown(keyRight))
                {
                    proj = new Projectile(7, 5, 5, 1);
                }
                else if (kbState.IsKeyDown(keyLeft))
                {
                    proj = new Projectile(7, 5, 5, 3);
                }

                else if (kbState.IsKeyDown(keyUp))
                {
                    proj = new Projectile(7, 5, 5, 0);
                }

                else if (kbState.IsKeyDown(keyDown))
                {
                    proj = new Projectile(7, 5, 5, 2);
                }
               
                proj.Active = true;
                proj.HitBox = new Rectangle(player1.HitBox.X - player1.HitBox.Width/4 - 4, player1.HitBox.Y - player1.HitBox.Height / 2,
                                player1.HitBox.Width, player1.HitBox.Height);
                //conditional to limit the amount of projectiles to four 
                if(projList.Count >= 4)
                {
                    projList.RemoveAt(0);
                    projList.Add(proj);
                }
                else
                {
                    projList.Add(proj);
                }

            }

            for(int i = 0; i < projList.Count(); i++)
            {
                Projectile temp = projList[i];
            
                    if(temp.Active && temp.HitBox.Intersects(player2.HitBox))
                    {
                        player2.Health -= temp.Damage;
                        projList.RemoveAt(i);
                    }
                if( i < projList.Count)
                {
                    if(projList[i] != null)
                    {
                        projList[i] = temp; 
                    }

                }
            }
            //if (proj1.Active)
            //{
                //proj1.Move();
            //}


            prevKbState = kbState;

        }
    }
}
