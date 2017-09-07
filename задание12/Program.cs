using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание12
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10;
            int q = 0;
            int[] MasOne = new int[N];
            int[] MasTwo = new int[N];
            int[] MasThree = new int[N];
            Random R = new Random ();

            for (int i = 0; i < N; i++)
            {
                MasOne[i] = R.Next(-50, 50);
                MasTwo[i] = MasOne[i];
                MasThree[i] = MasOne[i];
            }
            for (int i = 0; i < N; i++) Console.Write("{"+(i+1)+ "}" + MasOne[i]+ "  ");
            Console.WriteLine();

            ArrSort(MasOne,ref q);
            Console.WriteLine(q);
            ArrSort(MasOne, ref q);
            Console.WriteLine(q);
            for (int i = 0; i < N; i++) Console.Write("{" + (i + 1) + "}" + MasOne[i] + "  ");


            MasTwo = Merge_Sort(MasTwo);

            System.Console.WriteLine("\n\nThe array after sorting:");
            foreach (Int32 x in MasTwo)
                System.Console.Write(x + " ");
            Console.ReadKey();
        }
        public static void ArrSort(int[] array,ref int q)
        {
            int b = 0;
            q = 0;
            int left = 0;//Левая граница
            int right = array.Length - 1;//Правая граница
            while (left < right)
            {
                for (int i = left; i < right; i++)//Слева направо...
                {
                    if (array[i] > array[i + 1])
                    {
                        b = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = b;
                        b = i;
                        q++;
                    }
                }
                right = b;//Сохраним последнюю перестановку как границу
                if (left >= right) break;//Если границы сошлись выходим
                for (int i = right; i > left; i--)//Справа налево...
                {
                    if (array[i - 1] > array[i])
                    {
                        b = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = b;
                        b = i;
                        q++;
                    }
                }
                left = b;//Сохраним последнюю перестановку как границу
            }
        }

        static Int32[] Merge_Sort(Int32[] massive)
        {
            if (massive.Length == 1)
                return massive;
            Int32 mid_point = massive.Length / 2;
            return Merge(Merge_Sort(massive.Take(mid_point).ToArray()), Merge_Sort(massive.Skip(mid_point).ToArray()));
        }

        static Int32[] Merge(Int32[] mass1, Int32[] mass2)
        {
            Int32 a = 0, b = 0;
            Int32[] merged = new int[mass1.Length + mass2.Length];
            for (Int32 i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b])
                        merged[i] = mass2[b++];
                    else //if int go for
                        merged[i] = mass1[a++];
                else
                  if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            }
            return merged;
        }
    }
}
