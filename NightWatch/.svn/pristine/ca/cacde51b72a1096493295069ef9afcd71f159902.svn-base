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
using System.IO;

namespace NightWatch
{
    class Dialogue
    {
        DirectoryInfo directInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Content\\Dialogue\\GameDialogue.txt");

        private int dialogueLineIndicator;
        private bool triggerDialogue;

        private bool hasBegunDungeon;
        private bool hasBegunFoyer;
        private bool hasBegunBathroom;
        private bool hasBegunSafeRoom;
        private bool hasBegunKitchen;
        private bool hasBegunLibrary;
        private bool hasBegunGuestRoom;
        private bool hasBegunMasterRoom;
        private bool hasBegunGreenHouse;
        private bool hasBegunFoyerReturn;
        private bool hasBegunStudy;
        private bool hasBegunEnd;

        private List<String> dialogueLines = new List<string>();


        public bool HasBegunDungeon
        {
            get { return hasBegunDungeon; }
            set { hasBegunDungeon = value; }
        }
        public bool HasBegunFoyer
        {
            get { return hasBegunFoyer; }
            set { hasBegunFoyer = value; }
        }
        public bool HasBegunBathroom
        {
            get { return hasBegunBathroom; }
            set { hasBegunBathroom = value; }
        }
        public bool HasBegunSafeRoom
        {
            get { return hasBegunSafeRoom; }
            set { hasBegunSafeRoom = value; }
        }
        public bool HasBegunKitchen
        {
            get { return hasBegunKitchen; }
            set { hasBegunKitchen = value; }
        }
        public bool HasBegunLibrary
        {
            get { return hasBegunLibrary; }
            set { hasBegunLibrary = value; }
        }
        public bool HasBegunGuestRoom
        {
            get { return hasBegunGuestRoom; }
            set { hasBegunGuestRoom = value; }
        }
        public bool HasBegunMasterRoom
        {
            get { return hasBegunMasterRoom; }
            set { hasBegunMasterRoom = value; }
        }
        public bool HasBegunGreenHouse
        {
            get { return hasBegunGreenHouse; }
            set { hasBegunGreenHouse = value; }
        }
        public bool HasBegunFoyerReturn
        {
            get { return hasBegunFoyerReturn; }
            set { hasBegunFoyerReturn = value; }
        }
        public bool HasBegunStudy
        {
            get { return hasBegunStudy; }
            set { hasBegunStudy = value; }
        }
        public bool HasBegunEnd
        {
            get { return hasBegunEnd; }
            set { hasBegunEnd = value; }
        }



        public List<string> DialogueLines
        {
            get { return dialogueLines; }
        }

        public int DialogueLineIndicator
        {
            get { return dialogueLineIndicator; }
            set { dialogueLineIndicator = value; }
        }

        public bool TriggerDialogue
        {
            get { return triggerDialogue; }
            set { triggerDialogue = value; }
        }

        public Dialogue()
        {
            hasBegunDungeon = false;
            hasBegunFoyer = false;
            hasBegunBathroom = false;
            hasBegunSafeRoom = false;
            hasBegunKitchen = false;
            hasBegunLibrary = false;
            hasBegunGuestRoom = false;
            hasBegunMasterRoom = false;
            hasBegunGreenHouse = false;
            hasBegunFoyerReturn = false;
            hasBegunStudy = false;
            hasBegunEnd = false;

            triggerDialogue = false;
            dialogueLineIndicator = -1;
        }

        public void LoadPhrases()
        {
            {
                //Create new reader variable first
                StreamReader phraseReader = new StreamReader(directInfo.FullName);

                //The loop that goes through the file and prints out everything in it
                String line = "";
                int counter = 0;
                while (line != null)
                {
                    line = phraseReader.ReadLine();
                    if (line != null)
                    {
                        counter++;

                        dialogueLines.Add(line);
                    }
                }
            }
        }
    }
}
