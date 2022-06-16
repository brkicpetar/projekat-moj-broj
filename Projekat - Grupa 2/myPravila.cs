using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat___Grupa_2
{
    internal class myPravila
    {
        public void PokreniPravila()
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



                                                           pravila igre Moj Broj

");
            Console.ResetColor();
            Console.WriteLine("Cilj igre je da se od 6 nasumično odabranih brojeva sastavi matematički ispravan izraz jednak ili najbliži mogući zadatom, ");
            Console.WriteLine("nasumično izabranom, broju, koristeći osnovne matematičke operacije.");
            Console.WriteLine("Moguće je odabrati četiri jednocifrena broja iz opsega od 1 do 9, jedan od brojeva 10, 15 ili 20, kao i jedan");
            Console.WriteLine("od brojeva 25,50,75 ili 100. Ponuđeni brojevi se nasumično biraju klikom na dugme ENTER.");
            Console.WriteLine("Nakon odabira brojeva, korisnik ima na raspolaganju 60 sekundi da sastavi matematički izraz u skladu sa zahtevima.");
            Console.WriteLine("Na kraju se rešenje korisnika boduje na sledeći način:");
            Console.WriteLine();
            Console.WriteLine("1. ukoliko korisnik dobije tačan broj, dobija 30 poena");
            Console.WriteLine("2. ukoliko korisnik dobije broj sa razlikom (±1, ±2), dobija 20 poena");
            Console.WriteLine("3. ukoliko korisnik dobije broj sa razlikom (±2, ±5), dobija 10 poena");
            Console.WriteLine("4. ukoliko korisnik dobije rešenje sa većom razlikom, ne dobija poene");
            Console.WriteLine();
            Console.WriteLine("Izraz se smatra matematički ispravnim ukoliko se ne dodiruju dva različita znaka operacije, ");
            Console.WriteLine("ukoliko su zagrade dobro uparene i ukoliko krajnja vrednost pripada skupu prirodnih brojeva (zajedno sa brojem 0).");

            Console.WriteLine("\nPritisnite dugme ENTER kako biste se vratili na glavni meni.");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            return;
        }
    }
}