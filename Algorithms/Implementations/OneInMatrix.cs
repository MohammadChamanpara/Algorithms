using System;
using System.Collections.Generic;
using System.Linq;

class Empty
{
    public static void Run()
    {
        //var array = Tools.MakeArray(1, 2, 3);
        //Console.WriteLine(new Solution().XXXX(123));
    }

    // This is BinaryMatrix's API interface.
    // You should not implement it, or speculate about its implementation
    interface BinaryMatrix
    {
        int Get(int x, int y);
        IList<int> Dimensions();
    }


    class Solution
    {
        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            IList<int> dimensions = binaryMatrix.Dimensions();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int leftMost = cols;
            for (int i = 0; i < rows; i++)
            {
                if (binaryMatrix.Get(i, cols - 1) == 0)
                    continue;
                int minCol = FindLeftMostColumn(binaryMatrix, i,cols);
                if (minCol < leftMost)
                    leftMost = minCol;
            }
            return leftMost == cols ? -1 : leftMost;
        }

        private int FindLeftMostColumn(BinaryMatrix binaryMatrix, int i, int cols)
        {
            int start = 0;
            int end = cols - 2;
            int min = cols - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (binaryMatrix.Get(i, mid) == 1)
                {
                    if (mid < min)
                        min = mid;
                    end = mid - 1;
                }
                else
                    start = mid + 1;
            }
            return min;
        }
    }
}