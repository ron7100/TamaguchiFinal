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
    public class SignInUI:ScreenUI
    {
        public static void sign_in_main()
        {
            ScreenUI signinscreen = new ScreenUI("Sign In");

            bool foundPlayer = false;
            bool start = true;
            string username = "", pass = "";
            while(!foundPlayer)
            {
                if(!start) Console.WriteLine("Invalid username or password");
                start = false;
                Console.WriteLine("Enter username (enter \"-1\" to go back)");
                username = Util.read_string();
                if (username == "-1")
                {
                    MainUI.MainMenu();
                    return;
                }

                Console.WriteLine("Enter password (enter \"-1\" to go back)");
                pass = Util.read_string();
                if (pass == "-1")
                {
                    MainUI.MainMenu();
                    return;
                }
                foundPlayer = Player.has_player(username, pass);
            }
            Player curplayer = Player.find_player(username, pass);
            curplayer.sign_in();
            HomePageUI.home_page_menu();
        }
    }
}
