using System;
using FS_Utility;
using SolarOS_beta_;

namespace SolarOS_beta_
{
    class Comandi_Console
    {
        public static void validate(string __com)
        {
            string com = __com;
            string lcom = __com;

            if (lcom.Split(' ')[0] == "echo") Console.WriteLine(com.Remove(0, 5));
            else if (lcom.Split(' ')[0] == "print" || lcom.Split(' ')[0] == "scrivi") Console.WriteLine(com.Remove(0, 6));
            else if (lcom == "cls" || lcom == "clear" || lcom == "clearscreen" || lcom == "pulisci" || lcom == "pulisci schermo") { Console.Clear(); Core.Stampa_Logo(); }
            else if (lcom == "gui") GUI.StartGUI();
            else if (lcom == "help" || lcom == "h" || lcom == "aiuto" || lcom == "?") Commands.help();
            else if (lcom == "shutdown" || lcom == "spegni") Commands.shutdown();
            else if (lcom == "reboot" || lcom == "restart" || lcom == "riavvia") Commands.reboot();
            else if (lcom == "time") Commands.time();
            else if (lcom == "data" || lcom == "date") Commands.data();
            else if (lcom == "snake") Commands.snake();
            else if (lcom == "tick") Commands.tick();
            else if (lcom == "test") Commands.test();
            else if (lcom == "dispositivi") Commands.dispositivi();
        }
    }
    
    public static class Commands
    {
        public static void test()
        {
           // SolarOS_alpha_Test_.Memoria.Filesystem.Filesystem f = new SolarOS_alpha_Test_.Memoria.Filesystem.Filesystem();
           // f.CreaFS();
            Memoria.Filesystem.Filsystem f = new Memoria.Filesystem.Filsystem();
        }
        public static void dispositivi()
        {
           // SolarOS_alpha_Test_.Memoria.Filesystem.Filesystem f = new SolarOS_alpha_Test_.Memoria.Filesystem.Filesystem();
          //  f.Stampa_dispositivi();
        }
        public static void tick()
        {
            int t=0;
            t = Utilita.Attendi.ContaTick();
            Console.WriteLine(t);
        }
        public static void snake() 
        {
            Snake.Start();
        }
        public static void shutdown()
        {
           // Cosmos.System.Global.Dbg.Break();                   //break point
            Console.Clear();
            Console.WriteLine("Grazie Per aver usato SolarOS :)");
            Utilita.Attendi.AttendiSecondi(2);      //far attendere 3 secondi prima dello shutdown
            ACPI.Shutdown();
            ACPI.Disable();
            Cosmos.Core.Global.CPU.Halt();
        }
        public static void reboot() {
            Console.Clear();
            Console.WriteLine("Riavvio in corso...");
            ACPI.Reboot();
        }
        public static void help()
        {
                Console.Clear(); Core.Stampa_Logo();
                Console.WriteLine("-------------------< SolarOS  Help >--------------------");
                Console.WriteLine("help\t   stampa lista di comandi possibili");
                Console.WriteLine("cls\t   pulisce la console");
                Console.WriteLine("echo [Testo]\t   stampa un testo a schermo");
                Console.WriteLine("GUI\t   Entra nel test GUI (ancora in fase di sviluppo)");
                Console.WriteLine("time\t Mostra il tempo");
                Console.WriteLine("shutdown\t   spegne il computer");
                Console.WriteLine("snake\t (utilizza funzioni non implementate da rivedere)");
                Console.WriteLine("tick\t mostra i tick di sistema");
                Console.WriteLine("test\t per effettuare i test");
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("------------Premere-un-tasto-per-continuare-------------");
                Console.Read();
                Console.Clear(); Core.Stampa_Logo();
        }
        public static void time()
        {
            Console.Write("Sono le ore\t");
            Console.Write(Cosmos.Hardware.RTC.Hour.ToString());
            Console.Write(":");
            Console.Write(Cosmos.Hardware.RTC.Minute.ToString());
            Console.Write(":");
            Console.WriteLine(Cosmos.Hardware.RTC.Second.ToString());
        }
        public static void data()
        {
            time();
            Console.Write("La data odierna è\t");
            Console.Write(Cosmos.Hardware.RTC.DayOfTheMonth.ToString());
            Console.Write(":");
            Console.Write(Cosmos.Hardware.RTC.Month.ToString());
            Console.Write(":");
            Console.Write(Cosmos.Hardware.RTC.Year.ToString());
            Console.WriteLine();
        }
    }
}
