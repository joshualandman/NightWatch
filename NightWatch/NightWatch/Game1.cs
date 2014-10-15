using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace NightWatch
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Attributes

        Dialogue speaking;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Mansion world;
        Room currentRoom;
        Tile[,] floorPlan;
        static Texture2D itemPicSprite;
        Texture2D knife;
        Texture2D key;
        Texture2D dialogueBackground;
        SpriteFont textFont;
        Person player;
        Puzzle gamePuzzles;
        Screen gameScreens;
        Texture2D floor;
        Texture2D wall;
        Texture2D stoneFloor;
        Texture2D stoneWall;
        Texture2D barWall;
        Texture2D barDoor;
        Texture2D tileFloor;
        Texture2D vent;
        Texture2D openVent;
        Texture2D stuffedVent;
        Texture2D sink;
        Texture2D tableBack;
        Texture2D tableFront;
        Texture2D tableCorner;
        Texture2D freezer;
        Texture2D fridge;
        Texture2D cabinet;
        Texture2D bookShelf;
        Texture2D bedFront;
        Texture2D bedFrontLeft;
        Texture2D bedFrontRight;
        Texture2D bedSheet;
        Texture2D guestBedFront;
        Texture2D guestBedFrontLeft;
        Texture2D guestBedFrontRight;
        Texture2D guestBedBrokenPost;
        Texture2D guestBedSheet;
        Texture2D safe;
        Texture2D brokenSafe;
        Texture2D bedTop;
        Texture2D carpetFloor;
        Texture2D carpetStair;
        Texture2D carpetStairRailing;
        Texture2D carpetStairRailingFront;
        Texture2D counterFront;
        Texture2D counterTop;
        Texture2D dirtFloor;
        Texture2D dirtHole;
        Texture2D grass;
        Texture2D grassStone;
        Texture2D grave;
        Texture2D wardrobe;
        Texture2D wardrobeLeft;
        Texture2D wardrobeRight;
        Texture2D hedge;
        Texture2D door;
        Texture2D obj;
        Texture2D space;
        Texture2D titleScreen;
        Texture2D inventoryScreen;
        Texture2D pauseScreen;
        Texture2D invitationLetter;
        Texture2D watchScreen;
        List<Texture2D> ItemPics = new List<Texture2D>();

        Texture2D instructScreen;

        Texture2D jounralNum1;
        Texture2D jounralNum2;
        Texture2D jounralNum3;
        Texture2D jounralNum4;
        Texture2D jounralNum5;
        Texture2D jounralNum6;
        Texture2D jounralNum7;
        Texture2D jounralNum8;
        Texture2D jounralNumDescript;

        Texture2D secondHandSprite;
        Texture2D minuteHandSprite;

        SoundEffect click;
        SoundEffect ticking;
        List<SoundEffect> sounds;

        Vector2 origin;
        Vector2 changeLoc;
        float secondsRotationAngle;
        float minutesRotationAngle;

        int tempMoveX = 315;
        int tempMoveY = 78;

        Texture2D[] frames = new Texture2D[40];
        AnimatePlayer animation = new AnimatePlayer();
        //animation timing mechanic
        int count = 0;
        double timePerFrame = 10;

        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameScreens = new Screen();
            graphics.PreferredBackBufferHeight = GameVariables.gameHeight;
            graphics.PreferredBackBufferWidth = GameVariables.gameWidth;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        #region Initialize
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            #region Sounds
            // TODO: Add your initialization logic here
            click = Content.Load<SoundEffect>("Click");
            ticking = Content.Load<SoundEffect>("Ticking");
            sounds = new List<SoundEffect>();
            sounds.Add(click);
            sounds.Add(ticking);
            #endregion

            world = new Mansion();
            world.LoadItemMap();
            currentRoom = world.GetRoom("dungeonmap.txt");
            foreach (Item items in world.AllItems)
            {
                Texture2D temp = Content.Load<Texture2D>(items.ImgName);
                ItemPics.Add(temp);
            }
            currentRoom.CreateWalls();
            player = new Person(currentRoom);
            gamePuzzles = new Puzzle(currentRoom, player, world, sounds);
            player.Puzzles = gamePuzzles;

            speaking = new Dialogue();
            speaking.LoadPhrases();

            base.Initialize();
        }
        #endregion

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        #region LoadContent
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //knife = Content.Load<Texture2D>("Knife");
            //key = Content.Load<Texture2D>("Key");
            //Items.Add(knife);
            //Items.Add(key);

            floor = Content.Load<Texture2D>("WoodFloor");
            wall = Content.Load<Texture2D>("BasicWall2");
            stoneFloor = Content.Load<Texture2D>("StoneFloor");
            stoneWall = Content.Load<Texture2D>("StoneWall");
            barWall = Content.Load<Texture2D>("BarWall");
            barDoor = Content.Load<Texture2D>("BarDoor");
            tileFloor = Content.Load<Texture2D>("TileFloor");
            vent = Content.Load<Texture2D>("Vent");
            openVent = Content.Load<Texture2D>("VentOpen");
            stuffedVent = Content.Load<Texture2D>("VentStuffed");
            sink = Content.Load<Texture2D>("Sink");
            tableBack = Content.Load<Texture2D>("TableBack");
            tableFront = Content.Load<Texture2D>("TableFront");
            tableCorner = Content.Load<Texture2D>("TableCorner");
            freezer = Content.Load<Texture2D>("Freezer");
            fridge = Content.Load<Texture2D>("Fridge");
            cabinet = Content.Load<Texture2D>("Cabinet");
            bookShelf = Content.Load<Texture2D>("BookCase");
            bedFront = Content.Load<Texture2D>("BedFront");
            bedFrontLeft = Content.Load<Texture2D>("BedFrontLeft");
            bedFrontRight = Content.Load<Texture2D>("BedFrontRight");
            bedSheet = Content.Load<Texture2D>("BedSheet");
            bedTop = Content.Load<Texture2D>("BedTop");
            guestBedFront = Content.Load<Texture2D>("GuestBedFront");
            guestBedFrontLeft = Content.Load<Texture2D>("GuestBedFrontLeft");
            guestBedFrontRight = Content.Load<Texture2D>("GuestBedFrontRight");
            guestBedBrokenPost = Content.Load<Texture2D>("GuestBedBrokenPost");
            guestBedSheet = Content.Load<Texture2D>("GuestBedSheet");
            safe = Content.Load<Texture2D>("Safe");
            brokenSafe = Content.Load<Texture2D>("SafeBroken");
            carpetFloor = Content.Load<Texture2D>("CarpetFloor");
            carpetStair = Content.Load<Texture2D>("CarpetStairs");
            carpetStairRailing = Content.Load<Texture2D>("CarpetStairsRailing");
            carpetStairRailingFront = Content.Load<Texture2D>("CarpetStairsRailingFront");
            counterFront = Content.Load<Texture2D>("CounterFront");
            counterTop = Content.Load<Texture2D>("CounterTop");
            dirtFloor = Content.Load<Texture2D>("DirtFloor");
            dirtHole = Content.Load<Texture2D>("DirtHole");
            grass = Content.Load<Texture2D>("Grass");
            grassStone = Content.Load<Texture2D>("GrassStoneSteps");
            grave = Content.Load<Texture2D>("GrassTombStone");
            wardrobe = Content.Load<Texture2D>("Wardrobe");
            wardrobeLeft = Content.Load<Texture2D>("WardrobeLeft");
            wardrobeRight = Content.Load<Texture2D>("WardrobeRight");
            hedge = Content.Load<Texture2D>("Hedges");
            dialogueBackground = Content.Load<Texture2D>("black");
            textFont = Content.Load<SpriteFont>("Text");
            door = Content.Load<Texture2D>("Door");
            obj = Content.Load<Texture2D>("Object");
            space = Content.Load<Texture2D>("black");
            itemPicSprite = Content.Load<Texture2D>("itemPic");
            inventoryScreen = Content.Load<Texture2D>("FinalInventory");
            pauseScreen = Content.Load<Texture2D>("PauseScreen");
            titleScreen = Content.Load<Texture2D>("FinalTitleScreen");
            invitationLetter = Content.Load<Texture2D>("InvitationNotePicture");
            watchScreen = Content.Load<Texture2D>("WatchScreen");
            instructScreen = Content.Load<Texture2D>("InstructionScreen");
            secondHandSprite = Content.Load<Texture2D>("arm");
            minuteHandSprite = Content.Load<Texture2D>("arm");

            jounralNum1 = Content.Load<Texture2D>("Journal#1");
            jounralNum2 = Content.Load<Texture2D>("Journal#2");
            jounralNum3 = Content.Load<Texture2D>("Journal#3");
            jounralNum4 = Content.Load<Texture2D>("Journal#4");
            jounralNum5 = Content.Load<Texture2D>("Journal#5");
            jounralNum6 = Content.Load<Texture2D>("Journal#6");
            jounralNum7 = Content.Load<Texture2D>("Journal#7");
            jounralNum8 = Content.Load<Texture2D>("Journal#8");
            jounralNumDescript = Content.Load<Texture2D>("JournalDescription");

            for (int count = 0; count < animation.frames.Length; count++)
            {
                frames[count] = Content.Load<Texture2D>(animation.frames[count]);
            }
            // TODO: use this.Content to load your game content here
        }
        #endregion

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        #region Update
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //secondHandSprite.

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float totalSeconds = (float)gameTime.TotalGameTime.TotalSeconds;

            //rotates second hand is off by a few millisecs
            secondsRotationAngle += elapsed / (9.7f);
            float circle = MathHelper.Pi * 2;
            secondsRotationAngle = secondsRotationAngle % circle;

            //rotate the minutes might be off by a bit
            minutesRotationAngle += elapsed / 580.6f;
            minutesRotationAngle = minutesRotationAngle % circle;

            //Calling the methods from Screen that will chsck if the player is trying to pause the game or check the inventory in addition to checking the state the screens are in 
            gameScreens.CheckScreenState();
            gameScreens.CheckPauseAndInventoryKeysPressed();

            if (gameScreens.IsInventoryScreen == true)
            {
                this.IsMouseVisible = true;
            }
            else
            {
                this.IsMouseVisible = false;
            }

            #region Update Journals
            if (gamePuzzles.ContainsItem("Journal_Desc") && !player.JournalChanged[0])
            {
                jounralNumDescript = Content.Load<Texture2D>("JournalDescription");
                player.JournalChanged[0] = true;
            }
            if (gamePuzzles.ContainsItem("Journal_1") && !player.JournalChanged[1])
            {
                jounralNum1 = Content.Load<Texture2D>("Journal#1");
                player.JournalChanged[1] = true;
            }
            if (gamePuzzles.ContainsItem("Journal_2") && !player.JournalChanged[2])
            {
                jounralNum2 = Content.Load<Texture2D>("Journal#2");
                player.JournalChanged[2] = true;
            }
            if (gamePuzzles.ContainsItem("Journal_3") && !player.JournalChanged[3])
            {
                jounralNum3 = Content.Load<Texture2D>("Journal#3");
                player.JournalChanged[3] = true;
            }
            if (gamePuzzles.ContainsItem("Journal_4") && !player.JournalChanged[4])
            {
                jounralNum4 = Content.Load<Texture2D>("Journal#4");
                player.JournalChanged[4] = true;
            }
            if (gamePuzzles.ContainsItem("Journal_5") && !player.JournalChanged[5])
            {
                jounralNum5 = Content.Load<Texture2D>("Journal#5");
                player.JournalChanged[5] = true;
            }
            if (gamePuzzles.ContainsItem("Journal_6") && !player.JournalChanged[6])
            {
                jounralNum6 = Content.Load<Texture2D>("Journal#6");
                player.JournalChanged[6] = true;
            }
            if (gamePuzzles.ContainsItem("Journal_7") && !player.JournalChanged[7])
            {
                jounralNum7 = Content.Load<Texture2D>("Journal#7");
                player.JournalChanged[7] = true;
            }
            if (gamePuzzles.ContainsItem("Journal_8") && !player.JournalChanged[8])
            {
                jounralNum8 = Content.Load<Texture2D>("Journal#8");
                player.JournalChanged[8] = true;
            }
            #endregion


            // TODO: Add your update logic here
            if (gameScreens.IsTitleScreen == false)
            {
                gameScreens.PageThroughJournal();

                if (gameScreens.IsPauseScreen == false && gameScreens.IsInventoryScreen == false && gameScreens.IsJournalScreen == false)
                {
                    if (player.CurrentRoom.Name != currentRoom.Name)
                    {
                        player.UpdateRoom(currentRoom);
                    }
                    //Changed for dialogue
                    if (speaking.DialogueLineIndicator == -1)
                    {
                        player.ProcessInput();
                    }

                    #region DialogueHandler
                    if (currentRoom.Name == "dungeonmap.txt" && !speaking.HasBegunDungeon)
                    {
                        speaking.DialogueLineIndicator = 0;
                        speaking.HasBegunDungeon = true;
                    }
                    if (speaking.DialogueLineIndicator == 7 && gameScreens.singleKeyPress(Keys.Q))
                    {
                        speaking.DialogueLineIndicator = -1;
                    }

                    if (currentRoom.Name == "lowerfoyermap.txt" && !speaking.HasBegunFoyer)
                    {
                        speaking.DialogueLineIndicator = 8;
                        speaking.HasBegunFoyer = true;
                    }
                    if (speaking.DialogueLineIndicator == 10 && gameScreens.singleKeyPress(Keys.Q))
                    {
                        speaking.DialogueLineIndicator = -1;
                    }

                    if (currentRoom.Name == "lowerbathroommap.txt" && !speaking.HasBegunBathroom)
                    {
                        speaking.DialogueLineIndicator = 11;
                        speaking.HasBegunBathroom = true;
                    }
                    if (speaking.DialogueLineIndicator == 13 && gameScreens.singleKeyPress(Keys.Q))
                    {
                        speaking.DialogueLineIndicator = -1;
                    }

                    if (currentRoom.Name == "secretroommap.txt" && !speaking.HasBegunSafeRoom)
                    {
                        speaking.DialogueLineIndicator = 14;
                        speaking.HasBegunSafeRoom = true;
                    }
                    if (speaking.DialogueLineIndicator == 18 && gameScreens.singleKeyPress(Keys.Q))
                    {
                        speaking.DialogueLineIndicator = -1;
                    }

                    if (currentRoom.Name == "kitchenmap.txt" && !speaking.HasBegunKitchen)
                    {
                        speaking.DialogueLineIndicator = 19;
                        speaking.HasBegunKitchen = true;
                    }
                    if (speaking.DialogueLineIndicator == 21 && gameScreens.singleKeyPress(Keys.Q))
                    {
                        speaking.DialogueLineIndicator = -1;
                    }

                    if (currentRoom.Name == "librarymap.txt" && !speaking.HasBegunLibrary)
                    {
                        speaking.DialogueLineIndicator = 22;
                        speaking.HasBegunLibrary = true;
                    }
                    if (speaking.DialogueLineIndicator == 23 && gameScreens.singleKeyPress(Keys.Q))
                    {
                        speaking.DialogueLineIndicator = -1;
                    }

                    if (currentRoom.Name == "guestroommap.txt" && !speaking.HasBegunGuestRoom)
                    {
                        speaking.DialogueLineIndicator = 24;
                        speaking.HasBegunGuestRoom = true;
                    }
                    if (speaking.DialogueLineIndicator == 27 && gameScreens.singleKeyPress(Keys.Q))
                    {
                        speaking.DialogueLineIndicator = -1;
                    }

                    if (currentRoom.Name == "masterbedroommmap.txt" && !speaking.HasBegunMasterRoom)
                    {
                        speaking.DialogueLineIndicator = 28;
                        speaking.HasBegunMasterRoom = true;
                    }
                    if (speaking.DialogueLineIndicator == 31 && gameScreens.singleKeyPress(Keys.Q))
                    {
                        speaking.DialogueLineIndicator = -1;
                    }

                    if (currentRoom.Name == "greenhousemmap.txt" && !speaking.HasBegunGreenHouse)
                    {
                        speaking.DialogueLineIndicator = 32;
                        speaking.HasBegunGreenHouse = true;
                    }
                    if (speaking.DialogueLineIndicator == 34 && gameScreens.singleKeyPress(Keys.Q))
                    {
                        speaking.DialogueLineIndicator = -1;
                    }

                    if (currentRoom.Name == "lowerfoyermap.txt" && !speaking.HasBegunFoyerReturn && speaking.HasBegunFoyer == true && speaking.HasBegunGreenHouse == true)
                    {
                        speaking.DialogueLineIndicator = 35;
                        speaking.HasBegunFoyerReturn = true;
                    }
                    if (speaking.DialogueLineIndicator == 42 && gameScreens.singleKeyPress(Keys.Q))
                    {
                        speaking.DialogueLineIndicator = -1;
                    }

                    if (currentRoom.Name == "studymap.txt" && !speaking.HasBegunStudy)
                    {
                        speaking.DialogueLineIndicator = 43;
                        speaking.HasBegunStudy = true;
                    }
                    if (speaking.DialogueLineIndicator == 45 && gameScreens.singleKeyPress(Keys.Q))
                    {
                        speaking.DialogueLineIndicator = -1;
                    }

                    if (currentRoom.Name == "lowerfoyermap.txt" && !speaking.HasBegunEnd && speaking.HasBegunStudy == true)
                    {
                        speaking.DialogueLineIndicator = 46;
                        speaking.HasBegunEnd = true;
                    }
                    if (speaking.DialogueLineIndicator == 46 && gameScreens.singleKeyPress(Keys.Q))
                    {
                        speaking.DialogueLineIndicator = -1;
                    }
                    #endregion
                }
            }
            //animation update mecanic
            if (count % timePerFrame == 0)
            {
                animation.playerMachine();
            }
            count++;
            floorPlan = currentRoom.Tiles;
            CheckItemCollision();
            CheckDoors();
            gamePuzzles.Seconds = totalSeconds;

            if (speaking.DialogueLineIndicator != -1)
            {
                if (gameScreens.singleKeyPress(Keys.Q))
                {
                    speaking.DialogueLineIndicator++;
                }
            }

            base.Update(gameTime);
        }
        #endregion

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        #region Draw
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            DrawFloor();
            DrawItems();
            spriteBatch.Draw(frames[animation.getFrame()], player.ImgBox, Color.White);

            //When the game starts, it will immediately draw up the title screen.
            //Then it will display an "invitation" telling the player of the setting
            #region Title Screen
            if (gameScreens.IsTitleScreen == true)
            {
                //Creating the title screen
                if (gameScreens.TitleScreenVersion == 0)
                {
                    spriteBatch.Draw(titleScreen, new Vector2(0, 0), Color.White);
                }
                else
                    //Creating the invitation screen
                    if (gameScreens.TitleScreenVersion == 1)
                    {
                        spriteBatch.Draw(invitationLetter, new Vector2(0, 0), Color.White);
                    }
            }

            if (gameScreens.IsInstructScreen == true)
            {
                spriteBatch.Draw(instructScreen, new Vector2(0, 0), Color.White);
            }
            #endregion

            #region Dialogue
            for (int i = 0; i < speaking.DialogueLines.Count; i++)
            {
                if (speaking.DialogueLineIndicator != -1)
                {
                    if (speaking.DialogueLineIndicator == i)
                    {
                        spriteBatch.Draw(dialogueBackground, new Vector2(0, 0), Color.White);
                        spriteBatch.DrawString(textFont, speaking.DialogueLines[i], new Vector2(0, 0), Color.White);
                        spriteBatch.DrawString(textFont, "(Press 'Q' to continue)", new Vector2(550, 20), Color.White);
                    }
                }
            }
            #endregion

            #region Inventory Screen
            if (gameScreens.IsInventoryScreen == true)
            {
                spriteBatch.Draw(inventoryScreen, new Vector2(0, 0), Color.White);

                if (player.Backpack.Count != 0)
                {

                    Rectangle place = new Rectangle(tempMoveX, tempMoveY, 70, 70);

                    for (int i = 0; i < player.Backpack.Count; ++i)
                    {

                        if (!player.Backpack[i].ImgName.Equals("Page"))
                        {
                            spriteBatch.Draw(ItemPics[player.Backpack[i].ImgIndex], place, Color.White);
                            //tempMoveX += 100;// tempMoveY += 200;
                            //rectangles are 100 wide by 75 tall
                            place.X += 100;
                            if (place.X >= 800)
                            {
                                place.X = tempMoveX;
                                place.Y += 75;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Journal Screens
            if (gameScreens.IsJournalScreen == true)
            {
                if (gameScreens.JournalPageNum == 0)
                {
                    spriteBatch.Draw(jounralNumDescript, new Vector2(0, 0), Color.White);
                }
                if (gameScreens.JournalPageNum == 1)
                {
                    spriteBatch.Draw(jounralNum1, new Vector2(0, 0), Color.White);
                }
                if (gameScreens.JournalPageNum == 2)
                {
                    spriteBatch.Draw(jounralNum2, new Vector2(0, 0), Color.White);
                }
                if (gameScreens.JournalPageNum == 3)
                {
                    spriteBatch.Draw(jounralNum3, new Vector2(0, 0), Color.White);
                }
                if (gameScreens.JournalPageNum == 4)
                {
                    spriteBatch.Draw(jounralNum4, new Vector2(0, 0), Color.White);
                }
                if (gameScreens.JournalPageNum == 5)
                {
                    spriteBatch.Draw(jounralNum5, new Vector2(0, 0), Color.White);
                }
                if (gameScreens.JournalPageNum == 6)
                {
                    spriteBatch.Draw(jounralNum6, new Vector2(0, 0), Color.White);
                }
                if (gameScreens.JournalPageNum == 7)
                {
                    spriteBatch.Draw(jounralNum7, new Vector2(0, 0), Color.White);
                }
                if (gameScreens.JournalPageNum == 8)
                {
                    spriteBatch.Draw(jounralNum8, new Vector2(0, 0), Color.White);
                }
            }
            #endregion

            #region Watch Screen
            if (gameScreens.IsWatchScreen == true)
            {
                spriteBatch.Draw(watchScreen, new Rectangle(5, 5, 125, 125), Color.White);

                //Viewport view = graphics.GraphicsDevice.Viewport;
                origin.X = 20;
                origin.Y = secondHandSprite.Height;
                changeLoc.X = 143 / 2.0f - 5;
                changeLoc.Y = 23 / 2.0f + 70;

                spriteBatch.Draw(secondHandSprite, changeLoc, null, Color.White, secondsRotationAngle, origin, .18f, SpriteEffects.None, 0f);
                spriteBatch.Draw(minuteHandSprite, changeLoc, null, Color.White, minutesRotationAngle, origin, .21f, SpriteEffects.None, 0f);
            }
            #endregion

            #region Pause Screen
            if (gameScreens.IsPauseScreen == true)
            {
                spriteBatch.Draw(pauseScreen, new Vector2(0, 0), Color.White);
            }
            #endregion

            spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion

        #region  DrawFloor
        private void DrawFloor()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Rectangle spot = floorPlan[i, j].Box;

                    if (floorPlan[i, j].Id == 'W')
                        spriteBatch.Draw(wall, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'f')
                        spriteBatch.Draw(floor, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'O')
                        spriteBatch.Draw(obj, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'S')
                        spriteBatch.Draw(stoneWall, spot, Color.White);
                    else if (floorPlan[i, j].Id == 's')
                        spriteBatch.Draw(stoneFloor, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'b')
                        spriteBatch.Draw(barWall, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'B')
                        spriteBatch.Draw(barDoor, spot, Color.White);
                    else if (floorPlan[i, j].Id == 't')
                        spriteBatch.Draw(tileFloor, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'V')
                        spriteBatch.Draw(vent, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'v')
                        spriteBatch.Draw(openVent, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'K')
                        spriteBatch.Draw(sink, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'F')
                        spriteBatch.Draw(freezer, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'R')
                        spriteBatch.Draw(fridge, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'C')
                        spriteBatch.Draw(cabinet, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'L')
                        spriteBatch.Draw(tableBack, spot, Color.White);
                    else if (floorPlan[i, j].Id == '<')
                        spriteBatch.Draw(tableCorner, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'X')
                        spriteBatch.Draw(tableFront, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'k')
                        spriteBatch.Draw(bookShelf, spot, Color.White);
                    else if (floorPlan[i, j].Id == '1')
                        spriteBatch.Draw(bookShelf, spot, Color.White);
                    else if (floorPlan[i, j].Id == '2')
                        spriteBatch.Draw(bookShelf, spot, Color.White);
                    else if (floorPlan[i, j].Id == '3')
                        spriteBatch.Draw(bookShelf, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'P')
                        spriteBatch.Draw(guestBedFrontRight, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'p')
                        spriteBatch.Draw(guestBedBrokenPost, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'Q')
                        spriteBatch.Draw(guestBedFrontLeft, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'N')
                        spriteBatch.Draw(guestBedFront, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'H')
                        spriteBatch.Draw(guestBedSheet, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'Z')
                        spriteBatch.Draw(safe, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'z')
                        spriteBatch.Draw(brokenSafe, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'h')
                        spriteBatch.Draw(bedSheet, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'n')
                        spriteBatch.Draw(bedFront, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'l')
                        spriteBatch.Draw(bedFrontLeft, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'r')
                        spriteBatch.Draw(bedFrontRight, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'e')
                        spriteBatch.Draw(bedTop, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'c')
                        spriteBatch.Draw(carpetFloor, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'a')
                        spriteBatch.Draw(carpetStair, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'j')
                        spriteBatch.Draw(carpetStairRailing, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'J')
                        spriteBatch.Draw(carpetStairRailingFront, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'A')
                        spriteBatch.Draw(carpetStair, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'M')
                        spriteBatch.Draw(wardrobeLeft, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'm')
                        spriteBatch.Draw(wardrobeRight, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'w')
                        spriteBatch.Draw(wardrobe, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'g')
                        spriteBatch.Draw(counterFront, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'G')
                        spriteBatch.Draw(counterTop, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'd')
                        spriteBatch.Draw(dirtFloor, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'i')
                        spriteBatch.Draw(grass, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'I')
                        spriteBatch.Draw(grassStone, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'y')
                        spriteBatch.Draw(hedge, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'Y')
                        spriteBatch.Draw(dirtHole, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'U')
                        spriteBatch.Draw(grave, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'u')
                        spriteBatch.Draw(door, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'q')
                        spriteBatch.Draw(stuffedVent, spot, Color.White);
                    else if (floorPlan[i, j].Id == 'D')
                        spriteBatch.Draw(door, spot, Color.White);
                    else
                        spriteBatch.Draw(space, spot, Color.White);
                }
            }
        }
        #endregion

        #region DrawItems
        private void DrawItems()
        {
            foreach (Item item in world.AllItems)
            {
                if (!item.pItemIsPickedUp && item.RoomItIsIn.Equals(currentRoom))
                {
                    spriteBatch.Draw(ItemPics[item.ImgIndex], item.Box, Color.White);
                }
            }
        }
        #endregion

        #region CheckItemCollision

        private void CheckItemCollision()
        {
            foreach (Item item in world.AllItems)
            {
                if (item.RoomItIsIn.Equals(currentRoom))
                {
                    if (player.Box.Intersects(item.Box))
                        player.PickUpItem(item);
                }
            }
        }

        #endregion

        //CheckDoors checks collision between player and doors and switches the current room based on the door's Next property.
        #region CheckDoors
        private void CheckDoors()
        {
            foreach (Door door in currentRoom.DoorArray)
            {
                if (!door.Locked)
                {
                    Rectangle r = door.Box;
                    r.Inflate(5, 5);
                    if (player.Box.Intersects(r) && player.IsInteracting)
                    {
                        currentRoom = door.Next;
                        player.MoveThroughDoor(door);
                        break;
                    }
                }
            }
        }
        #endregion

    }
}
