using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace Milliomos
{
    internal class Program
    {
        static int level = 0;
        static int cash = 0;
        static int fixCash = 0;
        static Random random = new Random();
        static List<Kerdes> Questions = new List<Kerdes>();
        static List<SorKerdes> DefaultQuestions = new List<SorKerdes>();

        static bool DefaultQuestion(SorKerdes question)
        {
            bool correctAnswer = false;
            string[] answers = ["A", "B", "C", "D"];
            Console.WriteLine($"Current cash: {cash}");
            Console.WriteLine($"Current level: {level}");

            Console.WriteLine($"Here is a default question:");
            Console.WriteLine($"{question.Question}");

            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine($"{answers[i]}: {question.Answers[i]}");
            }

            string userAnswer = Console.ReadLine().ToUpper();
            if (userAnswer == question.Sequence)
            {
                correctAnswer = true;
            }

            Console.WriteLine();
            return correctAnswer;
        }

        static bool NormalQuestions(Kerdes question)
        {
            bool correctAnswer = false;
            string[] answers = ["A", "B", "C", "D"];
            Console.WriteLine($"Current cash: {cash}");
            Console.WriteLine($"Current level: {level}");

            Console.WriteLine($"Answer the question in the {question.Theme} topic:");
            Console.WriteLine($"{question.Question}");

            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine($"{answers[i]}: {question.Answers[i]}");
            }

            char userAnswer = char.ToUpper(Console.ReadKey().KeyChar);
            if (userAnswer == question.Correct)
            {
                correctAnswer = true;
            }

            Console.WriteLine();
            return correctAnswer;
        }

        static void StartGame()
        {
            level = 0;
            cash = 0;
            fixCash = 0;

            Console.Clear();
            bool game = true;

            Console.WriteLine("Welcome to the game!");

            if (DefaultQuestion(DefaultQuestions[random.Next(0, DefaultQuestions.Count)]))
            {
                Console.WriteLine("Congratulations! Now you are in the main game.");
            }
            else
            {
                Console.WriteLine("Wrong answer! Game over.");
                game = false;
            }

            level++;
            while (game && level < 16)
            {
                if (NormalQuestions(Questions[random.Next(0, Questions.Count)]))
                {
                    switch (level)
                    {
                        case 1: cash = 5000; break;
                        case 2: cash = 10000; break;
                        case 3: cash = 25000; break;
                        case 4: cash = 50000; break;
                        case 5: cash = 100000; fixCash = 100000; break;
                        case 6: cash = 200000; break;
                        case 7: cash = 300000; break;
                        case 8: cash = 500000; break;
                        case 9: cash = 800000; break;
                        case 10: cash = 1500000; fixCash = 1500000; break;
                        case 11: cash = 3000000; break;
                        case 12: cash = 5000000; break;
                        case 13: cash = 10000000; break;
                        case 14: cash = 20000000; break;
                        case 15: cash = 40000000; break;
                        default: Console.WriteLine("Error."); game = false; break;
                    }
                    Console.WriteLine($"The prize is now {cash} forint.");
                    level++;
                }
                else
                {
                    Console.WriteLine("Wrong answer! Game over.");
                    game = false;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            if (game)
            {
                Console.WriteLine("Congratulations! You've completed the game.");
            }
            else
            {
                Console.WriteLine("Game over. Better luck next time!");
            }

            ShowMenu();
        }

        static void ShowMenu()
        {
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": StartGame(); break;
                case "2": Environment.Exit(0); break;
                default: Console.WriteLine("Invalid choice. Please try again."); ShowMenu(); break;
            }
        }

        static void ReadIn()
        {
            string questionContent = File.ReadAllText("kerdes.txt");
            string[] questionLines = questionContent.Split('\n');
            string lineQuestionContent = File.ReadAllText("sorkerdes.txt");
            string[] lineQuestionLines = lineQuestionContent.Split('\n');

            for (int i = 0; i < questionLines.Length; i++)
            {
                string[] words = questionLines[i].Split(';');
                int level = int.Parse(words[0]);
                string question = words[1];
                string[] answers = { words[2], words[3], words[4], words[5] };
                char correct = char.Parse(words[6]);
                string theme = words[7];

                Kerdes kerdes = new Kerdes(level, question, answers, correct, theme);
                Questions.Add(kerdes);
            }

            for (int i = 0; i < lineQuestionLines.Length; i++)
            {
                string[] words = lineQuestionLines[i].Split(';');
                string question = words[0];
                string[] answers = { words[1], words[2], words[3], words[4] };
                string correct = words[5];
                string theme = words[6];

                SorKerdes kerdes = new SorKerdes(question, answers, correct, theme);
                DefaultQuestions.Add(kerdes);
            }
        }


        static void Main(string[] args)
        {
            ReadIn();
            ShowMenu();
        }
    }
}
