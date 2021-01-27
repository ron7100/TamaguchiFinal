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
    public partial class Player
    {
        // constructs a player with the given attributes.
        public Player(string fname, string lname, string username, string pass, string email, string gender, DateTime d)
        {
            Pets = new HashSet<Pet>();
            this.Fname = fname;
            this.Lname = lname;
            this.Username = username;
            this.Pass = pass;
            this.Email = email;
            this.Gender = gender;
            this.Birthdate = d;
        }

        // Prints a player nicely.
        public void print()
        {
            Console.WriteLine($"Player:\nUsername: {this.Username}\nPass: {this.Pass}");
        }

        //Returns true if a player with matching username and pass exists, return false otherwise.
        public static bool has_player(string username, string pass)
        {
            TryTamaContext bl = new TryTamaContext();
            foreach(Player p in bl.Players)
            {
                if (p.Username.Equals(username) && p.Pass.Equals(pass)) return true;
            }
            return false;           
        }

        //Tries to find a player with matching username and password. Returns the player.
        public static Player find_player(string username, string pass)
        {
            try
            {
                TryTamaContext bl = new TryTamaContext();
                foreach (Player p in bl.Players)
                {
                    if (p.Username == username && p.Pass == pass) return p;
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        
        //Signs in the curPlayer. Returns true if done successfully, false otherwise.
        public bool sign_in()
        {
            CurPlayer.curPlayer = this;
            bool found = has_player(this.Username, this.Pass);
            if(!found)
            {
                Console.WriteLine("Player nor found. Wrong username or password...");
                return false;
            }
            CurPlayer.curPlayer = this;
            return true;
        }
        
        //signs up a new player
        public void sign_up(TryTamaContext bl)
        {
            bl.Players.Add(this);
            bl.SaveChanges();
            this.sign_in();
        }

        //Signs out the current player.
        public void sign_out()
        {
            CurPlayer.curPlayer = null;
        }
    }
}
        