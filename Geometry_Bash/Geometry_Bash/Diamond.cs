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

        




        public Diamond(int player, Rectangle sAP, Texture2D texture, int windowWidth, int windowHeight, int[] stats) : base(texture, sAP, windowWidth, windowHeight)
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
        public override void Attack(Player player1, Player player2, KeyboardState kbState, double currentTime)
        {

            proj1 = new Projectile(5, 5, 5, 0);

            //proj1.HitBox.X = player1.HitBox.X + player1.HitBox.Width / 2;
            Diamond player = (Diamond)player1;

            if (kbState.IsKeyDown(player.keyAttack1) || !(prevKbState.IsKeyDown(player.keyAttack1)))
            {
                proj1.Active = true;
                proj1.Move();
            }

            if(proj1.Active && proj1.HitBox.Intersects(player2.HitBox))
            {
                player2.Health -= proj1.Damage;
            }

            prevKbState = kbState;

        }
    }
}
