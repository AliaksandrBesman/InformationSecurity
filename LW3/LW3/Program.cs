using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW3
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 4,
                columns = 4;
            string message = "HELLO KITTY! KOK";
            MatrixHelper matrix = new MatrixHelper();
            matrix.GenerateHorizontalMatrix(message, rows, columns);
            matrix.PrintMatrix();

            RoutePermutationHelper.Spiral spiral = new RoutePermutationHelper.Spiral();
            string encryptMessage = spiral.Encrypt(matrix);
            Console.WriteLine(encryptMessage);
            MatrixHelper matrix1 = new MatrixHelper();
            matrix1.GenerateHorizontalMatrix(encryptMessage,rows, columns);
            matrix1.PrintMatrix();

            Console.WriteLine("Decrtypt: ");
            MatrixHelper matrix2 =  spiral.Decrypt(encryptMessage,rows,columns);
            matrix2.PrintMatrix();

            Console.WriteLine("Multiple");
            MultiplePermutation multiplePermutation = new MultiplePermutation();
            multiplePermutation.LoadData(matrix2, "HELL", "KILP");
            multiplePermutation.Encrypt().PrintMatrix();
            multiplePermutation.Decrypt().PrintMatrix();
            //Console.WriteLine("check: " + 'b' % 'a');
        }

    }
}
