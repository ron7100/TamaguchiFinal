using System;
using TamaProg.UI;
using TamaProg.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using UILevel.DataTransferObjects;
using UILevel.WebServices;


namespace TamaProg.UI
{
    public class HomePageUI:ScreenUI
    {
        public static void home_page_menu()
        {
            ScreenUI homepagescreen = new ScreenUI("Home Page");
            PlayerDTO p = new PlayerDTO();
            const int OPTIONLEN = 4;
            const int PETOP = 1, PETSTATS = 2, PETHISTORY = 3, LOGOUT = 4;
            string[] optionsArr = { "Make your pet happier :)", "Stats about your pet", "Pet history", "Log out" };
            List<string> homepageoptions = new List<string>();
            homepageoptions.AddRange(optionsArr);
            homepagescreen.PrintList(homepageoptions);

            ScreenUI.choose_cmd(OPTIONLEN);
            int optioninput = Util.read_in_range(OPTIONLEN);

            switch (optioninput)
            {
                case PETOP:
                    OperationsUI.pet_op_menu();
                    return;
                case PETSTATS:
                    StatsUI.stats_menu();
                    return;
                case PETHISTORY:
                    PetHistoryUI.pet_history_menu();
                    return;
                case LOGOUT:
                    p.sign_out();
                    MainUI.MainMenu();
                    return;
            }
        }
    }
}
