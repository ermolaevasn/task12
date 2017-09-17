using System;
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
                MasOne[i] = R.Next(-50, 50);
                MasTwo[i] = MasOne[i];
            }
            for (int i = 0; i < N; i++) Console.Write("("+(i+1)+ ")" + MasOne[i]+ "  ");

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
