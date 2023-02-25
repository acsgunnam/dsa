using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa.Intervals
{
    [TestClass]
    public class _0057_insert_interval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();

            for (var i = 0; i < intervals.Length; i++)
            {
                if (newInterval[1] < intervals[i][0])
                {
                    result.Add(newInterval);
                    result.AddRange(
                        intervals.AsEnumerable().Skip(i).ToArray());

                    return result.ToArray();
                }
                else if (newInterval[0] > intervals[i][1])
                {
                    result.Add(intervals[i]);
                }
                else
                {
                    newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
                    newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
                }
            }

            result.Add(newInterval);

            return result.ToArray();
        }

        [TestMethod]
        public void Main()
        {
            int[][] intervals = new int[][] 
            { 
                new int[] { 1, 2 }, 
                new int[] { 3, 5 },
                new int[] { 6, 7 },
                new int[] { 8, 10 },
                new int[] { 12, 16 }
            };

            int[] newInterval = { 4, 8 };

            var result = Insert(intervals, newInterval);

            int[][] Output = new int[3][] { 
                new int[] { 1, 2 },
                new int[] { 3, 10 }, 
                new int[] { 12, 16 } };
        }
    }
}
