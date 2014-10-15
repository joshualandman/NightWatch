using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace NightWatch
{
    class Mansion
    {
        //Mansion holds an array of rooms
        private Room[] rooms;
        private DirectoryInfo di;
        private List<Item> allItems = new List<Item>();

        #region Properties
        public List<Item> AllItems
        {
          get { return allItems; }
          set { allItems = value; }
        }
        #endregion

        //Constructor for Mansion reads the Maps directory
        #region Constructor
        public Mansion()
        {
            di = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Content\\Maps");

            rooms = new Room[di.GetFiles().Length];

            LoadRooms();
            foreach (Room r in rooms)
            {
                r.LockDoors();
            }
        }
        #endregion

        //Loads every map text file in the Maps directory into the rooms array
        #region LoadRooms
        private void LoadRooms()
        {
            FileInfo[] files = di.GetFiles();

            for (int i = 0; i < files.Length; i++)
            {
                rooms[i] = new Room(files[i].Name, LoadData(files[i].FullName), this);
                LinkDoors(di.FullName + "\\" + rooms[i].Name, rooms[i]);
            }

            for (int i = 0; i < files.Length; i++)
            {
                rooms[i].TranslateFloor();
            }

            for (int i = 0; i < files.Length; i++)
            {
                for (int j = 0; j < rooms[i].DoorArray.Length; j++)
                {
                    rooms[i].DoorArray[j].SetNextRoom();
                }
            }
        }
        #endregion


        #region LoadItemMap

        public void LoadItemMap()
        {
            List<string> itemRawData = new List<string>();
            // Create the variable
            StreamReader input = null;

            try
            {
                // Create the object
                input = new StreamReader((Directory.GetCurrentDirectory() + "\\Content\\itemMaps.txt"));


                // Read lines until we're out of line
                String line = "";
                int counter = 0;
                while (line != null)
                {
                    // Read a line
                    line = input.ReadLine();

                    // Use it (if it exists)
                    if (line != null)
                    {
                        counter++;
                        itemRawData.Add(line);
                    }
                }

                for (int i = 0; i < itemRawData.Count; i++)
                {
                    String[] variables = itemRawData[i].Split(',');
                    Room currentRoom = GetRoom(variables[0]);
                    int x = int.Parse(variables[2]);
                    int y = int.Parse(variables[3]);
                    int itemIndex = int.Parse(variables[5]);

                    Item TempItem = new Item(variables[1], x, y, itemIndex, currentRoom);
                    TempItem.ImgName = variables[4];
                    currentRoom.ContainedItems.Add(TempItem);
                    AllItems.Add(TempItem);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
            }
            finally
            {
                // Close the file
                input.Close();
            }
        }

        #endregion


        //Returns the tile data from the room file
        #region LoadData
        private String[] LoadData(string path)
        {
            StreamReader mapReader = new StreamReader(path);
            String read;
            String[] lines = new String[15];

            int count = 0;

            while (count < 15)
            {
                read = mapReader.ReadLine();
                lines[count] = read;
                count++;
            }

            return lines;
        }
        #endregion

        //LinkDoors returns a list of strings representing the doors' links between rooms
        #region LinkDoors
        private void LinkDoors(string path, Room current)
        {
            StreamReader sr = new StreamReader(path);
            string read;
            List<String> doors = new List<string>();

            int x = 0;
            while (x < 15)
            {
                string hold = sr.ReadLine();
                x++;
            }

            while ((read = sr.ReadLine()) != null)
            {
                doors.Add(read);
            }

            sr.Close();

            String[] DoorLinkArray = new string[doors.Count];

            for (int i = 0; i < doors.Count; i++)
            {
                DoorLinkArray[i] = doors[i];
            }

            current.Doors = DoorLinkArray;
        }
        #endregion

        //GetRoom returns the data of one room, specified by name (Filename)
        #region GetRoom
        public Room GetRoom(String name)
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                if (name == rooms[i].Name)
                    return rooms[i];
            }
            return null;
        }
        #endregion
    }
}
