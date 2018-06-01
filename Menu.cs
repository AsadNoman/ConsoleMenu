using System;

namespace consolemenu
{

    public class Menu{
        private int rows, prev_rows;
        private int cur_row = 0;
        private string[] options;
        public static bool numbered = true;
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

        /// <summary> Create a menu
        ///<para> give a string array of desired options as parameters</para>
        /// </summary>
         public Menu(string[] strs, bool ? _numbered = true){
             if(_numbered == false)
                numbered = false;
            Console.Write("\n\n");
             prev_rows = Console.CursorTop;
             rows =  strs.Length;
             options = strs;
             DrawMenu();
         }

         private void DrawMenu(){

             for(int i = 0; i < rows; i++)
                 Console.Write("    {0}. {1}\n", (numbered ? (i+1).ToString() : " "), options[i]);
            
         }

        
        /// <summary>
        /// Key handling method
        /// </summary>
         private void printArrow(){
             Console.Write(' ');
             Console.SetCursorPosition(2, prev_rows + cur_row);
             Console.Write('>');
             Console.SetCursorPosition(2, prev_rows +cur_row);
         }
        
        /// <summary>
        /// Key handling method
        /// <para> returns selected option as string</para>
        /// </summary>
         public string selectOption(){
             
            Console.SetCursorPosition(2, prev_rows +cur_row);
            Console.Write('>');
            Console.SetCursorPosition(2, prev_rows +cur_row);
            while (true)
            {
                var keyInfo = Console.ReadKey();
                if(keyInfo.Key == ConsoleKey.UpArrow)
                  {
                        cur_row = rowdec(cur_row);
                        Console.SetCursorPosition(2,prev_rows + rowinc(cur_row));
                        printArrow();
                  }
                else if(keyInfo.Key == ConsoleKey.DownArrow)
                   {
                       cur_row = rowinc(cur_row);
                        Console.SetCursorPosition(2,prev_rows + rowdec(cur_row));
                        printArrow();
                   }
                else
                    break;

            
            }
            Console.SetCursorPosition(0, prev_rows + rows+1);
            return options[cur_row];
         }

    }
 
}