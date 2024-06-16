using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les17FileIO
{
    public class Program
    {
        static void DanhSachFolderFile(string path)
        {
            string[] arrFolders = Directory.GetDirectories(path);
            string[] arrFiles = Directory.GetFiles(path);
            foreach (string file in arrFiles)
            {
                Console.WriteLine(file);
            }

            foreach (string folder in arrFolders)
            {
                Console.WriteLine(folder);
                DanhSachFolderFile(folder);
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding= Encoding.UTF8;
            //get ten thu muc
            /*DirectoryInfo currInfo = new DirectoryInfo(".");
            Console.WriteLine(currInfo.FullName);
            Console.WriteLine(currInfo.Name);*/

            /* DirectoryInfo path = new DirectoryInfo("D:\\TuHocLapTrinh\\c#\\Fundamental\\document\\Csharp-coban");
             DirectoryInfo path2 = new DirectoryInfo(@"D:\TuHocLapTrinh\c#\Fundamental\document\Csharp-coban");
             // lay ra full duong dan
             Console.WriteLine(path2.FullName);
             // lay tem thu muc
             *//* Console.WriteLine(path2.Name);
              Console.Read();*//*

             //get thu muc cha
             Console.WriteLine(path2.Parent);

             //get thuoc tinh
             Console.WriteLine(path2.Attributes);

             // thoi gian tao thu  muc
             Console.WriteLine(path2.CreationTime);

             Console.WriteLine(path2.Root);*/

            //3. Tao thu muc
            //cach 1
            /*DirectoryInfo tCre1 = new DirectoryInfo(@"D:\TestCreateDir");
            tCre1.Create();*/

            /*string path = @"D:\TestCreateDir";*/
            /*Directory.CreateDirectory(path);*/

            /*if (Directory.Exists(path))
            {
                Console.WriteLine("Thu muc nay da ton tai");
            }else
            {
                Console.WriteLine("Thu muc chua co");
            }*/

            /*Directory.Delete(path);*/
            /*string path3 = @"D:\TuHocLapTrinh\c#\Fundamental\document\Csharp-coban";
            string[] listFile = Directory.GetFiles(path3);
            Console.WriteLine("Danh sach file nam trong thuc muc 0", path3);
            for (int i = 0; i < listFile.Length; i++)
            {
                Console.WriteLine(listFile[i]);
            }*/

            /*string path = @"D:\";
            string[] folderList = Directory.GetDirectories(path);
            Console.WriteLine("Danh sach thu muc nam trong thuc muc 0", path);
            foreach (string folder in folderList)
            {
                Console.WriteLine(folder);
            }*/

            /* string path = @"D:\TuHocLapTrinh\c#\Fundamental\document";
             DanhSachFolderFile(path);*/

            //8. Tim kiem file
            DirectoryInfo myData = new DirectoryInfo(@"D:\TuHocLapTrinh\c#\Fundamental\document");
            FileInfo[] pdfFiles = myData.GetFiles("*.pdf", SearchOption.AllDirectories);

            // so file thoa dieu kien tim kiem
            Console.WriteLine($"Tim Thay: {pdfFiles.Length}");

            foreach(FileInfo pdfFile in pdfFiles)
            {
                //day theo ten
                Console.WriteLine(pdfFile.Name);
            }

            Console.Read();
        }
    }
}
