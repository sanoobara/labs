namespace Lab2
{

    class Program
    {




        Program()
        {



        }


        static void Main(string[] args)
        {
            double x, y, n, x1;
            int len;
            double[] result;

            x = Vvod("Vvedite x:");
            y = Vvod("Vvedite y:");
            n = Vvod("Vvedite n:");
            x1 = x;
            len = (int)(10 / n);
            result = new double[len];

            Recurs(0, x, y, len, result, n);
            Vivod(len, x1, y, n, result);
        }

        static double Vvod(string str)
        {
            Console.WriteLine(str);
            return double.Parse(Console.ReadLine());
        }

        void Recurs(int i, double x, double y, int len, double[] result, double n)
        {
            if (i < len)
            {
                if (Math.Abs(x * y) > 10)
                {
                    result[i] = Math.Log2(Math.Abs(Math.Pow(x, 2) + Math.Abs(y)));
                }
                else if (Math.Abs(x * y) < 10)
                {
                    result[i] = Math.Exp(Math.Pow(x, 2) + y);
                }
                else
                {
                    result[i] = Math.Pow(x, 2) + y;
                }
                x = x + n;
                Recurs(i + 1, x, y, len, result, n);
            }
            else
            {
                return;
            }
        }
        static void Vivod(int len, double x1, double y, double n, double[] result)
        {
            for (int i = 0; i < len; i++)
            {
                if (Math.Abs(x1 * y) > 10)
                {
                    Console.WriteLine($"{i + 1}" + ".\t|xy|>10" + $".\t {result[i]}");
                }
                else if (Math.Abs(x1 * y) < 10)
                {
                    Console.WriteLine($"{i + 1}" + ".\t|xy|<10" + $".\t {result[i]}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}" + ".\t|xy|=10" + $".\t {result[i]}");
                }
                x1 = x1 + n;
            }
        }

    }
}