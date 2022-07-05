using System;
using System.Collections.Generic;
using System.Threading;

namespace SpellingBee_Lab
{
    internal class Program
    {
        static private int minimumLength = 4;
        static void Main(string[] args)
        {
            // Ask the user if they want to play or solve the spelling bee.
            Console.WriteLine("Would you like to solve or play the SpellingBee? (s for solve, p for play)");
            bool solving = (Console.ReadLine().ToLower() + "s")[0] == 's';
                // Above line just gets the user's input and checks if they said yes.
                // I also counter just hitting by having that accept the solving.
            if (solving) {
                // Create a list to contian the words.
                List<string> words = new List<string>(getWordsFromFile());

                // Ask the user what today's letters are.
                    // Creates variables to hold the 6 normal letters and one central letter. 
                List<char> letters; char centerLetter;
                while (true) {
                    // Ask the user for their input, parse it into a list.
                    Console.WriteLine("What are today's letters? (There should be seven, put the center letter in caps.)");
                    letters = new List<char>((Console.ReadLine() + " ").ToCharArray());
                    while (letters.Contains(' ')) letters.Remove(' ');

                    // Determine which letter is the central one.
                    centerLetter = ' ';
                    foreach (char c in letters) if (c.ToString().ToUpper() == c.ToString()) {
                        centerLetter = c.ToString().ToLower()[0];
                        letters.Remove(c);
                        break;
                    }

                    // If the input is good, proceed to find compatible words.
                    if (centerLetter != ' ' && letters.Count() == 6) break;
                    else {
                        // If the input's bad, tell the user and show them what we have:
                        Console.WriteLine("Try again, your input is malformed. (Example: \"Dlrmiao\")");
                        Console.WriteLine($"Here's my interpretation:\n\tCenter Letter: {centerLetter}, {centerLetter != ' '}\n\tLetters: {listToString(letters)}, {letters.Count()}");
                    }
                }

                // Once the input's confirmed, output it. 
                Console.WriteLine($"The center letter is {centerLetter}, the rest are {listToString(letters)}.\nSolving words... this may take some time.");
            
                Console.WriteLine("Filtering out words that don't use the center letter...");
                // Remove all words which don't contain the central letter:
                for(int i = 0; i < words.Count(); i++)
                    if (!words[i].Contains(centerLetter)) {
                        words.Remove(words[i]); i--;
                    }

                Console.WriteLine("Filtering out words that use letters which aren't included...");
                // Remove all words that use letters that aren't in the list.
                char[] lettersNotIncluded = getLettersNotUsedFromUsedLetters(letters, centerLetter);
                for(int i = 0; i < words.Count(); i++)
                    if (stringContains(words[i], lettersNotIncluded)) {
                        words.Remove(words[i]); i--;
                    }

                // Output the words that work.
                Console.WriteLine("The solutions are:");
                foreach (string word in words) if (word.Length >= minimumLength)
                    Console.WriteLine("\t" + word);
                    
            } else {
                // If the user selects to play the game, we generate the needed letters for the game.
                char[] letters = getRandomletters(6);
                char centerLetter = getRandomletters(1)[0];

                // Tell the user what their letters are.
                Console.Write($"Your letters are: ");
                foreach (char l in letters) Console.Write(l + ", ");

                Console.WriteLine($"\nYour center letter is {centerLetter}.");

                // Find the letters that can't be used in guesses.
                char[] notusedletters = getLettersNotUsedFromUsedLetters(letters, centerLetter);

                // In the background, figure out how many words there are that match.
                int numSolutions = -1; List<string> solutions = null;
                Thread t = new Thread(() => {
                    numSolutions = findNumSolutions(new List<char>(letters), centerLetter, out solutions);
                });
                t.Start();

                // Create a list to hold the user's guesses, so we know if they double-guess. 
                List<string> guessedWords = new List<string>();
                while (true) {
                    bool bypassCheck = false;
                    // Process the user's guesses.
                    Console.WriteLine("Enter your guess. (or put QUIT to exit.)");
                    string guess = Console.ReadLine().Trim();

                    // If the user chose to quit, quit.
                    if (guess.Equals("QUIT")) bypassCheck = true;

                    // Otherwise, process the guess as normal.
                    else if (!guessedWords.Contains(guess) && stringContains(guess, letters) && guess.Contains(centerLetter) && !stringContains(guess, notusedletters)) {
                        // If the guess is legal, congratulate the user and add it to the list.
                        Console.WriteLine("Good guess! That one works.\n");
                        guessedWords.Add(guess);
                    } else if (guessedWords.Contains(guess)) {
                        // If the user already guessed something, tell them.
                        Console.WriteLine("You already guessed that!\n");
                    } else {
                        // Tell the user if they're just wrong.
                        Console.WriteLine("Bad guess :(\n");
                    }
                    // Keep looping until the user has guessed all the words. 
                    if (numSolutions != -1)
                        // Tell the user how many words they have left. 
                        Console.WriteLine($"You have {numSolutions - guessedWords.Count()} words left.");
                    
                    if (numSolutions <= guessedWords.Count() || bypassCheck) {
                        Console.WriteLine("Good job! You found all the words!\nHere's what you guessed:\n");
                        foreach (string s in guessedWords)
                            Console.WriteLine("\t" + s);
                        
                        if (solutions.Count() >= 1) {
                            Console.WriteLine("In case you're curious, here's what the computer found:\n");
                            foreach (string solution in solutions)
                                Console.WriteLine("\t" + solution);

                            break;                    
                        } else {
                            Console.WriteLine("Funny thing is... the computer didn't find any solutions, so good job on you for doing that.");
                            Console.WriteLine("(Or shame on you for making up words.)");
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Simply loads the lines from the specified file, then removes the usage numbers.
        /// If configuring this program, change the count_1w variable to the location of your count_1w file.
        /// </summary>
        /// <returns>An array of all included words.</returns>
        public static string count_1w = "./20k.txt";
        static string[] getWordsFromFile() {
            string[] working = System.IO.File.ReadAllLines(count_1w);
            for (int i = 0; i < working.Length; i++) {
                // Remove everything after (and including) the space.
                if (working[i].Contains(' ') || working[i].Contains('	'))
                    working[i] = working[i].Substring(0, working[i].IndexOf('	')).Trim();
            }

            return working;
        }


        /// <summary>
        /// Converts a list to a string of the toStrings() of the objects in the list.
        /// </summary>
        /// <param name="l">The list to pass.</param>
        /// <typeparam name="T">The type of objects in the list. Normally, the compiler can figure this out for you, so you don't have to pass it.</typeparam>
        /// <returns>All the toStrings() in the list, concatenated without spaces.</returns>
        public static string listToString<T>(List<T> l) {
            string output = "";
            foreach (T o in l)
                output += o.ToString();
            
            return output;
        }

        private static char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        /// <summary>
        /// Determines the letters that aren't used by subtracting the used letters from the alphabet.
        /// </summary>
        /// <param name="letters">A list of 6 letters that the puzzle uses.</param>
        /// <param name="centerLetter">The central letter.</param>
        /// <returns>An array of letters that aren't used.</returns>
        public static char[] getLettersNotUsedFromUsedLetters(List<char> letters, char centerLetter) {
            List<char> lettersNotUsed = new List<char>();
            for (int i = 0; i < alphabet.Length; i++)
                if (!letters.Contains(alphabet[i]) && centerLetter != alphabet[i])
                    lettersNotUsed.Add(alphabet[i]);

            return lettersNotUsed.ToArray();
        }

        public static char[] getLettersNotUsedFromUsedLetters(char[] letters, char centerLetter) {
            List<char> l2 = new List<char>(letters);
            return getLettersNotUsedFromUsedLetters(l2, centerLetter);
        }


        /// <summary>
        /// Checks if a string contains any of the values in the array. 
        /// </summary>
        /// <param name="check"></param>
        /// <param name="lettersMaybeContained"></param>
        /// <returns>True if any of the letters in the array are found.</returns>
        public static bool stringContains(String check, char[] lettersMaybeContained) {
            int contained = 0;
            foreach (char c in check) foreach(char d in lettersMaybeContained)
                if (c == d) return true;

            return false;
        }

        public static char[] getRandomletters(int numLetters) {
            Random r = new Random();
            char[] letters = new char[numLetters];
            for (int i = 0; i < letters.Length; i++) {
                letters[i] = alphabet[r.Next(alphabet.Length)];
            }
            return letters;
        }

        /// <summary>
        /// Asynchronously finds a the number of compatible words 
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="centerLetter"></param>
        /// <returns>The number of words that solve this puzzle.</returns>
        private static int findNumSolutions(List<char> letters, char centerLetter, out List<String> words) {
            words = new List<string>(getWordsFromFile());

            // Remove all words which don't contain the central letter:
            for(int i = 0; i < words.Count(); i++)
                if (!words[i].Contains(centerLetter)) {
                    words.Remove(words[i]); i--;
                }

            // Remove all words that use letters that aren't in the list.
            char[] lettersNotIncluded = getLettersNotUsedFromUsedLetters(letters, centerLetter);
            for(int i = 0; i < words.Count(); i++)
                if (stringContains(words[i], lettersNotIncluded)) {
                    words.Remove(words[i]); i--;
                }

            // Remove all the words which are too small.
            for (int i = 0; i < words.Count(); i++)
                if (words[i].Length < minimumLength) {
                    words.Remove(words[i]); i--;
                }

            return words.Count();
        }
    }
}