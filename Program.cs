using System;

namespace consolemenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("This program depicts the working of a Menu for option selection within console.\n Options will be navigated using UP & DOWN ARROW KEYS and selected by pressing ENTER KEY.\n\n ... Press any key to proceed ...");
            Console.ReadKey();
            

            Menu m = new Menu(new string[]{"Cybernetics", "Coolnetics", "Dumbnetics", "Nonenetics", "Omninetics", "Onlynetics"}, true);
            
            Console.Write("\n\nYou have selected:\t{0}", m.selectOption());
            Console.ReadKey();
        }
    }
}
