using System;

namespace SolarOS_beta_
{
    public static class Snake
    {
        public static int score;
        public static int count;
        public static int[] x; // righe
        public static int[] y; // colonne
        public enum EDirection : int { none, left, right, up, down }
        public static EDirection direction;
        public static bool lose;
        public static void Start()
        {
            Console.Clear();
            score = 0;
            count = 0;
            lose = false;       //la variabile perdita = false per far continuare il ciclo
            direction = EDirection.none;
            x = new int[] { Console.WindowWidth / 2 };
            y = new int[] { Console.WindowHeight / 2 };
            do
            {
                // Ciclo del gioco
                {
                    //Lettura tasto
                    Console.WriteLine("Premere una freccia");
                    ConsoleKey key = Console.ReadKey().Key;
                    Console.Clear();
                    // Set the direction
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            direction = EDirection.up;
                            break;
                        case ConsoleKey.DownArrow:
                            direction = EDirection.down;
                            break;
                        case ConsoleKey.LeftArrow:
                            direction = EDirection.left;
                            break;
                        case ConsoleKey.RightArrow:
                            direction = EDirection.right;
                            break;
                    }
                    // Su
                    switch (direction)
                    {
                        case EDirection.up:
                            y[y.Length] = y[y.Length - 1] - 1;
                            if (y[y.Length - 1] == 0) lose = true;
                            break;
                        case EDirection.down:
                            y[y.Length] = y[y.Length - 1] + 1;
                            if (y[y.Length - 1] == Console.WindowHeight) lose = true;
                            break;
                        case EDirection.left:
                            x[x.Length] = x[x.Length - 1] - 1;
                            if (x[x.Length - 1] == 0) lose = true;
                            break;
                        case EDirection.right:
                            x[x.Length] = x[x.Length - 1] + 1;
                            if (x[x.Length - 1] == Console.WindowWidth) lose = true;
                            break;
                        case EDirection.none:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    // Pulitura schermo
                    Console.Clear();
                    // Disegno posizione X
                    foreach (int posx in x)
                    {
                        Console.CursorLeft = posx;
                        Utilita.SolarOSConsole.WriteLine("#", ConsoleColor.Green);
                    }
                    // Disegno posizione Y
                    foreach (int posy in y)
                    {
                        Console.CursorTop = posy;
                        Utilita.SolarOSConsole.WriteLine("#", ConsoleColor.Green);
                    }
                    // Se count è >= 8
                    if (count >= 8)
                    {
                        // Rimozione della prima posizione di X
                        x[count] = 0;
                        // Rimozione della prima posizione di Y
                        y[count] = 0;
                    }
                    // Incremento del count
                    if (direction != EDirection.none) count++;
                    // Incremento dello score
                    if (direction != EDirection.none) score += 2;
                }
            } while (!lose); // cicla finchè non è finito il gioco
            Console.Clear(); //pulitura della console
            Console.CursorTop = (Console.WindowWidth/2) - 2;
            Utilita.SolarOSConsole.WriteLine("YOU LOSE!", ConsoleColor.Red, true); //scrittura del hai perso
            Console.CursorTop++;
            Utilita.SolarOSConsole.WriteLine("Your score: " + score, ConsoleColor.White, true); //scrittura del punteggio
        }
    }
}
