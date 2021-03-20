using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW3
{
    class MultiplePermutationMatrix
    {

    }
    class MultiplePermutation
    {
        string horizontalWord,
                permutatedHWord,
                verticalWord,
            permutatedVWord;
        MatrixHelper matrixHelper;
        MatrixHelper encryptMatrixHelper;
        MatrixHelper decryptMatrixHelper;
        int[] hIndexes,
                vIndexes;

        public void LoadData(MatrixHelper matrixHelper, string hWord, string vWord)
        {
            this.matrixHelper = matrixHelper;
            this.horizontalWord = hWord;
            this.verticalWord = vWord;
            hIndexes = new int[hWord.Length];
            vIndexes = new int[vWord.Length];

        }

        public MatrixHelper Encrypt()
        {
            Console.WriteLine("StartEncrypt");
            matrixHelper.PrintMatrix();
            List<int> charactersIndexes;
            Dictionary<char, int> temp = new Dictionary<char, int>();

            //IndexPermutationGeneration
            string tempSortedCharacters = String.Concat(horizontalWord.OrderBy(p => p).Select(p => p).ToArray());
            string tempSoterIndexes = "";
            for (int ii = 0; ii < tempSortedCharacters.Length; ii++)
                tempSoterIndexes += ii.ToString();


            StringBuilder indexCharacters = new StringBuilder();
            int characterIndex = 0;
            for (int ii = 0; ii < horizontalWord.Length; ii++)
            {
                characterIndex = tempSortedCharacters.IndexOf(horizontalWord[ii]);
                indexCharacters.Append(tempSoterIndexes[characterIndex]);
                tempSortedCharacters = tempSortedCharacters.Remove(characterIndex, 1);
                tempSoterIndexes = tempSoterIndexes.Remove(characterIndex, 1);
            }

            MatrixHelper encryptMatrixHelperH = new MatrixHelper();
            encryptMatrixHelperH.SetMatrixSize(matrixHelper.Matrix.GetLength(0), matrixHelper.Matrix.GetLength(1));
            string indexCharactersString = indexCharacters.ToString();

            for (int j = 0; j < matrixHelper.Matrix.GetLength(1); j++)
                for (int i = 0; i < matrixHelper.Matrix.GetLength(0); i++)
                {
                    int tempJ = indexCharactersString.IndexOf(j.ToString());
                    encryptMatrixHelperH.Matrix[i, j] = matrixHelper.Matrix[i,tempJ];
                }

            Console.WriteLine("EncryptResult");
            encryptMatrixHelperH.PrintMatrix();
            permutatedHWord = indexCharactersString;

            Console.WriteLine("StartverticalPermutation");
            //Vertical Permutaion
            string tempSortedCharactersV = String.Concat(verticalWord.OrderBy(p => p).Select(p => p).ToArray());
            string tempSoterIndexesV = "";
            for (int ii = 0; ii < tempSortedCharactersV.Length; ii++)
                tempSoterIndexesV += ii.ToString();


            StringBuilder indexCharactersV = new StringBuilder();
            int characterIndexV = 0;
            for (int ii = 0; ii < verticalWord.Length; ii++)
            {
                characterIndexV = tempSortedCharactersV.IndexOf(verticalWord[ii]);
                indexCharactersV.Append(tempSoterIndexesV[characterIndexV]);
                tempSortedCharactersV = tempSortedCharactersV.Remove(characterIndexV, 1);
                tempSoterIndexesV = tempSoterIndexesV.Remove(characterIndexV, 1);
            }

            MatrixHelper encryptMatrixHelperV = new MatrixHelper();
            encryptMatrixHelperV.SetMatrixSize(matrixHelper.Matrix.GetLength(0), matrixHelper.Matrix.GetLength(1));
            string indexCharactersStringV = indexCharacters.ToString();

            for (int i = 0; i < matrixHelper.Matrix.GetLength(0); i++)
                for (int j = 0; j < matrixHelper.Matrix.GetLength(1); j++)
                {
                    int tempJ = indexCharactersStringV.IndexOf(i.ToString());
                    encryptMatrixHelperV.Matrix[i, j] = encryptMatrixHelperH.Matrix[tempJ, j];
                }
            encryptMatrixHelperV.PrintMatrix();

            permutatedVWord = indexCharactersStringV;
            encryptMatrixHelper = encryptMatrixHelperV;
            return encryptMatrixHelperV;
        }

         public MatrixHelper Decrypt()
        {
            Console.WriteLine("StartDecrypt");
            encryptMatrixHelper.PrintMatrix();
            List<int> charactersIndexes;
            Dictionary<char, int> temp = new Dictionary<char, int>();

            //Vertical Permutaion
            MatrixHelper decryptMatrixHelperV = new MatrixHelper();
            decryptMatrixHelperV.SetMatrixSize(matrixHelper.Matrix.GetLength(0), matrixHelper.Matrix.GetLength(1));

            for (int i = 0; i < matrixHelper.Matrix.GetLength(0); i++)
                for (int j = 0; j < matrixHelper.Matrix.GetLength(1); j++)
                {
                    int tempI = permutatedVWord.IndexOf(i.ToString());
                    decryptMatrixHelperV.Matrix[i, j] = encryptMatrixHelper.Matrix[tempI, j];
                }
            decryptMatrixHelperV.PrintMatrix();


            //IndexPermutationGeneration
            string tempSortedCharacters = String.Concat(horizontalWord.OrderBy(p => p).Select(p => p).ToArray());
            string tempSoterIndexes = "";
            for (int ii = 0; ii < tempSortedCharacters.Length; ii++)
                tempSoterIndexes += ii.ToString();

            StringBuilder indexCharacters = new StringBuilder();
            int characterIndex = 0;
            for (int ii = 0; ii < horizontalWord.Length; ii++)
            {
                characterIndex = tempSortedCharacters.IndexOf(horizontalWord[ii]);
                indexCharacters.Append(tempSoterIndexes[characterIndex]);
                tempSortedCharacters = tempSortedCharacters.Remove(characterIndex, 1);
                tempSoterIndexes = tempSoterIndexes.Remove(characterIndex, 1);
            }

            MatrixHelper decryptMatrixHelperH = new MatrixHelper();
            decryptMatrixHelperH.SetMatrixSize(matrixHelper.Matrix.GetLength(0), matrixHelper.Matrix.GetLength(1));
            string indexCharactersString = indexCharacters.ToString();

            for (int j = 0; j < matrixHelper.Matrix.GetLength(1); j++)
                for (int i = 0; i < matrixHelper.Matrix.GetLength(0); i++)
                {
                    int tempJ = permutatedHWord.IndexOf(j.ToString());
                    decryptMatrixHelperH.Matrix[i, j] = decryptMatrixHelperV.Matrix[i, tempJ];
                }

            Console.WriteLine("EncryptResult");
            decryptMatrixHelperH.PrintMatrix();
            permutatedHWord = indexCharactersString;


            Console.WriteLine("StartverticalPermutation");

            decryptMatrixHelper = decryptMatrixHelperH;
            return decryptMatrixHelper;
        }

        

        static public  int[] GenerateCharacterSequenceByIndexes(string word)
        {
            List<int> charactersIndexes;
            Dictionary<char, int> temp = new Dictionary<char, int>();
            string tempSortedCharacters = word.OrderBy(p=>p).ToString();
            string tempSoterIndexes= "";
            for (int ii = 0; ii < tempSortedCharacters.Length; ii++)
                tempSoterIndexes += ii.ToString();


            StringBuilder indexCharacters = new StringBuilder();
            for (int ii=0;ii<word.Length;ii ++)
            {
                indexCharacters.Append(tempSoterIndexes[tempSortedCharacters.IndexOf(word[ii])+ii]);
                tempSortedCharacters = tempSortedCharacters.Remove(0, 1);
            }
            
            return null;
        }
    }
}
