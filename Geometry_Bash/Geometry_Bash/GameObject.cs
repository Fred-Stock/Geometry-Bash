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
    class GameObject   //Inherited by Player, Enemy, Collectable
    {
      protected Texture2D texture;
      protected Rectangle sizeAndPosition;


        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }


        public GameObject(Texture2D texture, Rectangle sAP)
        {
            this.texture = texture;
            sizeAndPosition = sAP;
        }
    }
}
