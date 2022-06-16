using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

namespace Projekat___Grupa_2
{
    internal class myIgra
    {
        struct Izraz
        {
            public int rezultat;
            public string izrazString;
        }
        
        public void PokreniIgru()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(@"
          .         .                                                                                                                          
         ,8.       ,8.           ,o888888o.                8 8888           8 888888888o   8 888888888o.      ,o888888o.                8 8888 
        ,888.     ,888.       . 8888     `88.              8 8888           8 8888    `88. 8 8888    `88.  . 8888     `88.              8 8888 
       .`8888.   .`8888.     ,8 8888       `8b             8 8888           8 8888     `88 8 8888     `88 ,8 8888       `8b             8 8888 
      ,8.`8888. ,8.`8888.    88 8888        `8b            8 8888           8 8888     ,88 8 8888     ,88 88 8888        `8b            8 8888 
     ,8'8.`8888,8^8.`8888.   88 8888         88            8 8888           8 8888.   ,88' 8 8888.   ,88' 88 8888         88            8 8888 
    ,8' `8.`8888' `8.`8888.  88 8888         88            8 8888           8 8888888888   8 888888888P'  88 8888         88            8 8888 
   ,8'   `8.`88'   `8.`8888. 88 8888        ,8P 88.        8 8888           8 8888    `88. 8 8888`8b      88 8888        ,8P 88.        8 8888 
  ,8'     `8.`'     `8.`8888.`8 8888       ,8P  `88.       8 888'           8 8888      88 8 8888 `8b.    `8 8888       ,8P  `88.       8 888' 
 ,8'       `8        `8.`8888.` 8888     ,88'     `88o.    8 88'            8 8888    ,88' 8 8888   `8b.   ` 8888     ,88'     `88o.    8 88'  
,8'         `         `8.`8888.  `8888888P'         `Y888888 '              8 888888888P   8 8888     `88.    `8888888P'         `Y888888 '    




                                                             Traži se broj: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Random random = new Random();
            int kcifra1 = -1;
            int kcifra2 = -1;
            int kcifra3 = -1;

            ConsoleKeyInfo key = Console.ReadKey(true);
            while(key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            kcifra1 = random.Next(0,9);
            Console.Write(kcifra1);
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            kcifra2 = random.Next(0, 9);
            Console.Write(kcifra2);
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            kcifra3 = random.Next(0, 9);
            Console.WriteLine(kcifra3);
            konacniBroj = kcifra1 * 100 + kcifra2 * 10 + kcifra3;
            //konacniBroj = 418;

            int cifra1 = -1;
            int cifra2 = -1;
            int cifra3 = -1;
            int cifra4 = -1;
            int broj1 = -1;
            int broj2 = -1;

            int[] b1 = { 10, 15, 20 };
            int[] b2 = { 25, 50, 75, 100 };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPonuđeni brojevi:");
            Console.ForegroundColor = ConsoleColor.White;
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            cifra1 = random.Next(1, 9);
            Console.Write(cifra1 + "  ");
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            cifra2 = random.Next(1, 9);
            Console.Write(cifra2 + "  ");
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            cifra3 = random.Next(1, 9);
            Console.Write(cifra3 + "  ");

            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            cifra4 = random.Next(1, 9);
            Console.Write(cifra4 + "    ");
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            broj1 = b1[random.Next(0, 2)];
            Console.Write(broj1 + "     ");
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            broj2 = b2[random.Next(0, 3)];
            Console.WriteLine(broj2);


            List<int> l = new List<int>(){ cifra1, cifra2, cifra3, cifra4, broj1, broj2 };
            //List<int> l = new List<int>() { 1,8,8,7,20,100 };
            ponudjeniBrojevi = new List<Izraz>();
            foreach (var item in l)
            {
                Izraz iz = new Izraz();
                iz.rezultat = item;
                iz.izrazString = item.ToString();
                ponudjeniBrojevi.Add(iz);
            }
            
            stack = new Stack<string>();
        }
    }
}
