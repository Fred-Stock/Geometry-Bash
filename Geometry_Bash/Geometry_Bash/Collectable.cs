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

    class Collectable
    {
        BoostType type;
        Color color;


        public Collectable(BoostType type)
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
        }











    }
}
