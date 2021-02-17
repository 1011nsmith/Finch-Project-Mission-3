using FinchAPI;
using System;

namespace Finch_Starter
{
    class Program
    {
        // *************************************************************
        // Application:     The Talent Show
        // Author:          Smith, Nathan C
        // Description:
        // Date Created:    5/20/2016
        // Date Revised:    
        // *************************************************************

        static void Main(string[] args)
        {
            //
            // create a new Finch object and connect
            //
            Finch myFinch;
            myFinch = new Finch();
            myFinch.connect();

            ExploreLeds(myFinch);
            
            ExploreSounds(myFinch);
            
            ExploreMovement(myFinch);

            DisplayContinuePropmt();

            myFinch.disConnect();
        }

        static void ExploreMovement(Finch myFinch)
        {
            myFinch.setMotors(255, 255);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);

            myFinch.setMotors(-255, -255);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);

            myFinch.setMotors(0, 255);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);

            myFinch.setMotors(255, 100);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);

            myFinch.setMotors(-100, 200);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);
        }

        static void ExploreSounds(Finch myFinch)
        {
            //myFinch.noteOn(261);
            //myFinch.wait(1000);
            //myFinch.noteOff();

            //for (int frequency = 0; frequency < 2000; frequency = frequency + 100)
            //{
            //    myFinch.noteOn(frequency);
            //    myFinch.wait(2);
            //    myFinch.noteOff();
            //}

            for (int count = 0; count < 10; count++)
            {
                myFinch.noteOn(261);
                myFinch.wait(100);
                myFinch.noteOff();
                myFinch.wait(100);
            }
        }

        static void ExploreLeds(Finch myFinch)
        {
            //myFinch.setLED(255, 0, 0);
            //myFinch.wait(1000);
            //myFinch.setLED(0, 255, 0);
            //myFinch.wait(1000);
            //myFinch.setLED(0, 0, 255);
            //myFinch.wait(1000);
            //myFinch.setLED(0, 0, 0);

            for (int ledValue = 0; ledValue < 255; ledValue++)
            {
                myFinch.setLED(ledValue, ledValue, ledValue);
                myFinch.wait(10);
            }

            for (int ledValue = 255; ledValue > 0; ledValue--)
            {
                myFinch.setLED(ledValue, ledValue, ledValue);
                myFinch.wait(10);
            }
        }

        static void DisplayContinuePropmt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
