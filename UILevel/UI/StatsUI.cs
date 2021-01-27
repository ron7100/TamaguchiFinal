using System;
using TamaProg.UI;
using TamaProg.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;


namespace UILevel.UI
{
    public class StatsUI:ScreenUI
    {
        public static void stats_menu()
        {
            ScreenUI statsscreen = new ScreenUI("Stats");
            TryTamaContext bl = new TryTamaContext();
            var curpet = bl.Pets.Where(cur => cur.Id == CurPlayer.curPlayer.Activepetid).OrderBy(cur => cur.Id).LastOrDefault();

            // finds current operation:
            Console.WriteLine($"Stats about the current pet of " + CurPlayer.GetPlayer().Username + " - " + curpet.Petname);

            var lifespan = bl.LifeSpans.Where(l => l.LifeSpanId == curpet.Lifespanid).OrderBy(r => r.LifeSpanId).LastOrDefault();
            var lifestatus = bl.LifeStatuses.Where(l => l.Lifestatusid == curpet.Lifestatusid).OrderBy(cur => cur.Lifestatusid).LastOrDefault();

            Console.WriteLine($"Life span: {lifespan.LifeSpanName}");
            Console.WriteLine($"Life status: {lifestatus.Lifestatusname}");

            Console.WriteLine($"Clean level: {curpet.Cleanlevel}");
            Console.WriteLine($"happiness level: {curpet.Happinesslevel}");
            Console.WriteLine($"Hunger level: {curpet.Hungerlevel}");
            Console.WriteLine($"Weight: {curpet.Petweight}");
            Console.WriteLine($"Birthdate: {curpet.Petbirthdate}");

            statsscreen.wait();
            HomePageUI.home_page_menu();
        }
    }
}
