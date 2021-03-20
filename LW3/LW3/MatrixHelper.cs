using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW3
{
    class MatrixHelper
    {
        private char[,] matrix;

        public char[,] Matrix { get => matrix; set => matrix = value; }
        public void SetMatrixSize(int rows,int colums)
        {
            matrix = new char[rows, colums];
        }

        public void GenerateHorizontalMatrix(string message,int rows, int columns)
        {
            Matrix = new char[rows, columns];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    Matrix[i, j] = message[i * columns + j];
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
                for (int j = 0; j < Matrix.GetLength(1); j++)
                    Console.Write(Matrix[i, j].ToString() + (j == Matrix.GetLength(1)-1 ? '\n' : '\t'));
        }

    }
}
