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
    public class OperationsUI
    {
        public static void pet_op_menu()
        {
            ScreenUI petopscreen = new ScreenUI("Pet operations - make your pet happier!");
            Console.WriteLine("Choose an operation: (enter -1 to exit)");
            TryTamaContext bl = new TryTamaContext();
            int ind = 1;
            foreach(ActionInfo cur in bl.ActionInfos)
            {
                Console.WriteLine($"{ind}. " + cur.Actioninfoname);
                ind++;
            }

            const int IDSTART = 69;
            int OPTIONLEN = bl.ActionInfos.ToList().Count();
            int opt = Util.read_in_range_with_exit(OPTIONLEN);
            
            if(opt == -1)
            {
                HomePageUI.home_page_menu();
                return;
            }

            // finds current pet:
            var curpet = bl.Pets.Where(cur => cur.Id == CurPlayer.curPlayer.Activepetid).OrderBy(cur => cur.Id).LastOrDefault();

            // finds current operation:
            var curopt = bl.ActionInfos.Where(cur => cur.Actioninfoid == IDSTART + opt).OrderBy(cur => cur.Actioninfoid).LastOrDefault();

            bool success = curpet.do_operation(curopt, bl);
            Console.Clear();

            if (success)
            {
                Console.WriteLine("Action done succesfully.");
                Console.WriteLine($"Cleaness changed from {curpet.Cleanlevel - curopt.Cleannesseffect} to {curpet.Cleanlevel}");
                Console.WriteLine($"happiness changed from {curpet.Happinesslevel - curopt.Happinesseffect} to {curpet.Happinesslevel}");
                Console.WriteLine($"Hunger changed from {curpet.Hungerlevel - curopt.Hungereffect} to {curpet.Hungerlevel}");
                Console.WriteLine($"Weight changed from {curpet.Petweight - curopt.Weighteffect} to {curpet.Petweight}");
            }
            else
            {
                Console.WriteLine("Failed to do action.");
            }    
            petopscreen.wait();
            HomePageUI.home_page_menu();

        }
    }
}
