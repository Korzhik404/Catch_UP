using System;

namespace Catch_UP
{
    class Program
    {
        static int horizontal = 7, vertical = 9;
        static int CelHorizontal = 0, CelVertical = 0, poimal = 0;
        static string Cel;




        //Устанавливаем поля для героя
        static int Horizontal
        {
            get
            {
                return horizontal;
            }
            set
            {
                if (value < 0)
                {
                    horizontal = 0;
                }
                else if ((value > 119))
                {
                    horizontal = 119;
                }
                else
                {
                    horizontal = value;
                }
            }
        }
        static int Vertical
        {
            get
            {
                return vertical;
            }
            set
            {
                if (value < 3)
                {
                    vertical = 3;
                }
                else if ((value > 29))
                {
                    vertical = 29;
                }
                else
                {
                    vertical = value;
                }
            }
        }

        //Устанавливаем поля для цели
        static int GetCelHorizontal
        {
            get
            {
                return CelHorizontal;
            }
            set
            {
                if (value < 0)
                {
                    CelHorizontal = 0;
                }

                else if ((value > 119))
                {
                    CelHorizontal = 119;
                }

                else
                {
                    CelHorizontal = value;
                }
            }
        }

        static int GetCelVertical
        {
            get
            {
                return CelVertical;
            }
            set
            {
                if (value < 3)
                {
                    CelVertical = 3;
                }
                else if ((value > 29))
                {
                    CelVertical = 29;
                }
                else
                {
                    CelVertical = value;
                }
            }
        }

        static void Privet()
        {
            Console.WriteLine("Приветсвтую в игре догонялки");       
            Console.SetCursorPosition(50, 5);
            Console.Write("Нажмите клавишу ENTER, чтобы начать играть!");
            Console.ReadKey();
            Console.Clear();
        }





        //Создаем героя
        static void DrawingHero(int horizontal, int vertical)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(Horizontal, Vertical);
            Console.WriteLine("X");
        }




        //Создаем цель
        static void CelCreate()
        {
            string[] CelName = new string[] { "А", "Б", "В", "Г" };
            Console.ForegroundColor = ConsoleColor.Red;
            Random Cels = new Random();
            CelHorizontal = Cels.Next(10, 100);
            CelVertical = Cels.Next(5, 25);
            Console.SetCursorPosition(CelHorizontal, CelVertical);
            int name = Cels.Next(0, 4);
            Cel = (CelName[name]);
        }







        //Вид ЦЕЛИ
        static void DrawingCel()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(CelHorizontal, CelVertical);
            Console.WriteLine(Cel);
        }





        //Наша сцена
        static void DrawingScene()
        {
            Console.ForegroundColor = ConsoleColor.White;
            if ((Horizontal == CelHorizontal) && (Vertical == CelVertical))
            {
                Console.Beep(350, 200);
                poimal++;
                //фикс на позицию цели
                CelHorizontal = horizontal + 1; CelVertical = vertical + 1;
                //horizontal = 7, vertical = 9;
                DrawingCel();
                //end

            }
            if (poimal == 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(4, 1);
                Console.Write("Пойманые цели: 3 | Ю ВИН");
                Console.Beep(280, 300); Console.Beep(320, 300); Console.Beep(400, 300); Console.Beep(460, 600);
                Console.SetCursorPosition(65, 1);
                Console.Write("[Любая кнопка] - чтобы выйти ");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.SetCursorPosition(4, 1);
            Console.Write("Поймано целей: " + poimal + " из 3");
            Console.SetCursorPosition(45, 1);
            Console.Write("[Стрелки] или [WSAD] - Чтобы двигать героя");
            Console.SetCursorPosition(90, 1);
            Console.Write("[Пробел]-Чтобы выйти ");
            Console.SetCursorPosition(0, 2);
            for (int i = 0; i < 120; i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(0, 30);
            for (int i = 0; i < 120; i++)
            {
                Console.Write("-");
            }
        }





        //Игра
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 50);
            Console.CursorVisible = false;
            int gameworks = 0;
            Privet();
            Console.SetCursorPosition(4, 1);
            Console.Write("Попытайся поймать цель 3 раза");
            Console.SetCursorPosition(43, 1);
            Console.Write("[Нажмите любую кнопку] - Начать играть");
            Console.ReadKey();
            Console.Clear();
            ConsoleKeyInfo keyInfo;






            //Установка игры
            DrawingScene();
            CelCreate();
            DrawingHero(Horizontal, Vertical);
            DrawingCel();
            do
            {
                keyInfo = Console.ReadKey(true);
                Console.Clear();
                DrawingScene();

                //Движение цели
                Random CelMove = new Random();
                int HorVert = CelMove.Next(0, 11);
                if (HorVert < 5)
                {
                    int move = CelMove.Next(-1, 2);
                    CelHorizontal += move;
                }
                else
                {
                    int move = CelMove.Next(-1, 2);
                    CelVertical += move;
                }
                DrawingCel();
                DrawingScene();

                //Движение игрока
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        Vertical -= 2;
                        DrawingHero(Horizontal, Vertical);
                        DrawingScene();
                        break;
                    case ConsoleKey.S:
                        Vertical += 2;
                        DrawingHero(Horizontal, Vertical);
                        DrawingScene();
                        break;
                    case ConsoleKey.D:
                        Horizontal += 2;
                        DrawingHero(Horizontal, Vertical);
                        DrawingScene();
                        break;
                    case ConsoleKey.A:
                        Horizontal -= 2;
                        DrawingHero(Horizontal, Vertical);
                        DrawingScene();
                        break;
                    case ConsoleKey.RightArrow:
                        Horizontal += 2;
                        DrawingHero(Horizontal, Vertical);
                        DrawingScene();
                        break;
                    case ConsoleKey.LeftArrow:
                        Horizontal -= 2;
                        DrawingHero(Horizontal, Vertical);
                        DrawingScene();
                        break;
                    case ConsoleKey.UpArrow:
                        Vertical -= 2;
                        DrawingHero(Horizontal, Vertical);
                        DrawingScene();
                        break;
                    case ConsoleKey.DownArrow:
                        Vertical += 2;
                        DrawingHero(Horizontal, Vertical);
                        DrawingScene();
                        break;
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        Console.WriteLine("Так быстро сдался!!!???");
                        Console.WriteLine("ГЕЙМ ОВЕР!");
                        Console.Beep(400, 300); Console.Beep(320, 300); Console.Beep(280, 300);
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }
            while (gameworks == 0);
        }
    }
}

