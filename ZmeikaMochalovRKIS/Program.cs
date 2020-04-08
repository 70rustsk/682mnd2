using System;
using System.Threading;

namespace ZmeikaMochalovRKIS
{
    class Program
    {
        static void Main(string[] args)
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
            Console.ReadLine();
        }
    }
}