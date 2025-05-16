using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milliomos
{
    internal class SorKerdes
    {
        private string question;
        private string[] answers;
        private string sequence;
        private string theme;

        public SorKerdes(string question, string[] answers, string sequence, string theme)
        {
            this.question = question;
            this.answers = answers;
            this.sequence = sequence;
            this.theme = theme;
        }

        public string Question { get => question; }
        public string[] Answers { get => answers; }
        public string Sequence { get => sequence; }
        public string Theme { get => theme; }
    }
}
