using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FlippingtheMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> matrix = new List<List<int>>();
            // 112 42 83 119
            // 56 125 56 49
            // 15 78 101 43
            // 62 98 114 108
            matrix.Add(new List<int>(new int[] { 112, 42, 83, 119 }));
            matrix.Add(new List<int>(new int[] { 56, 125, 56, 49 }));
            matrix.Add(new List<int>(new int[] { 15, 78, 101, 43 }));
            matrix.Add(new List<int>(new int[] { 62, 98, 114, 108 }));
            Debug.WriteLine("題目");
            print(matrix);
            int r = flippingMatrix(matrix);
            Debug.WriteLine("answer : " + r.ToString());
            if (r == 414)
            {
                Debug.WriteLine("通過");
            }
            else
            {
                Debug.WriteLine("失敗");
            }

            matrix.Clear();
            matrix.Add(new List<int>(new int[] { 1, 2 }));
            matrix.Add(new List<int>(new int[] { 3, 4 }));
            Debug.WriteLine("題目");
            print(matrix);
            r = flippingMatrix(matrix);
            Debug.WriteLine("answer : " + r.ToString());
            if (r == 4)
            {
                Debug.WriteLine("通過");
            }
            else
            {
                Debug.WriteLine("失敗");
            }

            matrix.Clear();
            matrix.Add(new List<int>(new int[] { 107, 54, 128, 15 }));
            matrix.Add(new List<int>(new int[] { 12, 75, 110, 138 }));
            matrix.Add(new List<int>(new int[] { 100, 96, 34, 85 }));
            matrix.Add(new List<int>(new int[] { 75, 15, 28, 112 }));
            Debug.WriteLine("題目");
            print(matrix);
            r = flippingMatrix(matrix);
            Debug.WriteLine("answer : " + r.ToString());
            if (r == 488)
            {
                Debug.WriteLine("通過");
            }
            else
            {
                Debug.WriteLine("失敗");
            }

        }

        /*
         * Complete the 'flippingMatrix' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
         */

        public static int flippingMatrix(List<List<int>> matrix)
        {
            int ret = 0;

            int n = matrix.Count;
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    ret += max(matrix[i][j], matrix[i][n - j - 1], matrix[n - i - 1][j], matrix[n - i - 1][n - j - 1]);
                    Debug.WriteLine("({0},{1}) ({2},{3}) ({4},{5}) ({6},{7})", i, j, i, n - j - 1, n - i - 1, j, n - i - 1, n - j - 1);
                }
            }
            return ret;
        }
        public static int max(int a, int b, int c, int d)
        {
            int ret = a;
            if (b > ret) ret = b;
            if (c > ret) ret = c;
            if (d > ret) ret = d;
            return ret;
        }

        public static int flippingMatrix2(List<List<int>> matrix)
        {
            int ret = 0;
            /*
            bool flipping = true;
            while (flipping)
            {
                //flipping = horzFlippingMatrix(matrix) || vertFlippingMatrix(matrix);
                flipping = vertFlippingMatrix(matrix) || horzFlippingMatrix(matrix);
            }
            ret = caclSum(matrix);
            */

            for (int i = 0; i < matrix.Count; i++)
            {
                List<List<int>> _matrix = cloneMatrix(matrix);
                vertFlippingMatrixByIndex(_matrix, i);
                int sum = calcSum(_matrix);
                if (sum > ret) ret = sum;
                for (int j = 0; j < matrix.Count; j++)
                {
                    List<List<int>> __matrix = cloneMatrix(_matrix);
                    horzFlippingMatrixByIndex(__matrix, j);
                    sum = calcSum(__matrix);
                    if (sum > ret) ret = sum;
                }
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                List<List<int>> _matrix = cloneMatrix(matrix);
                horzFlippingMatrixByIndex(_matrix, i);
                int sum = calcSum(_matrix);
                if (sum > ret) ret = sum;
                for (int j = 0; j < matrix.Count; j++)
                {
                    List<List<int>> __matrix = cloneMatrix(_matrix);
                    vertFlippingMatrixByIndex(__matrix, j);
                    sum = calcSum(__matrix);
                    if (sum > ret) ret = sum;
                }
            }

            return ret;
        }

        public static List<List<int>> cloneMatrix(List<List<int>> matrix)
        {
            List<List<int>> ret = new List<List<int>>();

            for (int i = 0; i < matrix.Count; i++)
            {
                ret.Add(new List<int>(matrix[i].ToArray()));
            }

            return ret;
        }

        public static bool horzFlippingMatrix(List<List<int>> matrix)
        {
            bool ret = false;

            int n = matrix.Count / 2;

            for (int i = 0; i < matrix.Count; i++)
            {
                int left = 0;
                int right = 0;
                for (int j = 0; j < matrix.Count; j++)
                {
                    if (j < n)
                    {
                        left += matrix[i][j];
                    }
                    else
                    {
                        right += matrix[i][j];
                    }
                }
                if (right > left)
                {
                    //swap
                    for (int j = 0; j < n; j++)
                    {
                        int _j = matrix.Count - j - 1;
                        int temp = matrix[i][j];
                        matrix[i][j] = matrix[i][_j];
                        matrix[i][_j] = temp;
                    }

                    Debug.WriteLine("horzFlippingMatrix");
                    print(matrix);
                    ret = true;
                }
            }

            return ret;
        }

        public static bool vertFlippingMatrix(List<List<int>> matrix)
        {
            bool ret = false;

            int n = matrix.Count / 2;

            for (int i = 0; i < matrix.Count; i++)
            {
                int top = 0;
                int bottom = 0;
                for (int j = 0; j < matrix.Count; j++)
                {
                    if (j < n)
                    {
                        top += matrix[j][i];
                    }
                    else
                    {
                        bottom += matrix[j][i];
                    }
                }
                if (top < bottom)
                {
                    //swap
                    for (int j = 0; j < n; j++)
                    {
                        int _j = matrix.Count - j - 1;
                        int temp = matrix[j][i];
                        matrix[j][i] = matrix[_j][i];
                        matrix[_j][i] = temp;
                    }
                    Debug.WriteLine("vertFlippingMatrix");
                    print(matrix);
                    ret = true;
                }
            }

            return ret;
        }

        public static bool horzFlippingMatrixByIndex(List<List<int>> matrix, int index)
        {
            bool ret = false;

            int n = matrix.Count / 2;

            int i = index;
            for (int j = 0; j < n; j++)
            {
                int _j = matrix.Count - j - 1;
                int temp = matrix[i][j];
                matrix[i][j] = matrix[i][_j];
                matrix[i][_j] = temp;
            }

            Debug.WriteLine("horzFlippingMatrix");
            print(matrix);
            ret = true;

            return ret;
        }

        public static bool vertFlippingMatrixByIndex(List<List<int>> matrix, int index)
        {
            bool ret = false;

            int n = matrix.Count / 2;

            int i = index;

            //swap
            for (int j = 0; j < n; j++)
            {
                int _j = matrix.Count - j - 1;
                int temp = matrix[j][i];
                matrix[j][i] = matrix[_j][i];
                matrix[_j][i] = temp;
            }
            Debug.WriteLine("vertFlippingMatrix");
            print(matrix);
            ret = true;

            return ret;
        }

        public static int calcSum(List<List<int>> matrix)
        {
            int ret = 0;
            int n = matrix.Count / 2;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ret += matrix[i][j];
                }
            }

            return ret;
        }

        public static void print(List<List<int>> matrix)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix.Count; j++)
                {
                    Debug.Write(matrix[i][j].ToString() + " ");
                }
                Debug.WriteLine("");
            }

            Debug.WriteLine("---------------");

        }

    }
}
