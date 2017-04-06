// 

using System;
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
            for (var i = (Sequence.Length-1); i <= Genom.Length - size; i++)
            {
                var isTheSame = true;
                var temp = Genom.Skip(i).Take(size).ToArray();
                for (var j = 0; j < size; j++)
                    if (Sequence[j] != temp[j])
                        isTheSame = false;

                if (isTheSame)
                    result++;
            }

            return result;
        }

        public int OptimalSearch()
        {
            var size = Sequence.Length;
            switch (size)
            {
                case 2: return OptimalSearchSize2();
                case 3: return OptimalSearchSize3();
                case 4: return OptimalSearchSize4();
                default:return 0;
            }
        }

        int OptimalSearchSize2()
        {
            int result = 0;
            var firstTab = GetProperTable(Sequence[0]);
            var secondTab = GetProperTable(Sequence[1]);
            foreach (var firstElement in firstTab)
            {
                foreach (var secondElement in secondTab)
                {
                    if ((firstElement + 1) == secondElement)
                    {
                        result++;
                        break;
                    }
                }
            }
            return result;
        }

        int OptimalSearchSize3()
        {
            int result = 0;
            var firstTab = GetProperTable(Sequence[0]);
            var secondTab = GetProperTable(Sequence[1]);
            var thirdTab = GetProperTable(Sequence[2]);
            foreach (var firstElement in firstTab)
            {
                foreach (var secondElement in secondTab)
                {
                    if ((firstElement + 1) == secondElement)
                    {
                        foreach (var thirdElement in thirdTab)
                        {
                            if ((secondElement + 1) == thirdElement)
                            {
                                result++;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        int OptimalSearchSize4()
        {
            int result = 0;
            var firstTab = GetProperTable(Sequence[0]);
            var secondTab = GetProperTable(Sequence[1]);
            var thirdTab = GetProperTable(Sequence[2]);
            var fourthTab = GetProperTable(Sequence[3]);
            foreach (var firstElement in firstTab)
            {
                foreach (var secondElement in secondTab)
                {
                    if ((firstElement + 1) == secondElement)
                    {
                        foreach (var thirdElement in thirdTab)
                        {
                            if ((secondElement + 1) == thirdElement)
                            {
                                foreach (var fourthElement in fourthTab)
                                {
                                    if ((thirdElement + 1) == fourthElement)
                                    {
                                        result++;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        int[] GetProperTable(char character)
        {
            switch (character)
            {
                case 'A': return Adenina.ToArray();
                case 'T': return Tymina.ToArray();
                case 'C': return Cytozyna.ToArray();
                case 'G': return Guanina.ToArray();
                default:  return null;
            }
        }
    }

}
