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
        protected Keys keyUp;      //key bindings
        protected Keys keyDown;
        protected Keys keyLeft;
        protected Keys keyRight;

        protected Keys keyAttack1;
        protected Keys keyAttack2;

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

            if (keys.IsKeyDown(keyRight))
            {
                temp.X += 5;
            }
            if (keys.IsKeyDown(keyLeft))
            {
                temp.X -= 5;
            }

            if (keys.IsKeyDown(keyUp))
            {
                temp.Y -= 5;
            }

            if (keys.IsKeyDown(keyDown))
            {
                temp.Y += 5;
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

    }
}
