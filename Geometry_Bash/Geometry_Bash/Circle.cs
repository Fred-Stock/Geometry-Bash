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


        public Circle(int player, Rectangle sAP, Texture2D texture, int windowWidth, int windowHeight, int[] stats) : base(texture, sAP, windowWidth, windowHeight)
        {
            // stats loads in H/D/S
            health = stats[0];
            damage = stats[1];
            moveSpeed = stats[2];
            hit = false;

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


        public override void Attack(Player player1, Player player2, KeyboardState kbState, double currenttime)
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

            prevKbState = kbState;
        }
        
    }
}
