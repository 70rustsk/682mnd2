using System;
using System.Threading;

namespace ZmeikaMochalovRKIS
{
    class MyClass
    {
        public bool konec = false;
        int schet = 0, x, y, a, b, nomerhv;
        public int S, V;
        int[] hvostX = new int[20];// Массив для самой длины змеи X
        int[] hvostY = new int[20];// Массив для самой длины змеи Y
        Random R = new Random();
        ConsoleKeyInfo klavishi;
        public bool Setup(bool konec)
        {
            Console.WriteLine("Выберете уровень сложности: ");
            Console.WriteLine("(1)Легко,<10х10, медленно>");
            Console.WriteLine("(2)Средне,<15х15, средне>");
            Console.WriteLine("(3)Сложно,<20х20, быстро>");
            int kk = Convert.ToInt32(Console.ReadLine());
            if (kk == 1)
            {
                S = 10;
                V = 10;
            }
            if (kk == 2)
            {
                S = 15;
                V = 15;
            }
            if (kk == 3)
            {
                S = 20;
                V = 20;
            }
            konec = false;// если конец то ложь
            a = R.Next(3, S - 2);// Генерим еду
            b = R.Next(3, S - 2);// И тут
            Console.WriteLine();
            return konec;
        }
        public void Vse_eto()//поле и змейка с едой
        {
            Console.SetCursorPosition(0, 5);//курсор, место где начнёт рисоваться карта
            for (int i = 0; i < V + 1; i++)
                Console.Write("#");// Наверху граница
            Console.WriteLine();
            for (int i = 0; i < S; i++)
            {
                for (int j = 0; j < S; j++)
                {
                    if (j == 0 || j == S - 1)
                        Console.Write("#");// Боковые границы
                    if (i == y && j == x)
                        Console.Write((char)80); // Голова змеи
                    else if (i == b && j == a)
                        Console.Write((char)70); // Едаааааа
                    else
                    {
                        bool print = false;
                        for (int k = 0; k < nomerhv; k++)
                        {
                            if (hvostX[k] == j && hvostY[k] == i)
                            {
                                print = true;
                                Console.Write((char)79); // хвост
                            }
                        }
                        if (!print)
                            Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            for (int j = 0; j < S + 1; j++)
                Console.Write("#");// Нижняя граница
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Баллы: " + schet);
            Console.WriteLine();
        }
        public void Input_Logic()
        {
            int predznX = hvostX[0];
            int predznY = hvostY[0];
            int pred2X;
            int pred2Y;
            hvostX[0] = x;
            hvostY[0] = y;
            for (int i = 1; i < nomerhv; i++)
            {
                pred2X = hvostX[i];
                pred2Y = hvostY[i];
                hvostX[i] = predznX;
                hvostY[i] = predznY;
                predznX = pred2X;
                predznY = pred2Y;
            }
        }
        public void dvigenie()
        {
            if (Console.KeyAvailable == true)
            { klavishi = Console.ReadKey(true); }
            switch (klavishi.Key)
            {
                case ConsoleKey.UpArrow:
                    y--;// Вверх
                    break;
                case ConsoleKey.DownArrow:
                    y++;// Вниз
                    break;
                case ConsoleKey.RightArrow:
                    x++;// Вправо
                    break;
                case ConsoleKey.LeftArrow:
                    x--;// Влево
                    break;
            }
        }
        public void itog()
        {
            if (x > S)
                x = 0;
            else if (x < 0)
                x = S - 2;
            if (y > V)
                y = 0;
            else if (y < 0)
                y = V - 2;
            for (int g = 0; g < nomerhv; g++)
            {
                if (hvostY[g] == V || hvostX[g] == S)
                {
                    konec = true;
                    Console.WriteLine("Конец!");
                    Console.ReadKey();
                }
                else if (hvostY[g] < 1 || hvostX[g] < 1)
                {
                    konec = true;
                    Console.WriteLine("Конец!");
                    Console.ReadKey();
                }
            }
            if (konec != false)
            {
                Console.Clear();
                {
                    MyClass class1 = new MyClass();
                    class1.Setup(class1.konec);
                    while (!class1.konec)
                    {
                        class1.Vse_eto();
                        class1.Input_Logic();
                        class1.dvigenie();
                        class1.itog();
                    }
                    Console.ReadKey(true);
                }
            }
            if (x == a && y == b)
            {
                schet += 10;// Считаем баллы
                a = R.Next(3, S - 2);
                b = R.Next(3, S - 2);
                nomerhv++;
            }
        }
    }
}