using System;

namespace consolemenu
{

    public class Menu{
        private int rows;
        private int cur_row = 0;
        private string[] options;

        public int rowdec(int cur_row){
            cur_row--;
            
                if(cur_row == -1)
                    cur_row = rows -1;
                    return cur_row;
        }
        public int rowinc(int cur_row){
            cur_row++;
            
                if(cur_row == rows)
                    cur_row = 0;
                    return cur_row;
        }
         public Menu(string[] strs){
             rows = strs.Length;
             options = strs;
             DrawMenu();
         }

         private void DrawMenu(){
             for(int i = 0; i < rows; i++)
                 Console.Write("    {0}. {1}\n", i+1, options[i]);
            
         }

         public string selectOption(){
             
            Console.SetCursorPosition(2, cur_row);
            Console.Write('>');
            Console.SetCursorPosition(2, cur_row);
            while (true)
            {
                var keyInfo = Console.ReadKey();
                if(keyInfo.Key == ConsoleKey.UpArrow)
                  {
                        cur_row = rowdec(cur_row);
                        Console.SetCursorPosition(2, rowinc(cur_row));
                        Console.Write(' ');
                        Console.SetCursorPosition(2, cur_row);
                        Console.Write('>');
                        Console.SetCursorPosition(2, cur_row);
                  }
                else if(keyInfo.Key == ConsoleKey.DownArrow)
                   {
                       cur_row = rowinc(cur_row);
                        Console.SetCursorPosition(2, rowdec(cur_row));
                        Console.Write(' ');
                        Console.SetCursorPosition(2, cur_row);
                        Console.Write('>');
                        Console.SetCursorPosition(2, cur_row);

                   }
                else
                    break;

            
            }
            Console.SetCursorPosition(0, rows+1);
            return options[cur_row];
         }

    }
 
}