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
    class Screen
    {
        //This will be for Start, Pause screens, etc.

        //The enum state for the screens
        enum ScreenState
        {
            TitleScreen,
            InventoryScreen,
            PauseScreen,
            JournalScreen,
            WatchScreen,
            InstructionScreen,
            GameplayScreen
        }

        private KeyboardState keyState;
        private KeyboardState origKeyState;

        //Creates the ScreenState state
        ScreenState screenState = ScreenState.TitleScreen;

        //Boolean attributes that depict what screen is showing
        private bool isInventoryScreen;
        private bool isPauseScreen;
        private bool isTitleScreen;
        private bool isJournalScreen;
        private bool isWatchScreen;
        private bool isInstructScreen;
        private bool returnToGame;


        //The int that wil;l indicate what version of the start screen the player is on
        private int titleScreenVersion;

        private int journalPageNum;

        //Properties
        public bool IsInventoryScreen
        {
            get { return isInventoryScreen; }
        }

        public bool IsPauseScreen
        {
            get { return isPauseScreen; }
        }

        public bool IsTitleScreen
        {
            get { return isTitleScreen; }
        }

        public bool IsJournalScreen
        {
            get { return isJournalScreen; }
        }

        public bool IsWatchScreen
        {
            get { return isWatchScreen; }
        }

        public bool IsInstructScreen
        {
            get { return isInstructScreen; }
        }

        public bool ReturnToGame
        {
            get { return returnToGame; }
        }

        public int TitleScreenVersion
        {
            get { return titleScreenVersion; }
            set { titleScreenVersion = value; }
        }

        public int JournalPageNum
        {
            get { return journalPageNum; }
            set { journalPageNum = value; }
        }

        //Constructor
        public Screen()
        {
            isInventoryScreen = false;
            isPauseScreen = false;
            isWatchScreen = false;
            isInstructScreen = false;
            returnToGame = false;

            titleScreenVersion = 0;

            journalPageNum = 0;
        }

        //Checks to see if a key has been pressed and acts only once while the key is down.
        public bool singleKeyPress(Keys key)
        {
            if ((keyState.IsKeyDown(key)) && (origKeyState.IsKeyUp(key)))
            {
                origKeyState = keyState;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Checks what the player types 
        //If the pressed key is I, the screen state will be set to Inventory
        //If the pressed key is P, the screen state will be set to Pause
        //If the player presses "enter" at the start of the game, the start menu will close and open up the "invitation" screen, then close the inventory screen and start the game.
        //Pressing either key while the screen is active will return the game to it's origional state
        public void CheckPauseAndInventoryKeysPressed()
        {
            origKeyState = keyState;
            keyState = Keyboard.GetState();

            if (singleKeyPress(Keys.Enter) == true && screenState == ScreenState.TitleScreen)
            {
                //When the player presses "enter" for the first time, the game will progress from the start menu to the invitation screen 
                //The title screen version int will increment.
                if (titleScreenVersion == 0)
                {
                    titleScreenVersion = 1;
                }
                //After the player presses "enter" again, the actual game will start.
                //The int will be set to "-1" to be out of the way.
                else if (titleScreenVersion == 1)
                {
                    titleScreenVersion = -1;
                    screenState = ScreenState.GameplayScreen;
                }
            }

            if (singleKeyPress(Keys.H) == true && screenState != ScreenState.PauseScreen && screenState != ScreenState.InventoryScreen && screenState != ScreenState.JournalScreen && screenState != ScreenState.WatchScreen && screenState != ScreenState.GameplayScreen)
            {
                if (screenState == ScreenState.InstructionScreen)
                {
                    screenState = ScreenState.TitleScreen;
                }
                else
                {
                    screenState = ScreenState.InstructionScreen;
                }
            }

            if (singleKeyPress(Keys.J) == true && screenState == ScreenState.InventoryScreen)
            {
                screenState = ScreenState.JournalScreen;
            }

            if (singleKeyPress(Keys.I) == true && screenState != ScreenState.PauseScreen && screenState != ScreenState.TitleScreen)
            {
                if (screenState == ScreenState.InventoryScreen)
                {
                    screenState = ScreenState.GameplayScreen;
                }
                else
                {
                    screenState = ScreenState.InventoryScreen;
                }
            }

            if (singleKeyPress(Keys.W) == true && screenState != ScreenState.JournalScreen && screenState != ScreenState.PauseScreen)
            {
                if (screenState == ScreenState.WatchScreen)
                {
                    screenState = ScreenState.GameplayScreen;
                }
                else
                {
                    screenState = ScreenState.WatchScreen;
                }
            }

            if (singleKeyPress(Keys.P) == true)
            {
                if (screenState == ScreenState.PauseScreen && screenState != ScreenState.TitleScreen)
                {
                    screenState = ScreenState.GameplayScreen;
                }
                else if (screenState != ScreenState.TitleScreen)
                {
                    screenState = ScreenState.PauseScreen;
                }
            }
        }

        public void PageThroughJournal()
        {
            if (screenState == ScreenState.JournalScreen)
            {
                if (singleKeyPress(Keys.Left))
                {
                    if (journalPageNum >= 1)
                    {
                        journalPageNum = journalPageNum - 1;
                    }
                }

                if (singleKeyPress(Keys.Right))
                {
                    if (journalPageNum <= 7)
                    {
                        journalPageNum = journalPageNum + 1;
                    }
                }
            }
        }

        //When the screen states are changed, the bool for either screen states is set to true.
        public void CheckScreenState()
        {
            if (screenState == ScreenState.TitleScreen)
            {
                returnToGame = false;
                isPauseScreen = false;
                isInventoryScreen = false;
                isJournalScreen = false;
                isInstructScreen = false;
                isTitleScreen = true;
            }

            if (screenState == ScreenState.InventoryScreen)
            {
                returnToGame = false;
                isPauseScreen = false;
                isTitleScreen = false;
                isJournalScreen = false;
                isWatchScreen = false;
                isInstructScreen = false;
                isInventoryScreen = true;
            }

            if (screenState == ScreenState.PauseScreen)
            {
                returnToGame = false;
                isInventoryScreen = false;
                isTitleScreen = false;
                isJournalScreen = false;
                isWatchScreen = false;
                isInstructScreen = false;
                isPauseScreen = true;
            }

            if (screenState == ScreenState.JournalScreen)
            {
                returnToGame = false;
                isInventoryScreen = false;
                isTitleScreen = false;
                isPauseScreen = false;
                isWatchScreen = false;
                isInstructScreen = false;
                isJournalScreen = true;
            }

            if (screenState == ScreenState.WatchScreen)
            {
                returnToGame = false;
                isInventoryScreen = false;
                isTitleScreen = false;
                isPauseScreen = false;
                isJournalScreen = false;
                isInstructScreen = false;
                isWatchScreen = true;
            }

            if (screenState == ScreenState.InstructionScreen)
            {
                returnToGame = false;
                isInventoryScreen = false;
                isTitleScreen = false;
                isPauseScreen = false;
                isJournalScreen = false;
                isWatchScreen = false;
                isInstructScreen = true;
            }

            if (screenState == ScreenState.GameplayScreen)
            {
                isInventoryScreen = false;
                isPauseScreen = false;
                isTitleScreen = false;
                isJournalScreen = false;
                isWatchScreen = false;
                isInstructScreen = false;
                returnToGame = true;
            }
        }
    }
}
