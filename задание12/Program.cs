using System;
using System.Linq;

namespace задание12
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;//размер массива
            int q = 0;//счетчик для количества перестановок
            int sr = 0;//счетчик для количества сравнений


            Console.WriteLine("Введите длину массива N"); //ввод количества чисел последовательности
            Vvod("длина массива", out N);
            Proverka("длина массива", ref N);// проверка ввода длины
            int[] MasOne = new int[N];
            int[] MasTwo = new int[N];
            Random R = new Random ();

            for (int i = 0; i < N; i++)
            {
                MasOne[i] = R.Next(-100, 100);
                MasTwo[i] = MasOne[i];
            }
             
            Console.Write("Mas1: ");
            for (int i = 0; i < N; i++) Console.Write("("+(i+1)+ ")" + MasOne[i]+ "  ");
            Console.WriteLine();
            Console.Write("Mas2: ");
            for (int i = 0; i < N; i++) Console.Write("(" + (i + 1) + ")" + MasTwo[i] + "  ");

            Console.WriteLine();
            Console.WriteLine("Сортировка ПЕРЕМЕШИВАНИЕМ:");
            ArrSort(MasOne,ref q,ref sr);
            for (int i = 0; i < N; i++) Console.Write("(" + (i + 1) + ")" + MasOne[i] + "  ");
            Console.WriteLine();
            Console.WriteLine("количество перестановок и сравнений в неотсортированном массиве: "+q+ " and "+sr);
            ArrSort(MasOne, ref q, ref sr);
            Console.WriteLine("количество перестановок и сравнений в массиве, отсортированном по возрастанию: " + q+ " and " + sr);
            Array.Reverse(MasOne);
            ArrSort(MasOne, ref q,ref sr);
            Console.WriteLine("количество перестановок и сравнений в массиве, отсортированном по убыванию: " + q + " and " + sr);

            Console.WriteLine("Сортировка СЛИЯНИЕМ:");
            q = 0;
            sr = 0;
            MasTwo =sort(MasTwo, ref q,ref sr);
            for (int i = 0; i < N; i++) Console.Write("(" + (i + 1) + ")" + MasTwo[i] + " " );
            Console.WriteLine();
            Console.WriteLine("количество перестановок и сравнений в неотсортированном массиве: " + q + " and " + sr);
            q = 0;
            sr = 0;
            MasTwo = sort(MasTwo, ref q, ref sr);
            Console.WriteLine("количество перестановок и сравнений в массиве, отсортированном по возрастанию: " + 0  + " and " + sr);
            q = 0;
            sr = 0;
            Array.Reverse(MasTwo);
            MasTwo = sort(MasTwo, ref q, ref sr);
            Console.WriteLine("количество перестановок и сравнений в массиве, отсортированном по убыванию: " + q + " and " + sr);

            Console.ReadKey();
        }
        public static void ArrSort(int[] array,ref int q,ref int sr)//сортировка перемешиванием
        {
            int b = 0;
            sr = 0;//счетчик для кол-ва сравнений
            q = 0;//счетчик для кол-ва перестановок
            int left = 0;//Левая граница
            int right = array.Length - 1;//Правая граница
            while (left < right)//пока границы не сойдутся
            {
                for (int i = left; i < right; i++)//слева направо
                {
                    if (array[i] > array[i + 1])
                    {
                        q++;
                        b = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = b;
                        b = i;
                    }
                    sr++;
                }
                right = b;//Сохраним последнюю перестановку как границу
                if (left >= right) break;//Если границы сошлись выходим
                for (int i = right; i > left; i--)//справа налево
                {
                    if (array[i - 1] > array[i])
                    {
                        q++;
                        b = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = b;
                        b = i;
                    }
                    sr++;
                }
                left = b;//Сохраним последнюю перестановку как границу
            }
        }
        public static int[] sort(int[] massive, ref int q, ref int sr)
        {
            if (massive.Length == 1)
                return massive;
            int mid_point = massive.Length / 2;
            return merge(sort(massive.Take(mid_point).ToArray(), ref q, ref sr), sort(massive.Skip(mid_point).ToArray(), ref q, ref sr), ref q, ref sr);
        }
        public static int[] merge(int[] mass1, int[] mass2, ref int q, ref int sr)
        {
            int a = 0, b = 0;
            int[] merged = new int[mass1.Length + mass2.Length];
            for (int i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                {
                    if (mass1[a] > mass2[b] && b < mass2.Length)
                    {
                        merged[i] = mass2[b++];
                    }
                    else
                    {
                        merged[i] = mass1[a++];
                    }
                    q++;
                }
                else
                {
                    if (b < mass2.Length)
                    {
                        merged[i] = mass2[b++];
                    }
                    else
                    {
                        merged[i] = mass1[a++];
                    }
                    q++;
                }
                sr++;
            }
            return merged;
        }


        static void Proverka(string s, ref int a)//функция, для проверки ввода длины послдед-ти
        {
            bool ok = false;
            string buf;
            do
            {
                if (a > 0) ok = true;
                else
                {
                    if (!ok) Console.WriteLine("\aВведите " + s + " заново");
                    Console.Write(s + " = ");
                    buf = Console.ReadLine();
                    ok = Int32.TryParse(buf, out a);
                    ok = false;
                }
            } while (!ok);
        }
        static double Vvod(string s, out int l)//функция, для проверки чисел последовательности
        {
            bool ok;
            string buf;
            do
            {
                Console.Write(s + " = ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out l);
                if (!ok) Console.WriteLine("Введите " + s + " заново");
            } while (!ok);
            return l;
        }



    }
}
