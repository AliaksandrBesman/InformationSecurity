using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW3
{
    class RoutePermutationHelper
    {
       public class Spiral
        {
            public string Encrypt(MatrixHelper matrix)
            {
                return SpiralPermutate(matrix);
            }
            public MatrixHelper Decrypt(string message, int rows, int columns)
            {
                return SpiralDepermutate(message,rows, columns);
            }

            private string SpiralPermutate(MatrixHelper matrix)
            {
                StringBuilder encryptMessage = new StringBuilder();
                int i1, j1,
                    i, j;
                i1 = matrix.Matrix.GetLength(0);
                j1 = matrix.Matrix.GetLength(1);
                j = 0;
                while (j < j1)
                {
                    i = matrix.Matrix.GetLength(0) - i1;
                    j = matrix.Matrix.GetLength(1) - j1;
                    for (; j < j1; j++)
                    {
                        encryptMessage.Append(matrix.Matrix[i,j]);
                    }
                    j--;
                    for (i++; i < i1; i++)
                    {
                        encryptMessage.Append(matrix.Matrix[i, j]);
                    }
                    i--;
                    for (j--; j >= matrix.Matrix.GetLength(1) - j1; j--)
                    {
                        encryptMessage.Append(matrix.Matrix[i, j]);
                    }
                    j++;
                    for (i--; i > matrix.Matrix.GetLength(0) - j1; i--)
                    {
                        encryptMessage.Append(matrix.Matrix[i, j]);
                    }
                    i++;
                    i1--;
                    j1--;
                }
                return encryptMessage.ToString();

            }

            private MatrixHelper SpiralDepermutate(string message, int rows, int colums)
            {
                MatrixHelper matrix = new MatrixHelper( );
                matrix.SetMatrixSize(rows, colums);
                StringBuilder encryptMessage = new StringBuilder();
                int i1, j1,
                    i, j;
                i1 = matrix.Matrix.GetLength(0);
                j1 = matrix.Matrix.GetLength(1);
                j = 0;
                int indexMessageCharacter = 0;
                while (j < j1)
                {
                    i = matrix.Matrix.GetLength(0) - i1;
                    j = matrix.Matrix.GetLength(1) - j1;
                    for (; j < j1; j++)
                    {
                        matrix.Matrix[i, j]=message[indexMessageCharacter++];
                    }
                    j--;
                    for (i++; i < i1; i++)
                    {
                        matrix.Matrix[i, j] = message[indexMessageCharacter++];
                    }
                    i--;
                    for (j--; j >= matrix.Matrix.GetLength(1) - j1; j--)
                    {
                        matrix.Matrix[i, j] = message[indexMessageCharacter++];
                    }
                    j++;
                    for (i--; i > matrix.Matrix.GetLength(0) - j1; i--)
                    {
                        matrix.Matrix[i, j] = message[indexMessageCharacter++];
                    }
                    i++;
                    i1--;
                    j1--;
                }
                return matrix;
            }
        }
    }
}
