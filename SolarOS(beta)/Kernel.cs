using System;
using Sys = Cosmos.System;
using c = SolarOS_beta_.Utilita.SolarOSConsole;

namespace SolarOS_beta_
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Core.Stampa_Logo();     //stampa logo
            #region Controllo memoria
            Console.Write("#Memoria : " + Utilita.Memory.GetMemory() + "MB");
            if (Utilita.Memory.GetMemory() >= 256) c.WriteLine(" OK", ConsoleColor.Green);
            else c.WriteLine(" >256 MB RAM raccomandati!", ConsoleColor.Yellow);
            #endregion
            #region Controllo Filesystem
            Console.Write("#Inizializzazione Filsystem ...");
            // Filesystem.Initialize();
            c.WriteLine(" In corso di implementazione!(non ancora finito)", ConsoleColor.Yellow);
            #endregion
            #region Controllo Tastiera
            Console.Write("# Controllo regione tastiera : ");
            c.WriteLine(" OK", ConsoleColor.Green);
            #endregion
            #region Inizializzazione ACPI
            Console.Write("# Inizializzazione ACPI");
            if (ACPI.Init() == 0) c.WriteLine("OK", ConsoleColor.Green);
            else c.WriteLine("FAILD", ConsoleColor.Red);
            Console.WriteLine("#Abilitazione ACPI");
            #endregion
            c.WriteLine("Premere un tasto per continuare...", ConsoleColor.Gray);
            Console.Read();
            Console.Clear();
        }

        protected override void Run()
        {
            while (true)
            {
                Core.Stampa_Logo();
            cicloeterno:
                Utilita.Out.WritePrompt(); Comandi_Console.validate(Console.ReadLine());
                goto cicloeterno;
            }
        }
    }
}
