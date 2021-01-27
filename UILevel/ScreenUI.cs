using System;
using TamaProg.UI;
using TamaProg.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;



namespace TamaProg.UI
{

    public class ScreenUI
    {

        public void wait()
        {
            Console.WriteLine("(Press any character to continue)");
            Console.ReadKey();
        }
        public void PrintList(List<string> l)
        {
            int counter = 1;
            foreach (string curstr in l)
            {
                Console.WriteLine(counter + ". " + curstr);
                counter++;
            }
        }
        public static void Title(string name)
        {
            Console.WriteLine("--- " + name + " ---");
        }
        public ScreenUI()
        {
            Console.Clear();
            Title("Tamaguchi");
            if (CurPlayer.curPlayer != null) Console.WriteLine($"Welcome {CurPlayer.curPlayer.Username}!");
        }

        public ScreenUI(string titlename)
        {
            new ScreenUI();
            Console.WriteLine();
            Title(titlename);
            Console.WriteLine();
        }

        public static void choose_cmd(int len)
        {
            Console.WriteLine($"Please enter your option (insert a value from 1 to {len}).");
        }

    }
}
