using System;

namespace QuizGame
{
    class Program
    {
        static string[,] questions = {
            {"What is the capital of France? ", "C"},
            {"What is the capital of Italy? ", "B"},
            {"What is the capital of Spain? ", "B"},
            {"What is the capital of Moldova? ", "B"}
        };

        static string[,] options = {
            {"A. Bucuresti","B. Athena","C. Paris"},
            {"A. Madrid","B. Rome","C. Berna"},
            {"A. Ankara","B. Madrid","C. Kiev"},
            {"A. Praga","B. Chisinau","C. Viena"}
        };

        static void Main(string[] args)
        {
            new_game();
            while (play_again())
            {
                new_game();
            }
        }

        static void new_game()
        {
            int numQuestions = questions.GetLength(0);
            string[] guesses = new string[numQuestions];
            int correctGuesses = 0;

            for (int i = 0; i < numQuestions; i++)
            {
                Console.WriteLine(" -----------------------");
                Console.WriteLine(questions[i, 0]);
                for (int j = 0; j < options.GetLength(1); j++)
                {
                    Console.WriteLine(options[i, j]);
                }

                string guess = Console.ReadLine().ToUpper();
                guesses[i] = guess;
                correctGuesses += check_answers(questions[i, 1], guess);
            }

            display_score(correctGuesses, guesses);
            use_points(correctGuesses);
        }

        static int check_answers(string answer, string guess)
        {
            if (answer == guess)
            {
                Console.WriteLine("Correct");
                return 1;
            }
            else
            {
                Console.WriteLine("Wrong");
                return 0;
            }
        }

        static void display_score(int correctGuesses, string[] guesses)
        {
            Console.WriteLine(" -----------------------");
            Console.WriteLine("RESULTS!!!");
            Console.WriteLine(" -----------------------");
            Console.Write("Correct Answers: ");
            for (int i = 0; i < questions.GetLength(0); i++)
            {
                Console.Write(questions[i, 1] );
            }
            Console.WriteLine();

            Console.Write("Guesses: ");
            foreach (string guess in guesses)
            {
                Console.Write(guess );
            }
            Console.WriteLine();

            double score = (double)correctGuesses / questions.GetLength(0) * 100;
            string score_points = correctGuesses.ToString();

            Console.WriteLine(score + "%");
            Console.WriteLine("Nr points = " + score_points);
        }

        static void use_points(int correctGuesses)
        {
            int points = correctGuesses;
            int enchant = 0;

            for (int i = 0; i < points; i++)
            {
                Console.WriteLine("Use point: nr.  " + (i + 1));
                Console.Write("Press 1 to use the point.(60%): ");
                string user_input = Console.ReadLine();
                if (user_input == "1")
                {
                    points--;
                    if (new Random().NextDouble() < 0.6)
                    {
                        enchant++;
                        Console.WriteLine("Enchant +1");
                        TellJoke();
                    }
                    else
                    {
                        Console.WriteLine("No LUCK!");
                    }
                }
                else
                {
                    Console.WriteLine("You did not press the 1 key");
                }
                Console.WriteLine( points + " remaining points.");
                Console.WriteLine("You have " + enchant + " remaining points for enchanting.");
            }

            Console.WriteLine("You have run out of points. You have a total of " + enchant + " enchantments!");
        }

        static void TellJoke()
        {
            Console.WriteLine("Here's a joke for you:");
            Console.WriteLine("Why don't scientists trust atoms?");
            Console.WriteLine("Because they make up everything!");
        }

        static bool play_again()
        {
            Console.Write("play again? (yes/no): ");
            string response = Console.ReadLine().ToUpper();
            if (response == "YES")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
