using System;
using c = System.Console;

namespace SolarOS_beta_
{
    internal class Utilita
    {
    public static class SolarOSConsole
    {
        public static void Write(string text = null, ConsoleColor color = ConsoleColor.White, bool xcenter = false, bool ycenter = false)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            int X = Console.CursorLeft;
            if (xcenter) if (text != null) Console.CursorLeft = ((Console.WindowWidth / 2) - (text.Length / 2));
            int Y = Console.CursorTop;
            if (ycenter) Console.CursorTop = ((Console.WindowHeight / 2) - 1);
            Console.Write(text);
            if (xcenter) Console.CursorLeft = X;
            if (ycenter) Console.CursorTop = Y;
            Console.ForegroundColor = originalColor;
        }
        public static void WriteLine(string text = null, ConsoleColor color = ConsoleColor.White, bool xcenter = false, bool ycenter = false)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            int X = Console.CursorLeft;
            if (xcenter) Console.CursorLeft = ((Console.WindowWidth / 2) - (text.Length / 2));
            int Y = Console.CursorTop;
            if (ycenter) Console.CursorTop = ((Console.WindowHeight / 2) - 1);
            Console.WriteLine(text);
            if (xcenter) Console.CursorLeft = X;
            if (ycenter) Console.CursorTop = Y;
            Console.ForegroundColor = originalColor;
        }
        public static void Write(string __value, ConsoleColor __cc)
        {
            ConsoleColor cc = c.ForegroundColor;
            c.ForegroundColor = __cc;
            c.Write(__value);
            c.ForegroundColor = cc;
        }
        public static void WriteLine(string __value, ConsoleColor __cc)
        {
            ConsoleColor cc = c.ForegroundColor;
            c.ForegroundColor = __cc;
            c.WriteLine(__value);
            c.ForegroundColor = cc;
        }
    }
        public static class Memory
        {
            public static uint GetMemory() { return Cosmos.Core.CPU.GetAmountOfRAM() + 2; }
        }
        public static class Out
        {
            public enum PromptTypes { Standard, Echo, Info, Warning, Error }
            public static PromptTypes prompt { get; set; }
            public static void WritePrompt()
            {
                switch (prompt)
                {
                    case PromptTypes.Standard:
                        SolarOSConsole.Write("SolarOS> ", ConsoleColor.White); break;
                    case PromptTypes.Warning:
                        SolarOSConsole.Write("SolarOS> ", ConsoleColor.Yellow); break;
                    case PromptTypes.Error:
                        SolarOSConsole.Write("SolarOS> ", ConsoleColor.Red); break;
                    case PromptTypes.Echo:
                        SolarOSConsole.Write("User   > ", ConsoleColor.Gray); break;
                    case PromptTypes.Info:
                        SolarOSConsole.Write("Info   > ", ConsoleColor.Green); break;
                }
            }
            public static void SwitchPrompt(PromptTypes __prompt = PromptTypes.Standard) { prompt = __prompt; }
            public static void WriteError(string __excpt)
            {
                PromptTypes oldprompt = prompt;
                SwitchPrompt(PromptTypes.Error);
                c.WriteLine(__excpt);
                SwitchPrompt(oldprompt);
            }
            public static void WriteInformation(string __info)
            {
                PromptTypes oldprompt = prompt;
                SwitchPrompt(PromptTypes.Info);
                c.WriteLine(__info);
                SwitchPrompt(oldprompt);
            }
        }
        public static class Attendi
        {
            public static void AttendiTick(int value)
            {
                for (int i = 0; i < value; i++) { ;}
                return;
            }
            public static void AttendiSecondi(int value)
            {
                int start = Cosmos.Hardware.RTC.Second; int end;
                if (start + value > 59) end = 0;
                else end = start + value;
                while (Cosmos.Hardware.RTC.Second != end) { ;}
            }
            public static int ContaTick()
            {
                int tick = 0;
                var second = Cosmos.Hardware.RTC.Second.ToString("00");
                while (second == Cosmos.Hardware.RTC.Second.ToString("00"))
                    tick++;
                return tick;
            }
        }
    }
}
