using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0733_Flood_FillCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            //[[0,0,0],[0,1,1]]
            int[][] image = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };
            int[][] ret = s.FloodFill2(image, 1, 1, 1);
        }

        public class Solution
        {
            public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
            {
                int color = image[sr][sc];
                if (color != newColor) dfs(image, sr, sc, color, newColor);
                return image;
            }

            public void dfs(int[][] image, int r, int c, int color, int newColor)
            {
                if (image[r][c] == color)
                {
                    image[r][c] = newColor;
                    if (r >= 1) dfs(image, r - 1, c, color, newColor);
                    if (c >= 1) dfs(image, r, c - 1, color, newColor);
                    if (r + 1 < image.Length) dfs(image, r + 1, c, color, newColor);
                    if (c + 1 < image[0].Length) dfs(image, r, c + 1, color, newColor);
                }
            }

            // any diff?
            public int[][] FloodFill2(int[][] image, int sr, int sc, int newColor)
            {

                int oldColor = image[sr][sc];

                DoFloodFill(ref image, sr, sc, oldColor, newColor);

                return image;
            }

            public void DoFloodFill(ref int[][] image, int sr, int sc, int oldColor, int newColor)
            {
                // change current

                int row = image.Length;
                int col = image[0].Length;

                int color = image[sr][sc];
                if (color == oldColor)
                {
                    //flood if diff color
                    if (color != newColor)
                    {
                        image[sr][sc] = newColor;
                        // flood to 4 directions
                        if (sr > 0)
                        {
                            DoFloodFill(ref image, sr - 1, sc, oldColor, newColor);
                        }
                        if (sr < row - 1)
                        {
                            DoFloodFill(ref image, sr + 1, sc, oldColor, newColor);
                        }
                        if (sc > 0)
                        {
                            DoFloodFill(ref image, sr, sc - 1, oldColor, newColor);
                        }
                        if (sc < col - 1)
                        {
                            DoFloodFill(ref image, sr, sc + 1, oldColor, newColor);
                        }
                    }
                }
            }
        }

    }
}
