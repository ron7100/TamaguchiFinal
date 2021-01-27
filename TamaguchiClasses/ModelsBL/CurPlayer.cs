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
    public class CurPlayer
    {
        public static Player curPlayer;
        public static Player GetPlayer()
        {
            return curPlayer;
        }

    }
}
