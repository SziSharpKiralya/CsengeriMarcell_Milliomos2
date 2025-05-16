using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milliomos
{
    internal class Kerdes
    {
        private int level;
        private string question;
        private string[] answers;
        private char correct;
        private string theme;

        public Kerdes(int level, string question, string[] answers, char correct, string theme)
        {
            this.level = level;
            this.question = question;
            this.answers = answers;
            this.correct = correct;
            this.theme = theme;
        }

        public int Level { get => level; }
        public string Question { get => question; }
        public string[] Answers { get => answers; }
        public char Correct { get => correct; }
        public string Theme { get => theme; }
    }
}
