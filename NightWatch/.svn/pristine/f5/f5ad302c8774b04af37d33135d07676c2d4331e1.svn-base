using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace NightWatch
{
    class Puzzle
    {
        //This class will handle puzzles for wherever we may need them

        //Attributes
        private List<bool> cases;
        private bool isCompleted;
        private bool switch1;
        private bool switch2;
        private Person player;
        private Room currentRoom;
        private Mansion world;
        private float seconds;
        private float puzzleTimeStart;
        private List<SoundEffect> gameSounds;

        //Properties
        #region Properties
        public List<bool> Cases
        {
            get { return cases; }
            set { cases = value; }
        }

        public bool IsCompleted
        {
            get { return isCompleted; }
            set { isCompleted = value; }
        }

        public float Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }
        #endregion

        //Constructor
        #region Constructor
        public Puzzle(Room current, Person p, Mansion w, List<SoundEffect> sounds)
        {
            cases = new List<bool>();
            switch1 = false;
            switch2 = false;
            puzzleTimeStart = 0;
            world = w;
            player = p;
            currentRoom = current;
            gameSounds = sounds;
        }
        #endregion

        //Switches value at specified index; if true then set to false
        #region ToggleCase
        public void ToggleCase(int index)
        {
            if (cases[index])
                cases[index] = false;
            else cases[index] = true;
        }
        #endregion

        //Sets bool at the specified index to the new value
        #region SetCase
        public void SetCase(int index, bool newCase)
        {
            cases[index] = newCase;
        }
        #endregion

        #region CheckPuzzle
        public void CheckPuzzle(Tile tile)
        {
            // Check all puzzles
            switch (currentRoom.Name)
            {
                case "dungeonmap.txt":
                    DungeonPuzzle(tile);
                    break;
                case "lowerbathroommap.txt":
                    BathroomPuzzle(tile);
                    break;
                case "kitchenmap.txt":
                    KitchenPuzzle(tile);
                    break;
                case "librarymap.txt":
                    LibraryPuzzle(tile);
                    break;
                case "guestroommap.txt":
                    GuestRoomPuzzle(tile);
                    break;
                case "masterbedroommap.txt":
                    MasterBedroomPuzzle(tile);
                    break;
                case "backyardmap.txt":
                    BackyardPuzzle(tile);
                    break;
                case "studymap.txt":
                    StudyPuzzle(tile);
                    break;
                case "lowerfoyermap.txt":
                    FoyerLocks(tile, true);
                    break;
                case "upperfoyermap.txt":
                    FoyerLocks(tile, false);
                    break;
            }
        }
        #endregion

        #region Puzzle Methods
        /// <summary>
        /// This is the method to check if the 
        /// Dungeon puzzle is completed
        /// </summary>
        public void DungeonPuzzle(Tile interactedTile)
        {
            if (!isCompleted)
            {
                switch (interactedTile.Id)
                {
                    case 'B':
                        // Check for Knife
                        if (ContainsItem("Knife"))
                        {
                            interactedTile.Id = 's';
                            interactedTile.Interactable = false;
                            interactedTile.Passable = true;
                        }
                        break;
                    case 'D':
                        if (ContainsItem("DungeonKey"))
                        {
                            currentRoom.GetDoorByIndex(0).Locked = false;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// This is the method to check if the 
        /// Bathroom puzzle is completed
        /// </summary>
        public void BathroomPuzzle(Tile interactedTile)
        {
            if (!isCompleted)
            {
                switch (interactedTile.Id)
                {
                    case 'K':
                        // Check for ScrewDriver
                        if (!ContainsItem("ScrewDriver"))
                        {
                            player.Backpack.Add(world.AllItems[3]);
                        }
                        break;
                    case 'V':
                        // Check to see if you have the ScrewDriver
                        if (ContainsItem("ScrewDriver"))
                        {
                            currentRoom.GetDoorByIndex(0).Locked = false;
                            interactedTile.Id = 'v';
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// This is the method to check if the 
        /// Kitchen puzzle is completed
        /// </summary>
        public void KitchenPuzzle(Tile interactedTile)
        {
            if (!ContainsItem("LibraryKey"))
            {
                switch (interactedTile.Id)
                {
                    case 'R':
                        if (!ContainsItem("Apple") && !ContainsItem("FrozenApple") && puzzleTimeStart == 0)
                        {
                            player.Backpack.Add(world.AllItems[5]);
                        }
                        break;
                    case 'F':
                        for (int i = 0; i < player.Backpack.Count; ++i)
                        {
                            if (player.Backpack[i].Name == "Apple")
                            {
                                player.Backpack.Remove(world.AllItems[5]);
                                puzzleTimeStart = seconds;
                            }
                            else if (puzzleTimeStart > 0)
                            {
                                float elapsedTime = seconds - puzzleTimeStart;
                                if (elapsedTime >= 5 && elapsedTime <= 6)
                                {
                                    player.Backpack.Add(world.AllItems[6]);
                                    puzzleTimeStart = 0;
                                }
                                else
                                {
                                    puzzleTimeStart = 0;
                                }
                            }
                        }
                        break;
                    case 'C':
                        if (ContainsItem("FrozenApple"))
                        {
                            player.Backpack.RemoveAt(5);
                            player.Backpack.Add(world.AllItems[7]);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// This is the method to check if the 
        /// Library puzzle is completed
        /// </summary>
        public void LibraryPuzzle(Tile interactedTile)
        {
            if (!ContainsItem("GuestRoomKey"))
            {
                if (interactedTile.Id != 'D')
                {
                    gameSounds[0].Play();
                    switch (interactedTile.Id)
                    {
                        case '1':
                            if (puzzleTimeStart == 0)
                            {
                                puzzleTimeStart = seconds;
                                gameSounds[1].Play();
                                switch1 = true;
                            }
                            break;
                        case '2':
                            if (switch1 && (seconds - puzzleTimeStart) < 5)
                            {
                                switch2 = true;
                                gameSounds[1].Play();
                            }
                            break;
                        case '3':
                            if (switch1 && switch2 && (seconds - puzzleTimeStart) < 10)
                            {
                                player.Backpack.Add(world.AllItems[8]);
                                switch1 = false;
                                switch2 = false;
                                puzzleTimeStart = 0;
                            }
                            break;
                    }
                }
                if (!switch2 && (seconds - puzzleTimeStart) > 5)
                {
                    puzzleTimeStart = 0;
                }
                if (switch2 && (seconds - puzzleTimeStart) > 10)
                {
                    puzzleTimeStart = 0;
                }
            }
        }

        /// <summary>
        /// This is the method to check if the 
        /// Guest Room puzzle is completed
        /// </summary>
        public void GuestRoomPuzzle(Tile interactedTile)
        {
            if (!ContainsItem("MasterBedroomKey"))
            {
                switch (interactedTile.Id)
                {
                    case 'P':
                        interactedTile.Id = 'p';

                        for (int i = 0; i < 15; ++i)
                        {
                            for (int j = 0; j < 20; ++j)
                            {
                                if (currentRoom.Floor[i, j].Id == 'Z')
                                {
                                    currentRoom.Floor[i, j].Id = 'z';
                                }
                            }
                        }
                        break;
                    case 'z':
                        if (!ContainsItem("MasterBedroomKey"))
                        {
                            player.Backpack.Add(world.AllItems[9]);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// This is the method to check if the 
        /// Master Bedroom puzzle is completed
        /// </summary>
        public void MasterBedroomPuzzle(Tile interactedTile)
        {
            if (!isCompleted)
            {
                switch (interactedTile.Id)
                {
                    case 'w':
                        if (puzzleTimeStart == 0)
                        {
                            puzzleTimeStart = seconds;
                        }
                        break;
                    case 'v':
                        if (ContainsItem("Sheet") && ContainsItem("Curtain") && (seconds - puzzleTimeStart) < 60)
                        {
                            puzzleTimeStart = 0;

                            player.Backpack.Add(world.AllItems[12]);
                        }
                        break;
                    case 'D':
                        if (ContainsItem("BackyardKey"))
                        {
                            currentRoom.GetDoorByIndex(0).Locked = false;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// This is the method to check if the 
        /// Green House puzzle is completed
        /// </summary>
        public void BackyardPuzzle(Tile interactedTile)
        {
            if (!isCompleted)
            {
                if (ContainsItem("Shovel") && interactedTile.Id == 'd')
                {
                    interactedTile.Id = 'Y';
                    player.Backpack.Add(world.AllItems[14]);
                }
            }
        }

        /// <summary>0
        /// This is the method to check if the 
        /// Study puzzle is completed
        /// </summary>
        public void StudyPuzzle(Tile interactedTile)
        {
            if (!isCompleted)
            {
                if (!ContainsItem("FinalKey"))
                {
                    player.Backpack.Add(world.AllItems[15]);
                }
            }
        }
        #endregion

        #region FoyerLocks
        public void FoyerLocks(Tile tile, bool lower)
        {
            if (lower)
            {
                currentRoom.GetDoorByIndex(4).Locked = false;
                if (ContainsItem("KitchenKey"))
                {
                    currentRoom.GetDoorByIndex(5).Locked = false;
                }
                if (ContainsItem("BackyardKey"))
                {
                    currentRoom.GetDoorByIndex(1).Locked = false;
                }
                if (ContainsItem("GuestRoomKey"))
                {
                    currentRoom.GetDoorByIndex(3).Locked = false;
                }
            }
            else
            {
                if (ContainsItem("StudyKey"))
                {
                    currentRoom.GetDoorByIndex(0).Locked = false;
                }
                if (ContainsItem("LibraryKey"))
                {
                    currentRoom.GetDoorByIndex(1).Locked = false;
                }
                if (ContainsItem("MasterBedroomKey"))
                {
                    currentRoom.GetDoorByIndex(2).Locked = false;
                }
            }
        }
        #endregion

        #region ContainsItem
        /// <summary>
        /// Checks if the player has a certain item
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsItem(String name)
        {
            bool contained = false;
            foreach (Item item in player.Backpack)
            {
                if (item.Name == name)
                {
                    contained = true;
                }
            }

            return contained;
        }
        #endregion

        #region Update References
        /// <summary>
        /// Updates the references for the puzzle class.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="currentRoom"></param>
        public void UpdateReference(Person person, Room currentRoom)
        {
            player = person;
            this.currentRoom = currentRoom;
        }
        #endregion
    }
}
