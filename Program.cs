using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Timer
{
    class TimeProgram
    {
        static void Main()
        {
            Thread time_thread = new Thread(TimeUpdater);
            time_thread.Name = "Timer";
            time_thread.Priority = ThreadPriority.BelowNormal;
            time_thread.IsBackground = true;
            time_thread.Start();

            Console.WriteLine("Введите максимальное число: ");
            var str = Console.ReadLine();
            var N = int.Parse(str);

            var start1 = DateTime.Now;

            var prime_numbers = GetPrimeNumbers(N);

            var stop1 = DateTime.Now;

            Console.WriteLine(string.Join(",", prime_numbers));
            Console.WriteLine((stop1-start1));
            static List<int> GetPrimeNumbers(int N)
            {
                var result = new List<int>(N / 2); //приблизительное количество простых чисел
                for (int n = 2; n <= N; n++)
                {
                    var is_prime_number = true;
                    foreach (var x in result)
                        if (n % x == 0)
                        {
                            is_prime_number = false;
                            break;
                        }
                    if (is_prime_number) result.Add(n);

                }


                return result;
            }






            Console.ReadLine();
        }
        static void TimeUpdater()
        {
            while (true)
            {
                Console.Title = DateTime.Now.ToString();
                Thread.Sleep(100);
            }

        }
    }
}

