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
    enum BoostType
    {
        health,
        meter,
        attack,
        speed
    }

    class Collectable : GameObject
    {
        BoostType type;
        Color color;
        bool pickedUp;

        public Color Color
        {
            get { return color; }
        }


        public Collectable(BoostType type, Texture2D texture, Rectangle sAP) : base(texture, sAP)
        {
            switch (type)
            {
                case BoostType.attack:
                    color = Color.Red;
                    break;
                case BoostType.health:
                    color = Color.Yellow;
                    break;
                case BoostType.meter:
                    color = Color.Blue;
                    break;
                case BoostType.speed:
                    color = Color.Green;
                    break;

            }
            pickedUp = false;
        }

        public bool PickedUp(Player player)
        {
            if (player.HitBox.Intersects(sizeAndPosition))
            {
                switch (type)
                {
                    case BoostType.health:
                        if(player.Health < 10)
                        {
                           if(player.Health == 9 || player.Health == 8)
                            {
                                player.Health = 10;
                            }
                            else
                            {
                                player.Health += 3;
                            }
                        }
                        break;

                }
                pickedUp = true;
            }
            return pickedUp;
        }











    }
}
