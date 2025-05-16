using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milliomos
{
    internal class Kerdes
    {
        private int level { get; set; }
        private string question { get; set; }
        private string[] answers { get; set; }
        private char correct { get; set; }
        private string theme { get; set; }

        public Kerdes(int level, string question, string[] answers, char correct, string theme)
        {
            this.level = level;
            this.question = question;
            this.answers = answers;
            this.correct = correct;
            this.theme = theme;
        }





    }
}
