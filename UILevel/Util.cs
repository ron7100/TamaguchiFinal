using System;
using System.Collections.Generic;
using System.Text;

namespace UILevel
{
    public class Util
    {
        public static int read_int()
        {
            return int.Parse(Console.ReadLine());
        }

        public static string read_string()
        {
            return Console.ReadLine();
        }

        // Reads an integer. Keeps reading and requesting a new integer as long as it is out of bounds.
        public static int read_in_range(int maxval)
        {
            int opt;
            opt = read_int();
            while (opt < 1 || opt > maxval)
            {
                Console.WriteLine($"Invalid input. Please enter a number from 1 to {maxval}.");
                Console.WriteLine("Please Enter again.");
                opt = Util.read_int();
            }
            return opt;
        }

        // Reads an integer. Keeps reading and requesting a new integer as long as it is out of bounds nor -1.
        public static int read_in_range_with_exit(int maxval)
        {
            int opt;
            opt = read_int();
            while ((opt < 1 || opt > maxval) && (opt != -1))
            {
                Console.WriteLine($"Invalid input. Please enter a number from 1 to {maxval} (or -1 to exit).");
                Console.WriteLine("Please Enter again.");
                opt = Util.read_int();
            }
            return opt;
        }
    }
}
