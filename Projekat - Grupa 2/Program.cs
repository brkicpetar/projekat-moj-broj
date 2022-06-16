using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat___Grupa_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            Console.WriteLine();


            myMenu meni = new myMenu(new string[] { "Pokreni igru", "Pravila", "Istorija igara", "Napusti igru" }, @"
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



                                           DobrodoÅ¡li u igru Moj Broj! Odaberite opciju iz menija!
");
            int index = meni.Start();
            while (index != 3)
            {
                index = meni.Start();
            }
        }
    }
}