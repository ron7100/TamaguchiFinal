using System;
using System.Collections.Generic;
using System.Text;

namespace TamaProg.UI
{
    public class About
    {
        public static void printAbout()
        {
            ScreenUI screen = new ScreenUI("About");
            Console.WriteLine("This is a program created by Ron and Yoav");
            Console.WriteLine("The program simulates a Tamaguchi game.");
            Console.WriteLine("All the rights are reserved to Ron and Yoav, take it or leave it.");
            screen.wait();
        }
    }
}
