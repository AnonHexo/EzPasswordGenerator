using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EzPwdGen
{
    class Program
    {
        public static void Banner()
        {
            Console.WriteLine("\n");
            Console.WriteLine(" ______     _____              _  _____            ");
            Console.WriteLine("|  ____|   |  __ \\            | |/ ____|           ");
            Console.WriteLine("| |__   ___| |__) |_      ____| | |  __  ___ _ __  ");
            Console.WriteLine("|  __| |_  /  ___/\\ \\ /\\ / / _` | | |_ |/ _ \\ '_ \\ ");
            Console.WriteLine("| |____ / /| |     \\ V  V / (_| | |__| |  __/ | | |");
            Console.WriteLine("|______/___|_|      \\_/\\_/  \\___|\\_____|\\___|_| |_|");
            Console.WriteLine("\n                                by ***");
            Console.WriteLine("\n");
        }

        static RNGCryptoServiceProvider provider = new();
        public static void Main(string[] args)
        {
            Console.Title = "Ez Password Generator | by ***";
            Banner();
            Thread.Sleep(3000);
            Console.Clear();

            int PasswordAmount = 1;
            int PasswordLength = 10;

            bool bCapitals = true;
            bool bDigits = true;
            bool bSpecial = true;

            Console.WriteLine("[?] You want to use capitals? (Y/N):");
            try
            {
                switch (char.Parse(Console.ReadLine()))
                {
                    case 'Y':
                        break;
                    case 'N':
                        bCapitals = false;
                        break;
                    case 'y':
                        break;
                    case 'n':
                        bCapitals = false;
                        break;
                    default:
                        Console.WriteLine("[-] Invalid input, using default value (true)");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("[-] Invalid input, using default value (true)");
                Thread.Sleep(2000);
                Console.Clear();
            }


            Console.WriteLine("[?] You want to use digits? (Y/N):");
            try
            {
                switch (char.Parse(Console.ReadLine()))
                {
                    case 'Y':
                        break;
                    case 'N':
                        bDigits = false;
                        break;
                    case 'y':
                        break;
                    case 'n':
                        bDigits = false;
                        break;
                    default:
                        Console.WriteLine("[-] Invalid input, using default value (true)");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("[-] Invalid input, using default value (true)");
                Thread.Sleep(2000);
                Console.Clear();
            }

            Console.WriteLine("[?] You want to use special characters? (Y/N):");
            try
            {
                switch (char.Parse(Console.ReadLine()))
                {
                    case 'Y':
                        break;
                    case 'N':
                        bSpecial = false;
                        break;
                    case 'y':
                        break;
                    case 'n':
                        bSpecial = false;
                        break;
                    default:
                        Console.WriteLine("[-] Invalid input, using default value (true)");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("[-] Invalid input, using default value (true)");
                Thread.Sleep(2000);
                Console.Clear();
            }





            string CapitalLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string SmallLetters = "qwertyuiopasdfghjklzxcvbnm";
            string Digits = "0123456789";
            string SpecialCharacters = "!@#$%^&*()-_=+<,>.";
            string AllChar = SmallLetters;
            if (bCapitals)
            {
                AllChar += CapitalLetters;
            } if (bDigits)
            {
                AllChar += Digits;
            } if (bSpecial)
            {
                AllChar += SpecialCharacters;
            }


            Console.Clear();
            Console.Title = "Ez Password Generator | Settings: lowercase" +
                $"{(bCapitals ? ", capitals" : ", no capitals")}" +
                $"{(bDigits ? ", digits" : ", no digits")}" +
                $"{(bSpecial ? ", special characters" : ", no special characters")} | by ***";
            Console.WriteLine("[?] Enter amount of passwords:");
            try
            {
                PasswordAmount = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("[-] Invalid input, using default value (1)");
            }

            Console.WriteLine("[?] Enter the passwords length:");
            try
            {
                PasswordLength = int.Parse(Console.ReadLine());
            } catch (FormatException)
            {
                Console.WriteLine("[-] Invalid input, using default value (10)");
                Thread.Sleep(1000);
            }

            Console.Clear();
            Banner();
            Console.WriteLine($"[...] Generating {PasswordAmount} password(s) containing {PasswordLength} characters using: lowercase" +
                $"{(bCapitals ? ", capitals" : ", no capitals")}" +
                $"{(bDigits ? ", digits" : ", no digits")}" +
                $"{(bSpecial ? ", special characters" : ", no special characters")}.");
            Thread.Sleep(3000);

            string[] AllPasswords = new string[PasswordAmount];

            for (int i = 0; i < PasswordAmount; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int n = 0; n < PasswordLength; n++)
                {
                    Console.Title = $"Ez Password Generator | Generating {i} of {PasswordAmount} password ({n}/{PasswordLength}) | " +
                        $"Settings: lowercase " +
                        $"{(bCapitals ? ", capitals" : ", no capitals")}" +
                        $"{(bDigits ? ", digits" : ", no digits")}" +
                        $"{(bSpecial ? ", special characters" : ", no special characters")}" +
                        " | by ***";
                    sb = sb.Append(GenerateChar(AllChar));
                }

                AllPasswords[i] = sb.ToString();
            }

            Console.WriteLine("\n[+] Generated passwords:");

            foreach (string singlePassword in AllPasswords)
            {
                Console.WriteLine((Array.IndexOf(AllPasswords, singlePassword) +1) + ") " + singlePassword);
            }
            Console.WriteLine("\n\n- by https://github.com/AnonHexo");
            Console.ReadLine();
        }

        private static char GenerateChar(string availableChars)
        {
            var byteArray = new byte[1];
            char c;
            do
            {
                provider.GetBytes(byteArray);
                c = (char)byteArray[0];

            } while (!availableChars.Any(x => x == c));

            return c;
        }
    }

}