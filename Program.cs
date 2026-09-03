using System;
using System.Diagnostics;

namespace AlgorithmAnalysis
{
    class Program
    {
        // Cách 1: Tính thông thường O(n^2)
        static double NormalMethod(double[] a, double x, int n)
        {
            double result = a[0];
            for (int k = 1; k <= n; ++k)
            {
                double x_k = 1;
                for (int i = 0; i < k; ++i)
                {
                    x_k *= x;
                }
                result += a[k] * x_k;
            }
            return result;
        }

        // Cách 2: Lược đồ Horner O(n)
        static double HornerMethod(double[] a, double x, int n)
        {
            double result = a[n];
            for (int k = n - 1; k >= 0; --k)
            {
                result = result * x + a[k];
            }
            return result;
        }

        static void Main(string[] args)
        {
            int[] test_n = { 1000, 10000, 100000 };
            double x = 1.5; 

            Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3}",
                              "Bậc (n)", "Thời gian (Cách 1)", "Thời gian (Cách 2)", "Nhận xét");
            Console.WriteLine(new string('-', 80));

            foreach (int n in test_n)
            {
                double[] a = new double[n + 1];
                for (int i = 0; i <= n; i++) a[i] = 1.0;

                Stopwatch sw = new Stopwatch();

                // Đo thời gian Cách 1
                sw.Start();
                NormalMethod(a, x, n);
                sw.Stop();
                double time1 = sw.Elapsed.TotalMilliseconds;

                sw.Reset(); 

                // Đo thời gian Cách 2
                sw.Start();
                HornerMethod(a, x, n);
                sw.Stop();
                double time2 = sw.Elapsed.TotalMilliseconds;

                //nhận xét
                string nhanXet;
                if (time1 > time2 * 10) nhanXet = "Horner áp đảo hoàn toàn";
                else if (time1 > time2) nhanXet = "Horner nhanh hơn";
                else nhanXet = "Không chênh lệch đáng kể";

                //kết quả
                Console.WriteLine("{0,-10} | {1,-20:F4} | {2,-20:F4} | {3}",
                                  n, time1 + " ms", time2 + " ms", nhanXet);
            }
            Console.ReadLine();
        }
    }
}

