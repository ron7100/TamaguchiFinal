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
    public class MainUI : ScreenUI
    {
        public static void MainMenu()
        {
            Console.WriteLine("We Reached MainProg");
            ScreenUI menu = new ScreenUI("Main Menu");

            const int OPTIONLEN = 4;
            const int SIGNINVAL = 1, SIGNUPVAL = 2, ABOUTVAL = 3, EXITVAL = 4;
            string[] optionsArr = { "Sign in", "Sign up", "About", "Exit :("};
            List<string> menuoptions = new List<string>();
            menuoptions.AddRange(optionsArr);
            menu.PrintList(menuoptions);
            ScreenUI.choose_cmd(OPTIONLEN);
            int optioninput = Util.read_in_range(OPTIONLEN);

            switch (optioninput)
            {
                case SIGNINVAL:
                    SignInUI.sign_in_main();
                    MainMenu();
                    return;
                case SIGNUPVAL:
                    SignUpUI.sign_up_main();
                    MainMenu();
                    return;
                case ABOUTVAL:
                    About.printAbout();
                    MainMenu();
                    return;
                case EXITVAL:
                    Console.WriteLine("Exiting from Tamaguchi - see you soon!");
                    Environment.Exit(0);
                    return;
            }
        }
    }
}
