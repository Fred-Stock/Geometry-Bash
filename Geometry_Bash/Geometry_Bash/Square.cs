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
    class Square //: Player
    {
        
        public Square(int player, Texture2D texture)
        {
            if (player == 1)
            {
                keyUp = Keyboard.GetState().IsKeyDown(Keys.W);
                keyDown = Keyboard.GetState().IsKeyDown(Keys.S);
                keyLeft = Keyboard.GetState().IsKeyDown(Keys.A);
                keyRight = Keyboard.GetState().IsKeyDown(Keys.D);

                keyAttack1 = Keyboard.GetState().IsKeyDown(Keys.Q);
                keyAttack2 = Keyboard.GetState().IsKeyDown(Keys.E);

                sprite = 
                
            }

            //keyAttack1 = Keyboard.GetState().IsKeyDown()
        }


    }
}
