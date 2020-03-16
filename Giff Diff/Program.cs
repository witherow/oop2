using System;
using System.IO;

namespace Git_Diff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter A Git Command:");
            string command = Console.ReadLine();                            //takes the user's input in as a string
            command = command.Trim();                                       //removes leading/trailing whitespace from the string
            while (!command.StartsWith("diff"))                             //if the command is not a git diff command, tells the user to enter a different command
            {
                Console.WriteLine("Please Enter A Different Command.");
                command = Console.ReadLine();
                command = command.Trim();
            }


            command = command.Remove(0, 5);                                 //removes the command string from the command variable so just the file names are left
            string[] array = command.Split(".txt ", 2);                     //splits the variable into two parts using '.txt ' as a divider. Makes these strings an array
            array[0] += ".txt";                                             //concatinates the '.txt' part of the file name back onto the first file name

            
            for(int i = 0; i<2; i++)                                        //loops through the code twice, each loop being a different file
            {
                bool tryAgain = true;                                       //boolean variable that allows the try/catch code to play again if a file name has not been located
                while (tryAgain)
                {
                    try
                    {
                        File.ReadAllText(array[i]);                         //tries to read the text from the first file
                        tryAgain = false;                                   //changes the boolean variable so the try/catch code does not run again
                    }
                    catch                                                   //if there was an exception, runs this code so the user can enter a different file name
                    {
                        Console.WriteLine($"Error: {array[i]} Not Found.\nEnter Another File Name.");
                        array[i] = Console.ReadLine();
                        command.Trim();
                    }
                }
            }

            string fileOne = File.ReadAllText(array[0]);                    //stores the contents of the first file in a string by reading all the file's lines
            string fileTwo = File.ReadAllText(array[1]);                    //stores the contents of the second file in a string by reading all the file's lines
            if(fileOne == fileTwo)                                          //if the two strings are the same, runs the code to tell the user they're not different
            {
                Console.ForegroundColor = ConsoleColor.Green;               //sets the text colour to green
                Console.WriteLine($"{array[0]} and {array[1]} are not different");
                Console.ResetColor();                                       //resets the text colour for any later use
            }
            else                                                           //if the strings are not the same, runs the code to tell the user they're different
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{array[0]} and {array[1]} are different");
                Console.ResetColor();
            }
            

        }
    }
}
