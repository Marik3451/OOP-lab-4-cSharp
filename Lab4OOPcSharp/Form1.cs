using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab4OOPcSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int numberOfColumnsWithZeroElements = 0;
            int rowNumberWithMaxEqualElements = 0;
            int maxEqualElements = 0;
            int currentEqualElements = 0;
            int n = 5;
            int m = 5;
            Random random = new Random();
            int[,] matrix = new int[n, m];
            FillMatrix(n, m, random, matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        numberOfColumnsWithZeroElements++;
                    }

                    if (j > 0 && matrix[i, j] == matrix[i, j - 1])
                    {
                        currentEqualElements++;
                    }
                    else
                    {
                        if (currentEqualElements > maxEqualElements)
                        {
                            maxEqualElements = currentEqualElements;
                            rowNumberWithMaxEqualElements = i;
                        }
                        currentEqualElements = 1;
                    }

                }
            


            }
            dataGridView1.RowCount = matrix.GetLength(0);
            dataGridView1.ColumnCount = matrix.GetLength(1);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    dataGridView1[j, i].Value = matrix[i, j];
                }
            }

            textBox1.Text = numberOfColumnsWithZeroElements.ToString();
            textBox2.Text = rowNumberWithMaxEqualElements.ToString();
            textBox3.Text = FindMainDiagElem(matrix, n).ToString();
        }

        private static void FillMatrix(int n, int m, Random random, int[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = random.Next(0, 9);
                }
            }
        }

        public double FindMainDiagElem(int[,] matrix,int n)
        {
            double sum=0;
            for(int i = 0; i < n; i++)
            {
                sum+=matrix[i,i];
            }
            return sum / n;
        }
    }
}
