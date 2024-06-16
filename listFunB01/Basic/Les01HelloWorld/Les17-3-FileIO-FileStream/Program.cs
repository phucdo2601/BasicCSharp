using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les17_3_FileIO_FileStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //3.1 StreamWriter : Ghi file văn bản
            /*FileStream fs = new FileStream("testData1.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sWrite = new StreamWriter(fs);
            sWrite.WriteLine("Hello World");
            sWrite.Flush();
            fs.Close();*/

            //3.2 StreamReader : Đọc file văn bản
            /*FileStream fs = new FileStream("testData1.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sReader = new StreamReader(fs);
            string str = sReader.ReadToEnd();
            Console.WriteLine(str);
            fs.Close();*/

            //4 . BinaryWriter / BinaryReader
            /*FileStream fs = new FileStream("testData2.txt", FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bWriter = new BinaryWriter(fs);
            bWriter.Write(1234);
            fs.Close();*/
            /*FileStream fs = new FileStream("testData2.txt", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            var i = br.ReadInt32();
            Console.WriteLine(i);*/

            /**
             *  5 . Using 
             Trong các ví dụ trên, sau khi kết thúc làm việc với file, chúng ta phải tự mình gọi 
            lệnh đóng luồng file. Đây là một thao tác rất hay bị bỏ quên. 
            Để giải phóng người lập trình khỏi việc phải tự mình hủy bỏ các object như vậy, 
            C# cung cấp một cấu trúc mới: using block. 
             Khi kết thúc khối code, biến fs sẽ tự bị hủy bỏ
             */
            /*using (FileStream fs4 = new FileStream("testData3.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                BinaryWriter br4 = new BinaryWriter(fs4);
                br4.Write(66666);
                StreamWriter sw4 = new StreamWriter(fs4);
                sw4.Write("Hello World!!!! test");
                sw4.Flush();
            }*/

            /*using(var fs4 = new FileStream("testData3.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                BinaryReader br4 = new BinaryReader(fs4);   
                var i = br4.ReadInt32();
                StreamReader rd4 = new StreamReader(fs4);
                var str2 = rd4.ReadToEnd();
                Console.WriteLine(i);
                Console.WriteLine(str2);
            }*/

            //Phuong thuc tat
            //7 . File.WriteAllText :
            /*string path = @"D:\textCreate.txt";
            string content = "Hello everybody!!!!";
            File.WriteAllText(path, content);*/

            /**
             *  8 . File.WriteAllLines 
             Ghi string[] (mảng kiểu string),
             mỗi phần tử trong mảng sẽ được viết vào 1 dòng trong file
             */
            /*string path = @"D:\textCreate.txt";
            string[] noiDung2 = { "dong1", "day la pt2", "day la anh 3" };
            File.WriteAllLines(path, noiDung2);*/

            /**
             *  9 . File.AppendAllLines 
                Ghi nối đuôi string[] (mảng kiểu string),
             */
            /*string path = @"D:\textCreate.txt";
            string[] noiDung3 = { "haha1", "haha2", "haha3" };
            File.AppendAllLines(path, noiDung3);*/

            /**
             * 10 . File.ReadAllText 
                Sẽ đọc tất cả các dòng trong file và trả về 1 string.
             */
            /*string path = @"D:\textCreate.txt";
            string noidungDoc = File.ReadAllText(path);
            Console.WriteLine(noidungDoc);*/

            /**
             * 11 . File.ReadAllLines 
                 Trả về giá trị kiểu string[] (mảng kiểu string)
             */

            /*string path = @"D:\textCreate.txt";
            string[] arrNd = File.ReadAllLines(path);
            foreach (string nd in arrNd)
            {
                Console.WriteLine(nd);
            }*/

            /**
             * 12 . File.Move 
                Di chuyển và đổi tên nếu tên file đích khác tên gốc
             */
            /* string path1 = "testData3.txt";
             string path2 = @"D:\testMoveChangName.txt";
             File.Move(path1, path2);*/

            /**
             * 13 . File.Copy() 
                 Copy file .
             */
            /*string path = @"D:\textCreate.txt";
            string path2 = @"D:\textCreate-copy.txt";
            File.Copy(path, path2);*/

            //14 . File.Delete()
            string path2 = @"D:\textCreate-copy.txt";
            File.Delete(path2);


            Console.Read();

        }
    }
}
