using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace NightWatch
{
    class Tile
    {
        //Suggested attributes
        private bool passable;
        private bool lockable;
        private bool verticleWall;
        private bool horizontleWall;
        private bool interactable;
        private bool trCorner;
        private bool tlCorner;
        private bool brCorner;
        private bool blCorner;
        private int x;
        private int y;
        private Rectangle box;
        private char id;

        //Properties for such attributes
        #region Properties
        public Rectangle Box
        {
            get { return box; }
            set { box = value; }
        }

        public bool Passable
        {
            get { return passable; }
            set { passable = value; }
        }

        public bool Lockable
        {
            get { return lockable; }
            set { lockable = value; }
        }

        public bool Interactable
        {
            get { return interactable; }
            set { interactable = value; }
        }

        public bool VerticleWall
        {
            get { return verticleWall; }
            set { verticleWall = value; }
        }

        public bool HorizontleWall
        {
            get { return horizontleWall; }
            set { horizontleWall = value; }
        }

        public bool TRCorner
        {
            get { return trCorner; }
            set { trCorner = value; }
        }

        public bool TLCorner
        {
            get { return tlCorner; }
            set { tlCorner = value; }
        }

        public bool BRCorner
        {
            get { return brCorner; }
            set { brCorner = value; }
        }

        public bool BLCorner
        {
            get { return blCorner; }
            set { blCorner = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public char Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        //Constructor sets input to Id and initializes rectangle
        #region Constructor

        public Tile(char input, int xPos, int yPos)
        {
            id = input;
            box = new Rectangle(xPos, yPos, GameVariables.tileSize, GameVariables.tileSize);
            if (id == 'W' || id == 'S' || id == 'b' || id == 'B' || id == 'O' || id == '.' || id == 'D' || id == 'K' || id == 'V' || id == 'v' || id == 'F' || id == 'C' || id == 'R' ||
                    id == 'X' || id == 'L' || id == '<' || id == 'k' || id == '1' || id == '2' || id == '3' || id == 'P' || id == 'p' || id == 'Q' || id == 'N' || id == 'H' || id == 'h'
                    || id == 'n' || id == 'l' || id == 'r' || id == 'e' || id == 'P' || id == 'Z' || id == 'z' || id == 'm' || id == 'M' || id == 'w' || id == 'g' || id == 'G' || id == 'j'
                    || id == 'J' || id == 'y' || id == 'U' || id == 'u')
                passable = false;
            else
                passable = true;
            if (id == 'D' || id == 'B' || id == 'K' || id == 'V' || id == 'v' || id == 'F' || id == 'C' || id == 'R' || id == '1' || id == '2' || id == '3' || id == 'P' || id == 'Z' || id == 'z' || id == 'd')
            {
                interactable = true;
            }
        }

        #endregion
    }
}
