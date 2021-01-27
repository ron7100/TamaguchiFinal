using System;
using TamaProg.UI;
using TamaProg.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;


namespace TamaProg.Models
{
    public partial class Pet
    {
        public bool do_operation(ActionInfo curopt, TryTamaContext bl)
        {
            try
            {
                Cleanlevel += curopt.Cleannesseffect;
                Happinesslevel += curopt.Happinesseffect;
                Hungerlevel += curopt.Hungereffect;
                Petweight += (int)curopt.Weighteffect;

                ActionsHistory newAction = new ActionsHistory
                {
                    PetId = Id,
                    LifeSpanId = Lifespanid,
                    ActionId = curopt.Actioninfoid
                };

                bl.ActionsHistories.Add(newAction);
                bl.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
