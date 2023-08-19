using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MorseConvert
{
    internal class Program
    {
        static void Title()
        {
            Console.WriteLine();
            {//title
                Console.WriteLine(" ///===========================< MORSE CODE >===========================\\\\\\");
                Console.WriteLine("|||  |\\  /|  //||\\  |||\\\\  //// |||\\     //// ||| || ||| // |||\\\\ |||||  |||");
                Console.WriteLine("|||  ||\\/|| |||  || |||//  \\\\\\\\ ||\\  {} ||    |||\\|| |||//  |||//  |||   |||");
                Console.WriteLine("|||  ||||||  \\\\||/  |||\\\\  //// |||/     \\\\\\\\ |||\\\\| |||/   |||\\\\  |||   |||");
                Console.WriteLine(" \\\\\\===========================< TRANSLATOR >===========================///");
            }
            {//command list
                Console.WriteLine("\n____________________________________________________________________________\n" +
                    "                            \\\\ Command List //\n" +
                    "----------------------------------------------------------------------------");
                Console.WriteLine("             '1' - ENG to MOR        ||   'q' - Toggle Dynamic" +
                                "\n             '2' - MOR to ENG        ||   'w' - Toggle Classic" +
                                "\n             '3' - Command List      ||   'e' - Exit" +
                                "\n             '4' - Current Settings  ||   'r' - Reset");
                Console.WriteLine("____________________________________________________________________________");
            }
            {//disclosures
                Console.WriteLine("\n   * Dynamic allows for case sensitive messages ");
                Console.WriteLine("   * Classic uses extra spaces rather than the conventional '/' ");
                Console.WriteLine("   * Special settings are in a non cross compatible format ");
            }
            Console.WriteLine("\n============================================================================");
        }
        static void Start(bool upper, bool space)
        {
            //groups the start functions for the translation tables
            ToMor.Start(upper, space);
            ToEng.Start(upper, space);
        }
        static void CommandList()
        {
            //displays command list to user
            Console.WriteLine("--------\n  COMMAND LIST");
            Console.WriteLine(" '1' - ENG to MOR\n '2' - MOR to ENG\n '3' - Command List\n '4' - Current Settings");
            Console.WriteLine(" 'q' - Toggle Dynamic\n 'w' - Toggle Classic\n 'e' - Exit\n 'r' - Reset\n--------");
        }
        static string GetInput()
        {
            //gets input for command, not translation
            Console.Write("\n=> Input: ");
            return Console.ReadLine().ToLower().Trim();
        }
        static void Convert_ToMor(bool upper)
        {
            //converts from english to morse code, then formats input and display
            if (upper)
            {
                Console.Write("     ENG: ");
                Console.WriteLine($"     MOR: {ToMor.Convert(Console.ReadLine().Trim())} \n");
            }
            else
            {
                Console.Write("     ENG: ");
                Console.WriteLine($"     MOR: {ToMor.Convert(Console.ReadLine().ToLower().Trim())} \n");
            }
        }
        static void Convert_ToLet()
        {
            //converts from morse code to english, then formats input and display
            Console.Write("     MOR: ");
            Console.WriteLine($"     ENG: {ToEng.Convert(Console.ReadLine().Trim())} \n");
        }
        static void Main(string[] args)
        {
        start:
            bool cont = true;
            bool upper = false;
            bool space = false;
            string upper_On;
            string space_On;
            Title();
            Start(upper, space);
            
            
            while (cont)
            {
                Thread.Sleep(500);
                string opt = GetInput();               

                switch (opt)
                {
                    case "1":
                        Convert_ToMor(upper);
                        break;
                    case "2":
                        Convert_ToLet();
                        break;
                    case "3":
                        CommandList();
                        Console.WriteLine();
                        break;
                    case "4":
                        upper_On = (upper) ? "ON" : "OFF";
                        space_On = (space) ? "ON" : "OFF";
                        Console.WriteLine($" Dynamic: {upper_On}\n Classic: {space_On}\n");
                        break;
                    case "q":
                        upper = (upper == false) ? true : false;
                        Start(upper, space);
                        upper_On = (upper) ? "ON" : "OFF";
                        space_On = (space) ? "ON" : "OFF";
                        Console.WriteLine($" Dynamic: {upper_On}\n");
                        break;
                    case "w":
                        space = (space == false) ? true : false;
                        Start(upper, space);
                        upper_On = (upper) ? "ON" : "OFF";
                        space_On = (space) ? "ON" : "OFF";
                        Console.WriteLine($" Classic: {space_On}\n");
                        break;
                    case "e":
                        cont = false;
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine(" ///===========================< MORSE CODE >===========================\\\\\\");
                        Console.WriteLine("|||  |\\  /|  //||\\  |||\\\\  //// |||\\     //// ||| || ||| // |||\\\\ |||||  |||");
                        Console.WriteLine("|||  ||\\/|| |||  || |||//  \\\\\\\\ ||\\  {} ||    |||\\|| |||//  |||//  |||   |||");
                        Console.WriteLine("|||  ||||||  \\\\||/  |||\\\\  //// |||/     \\\\\\\\ |||\\\\| |||/   |||\\\\  |||   |||");
                        Console.WriteLine(" \\\\\\===========================< TRANSLATOR >===========================///");
                        Thread.Sleep(1000);
                        Console.WriteLine("Thanks for visiting");
                        Thread.Sleep(3000);
                        break;
                    case "r":
                        Thread.Sleep(1000);
                        Console.Clear();
                        goto start;
                    default:
                        Console.WriteLine("Invalid Command\n");
                        break;
                }
            }
        }
    }
}

