using System;
using System.Threading;

namespace vecame
{
    class PR 
    { 
        public int Hp { get; set; }
        public int[] Poz { get; set;}
        public int[] Level { get; set; }

        public PR() {
            Hp = 10;
            Level = new int[2];
            Level[0] = 0;
            Level[1] = 0;
        }
    }
    class GM
    {
        public void IN(int[] sx, string[,] palya, int[] poz) 
        {
            for (int i = 0; i < sx[0]; i++)
            {
                for (int j = 0; j < sx[1]; j++)
                {
                    if (poz[0] == i && poz[1] == j)
                    {
                        palya[i, j] = "x";
                    }
                    else
                    {
                        palya[i, j] = "o";
                    }
                }
            }
        }
        public void CT(int[] sx, string[,] palya) 
        {
            for (int i = 0; i < sx[0]; i++)
            {
                for (int j = 0; j < sx[1]; j++)
                {
                    Console.Write(palya[i, j]);
                    Thread.Sleep(10);
                }
                Console.WriteLine();
            }
        }
        public int CH(ConsoleKeyInfo c, int[] sx) {

            switch (c.Key)
            {
                case ConsoleKey.A:
                    return sx[0] = sx[1] = 15;
                case ConsoleKey.B:
                    return sx[0] = sx[1] = 10;
                case ConsoleKey.C:
                    return sx[0] = sx[1]= 5;
                default:
                    goto case ConsoleKey.A;
            }
        }
        public void MV(ConsoleKeyInfo d, PR jatekos, int[] sx, int[] lvl)
        {
            int a, b;
            switch (d.Key)
            {
                    case ConsoleKey.UpArrow:
                    a = jatekos.Poz[0];
                    b = (jatekos.Poz[0] - 1 + sx[0]) % sx[0];
                    jatekos.Poz[0] = b;
                    if (a - b < 0)
                    {
                        lvl[0]++;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    a = jatekos.Poz[0];
                    b = (jatekos.Poz[0] + 1 + sx[0]) % sx[0];
                    jatekos.Poz[0] = b;
                    if (a - b > 0)
                    {
                        lvl[0]--;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    a = jatekos.Poz[1];
                    b = (jatekos.Poz[1] - 1 + sx[1]) % sx[1];
                    jatekos.Poz[1] = b;
                    if (a - b < 0)
                    {
                        lvl[1]--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    
                    a = jatekos.Poz[1];
                    b = (jatekos.Poz[1] + 1 + sx[1]) % sx[1];
                    jatekos.Poz[1] = b;
                    if (a - b > 0)
                    {
                        lvl[1]++;
                    }
                    break;
                default:
                        Console.WriteLine("FIGYEL! TELJESÍT!");
                        Console.ReadKey();
                    break;
                }
}
    }
    class Program
    {
        static void Main(string[] args)
        {
            //valtozok
            //#1
            PR jatekos = new PR();
            jatekos.Poz = new int[2];
            jatekos.Poz[0] = 1;
            jatekos.Poz[1] = 1;
            //#2
            int[] sizex = new int[2];
            GM gmaster = new GM();
            
            //nehezsegi szint valasztas
            Console.Write("A=Nagy\nB=Közepes\nC=Kicsi\n");
            ConsoleKeyInfo c = Console.ReadKey();
            gmaster.CH(c,sizex);
            Console.Clear();

            //palya keszites
            string[,] palya = new string[sizex[0], sizex[1]];
            gmaster.IN(sizex, palya, jatekos.Poz);
            gmaster.CT(sizex, palya);
 
            //visszateres

            //parancs
            Console.WriteLine("\nMOZOGJ! UP DOWN LEFT RIGHT");

            Console.SetCursorPosition(0, Console.CursorTop - 2);

            //utasit
            while (1 > 0) {
                ConsoleKeyInfo d = Console.ReadKey();
                gmaster.MV(d, jatekos, sizex, jatekos.Level);
                gmaster.IN(sizex, palya, jatekos.Poz);
                Console.Clear();
                gmaster.CT(sizex, palya);
                Console.WriteLine($"\nEletero:{jatekos.Hp} Pálya: {jatekos.Level[0]}/{jatekos.Level[1]}");
            }
        }
    }
}
