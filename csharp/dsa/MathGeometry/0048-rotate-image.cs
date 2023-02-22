using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace dsa.MathGeometry
{
    [TestClass]
    public class _0048_rotate_image
    {
        
        public void Rotate(int[,] matrix)
        {
            (int left, int right) = (0, matrix.GetLength(0) - 1);

            while (left < right)
            {
                var limit = right - left;
                for (var i = 0; i < limit; i++)
                {
                    (int top, int bottom) = (left, right);

                    // save the top left position
                    var topLeft = matrix[top, left + i];

                    // put the bottom left value to the top left position
                    matrix[top, left + i] = matrix[bottom - i, left];

                    // put the bottom right value to the bottom left position
                    matrix[bottom - i, left] = matrix[bottom, right - i];

                    // put the top right value to the bottom right position
                    matrix[bottom, right - i] = matrix[top + i, right];

                    // put the saved top left value to the top right position
                    matrix[top + i, right] = topLeft;


                }

                left++;
                right--;
            }

            return;
        }

        [TestMethod]
        public void Main()
        {
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Rotate(matrix);
        }
    }
}