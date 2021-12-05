using System;
using System.Collections;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            while (arena.CheckWin() == Arena.TranslatePlayer(0))
            {
                arena.RenderArena();
                int input = int.Parse( Console.ReadLine());
                arena.PlayerPlay(input);
                Console.WriteLine("\n\n\n");
                Console.WriteLine("Ted hraje: " + ((arena.ActualPlayer == Arena.Players.FIRST ) ? "X" : "O"));
            }

            switch (arena.CheckWin())
            {
                case Arena.Players.FIRST:
                    Console.WriteLine($"Prvni hrac (X) vyhral");
                    break;
                case Arena.Players.SECOND:
                    Console.WriteLine($"Druhy hrac (O) vyhral");
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
        }
    }

    class Arena
    {
        public Players ActualPlayer;

        public int[] map = 
            { 0, 0 ,0 ,
              0, 0 ,0 ,
              0, 0 ,0 };

        public Arena()
        {
            ActualPlayer = Players.FIRST;
        }
        
        public enum Players
        {
            FIRST, SECOND, NONE
        }


        public void PlayerPlay(int pozice)
        {
            map[pozice-1] = TranslatePlayer(ActualPlayer);
            if (ActualPlayer == Players.FIRST) ActualPlayer = Players.SECOND;
            else ActualPlayer = Players.FIRST;
        }

        public static int TranslatePlayer(Players player)
        {
            switch (player)
            {
                case Players.FIRST:  
                    return 1;
                case Players.SECOND:
                    return 2;
                case Players.NONE:
                    return 0;
                default:
                    return 0;
            }
        }

        public static Players TranslatePlayer(int player)
        {
            switch (player)
            {
                case 1:
                    return Players.FIRST;
                case 2:
                    return Players.SECOND;
                case 0:
                    return Players.NONE;
                default:
                    return Players.NONE;
            }
        }

        public void RenderArena()
        {
            int i = 1;
            foreach(var x in map)
            {
                switch (x)
                {
                    case 0:
                        Console.Write($" {i} ");
                        break;
                    case 1:
                        Console.Write(" X ");
                        break;
                    case 2:
                        Console.Write(" O ");
                        break;
                }
                if (i % 3 == 0)
                {
                    Console.Write("\n");
                }
                i++;
            }
        }

        public Players CheckWin()
        {
            //Horizontal

            // ###
            // 
            //
            if (map[0] == 1 && map[1] == 1 && map[2] == 1)
            {
                return TranslatePlayer(1);
            }
            if (map[0] == 2 && map[1] == 2 && map[2] == 2)
            {
                return TranslatePlayer(2);
            }

            // 
            // ###
            //

            if (map[3] == 1 && map[4] == 1 && map[5] == 1)
            {
                return TranslatePlayer(1);
            }
            if (map[3] == 2 && map[4] == 2 && map[5] == 2)
            {
                return TranslatePlayer(2);
            }


            // 
            // 
            // ###

            if (map[6] == 1 && map[7] == 1 && map[8] == 1)
            {
                return TranslatePlayer(1);
            }
            if (map[6] == 2 && map[7] == 2 && map[8] == 2)
            {
                return TranslatePlayer(2);
            }

            //Vertical

            // #
            // #
            // #

            if (map[0] == 1 && map[0 + 3] == 1 && map[0 + 3 + 3] == 1)
            {
                return TranslatePlayer(1);
            }
            if (map[0] == 2 && map[0 + 3] == 2 && map[0 + 3 + 3] == 2)
            {
                return TranslatePlayer(2);
            }

            // .#
            // .#
            // .#

            if (map[1] == 1 && map[1 + 3] == 1 && map[1 + 3 + 3] == 1)
            {
                return TranslatePlayer(1);
            }
            if (map[1] == 2 && map[1 + 3] == 2 && map[1 + 3 + 3] == 2)
            {
                return TranslatePlayer(2);
            }

            // ..#
            // ..#
            // ..#

            if (map[2] == 1 && map[2 + 3] == 1 && map[2 + 3 + 3] == 1)
            {
                return TranslatePlayer(1);
            }
            if (map[2] == 2 && map[2 + 3] == 2 && map[2 + 3 + 3] == 2)
            {
                return TranslatePlayer(2);
            }

            //DIAGONAL

            // #..
            // .#.
            // ..#

            if (map[0] == 1 && map[0 + 4] == 1 && map[0 + 4 + 4] == 1)
            {
                return TranslatePlayer(1);
            }
            if (map[0] == 2 && map[0 + 4] == 2 && map[0 + 4 + 4] == 2)
            {
                return TranslatePlayer(2);
            }


            // ..#
            // .#.
            // #..

            if (map[2] == 1 && map[2 + 2] == 1 && map[2 + 2 + 2] == 1)
            {
                return TranslatePlayer(1);
            }
            if (map[2] == 2 && map[2 + 2] == 2 && map[2 + 2 + 2] == 2)
            {
                return TranslatePlayer(2);
            }

            return TranslatePlayer(0);
        }
    }
}
