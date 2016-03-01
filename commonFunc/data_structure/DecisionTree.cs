using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DecisionTree
{
    /// <summary>
    /// 决策树
    /// </summary>
    class DecisionTree
    {
        private Node[] Headers;
        private string[,] Table;
        private int Size = 0;

        //读取数据并将其存储在一个字符串[，].
        public void Init_And_Begin(string[] data)
        {
            //分分别是数据意
            string[] headers = data[0].Split(' ');
            Headers = new Node[headers.Length];
            int HeadLen = headers.Length;
            for (int i = 0; i < headers.Length; i++)
            {
                Headers[i] = new Node(headers[i], i);
            }
            //创建字符串[，]来存储数据
            Table = new string[data.Length, headers.Length];
            Size = data.Length;
            //初始化字符串[，]
            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < headers.Length; column++)
                {
                    Table[row, column] = data[row].Split(' ')[column];
                }
            }
            //如果最后一列了，然后下降的量表.
            for (int row = 0; row < Size; row++)
            {
                if (Table[row, HeadLen - 1] == "?")
                    Size--;
            }
            //然后开始
            decisive(Size, Table, Headers);
        }

        private void decisive(int Size2, string[,] data, Node[] Headers2)
        {
            //先打印数据a
            PrintTable(data);
            //它是用于存储特定属性的数量
            Hashtable hashTable1 = new Hashtable();
            //它是用于存储的是一些特定的属性
            Hashtable hashTable2 = new Hashtable();
            //计算属性的信息熵和存放在头
            info(Size2, data, Headers2, ref hashTable1, ref hashTable2);
            //选择最好的属性来划分
            choose_attribute_and_break(Size2, data, Headers2, ref hashTable1, ref hashTable2);
        }

        //计算属性的信息熵和存放在头
        private void info(int Size2, string[,] Table2, Node[] Headers2, ref Hashtable hashTable1, ref Hashtable hashTable2)
        {
            int yes_number = 0;
            int no_number = 0;
            //计算属性熵的数据 
            //先计算最后柱n
            for (int i = 1; i < Size2; i++)
            {
                if (Table2[i, Headers2.Length - 1].ToLower() == "yes")
                    yes_number++;
                else if (Table2[i, Headers2.Length - 1].ToLower() == "no")
                    no_number++;
            }
            Headers[Headers2.Length - 1].Entropy = CalculateInfo(yes_number, no_number);

            //计算其他属性熵
            for (int j = 0; j < Headers2.Length - 1; j++)
            {
                //计算列的熵[J]
                //商店属性J和哈希表的数值
                //存储属性，及其“是数在哈希表的值
                info_attributes(j, Size2, Table2, ref Headers2, ref hashTable1, ref hashTable2);
                //按照hashtable1和hashtable2，计算熵
                cal_info_attribute(j, Size2, ref Headers2, ref hashTable1, ref hashTable2);
                //清hashtable1和哈希表2
                hashTable1.Clear();
                hashTable2.Clear();
            }
        }

        //选择最佳属性拆分表
        private void choose_attribute_and_break(int Size2, string[,] table, Node[] Headers2, ref Hashtable hashTable1, ref Hashtable hashTable2)
        {
            //选择最小的属性spliet和索引存储在各个独立的
            int index = 0;
            int HeadLen = Headers2.Length;
            double minGain = Headers2[0].Entropy;
            for (int i = 0; i < Headers2.Length - 1; i++)
            {
                if (Headers2[i].Entropy < minGain)
                    index = i;
            }

            //计算的具体指标再次为工作contious
            info_attributes(index, Size2, table, ref Headers2, ref hashTable1, ref hashTable2);
            cal_info_attribute(index, Size2, ref Headers, ref hashTable1, ref hashTable2);
            foreach (System.Collections.DictionaryEntry row in hashTable1)
            {
                //如果该属性指标值都是，然后停止开
                if (int.Parse(hashTable1[row.Key].ToString()) == int.Parse(hashTable2[row.Key].ToString()))
                {
                    Console.WriteLine("The time of split:" + (Headers.Length - HeadLen + 1) + "    Column: " + Headers2[index].Name + "   Value:  " + row.Key.ToString() + " ----Yes");
                }
                //如果该属性指标值都没有，然后停止开
                else if (int.Parse(hashTable2[row.Key].ToString()) == 0)
                {
                    Console.WriteLine("The time of split: " + (Headers.Length - HeadLen + 1) + "    Column: " + Headers2[index].Name + "   Value:  " + row.Key.ToString() + "---- No");
                }
                //如果不是，那么连续开
                else
                {
                    Console.WriteLine("The time of split: " + (Headers.Length - HeadLen + 1) + "    Column: " + Headers2[index].Name + "   Value:   " + row.Key.ToString());
                    int Size3 = int.Parse(row.Value.ToString()) + 1;
                    string[,] data = new string[Size3, HeadLen];
                    //复制表的第一行
                    for (int j = 0; j < HeadLen; j++)
                        data[0, j] = table[0, j];
                    //如果索引列有行。关键的值，然后复制数据
                    int k = 0;
                    for (int i = 1; i < Size2; i++)
                    {
                        if (table[i, index] == row.Key.ToString())
                        {
                            k++;
                            for (int j = 0; j < HeadLen; j++)
                                data[k, j] = table[i, j];
                        }
                    }
                    //删除列的索引
                    for (int j = index; j < HeadLen - 1; j++)
                    {
                        for (int i = 0; i < Size3; i++)
                        {
                            data[i, j] = data[i, j + 1];
                        }
                    }
                    //更新头
                    Node[] Headers3 = new Node[HeadLen - 1];

                    for (int j = 0; j < HeadLen - 1; j++)
                    {
                        Headers3[j] = new Node(data[0, j], j);
                    }
                    //继续分裂 
                    decisive(Size3, data, Headers3);
                }
            }
        }
        //存储特定属性的具体值的个数为hashtable1 
        //和存储是一些特定的属性的一个特定值hashtable1 
        private void info_attributes(int index, int Size, string[,] data2, ref Node[] Headers2, ref Hashtable hashTable1, ref Hashtable hashTable2)
        {
            int HeadLen = Headers2.Length;
            for (int i = 1; i < Size; i++)
            {
                string current_attribute_value = data2[i, index];
                //如果这个值在哈希表
                if (hashTable1.Contains(current_attribute_value))
                {
                    //更新的数量这一价值
                    hashTable1[current_attribute_value] =
                        int.Parse(hashTable1[current_attribute_value].ToString()) + 1;
                    //如果最后一列是的，然后更新是在哈希表中的数
                    if (data2[i, HeadLen - 1].ToLower() == "yes")
                    {
                        hashTable2[current_attribute_value] = int.Parse(hashTable2[current_attribute_value].ToString()) + 1;
                    }
                }
                //如果该值不在哈希表
                else
                {
                    //如果最后一列是 
                    if (data2[i, HeadLen - 1].ToLower() == "yes")
                    {
                        //添加这个值到hashtable1和哈希表2
                        hashTable1.Add(current_attribute_value, 1);
                        hashTable2.Add(current_attribute_value, 1);
                    }
                    //如果最后一列没有,
                    else if (data2[i, HeadLen - 1].ToLower() == "no")
                    {
                        //添加这个值到hashtable1和哈希表2
                        hashTable1.Add(current_attribute_value, 1);
                        hashTable2.Add(current_attribute_value, 0);
                    }
                }
            }
        }

        //根据hashtable1和哈希计算属性的信息熵
        private void cal_info_attribute(int index, int Size, ref Node[] Headers, ref Hashtable hashTable1, ref Hashtable hashTable2)
        {
            int attribute_number = 0;
            foreach (System.Collections.DictionaryEntry row in hashTable1)
            {
                int yes_number = int.Parse(hashTable2[row.Key].ToString());
                attribute_number = int.Parse(row.Value.ToString());
                double d = CalculateInfo(yes_number, attribute_number - yes_number);
                double f = attribute_number * d / (Size - 1);
                Headers[index].Entropy += f;
            }
        }

        //计算熵
        private double CalculateInfo(params int[] Values)
        {
            double sum = 0.0;
            double total = 0.0;
            for (int i = 0; i < Values.Length; i++)
            {
                total += Values[i];
            }
            for (int i = 0; i < Values.Length; i++)
            {
                if (Values[i] != 0)
                {
                    sum += (Values[i] / total) * Math.Log(Values[i] / total, 2);
                }
            }
            return sum * (-1);
        }

        //打印表
        private void PrintTable(string[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1) - 1; j++)
                {
                    Console.Write(table[i, j] + "       \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        class Node
        {
            public Node(string param, int i)
            {
                this.Name = param;
                this.Count = i;
            }

            public int Count { get; set; }

            public string Name { get; set; }
            public double Entropy { get; set; }
        }

    }
}
