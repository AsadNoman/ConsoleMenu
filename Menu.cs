using System;

namespace consolemenu
{

    public class Menu{
        
        /// <summary>
        /// rows: Number of options
        /// prev_rows: Stores the count of previously written rows
        /// <para> The variables help avoiding writing over the previously written lines. </para>
        /// </summary>
        private int rows, prev_rows;
        
        /// <summary>
        /// Globally used for incrementing, decrementing and retrieving current row value.
        /// </summary>
        private int cur_row = 0;
        
        /// <summary>
        /// Stores inserted string array of options.
        /// </summary>
        private string[] options;
        
        /// <summary>
        /// Tells whether menu has to be ordered or not.
        /// </summary>
        public static bool numbered = true;
        
        /// <summary>
        /// Repeats indexes while decrementing
        /// <para> Implemented as a handler for Index related excepetions. </para>
        /// </summary>
        public int rowdec(int cur_row){
            cur_row--;
            
                if(cur_row == -1)
                    cur_row = rows -1;
                    return cur_row;
        }
        
        /// <summary>
        /// Repeats indexes while incrementing
        /// <para> Implemented as a handler for Index related excepetions. </para>
        /// </summary>
        public int rowinc(int cur_row){
            cur_row++;
            
                if(cur_row == rows)
                    cur_row = 0;
                    return cur_row;
        }

        /// <summary> Create a menu
        ///<para> Draws menu for inserted options.</para>
        /// <param name="strs"> Array of string desired as options for menu. </param>
        /// <param name="_numbered"> Optional parameter to specify ordered or unordered menu. Default value true.</param>
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


        /// <summary>
        /// Does the writing.
        /// </summary>
         private void DrawMenu(){

             for(int i = 0; i < rows; i++)
                 Console.Write("    {0}. {1}\n", (numbered ? (i+1).ToString() : " "), options[i]);
            
         }

        
        /// <summary>
        /// Responding method for key presses. 
        /// </summary>
         private void printArrow(){
             Console.Write(' ');
             Console.SetCursorPosition(2, prev_rows + cur_row);
             Console.Write('>');
             Console.SetCursorPosition(2, prev_rows +cur_row);
         }
        
        /// <summary>
        /// Key handling method.
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