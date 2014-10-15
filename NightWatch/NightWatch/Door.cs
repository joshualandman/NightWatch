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
    class Door : Tile
    {
        //Attributes
        private Room current;
        private Room next;
        private String nextName;
        private String doorLocation;
        private int nextDoor;
        private int newX;
        private int newY;
        private int doorId;
        private bool locked;

        //Constructor
        #region Constructor
        public Door(char input, int xPos, int yPos, Room currentRoom, int id, String nextRoomName, int nextDoorId, string doorPlace) :base(input, xPos, yPos)
        {
            current = currentRoom;
            doorId = id;
            nextName = nextRoomName;
            nextDoor = nextDoorId;
            doorLocation = doorPlace;
            locked = false;
            
        }
        #endregion

        //SetNextRoom must be called after all rooms are created(not null values)
        #region SetNextRoom
        public void SetNextRoom()
        {
            next = current.World.GetRoom(nextName);
            CalculateNewPosition();
        }
        #endregion

        //Properties
        #region Properties
        public Room Current
        {
            get { return current; }
            set { current = value; }
        }

        public Room Next
        {
            get { return next; }
            set { next = value; }
        }

        public String NextName
        {
            get { return nextName; }
            set { nextName = value; }
        }

        public String DoorLocation
        {
            get { return doorLocation; }
            set { doorLocation = value; }
        }

        public int NextDoor
        {
            get { return nextDoor; }
            set { nextDoor = value; }
        }

        public int NewX
        {
            get { return newX; }
            set { newX = value; }
        }

        public int NewY
        {
            get { return newY; }
            set { newY = value; }
        }

        public int DoorId
        {
            get { return doorId; }
            set { doorId = value; }
        }

        public bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }
        #endregion

        //CalculateNewPosition looks at the doorLocation variable and sets the new x and y position for the player at these places
        #region CalculateNewPosition
        private void CalculateNewPosition()
        {
            Door nextRoomDoor = next.GetDoorByIndex(nextDoor);

            if (nextRoomDoor.DoorLocation == "top")
            {
                newX = Box.X;
                newY = Box.Y - GameVariables.tileSize;
            }
            else if (nextRoomDoor.DoorLocation == "left")
            {
                newX = Box.X - GameVariables.tileSize;
                newY = Box.Y;
            }
            else if (nextRoomDoor.DoorLocation == "right")
            {
                newX = Box.X + GameVariables.tileSize;
                newY = Box.Y;
            }
            else
            {
                newX = Box.X;
                newY = Box.Y + GameVariables.tileSize;
            }
        }
        #endregion
    }
}
