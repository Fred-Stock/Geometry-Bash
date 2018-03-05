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


    }
}
