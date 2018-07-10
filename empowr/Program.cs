// Jason Thai
// 7/10/18
// Empowr Coding Puzzle
// Time to finish: 2 hours (to get correct results)
//                 3 - 4 hours (to make it flexible and user-friendly, debugging and manual testing)
// Difficulties: 1) How to check strings in reverse, implementing "new string" to pass boolean.
//               2) Debugging/testing.
//               3) Manipulating and converting strings to char and vice versa.
//               4) Multidimensional Arrays vs. Jagged Arrays
// Steps: 1) Understood I'm working with strings and char arrays.
//        2) Saw input1 was 3x3, focused on string size of 1, 2, or 3.
//        3) Got rid of duplicate counts by checking single characters only once.
//        4) After horizontal checking was done, I focused on reverse checking next.
//        5) Researched "Array.Reverse()" method, had to implement "new string" to get through boolean.
//        6) Implemented rest of checking: vertical, diagonal \, diagonal /.
//        7) Started working on input2, noticed "CATAPULT" was longer than the rest.
//        8) Started adding flexibility to code to work with any size of strings.
//        9) Multiple manual testing and debugging to get code working correctly.
//       10) Finished, added some text/output to make it more user-friendly.
//
// Note: I understand I was expected to finish this in under an hour, and I apologize!
//       There are many keywords I don't remember by heart, so I've done a lot of research to finish this.
//       However, once I read the assignment/puzzle, I knew I could do it, just needed some time is all.

using System;
using System.Linq;

namespace empowr
{
    public static class PuzzleSolver
    {
        public static string[] DICTIONARY = { "OX", "CAT", "TOY", "AT", "DOG", "CATAPULT", "T" };

        static bool IsWord(string testWord)
        {
            if (DICTIONARY.Contains(testWord))
                return true;
            return false;
        }

        public static int FindWords(char[,] puzzle)
        {
            // This will be outputted.
            int count = 0;

            // To reverse the characters and turn into a string.
            char[] tmp;
            string reverse = "";

            // Added flexibility for any size strings in dictionary.
            int maxLength = DICTIONARY.Max(w => w.Length);
            string s = "";

            // Horizontal
            Console.WriteLine("Horizontal");
            Console.WriteLine("==========");
            // i is left to right
            for (int i = 0; i < puzzle.GetLength(0); i++)
            {
                // j is up to down
                for (int j = 0; j < puzzle.GetLength(1); j++)
                {
                    // k is checking left to right (based on size of string in dictionary)
                    for (int k = 0; k < maxLength; k++)
                    {
                        // Make sure not to go out of bounds
                        if ((j + k) < puzzle.GetLength(1))
                        {
                            // Add to a temporary string to check
                            s += puzzle[i, j + k].ToString();

                            // Reverse string and store into a variable
                            tmp = s.ToCharArray();
                            Array.Reverse(tmp);
                            reverse = new string(tmp);

                            // Check string and reverse string
                            if (IsWord(s) || IsWord(reverse))
                            {
                                if (IsWord(s))
                                    Console.WriteLine(s);
                                else
                                    Console.WriteLine(tmp);
                                count++;
                            }
                        }
                    }
                    // Each iteration of k is adding to the string variable
                    // and checking to see if that string is in the dictionary.
                    // ex. "C" -> "CA" -> "CAT" -> reset -> "A" -> "AT" -> reset -> "T"
                    s = "";
                }
            }
            Console.WriteLine();

            // Same concept as horizontal, but manipulating i, j, k values
            // to create the string to be checked.
            // Vertical
            Console.WriteLine("Vertical");
            Console.WriteLine("========");
            for (int i = 0; i < puzzle.GetLength(0); i++)
            {
                for (int j = 0; j < puzzle.GetLength(1); j++)
                {
                    for (int k = 0; k < maxLength; k++)
                    {
                        if ((i + k) < puzzle.GetLength(0))
                        {
                            s += puzzle[i + k, j].ToString();
                            tmp = s.ToCharArray();
                            Array.Reverse(tmp);
                            reverse = new string(tmp);

                            // Avoid duplicate counts by skipping string size of 1.
                            if (s.Length == 1)
                            {
                                continue;
                            }

                            if (IsWord(s) || IsWord(reverse))
                            {
                                if (IsWord(s))
                                    Console.WriteLine(s);
                                else
                                    Console.WriteLine(tmp);
                                count++;
                            }
                        }
                    }
                    s = "";
                }
            }
            Console.WriteLine();

            // diagonal \
            Console.WriteLine("Diagonal \\");
            Console.WriteLine("==========");
            for (int i = 0; i < puzzle.GetLength(0); i++)
            {
                for (int j = 0; j < puzzle.GetLength(1); j++)
                {
                    for (int k = 0; k < maxLength; k++)
                    {
                        if (((i + k) < puzzle.GetLength(0)) && ((j + k) < puzzle.GetLength(1)))
                        {
                            s += puzzle[i + k, j + k].ToString();
                            tmp = s.ToCharArray();
                            Array.Reverse(tmp);
                            reverse = new string(tmp);

                            if (s.Length == 1)
                            {
                                continue;
                            }

                            if (IsWord(s) || IsWord(reverse))
                            {
                                if (IsWord(s))
                                    Console.WriteLine(s);
                                else
                                    Console.WriteLine(tmp);
                                count++;
                            }
                        }
                    }
                    s = "";
                }
            }
            Console.WriteLine();

            // diagonal /
            Console.WriteLine("Diagonal /");
            Console.WriteLine("==========");
            for (int i = 1; i < puzzle.GetLength(0); i++)
            {
                for (int j = 0; j < puzzle.GetLength(1); j++)
                {
                    for (int k = 0; k < maxLength; k++)
                    {
                        // Added extra checking boundaries
                        if (((i - k) < puzzle.GetLength(0)) && ((j + k) < puzzle.GetLength(1)) && ((i - k) >= 0))
                        {
                            s += puzzle[i - k, j + k].ToString();
                            tmp = s.ToCharArray();
                            Array.Reverse(tmp);
                            reverse = new string(tmp);

                            if (s.Length == 1)
                            {
                                continue;
                            }

                            if (IsWord(s) || IsWord(reverse))
                            {
                                if (IsWord(s))
                                    Console.WriteLine(s);
                                else
                                    Console.WriteLine(tmp);
                                count++;
                            }
                        }
                    }
                    s = "";
                }
            }

            Console.WriteLine();
            Console.WriteLine("Total Output");
            Console.WriteLine("============");
            return count;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Instead of doing everything in few lines,
            // I thought it'd be better to keep it simple and organized
            // so one can easily change the values in the input arrays.
            string[] input1 = { "CAT", "XZT", "YOT" };
            string[] input2 = { "CATAPULT", "XZTTOYOO", "YOTOXTXX" };

            // I could've just initialized the tests with the inputs,
            // but as I've said before, better to separate and organize them.
            char[,] test1 = new char[input1.Length, input1[0].Length];
            char[,] test2 = new char[input2.Length, input2[0].Length];

            // Storing the inputs into the tests.
            for (int i = 0; i < input1.Length; i++)
            {
                for (int j = 0; j < input1[i].Length; j++)
                {
                    test1[i, j] = input1[i][j];
                }
            }
            for (int i = 0; i < input2.Length; i++)
            {
                for (int j = 0; j < input2[i].Length; j++)
                {
                    test2[i, j] = input2[i][j];
                }
            }

            Console.WriteLine("Input1 = { \"CAT\", \"XZT\", \"YOT\" }");
            Console.WriteLine("Input2 = { \"CATAPULT\", \"XZTTOYOO\", \"YOTOXTXX\" }");
            Console.WriteLine();
            Console.WriteLine("Choose which input to test: 1 or 2");
            int input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch(input)
            {
                case 1:
                    foreach(string text in input1)
                    {
                        Console.WriteLine(text);
                    }
                    Console.WriteLine();
                    Console.WriteLine(PuzzleSolver.FindWords(test1));
                    break;
                case 2:
                    foreach (string text in input2)
                    {
                        Console.WriteLine(text);
                    }
                    Console.WriteLine();
                    Console.WriteLine(PuzzleSolver.FindWords(test2));
                    break;
            }
        }
    }
}