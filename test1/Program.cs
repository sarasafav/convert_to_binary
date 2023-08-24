using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryWriter bw;
            BinaryReader br;

            int i = 25;
            double d = 3.14157;
            bool b = true;
            string s = "I am happy";

            double k1 = 5.1;
            double k2 = 5.2;
            List<double> list1 = new List<double>();
            list1.Add(8);
            list1.Add(8.1);
            list1.Add(8.2);
            list1.Add(8.3);

            //create the file
            try
            {
                bw = new BinaryWriter(new FileStream("d:\\test.bin", FileMode.Create));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot create file.");
                return;
            }

            //writing into the file
            try
            {
                bw.Write(i);
                bw.Write(d);
                bw.Write(b);
                bw.Write(s);

                bw.Write(k1);
                bw.Write(k2);
                bw.Write(list1[0]);

                for (int j=0; j <100; j ++)
                {
                    bw.Write(j);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot write to file.");
                return;
            }
            bw.Close();

            //reading from the file
            try
            {
                br = new BinaryReader(new FileStream("d:\\test.bin", FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot open file.");
                return;
            }

            try
            {
                i = br.ReadInt32();
                Console.WriteLine("Integer data: {0}", i);
                d = br.ReadDouble();
                Console.WriteLine("Double data: {0}", d);
                b = br.ReadBoolean();
                Console.WriteLine("Boolean data: {0}", b);
                s = br.ReadString();
                Console.WriteLine("String data: {0}", s);

                k2= br.ReadDouble();
                Console.WriteLine("k2 data: {0}", k2);
                k2 = br.ReadDouble();
                Console.WriteLine("k2 data: {0}", k2);
                k2 = br.ReadDouble();
                Console.WriteLine("k2 data: {0}", k2);

                for (int j = 0; j < 100; j++)
                {
                    k2 = br.ReadInt32();
                    Console.WriteLine("j data: {0}", j);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot read from file.");
                return;
            }
            br.Close();
            Console.ReadKey();
        }
    }
}
