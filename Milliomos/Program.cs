using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace Milliomos
{
    internal class Program
    {
        static int cash = 0;
        static int level = 0;
        static List<Kerdes> Questions = new List<Kerdes>();
        static List<SorKerdes> DefaultQuestions = new List<SorKerdes>();

        static void StartGame()
        {
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
