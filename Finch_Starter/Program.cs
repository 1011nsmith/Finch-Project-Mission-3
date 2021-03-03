using FinchAPI;
using System;
using System.Linq;

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
                        DisplayDataRecorderMainMenu(finchRobot);
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

        //#region ALARM SYSTEM

        ///// <summary>
        ///// Alarm System Main Menu
        ///// </summary>
        ///// <param name="finchRobot"></param>
        //static void DisplayLightAlarmMainMenu(Finch finchRobot)
        //{
        //    Console.Clear();
        //    Console.CursorVisible = true;

        //    bool quitDataRecorderMenu = false;
        //    string userResonse;
        //    int menuChoice;
            


        //    do
        //    {
        //        DisplayHeader("Alarm System Menu");

        //        //
        //        // get user menu choice
        //        //
        //        Console.WriteLine();
        //        Console.WriteLine("\t1) Set Sensors to Monitor");
        //        Console.WriteLine();
        //        Console.WriteLine("\t2) Set Range Type");
        //        Console.WriteLine();
        //        Console.WriteLine("\t3) Set Maximum/Minimum Threshold Value");
        //        Console.WriteLine();
        //        Console.WriteLine("\t4) Set Time to Monitor");
        //        Console.WriteLine();
        //        Console.WriteLine("\t5) Set Alarm");
        //        Console.WriteLine();
        //        Console.WriteLine("\t6) Return to Main Menu");
        //        Console.WriteLine();
        //        Console.WriteLine();

        //        //
        //        // validate menu choice if not an int
        //        //
        //        bool validResponse;
        //        do
        //        {
        //            validResponse = true;
        //            Console.Write("\t\tEnter Choice: ");
        //            userResonse = Console.ReadLine().Trim();

        //            if (!int.TryParse(userResonse, out menuChoice))
        //            {
        //                Console.WriteLine();
        //                Console.WriteLine("\tPlease enter a whole number from 1 - 6.");
        //                Console.WriteLine();

        //                validResponse = false;
        //            }
        //        } while (!validResponse);

        //        //
        //        // validate if menu choice is or isn't an int from 1 - 6
        //        //
        //        switch (menuChoice)
        //        {
        //            case 1:
        //                sensorsToMonitor = DisplayAlarmSystemSetSensors();
        //                break;

        //            case 2:
        //                rangeType = DisplayAlarmSystemRangeType();
        //                break;

        //            case 3:
                        
        //                break;

        //            case 4:
                        
        //                break;

        //            case 5:

        //                break;

        //            case 6:
        //                quitDataRecorderMenu = true;
        //                break;

        //            default:
        //                Console.WriteLine();
        //                Console.WriteLine("\tPlease enter a whole number from 1 - 6 in the menu choice.");
        //                DisplayContinuePropmt();
        //                break;
        //        }

        //    } while (!quitDataRecorderMenu);
        //}

        ///// <summary>
        ///// Alarm System Set Alarm
        ///// </summary>
        ///// <param name="finchRobot"></param>
        ///// <param name="sensorsToMonitor"></param>
        ///// <param name="rangeType"></param>
        ///// <param name="minMaxThresholdValue"></param>
        ///// <param name="timeToMonitor"></param>
        //static void DisplayAlarmSystemSetAlarm
        //    (
        //    Finch finchRobot,
        //    string sensorsToMonitor,
        //    string rangeType,
        //    int minMaxThresholdValue,
        //    int timeToMonitor
        //    )
        //{
        //    DisplayHeader("Set Alarm");

        //    //echo values to user DO THIS
        //    Console.WriteLine("\tStart");

        //    // prompt user to start
        //    Console.ReadKey();

        //    switch (sensorsToMonitor)
        //    {
        //        case "left":
                    
        //            break;

        //        case "right":
                    
        //            break;

        //        case "both":
                    
        //            break;

        //        default:
        //            Console.WriteLine("\tUnknown Sensor Reference");
        //            break;
        //    }

        //    DisplayMenuPrompt("Alarm System Menu");
        //}
        
        ///// <summary>
        ///// Alarm System Time to Monitor
        ///// </summary>
        ///// <returns></returns>
        //static int DisplayAlarmSystemTimeToMonitor()
        //{
        //    int timeToMonitor = 0;

        //    DisplayHeader("Time to Monitor");

        //    Console.Write("\tEnter Time to Monitor: ");
        //    timeToMonitor = int.Parse(Console.ReadLine());

        //    DisplayMenuPrompt("Alarm System Menu");

        //    return timeToMonitor;
        //}
        //static void DisplayLightAlarmSetSensorsToMonitor()
        //{
            
        //}

        ///// <summary>
        ///// Alarm System Threshold Value
        ///// </summary>
        ///// <param name="sensorsToMonitor"></param>
        ///// <param name="finchRobot"></param>
        ///// <returns></returns>
        //static int DisplayAlarmSystemThresholdValue(string sensorsToMonitor, Finch finchRobot)
        //{
        //    int thresholdValue = 0;

        //    int currentLeftSensorValue = finchRobot.getLeftLightSensor();

        //    DisplayHeader("Threshold Value");

        //    //
        //    // display ambient values
        //    //
        //    switch (sensorsToMonitor)
        //    {
        //        case "left":
        //            Console.WriteLine($"\tCurrent {sensorsToMonitor} Sensor Value: {currentLeftSensorValue}");
        //            break;

        //        case "right":
        //            Console.WriteLine($"\tCurrent {sensorsToMonitor} Sensor Value: {currentRightSensorValue}");
        //            break;

        //        case "both":
        //            Console.WriteLine($"\tCurrent {sensorsToMonitor} Sensor Value: {currentLeftSensorValue}");
        //            Console.WriteLine($"\tCurrent {sensorsToMonitor} Sensor Value: {currentRightSensorValue}");
        //            break;

        //        default:
        //            Console.WriteLine("\tUnknown Sensor Reference");
        //            break;
        //    }

        //    DisplayMenuPrompt("Alarm System Menu");

        //    return thresholdValue;
        //}

        ///// <summary>
        ///// Alarm System Range Type
        ///// </summary>
        ///// <returns></returns>
        //static string DisplayAlarmSystemRangeType()
        //{
        //    string rangeType = "";

        //    DisplayHeader("Range Type");

        //    Console.Write("\tEnter Range Type [minimum, maximum]: ");
        //    rangeType = Console.ReadLine().Trim();

        //    DisplayMenuPrompt("Alarm System Menu");
        //    return rangeType;
        //}

        ///// <summary>
        ///// Alarm Systme Set Sensors
        ///// </summary>
        ///// <returns></returns>
        //static string DisplayAlarmSystemSetSensors()
        //{
        //    string sensorsToMonitor = "";

        //    DisplayHeader("Sensors to Monitor");

        //    Console.Write("\tEnter Sensors to Monitor [left, right, both]: ");
        //    sensorsToMonitor = Console.ReadLine().Trim();

        //    DisplayMenuPrompt("Alarm System Menu");

        //    return sensorsToMonitor;
        //}

        //#endregion

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
