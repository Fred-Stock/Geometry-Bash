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
    abstract class Player : GameObject 
    {
        protected bool keyUp;      //key bindings
        protected bool keyDown;
        protected bool keyLeft;
        protected bool keyRight;

        protected bool keyAttack1;
        protected bool keyAttack2;

        protected Texture2D sprite;
        protected Rectangle hitBox;

        protected double health;

        

        public Rectangle HitBox
        {
            get { return hitBox; }
        }

        public Player(Texture2D texture,  Rectangle sAP) : base(texture, sAP)
        {
            hitBox = sAP;

        }

        public void Move(KeyboardState keys)
        {

            //create a new temp rectangle to modify the posotion of the player
            Rectangle temp = hitBox;

            keys = Keyboard.GetState();

            if (keys.IsKeyDown(Keys.D))
            {
                temp.X += 5;
            }
            if (keys.IsKeyDown(Keys.A))
            {
                temp.X -= 5;
            }

            if (keys.IsKeyDown(Keys.W))
            {
                temp.Y -= 5;
            }

            if (keys.IsKeyDown(Keys.S))
            {
                temp.Y += 5;
            }
            hitBox = temp;
        }
    }
}
