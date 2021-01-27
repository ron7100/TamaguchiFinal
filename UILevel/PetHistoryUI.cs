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
    public class PetHistoryUI:ScreenUI
    {
        public static void pet_history_menu()
        {
            ScreenUI pethistscreen = new ScreenUI("Pet History");
            TryTamaContext bl = new TryTamaContext();
            var curpet = bl.Pets.Where(cur => cur.Id == CurPlayer.curPlayer.Activepetid).OrderBy(cur => cur.Id).LastOrDefault();
            Console.WriteLine("List of operations history of the pet - " + curpet.Petname);
            TryTamaContext bl2 = new TryTamaContext();
            foreach (ActionsHistory act in bl.ActionsHistories.Where(cur => cur.PetId == curpet.Id))
            {
                var curopt = bl2.ActionInfos.Where(cur => cur.Actioninfoid == act.ActionId).OrderBy(cur => cur.Actioninfoid).LastOrDefault();
                var curlifespan = bl2.LifeSpans.Where(l => l.LifeSpanId == act.LifeSpanId).OrderBy(r => r.LifeSpanId).LastOrDefault();
                
                Console.Write("Operation done: \"" + curopt.Actioninfoname + "\"");
                Console.WriteLine(" in the life span: " + curlifespan.LifeSpanName);
            }
            pethistscreen.wait();
        }
    }
}
