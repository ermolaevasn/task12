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

            for (int i = 0; i < N; i++) MasOne[i] = R.Next(-50,50);
            for (int i = 0; i < N; i++) Console.Write("{"+(i+1)+ "}" + MasOne[i]+ "  ");
            Console.WriteLine();

            ArrSort(MasOne,ref q);
            Console.WriteLine(q);
            ArrSort(MasOne, ref q);
            Console.WriteLine(q);
            for (int i = 0; i < N; i++) Console.Write("{" + (i + 1) + "}" + MasOne[i] + "  ");

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
    }
}
