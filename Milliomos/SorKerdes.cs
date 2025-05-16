using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milliomos
{
    internal class SorKerdes
    {
        private string question { get; set; }
        private string[] answers { get; set; }
        private string sequence { get; set; }
        private string theme { get; set; }

        public SorKerdes(string question, string[] answers, string sequence, string theme)
        {
            this.question = question;
            this.answers = answers;
            this.sequence = sequence;
            this.theme = theme;
        }
    }
}
