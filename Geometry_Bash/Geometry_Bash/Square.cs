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
    class Square : Player
    {
        

        private double timer;
        //private FrameCounter frameCounter = new FrameCounter();
        private int[] currentStats;
        private bool attackActive;
        private double attackTime;
        private double cooldownTimer;
        private bool hit;
        private String direction = "";

        int player;

        public Square(int player, Rectangle sAP, Texture2D texture, int windowWidth, int windowHeight, int[] stats) : base(texture, sAP, windowWidth, windowHeight)
        {
            // stats loads in H/D/S
            health = stats[0];
            damage = stats[1];
            moveSpeed = stats[2];
            currentStats = stats;

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

            hit = false;//boolean to prevent exseive hits
          
        }

        public override void Attack(Player player1, Player player2, KeyboardState kbState, GamePadState gpState, int playerNum, double currentTime)
        {
            Square player = (Square)player1;

            Rectangle temp = player1.HitBox;
            Rectangle temp2 = player2.HitBox;

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

                if(gpState.IsButtonDown(attack) && !prevGpState.IsButtonDown(attack))
                {
                    if (player1.MoveLocked == false)
                    {
                        timer = 0;
                        attackActive = true;
                        moveLocked = true;
                        player1.HitBox = temp;
                        //New Movement
                        temp = hitBox;


                        if (gpState.IsButtonDown(right))
                        {
                            direction = "right";
                        }
                        if (gpState.IsButtonDown(left))
                        {
                            direction = "left";
                        }

                        if (gpState.IsButtonDown(up))
                        {
                            direction = "up";
                        }

                        if (gpState.IsButtonDown(down))
                        {
                            direction = "down";
                        }
                    }
                }

            }
            //when attack button is pressed
            if (kbState.IsKeyDown(player.keyAttack1) && !(prevKbState.IsKeyDown(player.keyAttack1)))
            {
                //check if already active
                //no -> attack  yes -> don't do anything
                //attack:
                //Lock movement, activate hitbox, set timer
                //after attack:
                //set regular movement, deactivate hitbox, set cooldown


                if (player1.MoveLocked == false)
                {
                    timer = 0;
                    attackActive = true;
                    moveLocked = true;
                    player1.HitBox = temp;
                    //New Movement
                    temp = hitBox;

                    
                    if (kbState.IsKeyDown(keyRight))
                    {
                        direction = "right";
                    }
                    if (kbState.IsKeyDown(keyLeft))
                    {
                        direction = "left";
                    }

                    if (kbState.IsKeyDown(keyUp))
                    {
                        direction = "up";
                    }

                    if (kbState.IsKeyDown(keyDown))
                    {
                        direction = "down";
                    }

                    

                }
                
            }
                //checks every frame
                if (player1.MoveLocked)
                {
                    if (direction == "right")
                    {
                        temp.X += moveSpeed * 3;
                    }
                    if (direction == "left")
                    {
                        temp.X -= moveSpeed * 3;
                    }

                    if (direction == "up")
                    {
                        temp.Y -= moveSpeed * 3;
                    }

                    if (direction == "down")
                    {
                        temp.Y += moveSpeed * 3;
                    }
                    //player1.HitBox = temp;
                    hitBox = temp;

                    //check for collision with other player
                    if (player1.Collision(player1, player2) && !hit)
                    {
                        player2.Health -= damage; 

                        hit = true;

                        //knockback
                        if (direction == "down")
                            temp2.Y += 80;
                        if (direction == "up")
                            temp2.Y -= 80;
                        if (direction == "right")
                            temp2.X += 80;
                        if (direction == "left")
                            temp2.X -= 80;
                        

                        player2.HitBox = temp2;
                    }
                    timer += 1;
                    timer = Math.Min(timer, 4);
                }
                
                if (timer == 4)
                {
                    player1.MoveLocked = false;
                    direction = "";
                    timer = 0;
                    hit = false;
                }


                prevKbState = kbState;
                prevGpState = gpState;

        }

        // public override void Attack2(Player player1, Player player2, KeyboardState kbstate)
        // {
        //     
        //     Square player = (Square)player1;
        //
        //     bool hit = false;
        //
        //     if (kbstate.IsKeyDown(player.keyAttack2) && !(prevKbState.IsKeyDown(player.keyAttack2)))
        //     {
        //         Rectangle temp = player1.HitBox;
        //         for (int i = 0; i < 300; i++)
        //         player1.Rotation += 1f;
        //
        //     }
        // }

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

        public override void Step(Player player1, Player player2, KeyboardState kbState, double currentTime)
        {
           
        }
    }
}
