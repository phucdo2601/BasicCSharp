using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les17_2_FileIO_Path
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Path.Combine Kết hợp các chuỗi thành dường dẫn:
            string path = Path.Combine(@"D:\", "TestCreateDir", "test01xx.txt");
            Console.WriteLine(path);

            // 2. Path.ChangeExtension() Thay đổi phần mở rộng của đường dẫn
            string path2 = Path.ChangeExtension(path, "pdf");
            Console.WriteLine(path2);

            //3. Path.GetDirectoryName trả về thư mục chứa file theo đường dẫn path :
            string folder = Path.GetDirectoryName(path);
            Console.WriteLine(folder);

            // 4. Path.GetExtension : Lấy phần mở rộng
            string scale = Path.GetExtension(path);
            Console.WriteLine(scale);

            //5. Path.GetFileName trả về tên file
            string path5 = Path.GetFileName(path);
            Console.WriteLine(path5);

            // 6. Path.GetFullPath Lấy đường dẫn đầy đủ
            string path6 = Path.GetFullPath(@"thumuc\abc.txt");
            Console.WriteLine(path6);

            //TH2
            string path7 = Path.GetFullPath(@"C:\thumuc\abc.txt");
            Console.WriteLine(path7);

            //7. Path.GetPathRoot Lấy gốc của đường dẫn
            string path8 = Path.GetPathRoot(@"C:\thumuc\abc.txt");
            Console.WriteLine(path8);

            // 8. Get path của thư mục đặc biệt
            string pathSpec = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine(pathSpec);

            Console.Read();
        }
    }
}
