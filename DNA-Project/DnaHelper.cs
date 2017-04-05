using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace DNA_Project
{
    public class Dna
    {
        public char[] Genom { get; }
        public char[] Sequence { get; set; }
        List<int> Adenina;
        List<int> Guanina;
        List<int> Cytozyna;
        List<int> Tymina;

        public Dna(int size = 100)
        {
            Genom = GetGenom(size);
            Adenina = new List<int>();
            Guanina = new List<int>();
            Cytozyna = new List<int>();
            Tymina = new List<int>();
            GetIndexOfATCG();
        }

        char[] GetGenom(int size)
        {
            var random = new Random();
            var input = "ATCG";
            var chars = Enumerable.Range(0, size).Select(x => input[random.Next(0, input.Length)]);
            return chars.ToArray();
        }

        void GetIndexOfATCG()
        {
            for (var i = 0; i < Genom.Length; i++)
            {
                switch (Genom[i])
                {
                    case 'A':
                        Adenina.Add(i);
                        break;
                    case 'T':
                        Tymina.Add(i);
                        break;
                    case 'C':
                        Cytozyna.Add(i);
                        break;
                    case 'G':
                        Guanina.Add(i);
                        break;
                }
            }
        }

        public void SetSequence(int size = 2)
        {
            Sequence = Genom.Take(size).ToArray();
        }

        public int PreciseSearch()
        {
            var result = 1;
            var size = Sequence.Length;
            for (var i = Sequence.Length; i <= Genom.Length - size ; i++)
            {
                var isTheSame = true;
                char[] temp = Genom.Skip(i).Take(size).ToArray();
                for (int j = 0; j < size; j++)
                    if (Sequence[j] != temp[j])
                        isTheSame = false;

                if(isTheSame)
                    result++;
            }

            return result;
        }

    }

}
