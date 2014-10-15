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
    class Person
    {
        //Suggested attributes
        private bool[] journalChanged;
        private bool isInteracting;
        private Rectangle box;
        private Rectangle imgBox;
        private List<Item> backpack;
        private Room currentRoom;
        private Puzzle puzzles;
        private KeyboardState oldState;
        private KeyboardState newState;



        #region Constructor

        public Person(Room firstRoom)
        {
            box = new Rectangle(100, 180, GameVariables.tileSize, GameVariables.tileSize);
            backpack = new List<Item>();
            currentRoom = firstRoom;
            imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
            isInteracting = false;
            oldState = Keyboard.GetState();

            journalChanged = new bool[9];
            for(int i = 0; i < journalChanged.Length; i++)
                journalChanged[i] = false;
        }

        #endregion

        #region Properties

        public Rectangle Box
        {
            get { return box; }
            set { box = value; }
        }
        public Rectangle ImgBox
        {
            get { return imgBox; }
            set { imgBox = value; }
        }
        public bool IsInteracting
        {
            get { return isInteracting; }
            set { isInteracting = value; }
        }

        public List<Item> Backpack
        {
            get { return backpack; }
            set { backpack = value; }
        }

        public Room CurrentRoom
        {
            get { return currentRoom; }
            set { currentRoom = value; }
        }

        public Puzzle Puzzles
        {
            get { return puzzles; }
            set { puzzles = value; }
        }
        public bool[] JournalChanged
        {
            get { return journalChanged; }
            set { journalChanged = value; }
        }
        #endregion

        //Adds item to backpack
        #region PickUpItem

        public void PickUpItem(Item itemThatCanBePickedUp)
        {
            backpack.Add(itemThatCanBePickedUp);
            itemThatCanBePickedUp.pItemIsPickedUp = true;
            itemThatCanBePickedUp.X = GameVariables.gameWidth + GameVariables.tileSize;
        }

        #endregion

        //Takes key input and moves
        #region ProcessInput

        public void ProcessInput()
        {
             newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Up))
            {
                box.Y -= GameVariables.playerSpeed;
                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
            }
            if (newState.IsKeyDown(Keys.Left))
            {
                box.X -= GameVariables.playerSpeed;
                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
            }
            if (newState.IsKeyDown(Keys.Down))
            {
                box.Y += GameVariables.playerSpeed;
                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
            }
            if (newState.IsKeyDown(Keys.Right))
            {
                box.X += GameVariables.playerSpeed;
                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
            }

            CheckBorders();
            CheckCollisions();
            if (HandleKeyPress())
            {
                isInteracting = true;
                Interact();
            }
            else 
                isInteracting = false;
        }

        #endregion

        //Collides with window borders
        #region Checkborders

        public void CheckBorders()
        {
            if (box.X < 0)
            {
                box.X += GameVariables.playerSpeed;
                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
            }
            if (box.X > GameVariables.gameWidth - box.Width)
            {
                box.X -= GameVariables.playerSpeed;
                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
            }
            if (box.Y < 0)
            {
                box.Y += GameVariables.playerSpeed;
                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
            }
            if (box.Y > GameVariables.gameHeight - box.Height)
            {
                box.Y -= GameVariables.playerSpeed;
                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
            }
        }

        #endregion

        //CheckCollisions assures the player does not intersect with un-passable tiles
        #region CheckCollisions
        public void CheckCollisions()
        {
            foreach (Tile tile in currentRoom.Tiles)
            {
                if (box.Intersects(tile.Box) && tile.Passable == false)
                {
                    if (box.Intersects(tile.Box) && tile.Passable == false)
                    {

                        if (tile.TLCorner)
                        {
                            if (box.Right > tile.Box.Left && box.Right < tile.Box.Left + GameVariables.playerSpeed + 1)
                            {
                                box.X -= GameVariables.playerSpeed;
                                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
                            }
                            if (box.Bottom > tile.Box.Top && box.Bottom < tile.Box.Top + GameVariables.playerSpeed + 1)
                            {
                                box.Y -= GameVariables.playerSpeed;
                                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
                            }
                        }
                        else if (tile.TRCorner)
                        {
                            if (box.Left < tile.Box.Right && box.Left > tile.Box.Right - GameVariables.playerSpeed - 1)
                            {
                                box.X += GameVariables.playerSpeed;
                                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
                            }
                            if (box.Bottom > tile.Box.Top && box.Bottom < tile.Box.Top + GameVariables.playerSpeed + 1)
                            {
                                box.Y -= GameVariables.playerSpeed;
                                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
                            }
                        }
                        else if (tile.BLCorner)
                        {
                            if (box.Right > tile.Box.Left && box.Right < tile.Box.Left + GameVariables.playerSpeed + 1)
                            {
                                box.X -= GameVariables.playerSpeed;
                                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
                            }
                            if (box.Top < tile.Box.Bottom && box.Top > tile.Box.Bottom - GameVariables.playerSpeed - 1)
                            {
                                box.Y += GameVariables.playerSpeed;
                                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
                            }
                        }
                        else if (tile.BRCorner)
                        {
                            if (box.Left < tile.Box.Right && box.Left > tile.Box.Right - GameVariables.playerSpeed - 1)
                            {
                                box.X += GameVariables.playerSpeed;
                                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
                            }
                            if (box.Top < tile.Box.Bottom && box.Top > tile.Box.Bottom - GameVariables.playerSpeed - 1)
                            {
                                box.Y += GameVariables.playerSpeed;
                                imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
                            }
                        }
                        else
                        {
                            if (!tile.HorizontleWall)
                            {
                                if (box.Right > tile.Box.Left && box.Right < tile.Box.Left + GameVariables.playerSpeed + 1)
                                {
                                    box.X -= GameVariables.playerSpeed;
                                    imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
                                }
                                else if (box.Left < tile.Box.Right && box.Left > tile.Box.Right - GameVariables.playerSpeed - 1)
                                {
                                    box.X += GameVariables.playerSpeed;
                                    imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
                                }
                            }
                            if (!tile.VerticleWall)
                            {
                                if (box.Bottom > tile.Box.Top && box.Bottom < tile.Box.Top + GameVariables.playerSpeed + 1)
                                {
                                    box.Y -= GameVariables.playerSpeed;
                                    imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
                                }
                                else if (box.Top < tile.Box.Bottom && box.Top > tile.Box.Bottom - GameVariables.playerSpeed - 1)
                                {
                                    box.Y += GameVariables.playerSpeed;
                                    imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        //UpdateRoom changes the player's room attribute to match the game's reference
        #region UpdateRoom
        public void UpdateRoom(Room theRoom)
        {
            currentRoom = theRoom;
            currentRoom.CreateWalls();
        }
        #endregion

        //MoveThroughDoor is used in Person because of some weird error disallowing player.box.X/Y positions to be changed from Game1.cs
        #region MoveThroughDoor
        public void MoveThroughDoor(Door door)
        {
            box.X = currentRoom.World.GetRoom(door.NextName).GetDoorByIndex(door.NextDoor).NewX;
            box.Y = currentRoom.World.GetRoom(door.NextName).GetDoorByIndex(door.NextDoor).NewY;
            imgBox = new Rectangle(box.X - (GameVariables.tileSize / 2), box.Y - GameVariables.tileSize, GameVariables.tileSize * 2, GameVariables.tileSize * 2);
        }
        #endregion

        //Interact checks if "f" is down, and "interacts"
        #region Interact
        public void Interact()
        {
            foreach (Tile tile in currentRoom.Tiles)
            {
                if (tile.Interactable)
                {
                    Rectangle rect = tile.Box;
                    rect.Inflate(5, 5);
                    if (box.Intersects(rect))
                    {
                        puzzles.UpdateReference(this, currentRoom);
                        puzzles.CheckPuzzle(tile);
                        currentRoom.CreateWalls();
                    }
                }
            }
        }
        #endregion

        //HandleKeyPress Only returns true when a key has been pressed and released, preventing continuous interaction
        #region HandleKeyPress
        private bool HandleKeyPress()
        {
            bool pressed = false;

            //Key has just been pressed down
            if (newState.IsKeyDown(Keys.F) && !oldState.IsKeyDown(Keys.F))
                pressed = false;

            //Key is STILL DOWN, not lifted
            if (newState.IsKeyDown(Keys.F) && oldState.IsKeyDown(Keys.F))
                pressed = false;

            //Key has been pressed AND RELEASED, pressed = true
            if (!newState.IsKeyDown(Keys.F) && oldState.IsKeyDown(Keys.F))
                pressed = true;

            oldState = newState;

            return pressed;
        }
        #endregion
    }
}
