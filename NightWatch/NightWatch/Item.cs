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
    class Item
    {
        //Suggested attributes
        private bool collectible;
        private bool isKey;
        private bool isPickedUp;
        private string name;
        private string description;
        private int x;
        private int y;
        private int height = GameVariables.tileSize;
        private int length = GameVariables.tileSize;
        private Rectangle box;
        private Texture2D itemPicture;
        private String imgName;
        private int imgIndex;
        private Room roomItIsIn;

        #region Properties

        public bool Collectible
        {
            get { return collectible; }
            set { collectible = value; }
        }

        public bool IsKey
        {
            get { return isKey; }
            set { isKey = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public Rectangle Box
        {
            get { return box; }
            set { box = value; }
        }

        public int X
        {
            get { return x; }
            set
            {
                x = value;
                box.X = value;
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                box.Y = value;
            }
        }

        public int pHeight
        {
            get { return height; }
            set { height = value; }
        }

        public int pLength
        {
            get { return length; }
            set { length = value; }
        }


        public Boolean pItemIsPickedUp
        {
            get { return isPickedUp; }
            set { isPickedUp = value; }
        }

        public int ImgIndex
        {
            get { return imgIndex; }
            set { imgIndex = value; }
        }

        public String ImgName
        {
            get { return imgName; }
            set { imgName = value; }
        }
        public Room RoomItIsIn
        {
            get { return roomItIsIn; }
            set { roomItIsIn = value; }
        }
        #endregion

        public Item(string itemName, int x, int y, int index, Room currentRoom)
        {
            collectible = true;
            isPickedUp = false;
            this.name = itemName;
            box = new Rectangle(5, 5, GameVariables.tileSize, GameVariables.tileSize);
            box.X = x;
            box.Y = y;
            imgIndex = index;
            roomItIsIn = currentRoom;
        }

        public Item Comparator(string itemName)
        {
            return new Item(itemName, 0, 0, 0, null);
        }
    }
}
