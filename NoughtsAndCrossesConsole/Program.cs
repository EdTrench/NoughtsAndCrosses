using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrossesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Service.Game game = new Service.Game();
            game.Init();

            while (true)
            {
                game.Play();
                game.Display();
                Console.ReadKey();
            }
        }
    }
}
