using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class TMatrix
    {
        private double[,] _matrix;
        public int I { get; private set; }
        public int J { get; private set; }

        public TMatrix(int i, int j)
        {
            I = i;
            J = j;
            _matrix = new double[i,j];
        }

        public TMatrix(int i, int j, double[,] matrix)
        {
            _matrix = new double[i,j];
            System.Array.Copy(matrix, _matrix, matrix.Length);
        }

        public double this[int i, int j]
        {
            get
            {
                if (!IsCoordinateValid(i + 1,j + 1))
                    throw new Exception("matrix out of boundary");
                return _matrix[i ,j];
            }
            set
            {

                if (!IsCoordinateValid(i + 1, j + 1))
                    throw new Exception("matrix out of boundary");
                _matrix[i, j] = value;
            }
        }

        public static TMatrix FoldMatrix(TMatrix matrixA, TMatrix matrixB)
        {
            if (!((matrixA.I == matrixB.I) && (matrixA.J == matrixB.J)))
                return null;
            TMatrix resultMatrix = new TMatrix(matrixA.I, matrixA.J);
            for (int i = 0; i < matrixA.I; i++)
            {
                for (int j = 0; j < matrixA.J; j++)
                {
                    resultMatrix[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }
            return resultMatrix;
        }

        public static TMatrix MultiplyMatrix(TMatrix matrixA, TMatrix matrixB)
        {
            if (matrixA.J != matrixB.I)
                return null;
            TMatrix resultMatrix = new TMatrix(matrixA.I, matrixB.J);
            for (int i = 0; i < matrixA.I; i++)
            {
                for (int j = 0; j < matrixB.J; j++)
                {
                    for (int r = 0; r < matrixA.J; r++)
                    {
                        resultMatrix[i, j] += matrixA[i, r] + matrixB[r, j];
                    }
                }
            }
            return resultMatrix;

        }

        public TMatrix TransposeMatrix()
        {
            TMatrix resultMatrix = new TMatrix(J, I);
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    resultMatrix[j, i] = _matrix[i, j];
                }
            }
            return resultMatrix;
        }


        private bool IsCoordinateValid(int i, int j)
        {
            return (i <= I) && (j <= J);
        }

    }
}
