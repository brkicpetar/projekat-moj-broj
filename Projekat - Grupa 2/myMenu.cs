using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat___Grupa_2
{
    internal class myMenu
    {
        private int index;
        private string[] opcije;
        private string naslov;
        public myMenu(string[] opcije, string naslov)
        {
            this.opcije = opcije;
            this.naslov = naslov;
            index = 0;
        }
        private void Ispis()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(naslov);
            Console.ResetColor();
            Console.CursorVisible = false;

            for (int i = 0; i < opcije.Length; i++)
            {
                if (i == index)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write((i + 1).ToString() + ". ");
                Console.ResetColor();
                Console.WriteLine(opcije[i]);
            }
            Console.ResetColor();
        }
        public int Start()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.CursorVisible = false;
                Ispis();
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow && index > 0) index--;
                else if (key.Key == ConsoleKey.DownArrow && index < opcije.Length - 1) index++;
            } while (key.Key != ConsoleKey.Enter);
            return index;
        }
    }
}