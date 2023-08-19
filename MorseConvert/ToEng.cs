using System;
using System.Collections.Generic;

namespace MorseConvert
{
    internal static class ToEng
    {
        //table of letters & morse
        public static SortedList<string, char> Txt = new SortedList<string, char>();
        public static void Start(bool upper, bool space)
        {
            //determines what key/value pairs to add for which mode
            Txt.Clear();
            if (upper)
            {
                Txt.Add("^.-", 'A');
                Txt.Add("^-...", 'B');
                Txt.Add("^-.-.", 'C');
                Txt.Add("^-..", 'D');
                Txt.Add("^.", 'E');
                Txt.Add("^..-.", 'F');
                Txt.Add("^--.", 'G');
                Txt.Add("^....", 'H');
                Txt.Add("^..", 'I');
                Txt.Add("^.---", 'J');
                Txt.Add("^-.-", 'K');
                Txt.Add("^.-..", 'L');
                Txt.Add("^--", 'M');
                Txt.Add("^-.", 'N');
                Txt.Add("^---", 'O');
                Txt.Add("^.--.", 'P');
                Txt.Add("^--.-", 'Q');
                Txt.Add("^.-.", 'R');
                Txt.Add("^...", 'S');
                Txt.Add("^-", 'T');
                Txt.Add("^..-", 'U');
                Txt.Add("^...-", 'V');
                Txt.Add("^.--", 'W');
                Txt.Add("^-..-", 'X');
                Txt.Add("^-.--", 'Y');
                Txt.Add("^--..", 'Z');
            }
            Txt.Add(".-", 'a');
            Txt.Add("-...", 'b');
            Txt.Add("-.-.", 'c');
            Txt.Add("-..", 'd');
            Txt.Add(".", 'e');
            Txt.Add("..-.", 'f');
            Txt.Add("--.", 'g');
            Txt.Add("....", 'h');
            Txt.Add("..", 'i');
            Txt.Add(".---", 'j');
            Txt.Add("-.-", 'k');
            Txt.Add(".-..", 'l');
            Txt.Add("--", 'm');
            Txt.Add("-.", 'n');
            Txt.Add("---", 'o');
            Txt.Add(".--.", 'p');
            Txt.Add("--.-", 'q');
            Txt.Add(".-.", 'r');
            Txt.Add("...", 's');
            Txt.Add("-", 't');
            Txt.Add("..-", 'u');
            Txt.Add("...-", 'v');
            Txt.Add(".--", 'w');
            Txt.Add("-..-", 'x');
            Txt.Add("-.--", 'y');
            Txt.Add("--..", 'z');
            Txt.Add(".----", '1');
            Txt.Add("..---", '2');
            Txt.Add("...--", '3');
            Txt.Add("....-", '4');
            Txt.Add(".....", '5');
            Txt.Add("-....", '6');
            Txt.Add("--...", '7');
            Txt.Add("---..", '8');
            Txt.Add("----.", '9');
            Txt.Add("-----", '0');
            Txt.Add(".-.-.-", '.');
            Txt.Add("--..--", ',');
            Txt.Add("..--..", '?');
            Txt.Add(".---.", '\'');
            Txt.Add("-.-.--", '!');
            Txt.Add("-..-.", '/');
            Txt.Add("-.--.", '(');
            Txt.Add("-.--.-", ')');
            Txt.Add(".-...", '&');
            Txt.Add("---...", ':');
            Txt.Add("-.-.-.", ';');
            Txt.Add("-...-", '=');
            Txt.Add(".-.-.", '+');
            Txt.Add("-....-", '-');
            Txt.Add("..--.-", '_');
            Txt.Add(".-..-.", '"');
            Txt.Add("...-..-", '$');
            Txt.Add(".--.-.", '@');
            Txt.Add("/", ' ');
            wspace = (space == true) ? true : false;
        }
        //translation mode related variable
        public static bool wspace;

        //convert & output
        public static string Convert(string x)
        {
            string input_Let = x;
            string c1;
            bool cont = true;
            string output = "";
            if (wspace)
            {
                input_Let = input_Let.Replace("     ", " / ");
            }
            do
            {
                //breaks morse into strings
                if (input_Let.Contains(" "))
                {

                    c1 = input_Let.Substring(0, input_Let.IndexOf(" "));
                    input_Let = input_Let.Substring(input_Let.IndexOf(" ") + 1);
                }
                else
                {
                    c1 = input_Let;
                    cont = false;
                }

                //conversion loop
                bool valid_Char = false;
                foreach (string c2 in Txt.Keys)
                {
                    if (c1 == c2)
                    {
                        output += $"{Txt[c2]}";
                        valid_Char = true;
                        break;
                    }
                }
                if (!valid_Char && !(c1 == ""))
                {
                    output += "{?}";
                }
            } while (cont);
            return output;
        }
    }
}

