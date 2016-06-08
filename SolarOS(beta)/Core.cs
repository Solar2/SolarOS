using System;

namespace SolarOS_beta_
{
    internal class Core
    {
        public static string Version = "0.0.1b";
        public static void Mappatura_tastiera()
        {
            Console.WriteLine("Mappamento tastiera : {0}", Cosmos.Hardware.Global.Keyboard.ReadMapping());
            Console.WriteLine("Codice lettura tastiera : " + Cosmos.Hardware.Global.Keyboard.ReadScancode());
        }
        public static void Stampa_Logo()
        {
            int oldleft = Console.CursorLeft;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Versione numero : " + Version);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.CursorLeft = (Console.WindowWidth / 2) - ("----------------------------------- -------------------------".Length / 2);
            Console.Write("------------------------- ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("Solar OS");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" -------------------------");
            Console.CursorLeft = (Console.WindowWidth / 2) - ("--------------------------------------------------------------".Length / 2);
            Console.WriteLine("\t\t\t Test Alpha!");
            Console.CursorLeft = (Console.WindowWidth / 2) - ("------------------------------------ --------------------------".Length / 2);
            Console.WriteLine("--------------------------------------------------------------");
            Console.CursorLeft = oldleft;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--------------\\-----ççç----//-------------");
            Console.WriteLine("---------------\\--ç@@@@ç--//--------------");
            Console.WriteLine("------------====ç@@@@@@@@@ç====------------");
            Console.Write("---------=====ç@@@"); Utilita.SolarOSConsole.Write("SolarOS",ConsoleColor.Yellow); Console.WriteLine("@@ç=====----------");
            Console.WriteLine("------------====ç@@@@@@@@ç======-----------");
            Console.WriteLine("---------------//-ç@@@@ç-\\----------------");
            Console.WriteLine("--------------//----ççç---\\---------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
