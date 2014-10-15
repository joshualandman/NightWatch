using System;
using System.Collections.Generic;
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
    class AnimatePlayer
    {
        enum WalkingState
        {
            moveleft,
            moveright,
            moveforward,
            moveback,
            moveFR,
            moveFL,
            moveBR,
            moveBL,
            moveleft1,
            moveright1,
            moveforward1,
            moveback1,
            moveFR1,
            moveFL1,
            moveBR1,
            moveBL1,
            moveleft2,
            moveright2,
            moveforward2,
            moveback2,
            moveFR2,
            moveFL2,
            moveBR2,
            moveBL2,
            moveleft3,
            moveright3,
            moveforward3,
            moveback3,
            moveFR3,
            moveFL3,
            moveBR3,
            moveBL3,
            faceLeft,
            faceRight,
            faceForward,
            faceBack,
            faceFR,
            faceFL,
            faceBR,
            faceBL,
        }
        WalkingState Frame;
        public String[] frames = new String[40];

        public AnimatePlayer()
        {
            frames[0] = "Frames//LeftWalk";
            frames[1] = "Frames//RightWalk";
            frames[2] = "Frames//FrontWalk";
            frames[3] = "Frames//BackWalk";
            frames[4] = "Frames//FrontRightWalk";
            frames[5] = "Frames//FrontLeftWalk";
            frames[6] = "Frames//BackRightWalk";
            frames[7] = "Frames//BackLeftWalk";
            frames[8] = "Frames//LeftWalk1";
            frames[9] = "Frames//RightWalk1";
            frames[10] = "Frames//FrontWalk1";
            frames[11] = "Frames//BackWalk1";
            frames[12] = "Frames//FrontRightWalk1";
            frames[13] = "Frames//FrontLeftWalk1";
            frames[14] = "Frames//BackRightWalk1";
            frames[15] = "Frames//BackWalk1";
            frames[16] = "Frames//LeftWalk2";
            frames[17] = "Frames//RightWalk2";
            frames[18] = "Frames//FrontWalk2";
            frames[19] = "Frames//BackWalk2";
            frames[20] = "Frames//FrontRightWalk2";
            frames[21] = "Frames//FrontLeftWalk2";
            frames[22] = "Frames//BackRightWalk2";
            frames[23] = "Frames//BackLeftWalk2";
            frames[24] = "Frames//LeftWalk3";
            frames[25] = "Frames//RightWalk3";
            frames[26] = "Frames//FrontWalk3";
            frames[27] = "Frames//BackWalk3";
            frames[28] = "Frames//FrontRightWalk3";
            frames[29] = "Frames//FrontLeftWalk3";
            frames[30] = "Frames//BackRightWalk3";
            frames[31] = "Frames//BackLeftWalk3";
            frames[32] = "Frames//LeftStand";
            frames[33] = "Frames//RightStand";
            frames[34] = "Frames//FrontStand";
            frames[35] = "Frames//BackStand";
            frames[36] = "Frames//FrontRightStand";
            frames[37] = "Frames//FrontLeftStand";
            frames[38] = "Frames//BackRightStand";
            frames[39] = "Frames//BackLeftStand";
        }
        public void playerMachine()
        {
            KeyboardState key;
            key = Keyboard.GetState();

            if (key.IsKeyUp(Keys.Left) && key.IsKeyUp(Keys.Right) && key.IsKeyUp(Keys.Up) && key.IsKeyUp(Keys.Down))//standing positions
            {
                switch (Frame)
                {
                    case WalkingState.moveleft: Frame = WalkingState.faceLeft;
                        break;
                    case WalkingState.moveleft1: Frame = WalkingState.faceLeft;
                        break;
                    case WalkingState.moveleft2: Frame = WalkingState.faceLeft;
                        break;
                    case WalkingState.moveleft3: Frame = WalkingState.faceLeft;
                        break;

                    case WalkingState.moveright: Frame = WalkingState.faceRight;
                        break;
                    case WalkingState.moveright1: Frame = WalkingState.faceRight;
                        break;
                    case WalkingState.moveright2: Frame = WalkingState.faceRight;
                        break;
                    case WalkingState.moveright3: Frame = WalkingState.faceRight;
                        break;

                    case WalkingState.moveforward: Frame = WalkingState.faceForward;
                        break;
                    case WalkingState.moveforward1: Frame = WalkingState.faceForward;
                        break;
                    case WalkingState.moveforward2: Frame = WalkingState.faceForward;
                        break;
                    case WalkingState.moveforward3: Frame = WalkingState.faceForward;
                        break;

                    case WalkingState.moveback: Frame = WalkingState.faceBack;
                        break;
                    case WalkingState.moveback1: Frame = WalkingState.faceBack;
                        break;
                    case WalkingState.moveback2: Frame = WalkingState.faceBack;
                        break;
                    case WalkingState.moveback3: Frame = WalkingState.faceBack;
                        break;

                    case WalkingState.moveFR: Frame = WalkingState.faceFR;
                        break;
                    case WalkingState.moveFR1: Frame = WalkingState.faceFR;
                        break;
                    case WalkingState.moveFR2: Frame = WalkingState.faceFR;
                        break;
                    case WalkingState.moveFR3: Frame = WalkingState.faceFR;
                        break;

                    case WalkingState.moveFL: Frame = WalkingState.faceFL;
                        break;
                    case WalkingState.moveFL1: Frame = WalkingState.faceFL;
                        break;
                    case WalkingState.moveFL2: Frame = WalkingState.faceFL;
                        break;
                    case WalkingState.moveFL3: Frame = WalkingState.faceFL;
                        break;

                    case WalkingState.moveBR: Frame = WalkingState.faceBR;
                        break;
                    case WalkingState.moveBR1: Frame = WalkingState.faceBR;
                        break;
                    case WalkingState.moveBR2: Frame = WalkingState.faceBR;
                        break;
                    case WalkingState.moveBR3: Frame = WalkingState.faceBR;
                        break;

                    case WalkingState.moveBL: Frame = WalkingState.faceBL;
                        break;
                    case WalkingState.moveBL1: Frame = WalkingState.faceBL;
                        break;
                    case WalkingState.moveBL2: Frame = WalkingState.faceBL;
                        break;
                    case WalkingState.moveBL3: Frame = WalkingState.faceBL;
                        break;
                }
            }
            else if (key.IsKeyDown(Keys.Left) && key.IsKeyUp(Keys.Up) && key.IsKeyUp(Keys.Down))//move left
            {
                switch (Frame)
                {
                    //Stepping one direction
                    case WalkingState.moveleft: Frame = WalkingState.moveleft1;
                        break;
                    case WalkingState.moveleft1: Frame = WalkingState.moveleft2;
                        break;
                    case WalkingState.moveleft2: Frame = WalkingState.moveleft3;
                        break;
                    case WalkingState.moveleft3: Frame = WalkingState.moveleft;
                        break;

                    //change direction
                    case WalkingState.moveright: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveright1: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveright2: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveright3: Frame = WalkingState.moveleft;
                        break;

                    case WalkingState.moveforward: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveforward1: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveforward2: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveforward3: Frame = WalkingState.moveleft;
                        break;

                    case WalkingState.moveback: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveback1: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveback2: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveback3: Frame = WalkingState.moveleft;
                        break;

                    case WalkingState.moveFR: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveFR1: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveFR2: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveFR3: Frame = WalkingState.moveleft;
                        break;

                    case WalkingState.moveFL: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveFL1: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveFL2: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveFL3: Frame = WalkingState.moveleft;
                        break;

                    case WalkingState.moveBR: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveBR1: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveBR2: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveBR3: Frame = WalkingState.moveleft;
                        break;

                    case WalkingState.moveBL: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveBL1: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveBL2: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.moveBL3: Frame = WalkingState.moveleft;
                        break;

                    //from stop
                    case WalkingState.faceLeft: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.faceRight: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.faceForward: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.faceBack: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.faceBL: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.faceBR: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.faceFL: Frame = WalkingState.moveleft;
                        break;
                    case WalkingState.faceFR: Frame = WalkingState.moveleft;
                        break;
                }
            }
            else if (key.IsKeyDown(Keys.Right) && key.IsKeyUp(Keys.Up) && key.IsKeyUp(Keys.Down))//move right
            {
                switch (Frame)
                {
                    //Stepping one direction
                    case WalkingState.moveright: Frame = WalkingState.moveright1;
                        break;
                    case WalkingState.moveright1: Frame = WalkingState.moveright2;
                        break;
                    case WalkingState.moveright2: Frame = WalkingState.moveright3;
                        break;
                    case WalkingState.moveright3: Frame = WalkingState.moveright;
                        break;

                    //change direction
                    case WalkingState.moveleft: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveleft1: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveleft2: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveleft3: Frame = WalkingState.moveright;
                        break;

                    case WalkingState.moveforward: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveforward1: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveforward2: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveforward3: Frame = WalkingState.moveright;
                        break;

                    case WalkingState.moveback: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveback1: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveback2: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveback3: Frame = WalkingState.moveright;
                        break;

                    case WalkingState.moveFR: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveFR1: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveFR2: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveFR3: Frame = WalkingState.moveright;
                        break;

                    case WalkingState.moveFL: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveFL1: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveFL2: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveFL3: Frame = WalkingState.moveright;
                        break;

                    case WalkingState.moveBR: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveBR1: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveBR2: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveBR3: Frame = WalkingState.moveright;
                        break;

                    case WalkingState.moveBL: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveBL1: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveBL2: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.moveBL3: Frame = WalkingState.moveright;
                        break;

                    //from stop
                    case WalkingState.faceLeft: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.faceRight: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.faceForward: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.faceBack: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.faceBL: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.faceBR: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.faceFL: Frame = WalkingState.moveright;
                        break;
                    case WalkingState.faceFR: Frame = WalkingState.moveright;
                        break;
                }
            }
            else if (key.IsKeyDown(Keys.Down) && key.IsKeyUp(Keys.Left) && key.IsKeyUp(Keys.Right))//move forward
            {
                switch (Frame)
                {
                    //Stepping one direction
                    case WalkingState.moveforward: Frame = WalkingState.moveforward1;
                        break;
                    case WalkingState.moveforward1: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveforward2: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveforward3: Frame = WalkingState.moveforward;
                        break;

                    //change direction
                    case WalkingState.moveleft: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveleft1: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveleft2: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveleft3: Frame = WalkingState.moveforward;
                        break;

                    case WalkingState.moveright: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveright1: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveright2: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveright3: Frame = WalkingState.moveforward;
                        break;

                    case WalkingState.moveback: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveback1: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveback2: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveback3: Frame = WalkingState.moveforward;
                        break;

                    case WalkingState.moveFR: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveFR1: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveFR2: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveFR3: Frame = WalkingState.moveforward;
                        break;

                    case WalkingState.moveFL: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveFL1: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveFL2: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveFL3: Frame = WalkingState.moveforward;
                        break;

                    case WalkingState.moveBR: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveBR1: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveBR2: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveBR3: Frame = WalkingState.moveforward;
                        break;

                    case WalkingState.moveBL: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveBL1: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveBL2: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.moveBL3: Frame = WalkingState.moveforward;
                        break;

                    //from stop
                    case WalkingState.faceLeft: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.faceRight: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.faceForward: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.faceBack: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.faceBL: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.faceBR: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.faceFL: Frame = WalkingState.moveforward;
                        break;
                    case WalkingState.faceFR: Frame = WalkingState.moveforward;
                        break;
                }
            }
            else if (key.IsKeyDown(Keys.Up) && key.IsKeyUp(Keys.Left) && key.IsKeyUp(Keys.Right))//move back
            {
                switch (Frame)
                {
                    //Stepping one direction
                    case WalkingState.moveback: Frame = WalkingState.moveback1;
                        break;
                    case WalkingState.moveback1: Frame = WalkingState.moveback2;
                        break;
                    case WalkingState.moveback2: Frame = WalkingState.moveback3;
                        break;
                    case WalkingState.moveback3: Frame = WalkingState.moveback;
                        break;

                    //change direction
                    case WalkingState.moveleft: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveleft1: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveleft2: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveleft3: Frame = WalkingState.moveback;
                        break;

                    case WalkingState.moveright: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveright1: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveright2: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveright3: Frame = WalkingState.moveback;
                        break;

                    case WalkingState.moveforward: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveforward1: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveforward2: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveforward3: Frame = WalkingState.moveback;
                        break;

                    case WalkingState.moveFR: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveFR1: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveFR2: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveFR3: Frame = WalkingState.moveback;
                        break;

                    case WalkingState.moveFL: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveFL1: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveFL2: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveFL3: Frame = WalkingState.moveback;
                        break;

                    case WalkingState.moveBR: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveBR1: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveBR2: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveBR3: Frame = WalkingState.moveback;
                        break;

                    case WalkingState.moveBL: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveBL1: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveBL2: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.moveBL3: Frame = WalkingState.moveback;
                        break;

                    //from stop
                    case WalkingState.faceLeft: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.faceRight: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.faceForward: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.faceBack: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.faceBL: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.faceBR: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.faceFL: Frame = WalkingState.moveback;
                        break;
                    case WalkingState.faceFR: Frame = WalkingState.moveback;
                        break;
                }
            }
            else if (key.IsKeyDown(Keys.Down) && key.IsKeyDown(Keys.Right))//move front right
            {
                switch (Frame)
                {
                    //Stepping one direction
                    case WalkingState.moveFR: Frame = WalkingState.moveFR1;
                        break;
                    case WalkingState.moveFR1: Frame = WalkingState.moveFR2;
                        break;
                    case WalkingState.moveFR2: Frame = WalkingState.moveFR3;
                        break;
                    case WalkingState.moveFR3: Frame = WalkingState.moveFR;
                        break;

                    //change direction
                    case WalkingState.moveleft: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveleft1: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveleft2: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveleft3: Frame = WalkingState.moveFR;
                        break;

                    case WalkingState.moveright: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveright1: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveright2: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveright3: Frame = WalkingState.moveFR;
                        break;

                    case WalkingState.moveforward: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveforward1: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveforward2: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveforward3: Frame = WalkingState.moveFR;
                        break;

                    case WalkingState.moveback: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveback1: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveback2: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveback3: Frame = WalkingState.moveFR;
                        break;

                    case WalkingState.moveFL: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveFL1: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveFL2: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveFL3: Frame = WalkingState.moveFR;
                        break;

                    case WalkingState.moveBR: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveBR1: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveBR2: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveBR3: Frame = WalkingState.moveFR;
                        break;

                    case WalkingState.moveBL: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveBL1: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveBL2: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.moveBL3: Frame = WalkingState.moveFR;
                        break;

                    //from stop
                    case WalkingState.faceLeft: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.faceRight: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.faceForward: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.faceBack: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.faceBL: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.faceBR: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.faceFL: Frame = WalkingState.moveFR;
                        break;
                    case WalkingState.faceFR: Frame = WalkingState.moveFR;
                        break;
                }
            }
            else if (key.IsKeyDown(Keys.Down) && key.IsKeyDown(Keys.Left))//move front left
            {
                switch (Frame)
                {
                    //Stepping one direction
                    case WalkingState.moveFL: Frame = WalkingState.moveFL1;
                        break;
                    case WalkingState.moveFL1: Frame = WalkingState.moveFL2;
                        break;
                    case WalkingState.moveFL2: Frame = WalkingState.moveFL3;
                        break;
                    case WalkingState.moveFL3: Frame = WalkingState.moveFL;
                        break;

                    //change direction
                    case WalkingState.moveleft: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveleft1: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveleft2: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveleft3: Frame = WalkingState.moveFL;
                        break;

                    case WalkingState.moveright: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveright1: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveright2: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveright3: Frame = WalkingState.moveFL;
                        break;

                    case WalkingState.moveforward: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveforward1: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveforward2: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveforward3: Frame = WalkingState.moveFL;
                        break;

                    case WalkingState.moveback: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveback1: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveback2: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveback3: Frame = WalkingState.moveFL;
                        break;

                    case WalkingState.moveFR: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveFR1: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveFR2: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveFR3: Frame = WalkingState.moveFL;
                        break;

                    case WalkingState.moveBR: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveBR1: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveBR2: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveBR3: Frame = WalkingState.moveFL;
                        break;

                    case WalkingState.moveBL: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveBL1: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveBL2: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.moveBL3: Frame = WalkingState.moveFL;
                        break;

                    //from stop
                    case WalkingState.faceLeft: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.faceRight: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.faceForward: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.faceBack: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.faceBL: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.faceBR: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.faceFL: Frame = WalkingState.moveFL;
                        break;
                    case WalkingState.faceFR: Frame = WalkingState.moveFL;
                        break;
                }
            }


            else if (key.IsKeyDown(Keys.Up) && key.IsKeyDown(Keys.Right))//move back right
            {
                switch (Frame)
                {
                    //Stepping one direction
                    case WalkingState.moveBR: Frame = WalkingState.moveBR1;
                        break;
                    case WalkingState.moveBR1: Frame = WalkingState.moveBR2;
                        break;
                    case WalkingState.moveBR2: Frame = WalkingState.moveBR3;
                        break;
                    case WalkingState.moveBR3: Frame = WalkingState.moveBR;
                        break;

                    //change direction
                    case WalkingState.moveleft: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveleft1: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveleft2: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveleft3: Frame = WalkingState.moveBR;
                        break;

                    case WalkingState.moveright: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveright1: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveright2: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveright3: Frame = WalkingState.moveBR;
                        break;

                    case WalkingState.moveforward: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveforward1: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveforward2: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveforward3: Frame = WalkingState.moveBR;
                        break;

                    case WalkingState.moveback: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveback1: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveback2: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveback3: Frame = WalkingState.moveBR;
                        break;

                    case WalkingState.moveFL: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveFL1: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveFL2: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveFL3: Frame = WalkingState.moveBR;
                        break;

                    case WalkingState.moveFR: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveFR1: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveFR2: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveFR3: Frame = WalkingState.moveBR;
                        break;

                    case WalkingState.moveBL: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveBL1: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveBL2: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.moveBL3: Frame = WalkingState.moveBR;
                        break;

                    //from stop
                    case WalkingState.faceLeft: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.faceRight: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.faceForward: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.faceBack: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.faceBL: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.faceBR: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.faceFL: Frame = WalkingState.moveBR;
                        break;
                    case WalkingState.faceFR: Frame = WalkingState.moveBR;
                        break;
                }
            }
            else if (key.IsKeyDown(Keys.Up) && key.IsKeyDown(Keys.Left))//move back left
            {
                switch (Frame)
                {
                    //Stepping one direction
                    case WalkingState.moveBL: Frame = WalkingState.moveBL1;
                        break;
                    case WalkingState.moveBL1: Frame = WalkingState.moveBL2;
                        break;
                    case WalkingState.moveBL2: Frame = WalkingState.moveBL3;
                        break;
                    case WalkingState.moveBL3: Frame = WalkingState.moveBL;
                        break;

                    //change direction
                    case WalkingState.moveleft: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveleft1: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveleft2: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveleft3: Frame = WalkingState.moveBL;
                        break;

                    case WalkingState.moveright: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveright1: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveright2: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveright3: Frame = WalkingState.moveBL;
                        break;

                    case WalkingState.moveforward: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveforward1: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveforward2: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveforward3: Frame = WalkingState.moveBL;
                        break;

                    case WalkingState.moveback: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveback1: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveback2: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveback3: Frame = WalkingState.moveBL;
                        break;

                    case WalkingState.moveFL: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveFL1: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveFL2: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveFL3: Frame = WalkingState.moveBL;
                        break;

                    case WalkingState.moveFR: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveFR1: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveFR2: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveFR3: Frame = WalkingState.moveBL;
                        break;

                    case WalkingState.moveBR: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveBR1: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveBR2: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.moveBR3: Frame = WalkingState.moveBL;
                        break;

                    //from stop
                    case WalkingState.faceLeft: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.faceRight: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.faceForward: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.faceBack: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.faceBL: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.faceBR: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.faceFL: Frame = WalkingState.moveBL;
                        break;
                    case WalkingState.faceFR: Frame = WalkingState.moveBL;
                        break;
                }
            }
        }
        public int getFrame()
        {
            int img = 0;
            switch (Frame)
            {
                case WalkingState.moveleft: img = 0; break;
                case WalkingState.moveright: img = 1; break;
                case WalkingState.moveforward: img = 2; break;
                case WalkingState.moveback: img = 3; break;
                case WalkingState.moveFR: img = 4; break;
                case WalkingState.moveFL: img = 5; break;
                case WalkingState.moveBR: img = 6; break;
                case WalkingState.moveBL: img = 7; break;
                case WalkingState.moveleft1: img = 8; break;
                case WalkingState.moveright1: img = 9; break;
                case WalkingState.moveforward1: img = 10; break;
                case WalkingState.moveback1: img = 11; break;
                case WalkingState.moveFR1: img = 12; break;
                case WalkingState.moveFL1: img = 13; break;
                case WalkingState.moveBR1: img = 14; break;
                case WalkingState.moveBL1: img = 15; break;
                case WalkingState.moveleft2: img = 16; break;
                case WalkingState.moveright2: img = 17; break;
                case WalkingState.moveforward2: img = 18; break;
                case WalkingState.moveback2: img = 19; break;
                case WalkingState.moveFR2: img = 20; break;
                case WalkingState.moveFL2: img = 21; break;
                case WalkingState.moveBR2: img = 22; break;
                case WalkingState.moveBL2: img = 23; break;
                case WalkingState.moveleft3: img = 24; break;
                case WalkingState.moveright3: img = 25; break;
                case WalkingState.moveforward3: img = 26; break;
                case WalkingState.moveback3: img = 27; break;
                case WalkingState.moveFR3: img = 28; break;
                case WalkingState.moveFL3: img = 29; break;
                case WalkingState.moveBR3: img = 30; break;
                case WalkingState.moveBL3: img = 31; break;
                case WalkingState.faceLeft: img = 32; break;
                case WalkingState.faceRight: img = 33; break;
                case WalkingState.faceForward: img = 34; break;
                case WalkingState.faceBack: img = 35; break;
                case WalkingState.faceFR: img = 36; break;
                case WalkingState.faceFL: img = 37; break;
                case WalkingState.faceBR: img = 38; break;
                case WalkingState.faceBL: img = 39; break;
            }
            return img;
        }
    }
}
