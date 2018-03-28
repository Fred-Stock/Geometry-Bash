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
    class Circle : Player
    {


        public Circle(int player, Rectangle sAP, Texture2D texture, int windowWidth, int windowHeight, int[] stats) : base(texture, sAP, windowWidth, windowHeight)
        {
            // stats loads in H/D/S
            health = stats[0];
            moveSpeed = stats[2];


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

        
    }
}
