using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test
{
    public partial class Form1 : Form
    {
        DAG DP = new DAG();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                textBox1.Text = String.Empty;
                Result_box.Text = String.Empty;

                try
                {
                    {
                        textBox1.Text = File.ReadAllText(fileName);
                        DP.Process(fileName);
                    }
                }
                catch
                {
                    MessageBox.Show("The file could not be read");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BFS_button_Click(object sender, EventArgs e)
        {
            Result_box.Text = String.Empty;
            if (DP.N == 0)
            {
                Result_box.Text = "Empty Matrix";
            }
            else
            {
                DP.sortBFS(DP.N);
                int semester = 0;
                foreach (List<string> list in DP.resultBFS1)
                {
                    semester++;
                    Result_box.AppendText("Semester " + semester + "\t: ");
                    foreach (string item in list)
                    {
                        Result_box.AppendText(item + " ");
                    }
                    Result_box.AppendText(Environment.NewLine);
                }
            }
        }

        private void DFS_button_Click(object sender, EventArgs e)
        {
            Result_box.Text = String.Empty;
            DP.GetDFS();
            for (int j = 0; j < DP.N; j++)
            {
                if (DP.IsZeroCol(j))
                {
                    DP.arrFirst.Add(j);
                }
            }

            int a = 0;
            while (a < DP.arrFirst.Count)
            {
                DP.ProcessDFS(DP.arrFirst[a]);

                int sem = 0;
                for (int i = 0; i < DP.N; i++)
                {
                    sem++;
                    Result_box.AppendText("Semester " + sem + "\t: ");
                    Result_box.AppendText(DP.Value[DP.arrDFS[i]] + " ");
                    Result_box.AppendText(Environment.NewLine);
                }

                DP.allResult.Add(DP.arrDFS);
                DP.arrDFS.Clear();
                a++;
            }
        }

        private void Result_box_TextChanged(object sender, EventArgs e)
        {

        }
    }

    class DAG
    {
        public int N { get; private set; }
        public string[] Value { get; private set; }
        public List<List<string>> resultBFS1 = new List<List<string>>();
        public int[,] Adjmat { get; private set; }


        private int adj, end; //idx = row; adj = col
        private int counttime;
        public int[,] Adjmatcopy;
        public string[] Valuecopy;
        public bool[] ValueVisit;
        public List<int> arrFirst;
        public List<List<int>> allResult;
        public List<int> arrP;
        public List<int> arrQ;
        public List<int> arrDFS;
        public List<int> tempQ;
        public Stack<int> st;


        internal void IntoMatrix(string[] lines)
        {
            Adjmat = new int[N, N];
            Value = new string[N];

            string[] Deliminators = { ", ", "." };
            int i = 0;
            foreach (string line in lines)
            {
                string[] Adjs = line.Split(Deliminators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string adj in Adjs)
                {
                    int idx = Array.IndexOf(Value, adj);
                    if (idx == -1)
                    {
                        Value[i] = adj;
                        idx = i;
                        i++;
                    }
                    if (adj != Adjs[0])
                    {
                        Adjmat[idx, Array.IndexOf(Value, Adjs[0])] = 1; //Adjs[0] ditunjuk idx
                    }
                }
            }
        }

        /* --------------------------------------- START OF BFS PROCEDURES ---------------------------------------- */
        internal void delArrElmt(int idx)
        {
            // Set nama mata kuliah menjadi "Cx"
            Value[idx] = "Cx";
        }

        internal void delPreRequisite(int idx, int N)
        {
            // Menghapus prasyarat mata kuliah karena telah diambil
            for (int i = 0; i < N; i++)
            {
                Adjmat[idx, i] = 0;
            }
        }

        public List<int> noPreRequisite(int N)
        {
            // Mengembalikan list berisi indeks elemen array yang prasyaratnya sudah terpenuhi
            List<int> temp = new List<int>();
            int i = 0;
            int j, countZero;
            while (i < N)
            {
                if (Value[i] != "Cx")
                {
                    j = 0;
                    countZero = 0;
                    while (j < N)
                    {
                        if (Adjmat[j, i] == 0)
                            countZero++;
                        else
                            break;
                        j++;
                    }
                    if (countZero == N)
                    {
                        temp.Add(i);
                    }
                }
                i++;
            }
            return temp;
        }

        internal int nbNotUsed(int N)
        {
            // Mengembalikan jumlah mata kuliah yang belum diambil
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                if (Value[i] != "Cx")
                    count++;
            }
            return count;
        }

        internal void sortBFS(int N)
        {
            // Fungsi implementasi BFS (Pada matriks mata kuliah)
            List<int> temp = new List<int>();
            List<string> str = new List<string>();
            if (nbNotUsed(N) > 1)
            {
                temp = noPreRequisite(N);
                foreach (int item in temp)
                {
                    str.Add(Value[item]);
                    delArrElmt(item);
                    delPreRequisite(item, N);
                }
                resultBFS1.Add(str);
                sortBFS(N);
            }
            else if (nbNotUsed(N) == 1)
            {
                for (int i = 0; i < N; i++)
                {
                    if (Value[i] != "Cx")
                    {
                        str.Add(Value[i]);
                        delArrElmt(i);
                        delPreRequisite(i, N);
                        break;
                    }
                }
                resultBFS1.Add(str);

            }
        }

        /* --------------------------------------- END OF BFS PROCEDURES ---------------------------------------- */

        /* --------------------------------------- START OF DFS PROCEDURES ---------------------------------------- */
        internal void GetDFS()
        {
            counttime = 0;
            end = 0;

            Adjmatcopy = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Adjmatcopy[i, j] = Adjmat[i, j];
                }
            }

            Valuecopy = new string[N];
            for (int i = 0; i < N; i++)
            {
                Valuecopy[i] = Value[i];
            }

            ValueVisit = new bool[N];
            for (int i = 0; i < N; i++)
            {
                ValueVisit[i] = false;
            }

            arrP = new List<int>();
            for (int i = 0; i < N; i++)
            {
                arrP.Add(0);
            }
            arrQ = new List<int>();
            for (int i = 0; i < N; i++)
            {
                arrQ.Add(0);
            }
            arrDFS = new List<int>();
            arrFirst = new List<int>();
            allResult = new List<List<int>>();
            tempQ = new List<int>();
            st = new Stack<int>();
        }


        internal bool IsZeroCol(int col)
        {
            bool zerocol = false;
            int count = 0;
            int i = 0;
            while ((i < N) && (zerocol == false))
            {
                if (Adjmat[i, col] == 0)
                {
                    count++;
                }
                i++;
                if (count == N)
                {
                    zerocol = true;
                }
            }
            return zerocol;
        }

        internal int FindAdj(int row)
        {
            bool found = false;
            int col = 999;
            int j = 0;
            while ((j < N) && (found == false))
            {
                if (Adjmatcopy[row, j] == 1)
                {
                    found = true;
                    col = j;
                }
                else
                {
                    j++;
                }
            }
            return col;
        }

        internal int FindPointed(int col)
        {
            bool found = false;
            int row = 999;
            int i = 0;
            while ((i < N) && (found == false))
            {
                if (Adjmatcopy[i, col] == 1)
                {
                    found = true;
                    row = i;
                }
                else
                {
                    i++;
                }
            }
            return row;
        }

        internal bool isVisited(int idx)
        {
            if (ValueVisit[idx] == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void MakeZero(int row, int col)
        { //MakeZero(idx, findadj)
            Adjmatcopy[row, col] = 0;
        }

        internal void PushAndSetStart(int idx)
        {
            if (!isVisited(idx))
            {
                st.Push(idx);
                counttime++;
                arrP.RemoveAt(idx);
                arrP.Insert(idx, counttime);
                ValueVisit[idx] = true;
            }
        }

        internal void PopAndSetEnd()
        {
            string pop = st.Pop().ToString();
            end = Convert.ToInt32(pop);
            counttime++;
            arrQ.RemoveAt(end);
            arrQ.Insert(end, counttime);
        }

        internal int FindIdx(int x, List<int> Arr)
        {
            int i = 0;
            int res = 999;
            while ((i < Arr.Count) && (res == 999))
            {
                if (Arr[i] == x)
                {
                    res = i;
                }
                else
                {
                    i++;
                }
            }
            return res;
        }

        internal void ProcessDFS(int idx)
        {
            //int top;
            PushAndSetStart(idx);
            while (st.Count != 0)
            {
                adj = FindAdj(idx);
                if (adj != 999)
                {
                    if (!isVisited(adj))
                    {
                        MakeZero(idx, adj);
                        PushAndSetStart(adj);
                        //arrDFS.Add(adj);
                        idx = adj;
                    }
                    else
                    {
                        MakeZero(idx, adj);
                    }
                }
                else
                {
                    if (FindAdj(Convert.ToInt32(st.Peek().ToString())) != 999)
                    {
                        idx = Convert.ToInt32(st.Peek().ToString());
                    }
                    else
                    {
                        idx = Convert.ToInt32(st.Peek().ToString());
                        PopAndSetEnd();
                    }
                }
            }

            for (int i = 0; i < arrQ.Count; i++)
            {
                tempQ.Add(arrQ[i]);
            }
            tempQ.Sort();
            tempQ.Reverse();
            for (int i = 0; i < N; i++)
            {
                int a = FindIdx(tempQ[i], arrQ);
                arrDFS.Add(a);
            }
        }
        /* --------------------------------------- END OF DFS PROCEDURES ---------------------------------------- */

        internal void Process(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            N = lines.Length;
            IntoMatrix(lines);
        }
    }
}