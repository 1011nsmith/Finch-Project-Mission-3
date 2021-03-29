using FinchAPI;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Finch_Starter
{

    // *************************************************************
    //
    // Title:            Project Finch Control
    // Description:      Application which interacts with the user
    //                   to operate the Finch Robot's talent show.
    // Application Type: Console
    // Author:           Smith, Nathan C
    // Date Created:     2/14/2021
    // Last Revised:     2/20/2021
    //
    // *************************************************************

    /// <summary>
    /// User Commands to Use
    /// </summary>
    public enum Command
    {
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        WHITELIGHT,
        LEDOFF,
        REDLIGHT,
        GREENLIGHT,
        BLUELIGHT,
        NOTEON,
        NOTEOFF,
        GETTEMPERATURE,
        GETLIGHTVALUE,
        LIGHTANDSOUND,
        LIGHTSOUNDANDMOVEFORWARD,
        DONE
    }

    class Program
    {

        static void Main(string[] args)
        {
            DisplaySetTheme();

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
                        DisplayDataRecorderMainMenu(finchRobot);
                        break;

                    case "D":
                        DisplayLightAlarmMainMenu(finchRobot);
                        break;

                    case "E":
                        DisplayUserProgrammingMenuScreen(finchRobot);
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

        #region FILE I/O

        /// <summary>
        /// Set Theme
        /// </summary>
        static void DisplaySetTheme()
        {
            (ConsoleColor foregroundColor, ConsoleColor backgroundColor) themeColors;
            bool themeChosen = false;
            string userResponse;
            bool exitLoop = false;

            DisplayHeader("Current Application Color Theme");

            // set current theme from data
            Console.WriteLine();
            themeColors = DisplayReadThemeData(out string fileIOStatusMessage);

            Console.ForegroundColor = themeColors.foregroundColor;
            Console.BackgroundColor = themeColors.backgroundColor;
            
            Console.Clear();

            DisplayHeader("Set Application Color Theme");
            Console.WriteLine();
            Console.WriteLine("\tCurrent foreground color: {0}", Console.ForegroundColor);
            Console.WriteLine("\tCurrent background color: {0}", Console.BackgroundColor);
            Console.WriteLine();

            do
            {
                Console.Write(" Would you like to change the current application theme? [ yes | no ] ");
                userResponse = Console.ReadLine().Trim().ToLower();

                if (userResponse == "yes")
                {
                    Console.Clear();

                    Console.WriteLine();
                    Console.WriteLine("********************************  ALL AVAILABLE COLORS  *********************************");
                    Console.WriteLine("|  Red  |  Green  |  Yellow  |  White  |  Cyan  |  Black  |  Blue  |  Gray  |  Magenta  |");
                    Console.WriteLine("  | DarkRed | DarkGreen | DarkYellow | Dark Cyan | DarkGray | DarkBlue | DarkMagenta |");
                    Console.WriteLine("*****************************************************************************************");
                    Console.WriteLine();
                    Console.WriteLine("\tPLEASE NOTE: Enter the color exactly as they are displayed above.");
                    Console.WriteLine();

                    do
                    {
                        themeColors.foregroundColor = DisplayGetConsoleColorFromUser("foreground");
                        themeColors.backgroundColor = DisplayGetConsoleColorFromUser("background");

                        // set new theme
                        Console.ForegroundColor = themeColors.foregroundColor;
                        Console.BackgroundColor = themeColors.backgroundColor;

                        DisplayHeader("New Application Theme");

                        Console.WriteLine();
                        Console.WriteLine("\tNew foreground color: {0}", Console.ForegroundColor);
                        Console.WriteLine("\tNew background color: {0}", Console.BackgroundColor);
                        Console.WriteLine();
                        Console.Write(" Would you like to keep this new theme? ");

                        if (Console.ReadLine().Trim().ToLower() == "yes")
                        {
                            themeChosen = true;
                            DisplayWriteThemeData(themeColors.foregroundColor, themeColors.backgroundColor);
                            exitLoop = true;
                        }

                    } while (!themeChosen);
                }
                else if (userResponse == "no")
                {
                    exitLoop = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" Sorry, an invalid response was recorded.");
                    Console.WriteLine();
                }
            } while (!exitLoop);

            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue to the rest of the application. ");
            Console.ReadKey();
        }

        /// <summary>
        /// Get Console Color form User
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        static ConsoleColor DisplayGetConsoleColorFromUser(string property)
        {
            ConsoleColor consoleColor;
            bool validConsoleColor;

            do
            {
                Console.Write(" Enter a {0} color: ", property);
                validConsoleColor = Enum.TryParse<ConsoleColor>(Console.ReadLine().Trim(), true, out consoleColor);

                if (!validConsoleColor)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tThe color you entered isn't a valid console color. Please try again.");
                    Console.WriteLine();
                }
                else
                {
                    validConsoleColor = true;
                }
            } while (!validConsoleColor);

            return consoleColor;
        }

        /// <summary>
        /// Read Theme Info from Data File
        /// </summary>
        /// <returns></returns>
        static (ConsoleColor foregroundColor, ConsoleColor backgroundColor) DisplayReadThemeData(out string fileIOStatusMessage)
        {
            string dataPath = @"Data/Theme.txt";
            string[] themeColors;

            ConsoleColor foregroundColor = ConsoleColor.Black;
            ConsoleColor backgroundColor = ConsoleColor.White;

            try
            {
                themeColors = File.ReadAllLines(dataPath);

                if (Enum.TryParse(themeColors[0], true, out foregroundColor) && 
                    Enum.TryParse(themeColors[1], true, out backgroundColor))
                {
                    fileIOStatusMessage = "Complete";
                }
                else
                {
                    fileIOStatusMessage = "Data file invalidly entered.";
                }
            }
            catch (DirectoryNotFoundException)
            {
                fileIOStatusMessage = "Unable to locate the data file folder.";
            }
            catch (Exception)
            {
                fileIOStatusMessage = "Unable to read data file.";
            }
            

            return (foregroundColor, backgroundColor);
        }

        /// <summary>
        /// Write Theme Info to Data File
        /// </summary>
        /// <param name="foreground"></param>
        /// <param name="background"></param>
        static string DisplayWriteThemeData(ConsoleColor foreground, ConsoleColor background)
        {
            string dataPath = @"Data/Theme.txt";
            string fileIOStatusMessage = "";

            try
            {
                File.WriteAllText(dataPath, foreground.ToString() + "\n");
                File.AppendAllText(dataPath, background.ToString());
                fileIOStatusMessage = "Complete";
            }
            catch (DirectoryNotFoundException)
            {
                fileIOStatusMessage = "Unable to locate the data file folder.";
            }
            catch (Exception)
            {
                fileIOStatusMessage = "Unable to write to the data file.";
            }

            return fileIOStatusMessage;
        }

        #endregion

        #region USER PROGRAMMING

        /// <summary>
        /// User Programming Menu Screen
        /// </summary>
        /// <param name="finchRobot"></param>
        static void DisplayUserProgrammingMenuScreen(Finch finchRobot)
        {
            Console.Clear();
            Console.CursorVisible = true;

            bool quitUserProgrammingMenu = false;
            string userResonse;
            int menuChoice;

            (int motorSpeed, int ledBrightness, double waitseconds, int soundFrequency) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitseconds = 0;
            commandParameters.soundFrequency = 0;
            List<Command> commands = null;
            
            do
            {
                DisplayHeader("User Programming Menu");

                //
                // get user menu choice
                //
                Console.WriteLine();
                Console.WriteLine("\t1) Set Command Parameters");
                Console.WriteLine();
                Console.WriteLine("\t2) Add Finch Commands");
                Console.WriteLine();
                Console.WriteLine("\t3) View Finch Commands");
                Console.WriteLine();
                Console.WriteLine("\t4) Execute Finch Commands");
                Console.WriteLine();
                Console.WriteLine("\t5) Return to Main Menu");
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
                        Console.WriteLine("\tPlease enter a whole number from 1 - 5.");
                        Console.WriteLine();

                        validResponse = false;
                    }
                } while (!validResponse);

                //
                // validate if menu choice is or isn't an int from 1 - 5
                //
                switch (menuChoice)
                {
                    case 1:
                        commandParameters = DisplayUserProgrammingSetCommandParameters();
                        break;

                    case 2:
                        commands = DisplayUserProgrammingAddFinchCommands();
                        break;

                    case 3:
                        DisplayUserProgrammingViewFinchCommands(commands);
                        break;

                    case 4:
                        DisplayUserProgrammingExecuteCommands(finchRobot, commands, commandParameters);
                        break;

                    case 5:
                        quitUserProgrammingMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a whole number from 1 - 5 in the menu choice.");
                        DisplayContinuePropmt();
                        break;
                }

            } while (!quitUserProgrammingMenu);
        }

        /// <summary>
        /// Display User Programming Execute Commands
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="commands"></param>
        /// <param name="commandParameters"></param>
        static void DisplayUserProgrammingExecuteCommands(Finch finchRobot, List<Command> commands, (int motorSpeed, int ledBrightness, double waitseconds, int soundFrequency) commandParameters)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            double waitSeconds = commandParameters.waitseconds;
            int soundFrequency = commandParameters.soundFrequency;
            
            Console.Clear();

            DisplayHeader("Execute Commands");

            Console.WriteLine();
            Console.WriteLine(" The Finch Robot will now execute all commands that were entered.");
            Console.WriteLine();


            DisplayContinuePropmt();
            Console.WriteLine();
            Console.WriteLine();

            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        break;

                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        break;

                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        break;

                    case Command.WAIT:
                        int waitMilliseconds = (int)waitSeconds * 1000;
                        finchRobot.wait(waitMilliseconds);
                        break;

                    case Command.TURNRIGHT:
                        finchRobot.setMotors(motorSpeed, 0);
                        break;

                    case Command.TURNLEFT:
                        finchRobot.setMotors(0, motorSpeed);
                        break;

                    case Command.WHITELIGHT:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        break;

                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        break;

                    case Command.REDLIGHT:
                        finchRobot.setLED(ledBrightness, 0, 0);
                        break;

                    case Command.GREENLIGHT:
                        finchRobot.setLED(0, ledBrightness, 0);
                        break;

                    case Command.BLUELIGHT:
                        finchRobot.setLED(0, 0, ledBrightness);
                        break;

                    case Command.NOTEON:
                        finchRobot.noteOn(soundFrequency);
                        break;

                    case Command.NOTEOFF:
                        finchRobot.noteOff();
                        break;

                    case Command.GETTEMPERATURE:
                        double temp = (finchRobot.getTemperature() * 9 / 5) + 32;
                        Console.WriteLine("\tThe Current Temperature is: {0:n1} * F", temp);
                        Console.WriteLine();
                        break;

                    case Command.GETLIGHTVALUE:
                        int leftlightValue = finchRobot.getLeftLightSensor();
                        int rightLightValue = finchRobot.getRightLightSensor();
                        Console.WriteLine("\tCurrent Left Light Sensor Value: {0}", leftlightValue);
                        Console.WriteLine("\tCurrent Right Light Sensor Value: {0}", rightLightValue);
                        Console.WriteLine();
                        break;

                    case Command.LIGHTANDSOUND:
                        finchRobot.noteOn(soundFrequency);
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        break;

                    case Command.LIGHTSOUNDANDMOVEFORWARD:
                        finchRobot.noteOn(soundFrequency);
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        break;

                    case Command.DONE:
                        break;

                    default:
                        Console.WriteLine("\tUnknown Command Error.");
                        break;
                }

                Console.WriteLine($"\tCommand: {command}");
                Console.WriteLine();
            }

            DisplayMenuPrompt("User Programming Menu");
        }

        /// <summary>
        /// Display View Finch Commands
        /// </summary>
        /// <param name="commands"></param>
        static void DisplayUserProgrammingViewFinchCommands(List<Command> commands)
        {
            Console.Clear();

            DisplayHeader("View User-Entered Finch Commands");

            Console.WriteLine();
            Console.WriteLine("\tCommand List");
            Console.WriteLine("\t------------");

            foreach (Command command in commands)
            {
                Console.WriteLine("\t" + command);
            }

            DisplayMenuPrompt("User Programming Menu");
        }

        /// <summary>
        /// Display Add Finch Commands
        /// </summary>
        /// <returns></returns>
        static List<Command> DisplayUserProgrammingAddFinchCommands()
        {
            List<Command> commands = new List<Command>();
            bool isDone = false;
            string userResponse;
            Command command;

            DisplayHeader("User Commands for Finch");

            Console.WriteLine();
            Console.WriteLine("\tAll available commands for the Finch Robot: ");
            Console.WriteLine();

            Console.WriteLine("|   MOVEFORWARD    |   MOVEBACKWARD   |    STOPMOTORS    |      WAIT       |         TURNRIGHT          |     TURNLEFT     |");
            Console.WriteLine("|------------------|------------------|------------------|-----------------|----------------------------|------------------|");
            Console.WriteLine("|    WHITELIGHT    |     REDLIGHT     |    GREENLIGHT    |    BLUELIGHT    |           LEDOFF           |      NOTEON      |");
            Console.WriteLine("|------------------|------------------|------------------|-----------------|----------------------------|------------------|");
            Console.WriteLine("|     NOTEOFF      |  GETTEMPERATURE  |  GETLIGHT VALUE  |  LIGHTANDSOUND  |  LIGHTSOUNDANDMOVEFORWARD  |       DONE       |");

            do
            {
                Console.WriteLine();
                Console.Write(" Enter Command: ");
                userResponse = Console.ReadLine().ToUpper();

                if (userResponse != "DONE")
                {
                    if (Enum.TryParse(userResponse, out command))
                    {
                        commands.Add(command);
                    }
                    else
                    {
                        Console.WriteLine("\tPlease enter a proper command.");
                    }
                }
                else
                {
                    isDone = true;
                }

            } while (!isDone);

            DisplayMenuPrompt("User Programming Menu");

            return commands;
        }

        /// <summary>
        /// Display Set Command Parameters
        /// </summary>
        /// <returns></returns>
        static (int motorSpeed, int ledBrightness, double waitseconds, int soundFrequency) DisplayUserProgrammingSetCommandParameters()
        {
            (int motorSpeed, int ledBrightness, double waitseconds, int soundFrequency) commandParameters;
            bool validResponse;
            string userResponse;

            DisplayHeader("Command Parameters");

            // get motor speed
            do
            {
                validResponse = true;
                Console.WriteLine();
                Console.Write(" Enter Motor Speed: ");
                userResponse = Console.ReadLine().Trim();

                if (!int.TryParse(userResponse, out commandParameters.motorSpeed) || commandParameters.motorSpeed < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a positive whole number.");
                    Console.WriteLine();

                    validResponse = false;
                }
            } while (!validResponse);
            
            // get LED brightness
            do
            {
                validResponse = true;
                Console.Write(" Enter LED Brightness: ");
                userResponse = Console.ReadLine().Trim();

                if (!int.TryParse(userResponse, out commandParameters.ledBrightness) || commandParameters.ledBrightness < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a positive whole number.");
                    Console.WriteLine();

                    validResponse = false;
                }
            } while (!validResponse);

            // get sound frequency
            do
            {
                validResponse = true;
                Console.Write(" Enter Sound Frequency: ");
                userResponse = Console.ReadLine().Trim();

                if (!int.TryParse(userResponse, out commandParameters.soundFrequency) || commandParameters.soundFrequency < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a positive whole number.");
                    Console.WriteLine();

                    validResponse = false;
                }
            } while (!validResponse);

            // get wait time
            do
            {
                validResponse = true;
                Console.Write(" Enter Wait Time (Seconds): ");
                userResponse = Console.ReadLine().Trim();

                if (!double.TryParse(userResponse, out commandParameters.waitseconds) || commandParameters.waitseconds < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a positive number.");
                    Console.WriteLine();

                    validResponse = false;
                }
            } while (!validResponse);

            DisplayMenuPrompt("User Programming Menu");

            return commandParameters;
        }

        #endregion

        #region ALARM SYSTEM

        /// <summary>
        /// Alarm System Main Menu
        /// </summary>
        /// <param name="finchRobot"></param>
        static void DisplayLightAlarmMainMenu(Finch finchRobot)
        {
            Console.Clear();
            Console.CursorVisible = true;

            bool quitDataRecorderMenu = false;
            string userResonse;
            int menuChoice;

            string tempOrLight = "";
            string sensorsToMonitor = "";
            string rangeType = "";
            double minMaxThresholdValue = 0;
            int timeToMonitor = 0;

            do
            {
                DisplayHeader("Alarm System Menu");

                //
                // get user menu choice
                //
                Console.WriteLine();
                Console.WriteLine("\t1) Temperature or Light?");
                Console.WriteLine();
                Console.WriteLine("\t2) Set Sensors to Monitor");
                Console.WriteLine();
                Console.WriteLine("\t3) Set Range Type");
                Console.WriteLine();
                Console.WriteLine("\t4) Set Maximum/Minimum Threshold Value");
                Console.WriteLine();
                Console.WriteLine("\t5) Set Time to Monitor");
                Console.WriteLine();
                Console.WriteLine("\t6) Set Alarm");
                Console.WriteLine();
                Console.WriteLine("\t7) Return to Main Menu");
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
                        Console.WriteLine("\tPlease enter a whole number from 1 - 7.");
                        Console.WriteLine();

                        validResponse = false;
                    }
                } while (!validResponse);

                //
                // validate if menu choice is or isn't an int from 1 - 7
                //
                switch (menuChoice)
                {
                    case 1:
                        tempOrLight = DisplayAlarmSystemTemperatureOrLight();
                        break;
                    
                    case 2:
                        sensorsToMonitor = DisplayAlarmSystemSetSensors(tempOrLight);
                        break;

                    case 3:
                        rangeType = DisplayAlarmSystemRangeType();
                        break;

                    case 4:
                        minMaxThresholdValue = DisplayAlarmSystemThresholdValue(sensorsToMonitor, finchRobot, tempOrLight);
                        break;

                    case 5:
                        timeToMonitor = DisplayAlarmSystemTimeToMonitor();
                        break;

                    case 6:
                        DisplayAlarmSystemSetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor, tempOrLight);
                        break;

                    case 7:
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a whole number from 1 - 7 in the menu choice.");
                        DisplayContinuePropmt();
                        break;
                }

            } while (!quitDataRecorderMenu);
        }

        /// <summary>
        /// Temperature or Light?
        /// </summary>
        /// <returns></returns>
        static string DisplayAlarmSystemTemperatureOrLight()
        {
            Console.Clear();
            Console.CursorVisible = true;
            string tempOrLight = "";
            bool validResponse;

            DisplayHeader("Temperature or Light Monitoring");

            Console.WriteLine();
            Console.WriteLine(" The Finch Robot can read the light level values and temperature values of it's surroundings.");
            Console.WriteLine(" However, the Finch can only monitor one at a time.");

            do
            {
                validResponse = true;

                Console.WriteLine();
                Console.Write(" Would you like to monitor current light values or current temperature values? [enter 'temperature' or 'light'] ");
                tempOrLight = Console.ReadLine().Trim().ToLower();

                if (tempOrLight != "temperature" && tempOrLight != "light")
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter 'temperature' or 'light'.");
                    Console.WriteLine();

                    validResponse = false;
                }

            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Values to monitor is now set to: {0}", tempOrLight);

            Console.WriteLine();
            DisplayMenuPrompt("Alarm System Menu");

            return tempOrLight;
        }

        /// <summary>
        /// Alarm System Set Alarm
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="sensorsToMonitor"></param>
        /// <param name="rangeType"></param>
        /// <param name="minMaxThresholdValue"></param>
        /// <param name="timeToMonitor"></param>
        static void DisplayAlarmSystemSetAlarm
            (
            Finch finchRobot,
            string sensorsToMonitor,
            string rangeType,
            double minMaxThresholdValue,
            int timeToMonitor,
            string tempOrLight
            )
        {
            Console.Clear();
            Console.CursorVisible = true;
            bool thresholdExceeded = false;
            double currentLeftLightValue;
            double currentRightLightValue;
            double currentTempValue;
            int secondsElapsed = 1;
            
            DisplayHeader("Set Alarm");

            //echo values to user again
            Console.WriteLine();
            Console.WriteLine(" Values Monitoring.....{0} values", tempOrLight);
            Console.WriteLine(" Sensors to Monitor....{0} sensor(s)", sensorsToMonitor);
            Console.WriteLine(" Range Type............{0} value", rangeType);
            Console.WriteLine(" Threshold Value.......{0}", minMaxThresholdValue);
            Console.WriteLine(" Time to Monitor.......{0} seconds", timeToMonitor);
            Console.WriteLine();

            // prompt user to start
            Console.WriteLine();
            Console.WriteLine("\tPress any key to begin Finch Robot monitoring.");
            Console.ReadKey();

            if (tempOrLight == "light")
            {
                do
                {
                    // get and display current light value based on which sensor it is
                    // monitor if threshold is exceeded based on user's range type and current light value(s)
                    switch (sensorsToMonitor)
                    {
                        case "left":
                            currentLeftLightValue = finchRobot.getLeftLightSensor();

                            Console.WriteLine();
                            Console.WriteLine($"Current Left Sensor Light Value {secondsElapsed} second(s): {currentLeftLightValue:n1}");

                            finchRobot.wait(1000);
                            secondsElapsed++;

                            if (rangeType == "minimum")
                            {
                                if (currentLeftLightValue < minMaxThresholdValue)
                                {
                                    thresholdExceeded = true;
                                }
                            }
                            else if (rangeType == "maximum")
                            {
                                if (currentLeftLightValue > minMaxThresholdValue)
                                {
                                    thresholdExceeded = true;
                                }
                            }

                            break;

                        case "right":
                            currentRightLightValue = finchRobot.getRightLightSensor();

                            Console.WriteLine();
                            Console.WriteLine($"Current Right Sensor Light Value {secondsElapsed} second(s): {currentRightLightValue:n1}");

                            finchRobot.wait(1000);
                            secondsElapsed++;

                            if (rangeType == "minimum")
                            {
                                if (currentRightLightValue < minMaxThresholdValue)
                                {
                                    thresholdExceeded = true;
                                }
                            }
                            else if (rangeType == "maximum")
                            {
                                if (currentRightLightValue > minMaxThresholdValue)
                                {
                                    thresholdExceeded = true;
                                }
                            }

                            break;

                        case "both":
                            currentLeftLightValue = finchRobot.getLeftLightSensor();
                            currentRightLightValue = finchRobot.getRightLightSensor();

                            Console.WriteLine();
                            Console.WriteLine($"{secondsElapsed} second(s)");
                            Console.WriteLine($"Current Left Light Value {currentLeftLightValue:n1}");
                            Console.WriteLine($"Current Right Light Value {currentRightLightValue:n1}");

                            finchRobot.wait(1000);
                            secondsElapsed++;

                            if (rangeType == "minimum")
                            {
                                if (currentLeftLightValue < minMaxThresholdValue)
                                {
                                    thresholdExceeded = true;
                                }
                                else if (currentRightLightValue < minMaxThresholdValue)
                                {
                                    thresholdExceeded = true;
                                }
                            }
                            else if (rangeType == "maximum")
                            {
                                if (currentLeftLightValue > minMaxThresholdValue)
                                {
                                    thresholdExceeded = true;
                                }
                                else if (currentRightLightValue > minMaxThresholdValue)
                                {
                                    thresholdExceeded = true;
                                }
                            }
                            break;

                        default:
                            Console.WriteLine("'left' 'right' or 'both' light sensors were not specified earlier.");
                            Console.WriteLine("Return to the alarm system main menu to specify them.");
                            break;
                    }

                } while (!thresholdExceeded && (secondsElapsed <= timeToMonitor));
            }

            else if (tempOrLight == "temperature")
            {
                do
                {
                    currentTempValue = finchRobot.getTemperature() * 9 / 5 + 32;
                    
                    Console.WriteLine();
                    Console.WriteLine($"Current Temperature {secondsElapsed} second(s): {currentTempValue:n1} * F");

                    finchRobot.wait(1000);
                    secondsElapsed++;

                    if (rangeType == "minimum")
                    {
                        if (currentTempValue < minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                    }
                    else if (rangeType == "maximum")
                    {
                        if (currentTempValue > minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                    }

                } while (!thresholdExceeded && (secondsElapsed <= timeToMonitor));
            }
            
            if (thresholdExceeded)
            {
                finchRobot.noteOn(1000);
                finchRobot.wait(500);
                finchRobot.noteOff();
                finchRobot.noteOn(1000);
                finchRobot.wait(500);
                finchRobot.noteOff(); 
                finchRobot.noteOn(1000);
                finchRobot.wait(500);
                finchRobot.noteOff();
                Console.WriteLine();
                Console.WriteLine(" *************************************");
                Console.WriteLine(" *              WARNING              *");
                Console.WriteLine(" *                                   *");
                Console.WriteLine(" *        Threshold Exceeded!        *");
                Console.WriteLine(" *************************************");
            }
            else
            {
                finchRobot.noteOn(1500);
                finchRobot.wait(300);
                finchRobot.noteOff();
                finchRobot.noteOn(1000);
                finchRobot.wait(300);
                finchRobot.noteOff();
                finchRobot.noteOn(500);
                finchRobot.wait(200);
                finchRobot.noteOff();
                Console.WriteLine();
                Console.WriteLine(" *************************************");
                Console.WriteLine(" *    Threshold Was Not Exceeded     *");
                Console.WriteLine(" *                                   *");
                Console.WriteLine(" *          Time Limit Met           *");
                Console.WriteLine(" *************************************");
            }
            
            DisplayMenuPrompt("Alarm System Menu");
        }

        /// <summary>
        /// Alarm System Time to Monitor
        /// </summary>
        /// <returns></returns>
        static int DisplayAlarmSystemTimeToMonitor()
        {
            int timeToMonitor = 0;
            bool validResponse;
            string userResponse;

            DisplayHeader("Time to Monitor");

            do
            {
                validResponse = true;

                Console.WriteLine();
                Console.Write("\tEnter Time to Monitor [seconds]: ");
                userResponse = Console.ReadLine().Trim().ToLower();

                if (!int.TryParse(userResponse, out timeToMonitor) || timeToMonitor < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a positive whole number.");
                    Console.WriteLine();

                    validResponse = false;
                }

            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Time to monitor is now set to {0} seconds.", timeToMonitor);
            DisplayMenuPrompt("Alarm System Menu");

            return timeToMonitor;
        }

        /// <summary>
        /// Alarm System Threshold Value
        /// </summary>
        /// <param name="sensorsToMonitor"></param>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        static double DisplayAlarmSystemThresholdValue(string sensorsToMonitor, Finch finchRobot, string tempOrLight)
        {
            double thresholdValue = 0;
            bool validResponse;

            double currentTemperatureValue = finchRobot.getTemperature() * 9 / 5 + 32;
            int currentLeftSensorValue = finchRobot.getLeftLightSensor();
            int currentRightSensorValue = finchRobot.getRightLightSensor();

            DisplayHeader("Threshold Value");

            if (tempOrLight == "light")
            {
                //
                // display ambient values
                //
                Console.WriteLine();
                switch (sensorsToMonitor)
                {
                    case "left":
                        Console.WriteLine($"\tCurrent {sensorsToMonitor} Sensor Value: {currentLeftSensorValue}");
                        break;

                    case "right":
                        Console.WriteLine($"\tCurrent {sensorsToMonitor} Sensor Value: {currentRightSensorValue}");
                        break;

                    case "both":
                        Console.WriteLine($"\tCurrent left Sensor Value: {currentLeftSensorValue}");
                        Console.WriteLine($"\tCurrent right Sensor Value: {currentRightSensorValue}");
                        break;

                    default:
                        Console.WriteLine("\tUnknown Sensor Reference.");
                        break;
                }
            }

            else if (tempOrLight == "temperature")
            {
                // display current temp in fahrenheit
                Console.WriteLine();
                Console.WriteLine($"\tCurrent Temperature Value: {currentTemperatureValue:n1} * F");
                Console.WriteLine();
            }
            
            //
            // get threshold from user
            //
            do
            {
                validResponse = true;

                Console.WriteLine();
                Console.Write("\tEnter Threshold Value: ");
                string userResponse = Console.ReadLine().Trim();

                if (!double.TryParse(userResponse, out thresholdValue))
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a number. [23, 11.4, 78.2, etc.]");
                    Console.WriteLine();

                    validResponse = false;
                }
            } while (!validResponse);
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Threshold value is now set to: {0}", thresholdValue);

            Console.WriteLine();
            DisplayMenuPrompt("Alarm System Menu");

            return thresholdValue;
        }

        /// <summary>
        /// Alarm System Range Type
        /// </summary>
        /// <returns></returns>
        static string DisplayAlarmSystemRangeType()
        {
            string rangeType = "";
            bool validResponse;

            DisplayHeader("Range Type");
            
            do
            {
                validResponse = true;

                Console.WriteLine();
                Console.Write("\tEnter Range Type [minimum or maximum]: ");
                rangeType = Console.ReadLine().Trim().ToLower();

                if (rangeType != "minimum" && rangeType != "maximum")
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter 'minimum' or 'maximum'.");
                    Console.WriteLine();

                    validResponse = false;
                }

            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Range Type is now set to: {0}", rangeType);

            Console.WriteLine();
            DisplayMenuPrompt("Alarm System Menu");

            return rangeType;
        }

        /// <summary>
        /// Alarm System Set Sensors
        /// </summary>
        /// <returns></returns>
        static string DisplayAlarmSystemSetSensors(string tempOrLight)
        {
            string sensorsToMonitor = "";
            bool validResponse;

            DisplayHeader("Sensors to Monitor");

            if (tempOrLight == "light")
            {
                do
                {
                    validResponse = true;

                    Console.WriteLine();
                    Console.Write("\tEnter Sensors to Monitor [left, right, both]: ");
                    sensorsToMonitor = Console.ReadLine().Trim().ToLower();

                    if (sensorsToMonitor != "left" && sensorsToMonitor != "right" && sensorsToMonitor != "both")
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter 'left', 'right', or 'both'.");
                        Console.WriteLine();

                        validResponse = false;
                    }

                } while (!validResponse);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" Sensors to monitor is now set to: {0}", sensorsToMonitor);
            }

            else if (tempOrLight == "temperature")
            {
                Console.WriteLine();
                Console.WriteLine(" The finch only has one temperature sensor, so this option only applies if 'light level values' was chosen to monitor.");
                Console.WriteLine();
            }

            Console.WriteLine();
            DisplayMenuPrompt("Alarm System Menu");

            return sensorsToMonitor;
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
            DisplayMenuPrompt("Talent Show Menu");
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
            DisplayMenuPrompt("Talent Show Menu");
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
            DisplayMenuPrompt("Talent Show Menu");
        }

        #endregion

        #region DATA RECORDER

        /// <summary>
        /// Display Data Recorder Menu
        /// </summary>
        static void DisplayDataRecorderMainMenu(Finch finchRobot)
        {
            Console.Clear();
            Console.CursorVisible = true;

            bool quitDataRecorderMenu = false;
            string userResonse;
            int menuChoice;
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;
            //double[] celsiusTemps = null;

            do
            {
                DisplayHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine();
                Console.WriteLine("\t1) Number of Data Points");
                Console.WriteLine();
                Console.WriteLine("\t2) Frequency of Data Points");
                Console.WriteLine();
                Console.WriteLine("\t3) Get Temperatures");
                Console.WriteLine();
                Console.WriteLine("\t4) Show Data");
                Console.WriteLine();
                Console.WriteLine("\t5) Return to Main Menu");
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
                        Console.WriteLine("\tPlease enter a whole number from 1 - 5.");
                        Console.WriteLine();

                        validResponse = false;
                    }
                } while (!validResponse);

                //
                // validate if menu choice is or isn't an int from 1 - 5
                //
                switch (menuChoice)
                {
                    case 1:
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case 2:
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case 3:
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case 4:
                        DataRecorderDisplayGetData(temperatures); //celsiusTemps);
                        break;

                    case 5:
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a whole number from 1 - 5 in the menu choice.");
                        DisplayContinuePropmt();
                        break;
                }

            } while (!quitDataRecorderMenu);
        }

        /// <summary>
        /// Display Data Table
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayDataTable(double[] temperatures) //double[] celsiusTemps)
        {
            DisplayHeader("Temperature Chart (sorted from lowest to highest temperature)");
            
            Console.WriteLine();
            Console.WriteLine(
                " Reading #".PadLeft(20) +
                " Temperature (* Fahrenheit)".PadLeft(30))
                ;

            Console.WriteLine(
                "----------".PadLeft(20) +
                "---------------------------".PadLeft(30))
                ;

            for (int index = 1; index <= temperatures.Length; index++)
            {
                Array.Sort(temperatures);
                Console.WriteLine(
                (index).ToString().PadLeft(20) +
                (temperatures[index - 1]).ToString("n1").PadLeft(30))
                ;
            }

            //Console.WriteLine();
            //Console.WriteLine(
            //    "    ----------------------------------------------------".PadLeft(10))
            //    ;

            //Console.WriteLine();
            //Console.WriteLine(
            //    " Reading #".PadLeft(20) +
            //    " Temperature (* Celsius)".PadLeft(30))
            //    ;

            //Console.WriteLine(
            //    "----------".PadLeft(20) +
            //    "---------------------------".PadLeft(30))
            //    ;
            //for (int index1 = 1; index1 <= celsiusTemps.Length; index1++)
            //{
            //    Array.Sort(celsiusTemps);
            //    Console.WriteLine(
            //    (index1).ToString().PadLeft(20) +
            //    (celsiusTemps[index1 - 1]).ToString("n1").PadLeft(30))
            //    ;
            //}

        }

        /// <summary>
        /// Display Get Data
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayGetData(double[] temperatures) //double[] celsiusTemps)
        {
            Console.Clear();
            Console.CursorVisible = false;
            DataRecorderDisplayDataTable(temperatures); //celsiusTemps);

            double sumTemps;
            sumTemps = temperatures.Sum();

            double averageTemp;
            averageTemp = temperatures.Average();

            //double celsiusSumTemps;
            //celsiusSumTemps = celsiusTemps.Sum();

            //double celsiusAverageTemp;
            //celsiusAverageTemp = celsiusTemps.Average();

            Console.WriteLine();
            Console.WriteLine("\tTotal Sum of all Temperatures: {0:n1}* F", sumTemps);
            Console.WriteLine();
            Console.WriteLine("\tAverage Temperature: {0:n1}* F", averageTemp);
            Console.WriteLine();
            Console.WriteLine();
            //Console.WriteLine("\tTotal Sum of all Temperatures (celsius): {0:n1}* C", celsiusSumTemps);
            //Console.WriteLine();
            //Console.WriteLine("\tAverage Temperature (celsius): {0:n1}* C", celsiusAverageTemp);
            //Console.WriteLine();
            //Console.WriteLine();
            DisplayMenuPrompt("Data Recorder Menu");
        }

        /// <summary>
        /// Get temperatures from robot
        /// </summary>
        /// <param name="numberOfDataPoints">number of data points</param>
        /// <param name="dataPointFrequency">data point frequency</param>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>temperatures</returns>
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            Console.Clear();
            Console.CursorVisible = false;
            double[] temperatures = new double[numberOfDataPoints];
            //double[] celsiusTemps = new double[numberOfDataPoints];
            int dataPointFrequencyMs;

            //
            // convert frequency in seconds to milliseconds
            //
            dataPointFrequencyMs = (int)(dataPointFrequency * 1000);

            DisplayHeader("Temperatures");

            Console.WriteLine();
            Console.WriteLine($"\tThe Finch Robot will now record {numberOfDataPoints} current temperature(s) of it's surroundings {dataPointFrequency} second(s) apart.");
            Console.WriteLine();
            Console.WriteLine("\tPress any key to begin.");
            Console.ReadKey();

            for (int index = 1; index <= numberOfDataPoints; index++)
            {
                temperatures[index - 1] = finchRobot.getTemperature() * 9 / 5 + 32;
                //celsiusTemps[index - 1] = finchRobot.getTemperature();

                //
                // echo new temperature
                //
                Console.WriteLine();
                Console.WriteLine($"\tTemperature {index}: {temperatures[index - 1]:n1}* F");

                finchRobot.wait(dataPointFrequencyMs);
            }

            Console.WriteLine();
            Console.WriteLine(" The Finch Robot has finished reading temperatures.");
            Console.WriteLine();

            DisplayContinuePropmt();

            //
            // display table of temperatures
            //
            DataRecorderDisplayDataTable(temperatures); //celsiusTemps);

            DisplayMenuPrompt("Data Recorder Menu");

            return temperatures;
            //return celsiusTemps;
        }

        /// <summary>
        /// Get Data Point Fequency
        /// </summary>
        /// <returns>dataPointFrequency</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            Console.Clear();
            Console.CursorVisible = true;
            double dataPointFrequency;
            bool validResponse;

            DisplayHeader("Data Point Frequency");

            do
            {
                validResponse = true;

                Console.WriteLine();
                Console.Write(" Enter the Data Point Frequency (in seconds): ");
                string userResponse = Console.ReadLine().Trim();

                if (!double.TryParse(userResponse, out dataPointFrequency) || dataPointFrequency < 0)
                {

                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a positive number. [3, 4.2, .5, etc.]");
                    Console.WriteLine();

                    validResponse = false;
                }
            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine($"\tYou chose {dataPointFrequency} second(s) as the data point frequency.");
            Console.WriteLine();

            DisplayMenuPrompt("Data Recorder Menu");

            return dataPointFrequency;
        }

        /// <summary>
        /// Get Number of Data Points from User
        /// </summary>
        /// <returns>numberofDataPoints</returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            Console.Clear();
            Console.CursorVisible = true;
            int numberOfDataPoints;
            bool validResponse;

            DisplayHeader("Number of Data Points");

            do
            {
                validResponse = true;

                Console.WriteLine();
                Console.Write(" Enter the Number of Data Points: ");
                string userResponse = Console.ReadLine().Trim();

                if (!int.TryParse(userResponse, out numberOfDataPoints) || numberOfDataPoints < 0)
                {

                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a positive whole number. [3, 10, 27, etc.]");
                    Console.WriteLine();

                    validResponse = false;
                }
            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine($"\tYou chose {numberOfDataPoints} as the number of data points.");
            Console.WriteLine();

            DisplayMenuPrompt("Data Recorder Menu");

            return numberOfDataPoints;
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
            DisplayMenuPrompt("Main Menu");
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

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuPromptText)
        {
            Console.CursorVisible = true;
            Console.WriteLine();
            Console.Write("\t\tPress any key to return to the {0}.", menuPromptText);
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
