using FinchAPI;
using System;

namespace Finch_Starter
{

    // *************************************************************
    //
    // Title:            Finch Control - The Talent Show
    // Description:      Application which interacts with the user
    //                   to operate the Finch Robot's talent show.
    // Application Type: Console
    // Author:           Smith, Nathan C
    // Date Created:     2/14/2021
    // Last Revised:     2/20/2021
    //
    // *************************************************************

    class Program
    {

        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();

            MainMenuScreen();

            DisplayClosingScreen();
        }

        #region MAIN MENU

        /// <summary>
        /// Main Menu Screen
        /// </summary>
        static void MainMenuScreen()
        {
            Console.Clear();
            Console.CursorVisible = true;

            Finch finchRobot;
            finchRobot = new Finch();

            bool quitApplication = false;
            string menuChoice;

            do
            {
                Console.WriteLine();
                DisplayHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine();
                Console.WriteLine("\tA) Connect Finch Robot");
                Console.WriteLine();
                Console.WriteLine("\tB) Talent Show");
                Console.WriteLine();
                Console.WriteLine("\tC) Data Recorder");
                Console.WriteLine();
                Console.WriteLine("\tD) Alarm System");
                Console.WriteLine();
                Console.WriteLine("\tE) User Programming");
                Console.WriteLine();
                Console.WriteLine("\tF) Disconnect Finch Robot");
                Console.WriteLine();
                Console.WriteLine("\tG) Quit Application");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\t\tEnter Choice: ");
                menuChoice = Console.ReadLine().Trim().ToUpper();

                //
                // process and validate user menu choice
                //
                switch (menuChoice)
                {
                    case "A":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "B":
                        DisplayTalentShowMainMenu(finchRobot);
                        break;

                    case "C":
                        DisplayUnderWorkMessage();
                        break;

                    case "D":
                        DisplayUnderWorkMessage();
                        break;

                    case "E":
                        DisplayUnderWorkMessage();
                        break;

                    case "F":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "G":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter from A - G in the menu choice.");
                        DisplayContinuePropmt();
                        break;
                }
            } while (!quitApplication);  

        }

        #endregion

        #region TALENT SHOW

        /// <summary>
        /// Display Talent Show Menu
        /// </summary>
        static void DisplayTalentShowMainMenu(Finch finchRobot)
        {
            Console.Clear();
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string userResonse;
            int menuChoice;

            do
            {
                DisplayHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine();
                Console.WriteLine("\t1) Light and Sound");
                Console.WriteLine();
                Console.WriteLine("\t2) Dance");
                Console.WriteLine();
                Console.WriteLine("\t3) Mixing it up");
                Console.WriteLine();
                Console.WriteLine("\t4) Return to Main Menu");
                Console.WriteLine();
                Console.WriteLine();
                
                //
                // validate menu choice if not an int
                //
                bool validResponse;
                do
                {
                    validResponse = true;
                    Console.Write("\t\tEnter Choice: ");
                    userResonse = Console.ReadLine().Trim();

                    if (!int.TryParse(userResonse, out menuChoice))
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a whole number from 1 - 4.");
                        Console.WriteLine();

                        validResponse = false;
                    }
                } while (!validResponse);
                
                //
                // validate if menu choice is or isn't an int from 1 -4
                //
                switch (menuChoice)
                {
                    case 1:
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case 2:
                        TalentShowDisplayDance(finchRobot);
                        break;

                    case 3:
                        TalentShowDisplayMixItUp(finchRobot);
                        break;

                    case 4:
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a number from 1 - 4 in the menu choice.");
                        DisplayContinuePropmt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// Talent Show Light and Sound Screen
        /// </summary>
        /// <param name="finchRobot"></param>
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.Clear();
            Console.CursorVisible = false;

            DisplayHeader("Light and Sound");

            Console.WriteLine();
            Console.WriteLine("\tThe Finch Robot will now play part Darth Vader's Theme Song 'The Imperial March'!");
            DisplayContinuePropmt();

            //
            // vader theme song with red LED
            //
            for (int lightLevel = 0; lightLevel < 255; lightLevel++)
            {
                finchRobot.setLED(lightLevel, 0, 0);
            }

            // first line
            finchRobot.noteOn(880);
            finchRobot.wait(600);
            finchRobot.noteOff();

            finchRobot.noteOn(880);
            finchRobot.wait(600);
            finchRobot.noteOff();

            finchRobot.noteOn(880);
            finchRobot.wait(600);
            finchRobot.noteOff();

            finchRobot.noteOn(698);
            finchRobot.wait(400);
            finchRobot.noteOff();

            finchRobot.noteOn(523);
            finchRobot.wait(200);
            finchRobot.noteOff();

            finchRobot.noteOn(880);
            finchRobot.wait(600);
            finchRobot.noteOff();

            finchRobot.noteOn(698);
            finchRobot.wait(400);
            finchRobot.noteOff();

            finchRobot.noteOn(523);
            finchRobot.wait(200);
            finchRobot.noteOff();

            finchRobot.noteOn(880);
            finchRobot.wait(1000);
            finchRobot.noteOff();

            // second line
            finchRobot.noteOn(659);
            finchRobot.wait(600);
            finchRobot.noteOff();

            finchRobot.noteOn(659);
            finchRobot.wait(600);
            finchRobot.noteOff();

            finchRobot.noteOn(659);
            finchRobot.wait(600);
            finchRobot.noteOff();

            finchRobot.noteOn(739);
            finchRobot.wait(400);
            finchRobot.noteOff();

            finchRobot.noteOn(523);
            finchRobot.wait(200);
            finchRobot.noteOff();

            finchRobot.noteOn(932);
            finchRobot.wait(600);
            finchRobot.noteOff();

            finchRobot.noteOn(698);
            finchRobot.wait(400);
            finchRobot.noteOff();

            finchRobot.noteOn(523);
            finchRobot.wait(200);
            finchRobot.noteOff();

            finchRobot.noteOn(880);
            finchRobot.wait(1000);
            finchRobot.noteOff();

            for (int lightLevel = 255; lightLevel > 0; lightLevel--)
            {
                finchRobot.setLED(lightLevel, 0, 0);
            }

            Console.WriteLine();
            DisplayTalentShowMenuPrompt();
        }

        /// <summary>
        /// Talent Show Dance Screen
        /// </summary>
        /// <param name="finchRobot"></param>
        static void TalentShowDisplayDance(Finch finchRobot)
        {
            Console.Clear();
            Console.CursorVisible = false;

            DisplayHeader("Dance");

            Console.WriteLine();
            Console.WriteLine("\tThe Finch Robot will now perfom two mini dances!");
            Console.WriteLine("\tPlease make sure the Finch is on a solid surface with some space.");
            Console.WriteLine();

            DisplayContinuePropmt();
            Console.WriteLine();

            // do figure 8
            finchRobot.setMotors(255, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(255, 75);
            finchRobot.wait(1400);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(255, 255);
            finchRobot.wait(800);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(95, 255);
            finchRobot.wait(1900);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(255, 255);
            finchRobot.wait(600);
            finchRobot.setMotors(0, 0);

            Console.WriteLine();
            Console.WriteLine("\t'The Figure Eight'");
            Console.WriteLine();
            Console.WriteLine(" Please re-adjust the Finch with space behind it for the final dance move.");
            Console.WriteLine();
            DisplayContinuePropmt();
            Console.WriteLine();

            // do moonwalk
            finchRobot.setMotors(-180, -50);
            finchRobot.wait(400);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(-50, -210);
            finchRobot.wait(400);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(-200, -50);
            finchRobot.wait(400);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(-50, -200);
            finchRobot.wait(400);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(-200, -50);
            finchRobot.wait(400);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(-50, -200);
            finchRobot.wait(400);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(-200, -50);
            finchRobot.wait(400);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(-50, -200);
            finchRobot.wait(400);
            finchRobot.setMotors(0, 0);


            Console.WriteLine();
            Console.WriteLine("\t'The Moonwalk'");
            Console.WriteLine();
            Console.WriteLine();
            DisplayTalentShowMenuPrompt();
        }

        /// <summary>
        /// Talent Show Mixing it Up
        /// </summary>
        /// <param name="finchRobot"></param>
        static void TalentShowDisplayMixItUp(Finch finchRobot)
        {
            Console.Clear();
            Console.CursorVisible = false;

            DisplayHeader("Mixing It Up");

            Console.WriteLine();
            Console.WriteLine("\tThe Finch Robot will dance to 'Hot Cross Buns' with colors!");
            Console.WriteLine();

            DisplayContinuePropmt();

            // first line hot cross buns
            finchRobot.noteOn(988);
            finchRobot.setMotors(155, 55);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(400);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);

            finchRobot.noteOn(880);
            finchRobot.setMotors(55, 155);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(400);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);

            finchRobot.noteOn(784);
            finchRobot.setMotors(100, 25);
            finchRobot.setLED(0, 0, 255);
            finchRobot.wait(900);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);

            finchRobot.noteOn(988);
            finchRobot.setMotors(155, 55);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(400);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);

            finchRobot.noteOn(880);
            finchRobot.setMotors(55, 155);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(400);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);

            finchRobot.noteOn(784);
            finchRobot.setMotors(100, 25);
            finchRobot.setLED(0, 0, 255);
            finchRobot.wait(900);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);

            // second line hot cross buns
            finchRobot.noteOn(784);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            finchRobot.noteOn(784);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            finchRobot.noteOn(784);
            finchRobot.setLED(0, 0, 255);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            finchRobot.noteOn(784);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(250);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            finchRobot.noteOn(880);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            finchRobot.noteOn(880);
            finchRobot.setLED(0, 0, 255);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            finchRobot.noteOn(880);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            finchRobot.noteOn(880);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(250);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            finchRobot.noteOn(988);
            finchRobot.setMotors(155, 55);
            finchRobot.setLED(0, 0, 255);
            finchRobot.wait(400);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);

            finchRobot.noteOn(880);
            finchRobot.setMotors(55, 155);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(400);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);

            finchRobot.noteOn(784);
            finchRobot.setMotors(100, 25);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(900);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);

            Console.WriteLine();
            DisplayTalentShowMenuPrompt();
        }

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// Connect Finch Robot Screen
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="userResponse"></param>
        static void DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayHeader("Finch Robot Connection");

            Console.WriteLine();
            Console.WriteLine(" The program will now connect to your finch robot.");
            Console.WriteLine(" Please make sure that the USB cord is connected to your computer and the finch.");
            Console.WriteLine();

            DisplayContinuePropmt();
            Console.WriteLine();

            robotConnected = finchRobot.connect();

            do
            {
                robotConnected = true;

                finchRobot.noteOn(500);
                finchRobot.wait(200);
                finchRobot.noteOff();
                finchRobot.noteOn(1000);
                finchRobot.wait(300);
                finchRobot.noteOff();
                finchRobot.noteOn(2000);
                finchRobot.wait(400);
                finchRobot.noteOff();

                finchRobot.setLED(255, 0, 0);
                finchRobot.wait(500);
                finchRobot.setLED(0, 255, 0);
                finchRobot.wait(500);
                finchRobot.setLED(0, 0, 255);
                finchRobot.wait(500);
                finchRobot.setLED(0, 0, 0);

                Console.WriteLine();
                Console.WriteLine(" Finch Robot sucessfully connected.");
                Console.WriteLine();

                if (!robotConnected)
                {
                    Console.WriteLine();
                    Console.WriteLine("\t\tPlease make sure that the USB cord is attached to both your computer and the finch.");
                    Console.WriteLine();

                    robotConnected = false;
                }

            } while (!robotConnected);

            Console.WriteLine();
            DisplayMenuPrompt();
        }

        /// <summary>
        /// Display Disconnect Finch Robot
        /// </summary>
        /// <param name="finchRobot"></param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.Clear();
            Console.CursorVisible = false;
            DisplayHeader("Finch Robot Disconnection");

            Console.WriteLine();
            Console.WriteLine(" The application will now disconnect the finch robot.");
            Console.WriteLine();

            DisplayContinuePropmt();
            Console.WriteLine();

            finchRobot.noteOn(1000);
            finchRobot.wait(2000);
            finchRobot.noteOff();
            for (int lightLevel = 255; lightLevel > 0; lightLevel--)
            {
                finchRobot.setLED(lightLevel, lightLevel, lightLevel);
            }

            finchRobot.disConnect();

            Console.WriteLine();
            Console.WriteLine(" Your finch has sucessfully disconnected.");
            Console.WriteLine();

            DisplayContinuePropmt();
        }

        #endregion

        #region WELCOME AND CLOSING SCREENS

        /// <summary>
        /// Display Closing Screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.CursorVisible = false;

            DisplayHeader("Closing Screen");

            Console.WriteLine();
            Console.WriteLine(" Thank you for your interest in our Finch Robot Control application.");
            Console.WriteLine();
            Console.WriteLine(" BIRDIE CODING INC.");
            Console.WriteLine();

            DisplayContinuePropmt();
        }

        /// <summary>
        /// Display Welcome Screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.CursorVisible = true;

            string userName;

            DisplayHeader("Project Finch Control");

            Console.WriteLine();
            Console.WriteLine(" Hello, welcome to the Interactive Finch Robot Application");
            Console.WriteLine();

            Console.Write(" What is your name? ");
            userName = Console.ReadLine().Trim();

            Console.WriteLine();
            Console.WriteLine(" It is nice to meet you, {0}", userName);
            Console.WriteLine(" {0}, This program will allow you to connect to your Finch Robot and choose from a variety of actions that it can perform.", userName);
            Console.WriteLine();
            
            DisplayContinuePropmt();
        }

        #endregion

        #region MISCELLANEOUS/OTHER

        /// <summary>
        /// Display Under Work Message
        /// </summary>
        static void DisplayUnderWorkMessage()
        {
            Console.Clear();
            Console.CursorVisible = false;

            DisplayHeader("Error");

            Console.WriteLine();
            Console.WriteLine(" Sorry, but this option is still under development.");
            Console.WriteLine();

            DisplayMenuPrompt();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt()
        {
            Console.CursorVisible = true;
            Console.WriteLine();
            Console.Write("\tPress any key to return to the Main Menu.  ");
            Console.ReadKey();
        }

        /// <summary>
        /// Talent Show Menu Prompt
        /// </summary>
        static void DisplayTalentShowMenuPrompt()
        {
            Console.CursorVisible = true;
            Console.WriteLine();
            Console.Write("\tPress any key to return to the Talent Show Menu.  ");
            Console.ReadKey();
        }

        /// <summary>
        /// Set Theme
        /// </summary>
        static void SetTheme()
        {
            Console.WindowWidth = 150;
            Console.WindowHeight = 40;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Display Header
        /// </summary>
        /// <param name="headerText"></param>
        static void DisplayHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine("\t\t{0}", headerText);
        }

        /// <summary>
        /// Display Continue Prompt
        /// </summary>
        static void DisplayContinuePropmt()
        {
            Console.CursorVisible = true;
            Console.WriteLine();
            Console.Write("\tPress any key to continue.  ");
            Console.ReadKey();
        }
        #endregion
    }
}
