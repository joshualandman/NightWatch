using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NightWatch
{
    class Room
    {
        //Suggested attributes
        private bool timed;
        private List<Item> containedItems;
        private string name;
        private String[] floorPlan;
        private Door[] doorArray;
        private Tile[,] floor;
        private String[] doors;
        private Mansion world;


        #region Properties

        //Properties for attributes
        public Mansion World
        {
            get { return world; }
            set { world = value; }
        }

        public bool Timed
        {
            get { return timed; }
            set { timed = value; }
        }

        public List<Item> ContainedItems
        {
            get { return containedItems; }
            set { containedItems = value; }
        }

        public Tile[,] Tiles
        {
            get { return floor; }
            set { floor = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String[] FloorPlan
        {
            get { return floorPlan; }
            set { floorPlan = value; }
        }

        public String[] Doors
        {
            get { return doors; }
            set
            {
                doors = value;
                doorArray = new Door[value.Length];
            }
        }

        public Tile[,] Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        public Door[] DoorArray
        {
            get
            {
                if (doorArray != null)
                    return doorArray;
                else return null;
            }
        }
        #endregion

        #region AddItemToList

        //Method to add single items to list of contained items
        public void AddItemToList(Item item)
        {
            containedItems.Add(item);
        }
        #endregion

        //Constructor sets the name of the room and translates the data into characters for the floor tiles
        #region Constructor

        public Room(String id, String[] data, Mansion w)
        {
            containedItems = new List<Item>();
            world = w;
            name = id;
            floorPlan = new String[15];
            for (int i = 0; i < 15; i++)
            {
                floorPlan[i] = data[i];
            }
            floor = new Tile[15, 20];


            //TranslateFloor();
        }

        #endregion

        //TranslateFloor takes the array of strings and sets them to the characters for the tiles
        #region TranslateFloor

        public void TranslateFloor()
        {
            //doors int holds the "door id" for any doors in the room
            int doorIndex = 0;

            for (int i = 0; i < 15; i++)
            {
                char[] layer = floorPlan[i].ToCharArray();
                for (int j = 0; j < 20; j++)
                {
                    if (layer[j] == 'D' || layer[j] == 'V' || layer[j] == 'A')
                    {
                        String[] parameters = doors[doorIndex].Split(',');
                        int currentId = int.Parse(parameters[0]);
                        int nextId = int.Parse(parameters[2]);
                        doorArray[doorIndex] = new Door(layer[j], GameVariables.tileSize * j, GameVariables.tileSize * i, this, currentId, parameters[1], nextId, parameters[3]);
                        floor[i, j] = doorArray[doorIndex];
                        doorIndex++;
                    }
                    else
                        floor[i, j] = new Tile(layer[j], GameVariables.tileSize * j, GameVariables.tileSize * i);
                }
            }
        }
        #endregion

        //GetDoorByIndex returns the door object with the specified index
        #region GetDoorByIndex
        public Door GetDoorByIndex(int index)
        {

            for (int i = 0; i < doorArray.Length; i++)
            {
                if (index == doorArray[i].DoorId)
                    return doorArray[i];
            }

            return null;

        }
        #endregion

        // Check all the tiles to see if rows of tiles
        // make walls.
        #region Create Walls
        public void CreateWalls()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    // Checks to see if the tiles above and
                    // below the current one are null and are walls
                    #region Verticle Checks
                    if (i == 0)
                    {
                        if (!floor[i + 1, j].Passable)
                        {
                            floor[i, j].VerticleWall = true;
                        }
                        else
                        {
                            floor[i, j].VerticleWall = false;
                        }
                    }
                    else if (i == 14)
                    {
                        if (!floor[i - 1, j].Passable)
                        {
                            floor[i, j].VerticleWall = true;
                        }
                        else
                        {
                            floor[i, j].VerticleWall = false;
                        }
                    }
                    else if (!floor[i - 1, j].Passable && !floor[i + 1, j].Passable)
                    {
                        floor[i, j].VerticleWall = true;
                    }

                    else
                    {
                        floor[i, j].VerticleWall = false;
                    }
                    #endregion
                    // Checks to see if the ties next to
                    // the current one are null and are walls
                    #region Horizontle Checks
                    if (j == 0)
                    {
                        if (!floor[i, j + 1].Passable)
                        {
                            floor[i, j].HorizontleWall = true;
                        }
                        else
                        {
                            floor[i, j].HorizontleWall = false;
                        }
                    }
                    else if (j == 19)
                    {
                        if (!floor[i, j - 1].Passable)
                        {
                            floor[i, j].HorizontleWall = true;
                        }
                        else
                        {
                            floor[i, j].HorizontleWall = false;
                        }
                    }
                    else if (!floor[i, j - 1].Passable && !floor[i, j + 1].Passable)
                    {
                        floor[i, j].HorizontleWall = true;
                    }

                    else
                    {
                        floor[i, j].HorizontleWall = false;
                    }
                    // Checks if the tile is a corner
                    if (!floor[i, j].VerticleWall && !floor[i, j].HorizontleWall && i != 0 && i != 14 && j != 0 && j != 19)
                    {
                        if (!floor[i - 1, j].Passable && !floor[i, j + 1].Passable)
                        {
                            floor[i, j].BLCorner = true;
                        }
                        else if (!floor[i - 1, j].Passable && !floor[i, j - 1].Passable)
                        {
                            floor[i, j].BRCorner = true;
                        }
                        else if (!floor[i + 1, j].Passable && !floor[i, j + 1].Passable)
                        {
                            floor[i, j].TLCorner = true;
                        }
                        else if (!floor[i + 1, j].Passable && !floor[i, j - 1].Passable)
                        {
                            floor[i, j].TRCorner = true;
                        }
                    }
                    #endregion
                }
            }
        }
        #endregion

        // Locks specific doors in each room
        public void LockDoors()
        {
            switch (name)
            {
                case "lowerfoyermap.txt":
                    foreach (Door d in doorArray)
                    {
                        if (d.DoorId != 1 && d.DoorId != 3)
                        {
                            d.Locked = true;
                        }
                    }
                    break;
                case "upperfoyermap.txt":
                    foreach (Door d in doorArray)
                    {
                        d.Locked = true;
                    }
                    break;
                case "dungeonmap.txt":
                    foreach (Door d in doorArray)
                    {
                        d.Locked = true;
                    }
                    break;
                case "lowerbathroommap.txt":
                    foreach (Door d in doorArray)
                    {
                        if (d.DoorId != 1)
                        {
                            d.Locked = true;
                        }
                    }
                    break;
                default: break;
            }
        }
    }
}
