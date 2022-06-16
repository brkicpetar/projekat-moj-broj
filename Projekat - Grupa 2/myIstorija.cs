using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat___Grupa_2
{
    internal class myIstorija
    {
        public void PokreniIstoriju()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
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



                                                           Istorija igara Moj Broj:


");
            Console.ResetColor();
            int brojac = 0;
            //ispisivanje istorije podataka
            if(string.IsNullOrEmpty(System.IO.File.ReadAllText("istorija.raz")))
            {
                Console.WriteLine("Istorija je prazna.");
            }
            else
            {
                foreach (var item in System.IO.File.ReadAllLines("istorija.raz"))
                {
                    Console.WriteLine((brojac + 1) + ". " + item);
                    brojac++;
                }
            }
            Console.WriteLine("\nPritisnite dugme ENTER kako biste se vratili na glavni meni.");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}