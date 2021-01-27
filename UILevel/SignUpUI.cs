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
    public class SignUpUI:ScreenUI
    {
        public static void sign_up_main()
        {
            ScreenUI signupscreen = new ScreenUI("Sign Up");
            
            Console.WriteLine("Enter first name");
            string fname = Util.read_string();
            Console.WriteLine("Enter last name");
            string lname = Util.read_string();
            Console.WriteLine("Enter user name");
            string username = Util.read_string();
            Console.WriteLine("Enter password");
            string pass = Util.read_string();
            Console.WriteLine("Enter email");
            string email = Util.read_string();
            Console.WriteLine("Enter gender (Please enter \"male\" or \"female\" or \"other\")");
            string gender = Util.read_string();
            Console.WriteLine("Enter birth year");
            int year = Util.read_int();
            Console.WriteLine("Enter birth month");
            int month = Util.read_int();
            Console.WriteLine("Enter birth day");
            int day = Util.read_int();
            DateTime d = new DateTime(year, month, day);
            TryTamaContext bl = new TryTamaContext();
            Player curp = new Player(fname, lname, username, pass, email, gender, d);
            curp.sign_up(bl);
            HomePageUI.home_page_menu();
        }
    }
}