using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace Les33_DependencyInjection
{
    /**
     * Inversion of Control (IoC - Đảo ngược điều khiển) là một nguyên lý thiết kế trong công nghệ phần mềm trong đó các thành phần nó dựa vào để làm 
     * việc bị đảo ngược quyền điều khiển khi so sánh với lập trình hướng thủ thục truyền thống.
     */

    /**
     * Dependency injection (DI) là một kỹ thuật trong lập trình, nó là một hình thức cụ thể của Inverse of Control (Dependency Inverse) đã nói ở trên. 
     * DI thiết kế sao cho các dependency (phụ thuộc) của một đối tượng CÓ THỂ được đưa vào, tiêm vào đối tượng đó (Injection) khi nó cần tới 
     * (khi đối tượng khởi tạo).
     */

    interface IClassB
    {
        void ActionB();
    }

    interface  IClassC
    {
        void ActionC();
    }



    class ClassC : IClassC
    {
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB : IClassB
    {
        // Phụ thuộc của ClassB là ClassC
        IClassC c_dependency;

        public ClassB(IClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");
        public void ActionC()
        {
            Console.WriteLine("Action in C1");
        }
    }

    class ClassB1 : IClassB
    {
        IClassC c_dependency;
        public ClassB1(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB1 is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in B1");
            c_dependency.ActionC();
        }
    }

    class ClassB2 : IClassB
    {
        IClassC c_dependency;
        string message;
        public ClassB2(IClassC classc, string mgs)
        {
            c_dependency = classc;
            message = mgs;
            Console.WriteLine("ClassB2 is created");
        }
        public void ActionB()
        {
            Console.WriteLine(message);
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        // Phụ thuộc của ClassA là ClassB
        IClassB b_dependency;

        public ClassA(IClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }

    class Horn
    {
        int level;

        public Horn(int level)
        {
            this.level = level;
        }

        public void Beep() => Console.WriteLine("Beep - Beep - Beep ...");
    }

    class Car
    {
        Horn _horn { get; set; }
        public Car(Horn horn) {
            _horn = horn;
        }

        public void Beep()
        {

            _horn.Beep();
        }
    }

    public class MyServiceOptions
    {
        public string data1 { get; set; }
        public int data2 { get; set; }

    }

    public class MyService
    {
        public string data1 { get; set; }
        public int data2 { get; set; }

        public MyService(IOptions<MyServiceOptions> options)
        {
            var _options = options.Value;   
            data1 = _options.data1;
            data2 = _options.data2;
        }

        public void PrintData() => Console.WriteLine($"{data1} / {data2}");
    }

    internal class Program
    {
        //factory
        public static IClassB CreateB2(IServiceProvider provider)
        {
            var b2 = new ClassB2(
                        provider.GetService<IClassC>(),
                        "Thực hiện trong ClassB2"
                        );
            return b2;
        }

        static void Main(string[] args)
        {
            /*IClassC objectC = new ClassC1();
            IClassB objectB = new ClassB1(objectC);
            ClassA objectA = new ClassA(objectB);

            objectA.ActionA();*/

            /*Horn horn = new Horn(7);

            Car car = new Car(horn);
            car.Beep();*/

            /**
             * Thu vien Dependency Injection
             * DI container: ServiceCollection
             * Dang ki su dung dich vu(lop)
             * ServiceProvider -> Get Service 
             * 
             */

            var services = new ServiceCollection();

            //Dang ky cac dich vu...


            //IClassC, ClassC, ClassC1
            #region Singleton - Duy nhất một phiên bản thực thi (instance of class) (dịch vụ) được tạo ra cho hết vòng đời của ServiceProvider
            /**
             * Tao kieu Singleton thi khi truy cap tu lan thu 2 tro di thi no se lay chinh doi tuong dc khoi tao lan dau tien chu ko phai moi
             */
            /*services.AddSingleton<IClassC, ClassC1>();*/

            #endregion

            #region Traisent - Một phiên bản của dịch vụ được tạo mỗi khi được yêu cầu
            /*services.AddTransient<IClassC, ClassC1>();*/

            #endregion

            #region Scoped - Một bản thực thi (instance) của dịch vụ (Class) được tạo ra cho mỗi phạm vi, tức tồn tại cùng với sự tồn tại của một đối tượng kiểu ServiceScope (đối tượng này tạo bằng cách gọi ServiceProvider.CreateScope, đối tượng này hủy thì dịch vụ cũng bị hủy).
            /*services.AddScoped<IClassC, ClassC1>();*/

            #endregion


            #region Minh hoa nguyen ly IoC
            /**
             * ClassA
             * IClassB, ClassB, ClassB1
             * IClassC, ClassC, ClassC1
             * 
             */
            //services.AddSingleton<ClassA, ClassA>();
            //services.AddSingleton<IClassB, ClassB>();
            //services.AddSingleton<IClassC, ClassC1>();

            #endregion

            #region Sử dụng Delegate / Factory đăng ký dịch vụ
            //services.AddSingleton<ClassA, ClassA>();
            ////services.AddSingleton<IClassB, ClassB2>(
            ////    (provider) =>
            ////    {
            ////        var b2 = new ClassB2(
            ////            provider.GetService<IClassC>(),
            ////            "Thực hiện trong ClassB2"
            ////            );
            ////        return b2;
            ////    }
            ////    );

            ////su dung factoy
            //services.AddSingleton<IClassB>(
            //    CreateB2
            //    );

            //services.AddSingleton<IClassC, ClassC1>();


            #endregion

            #region Sử dụng Options khởi tạo dịch vụ trong DI
            /**
             * Trước tiên cần thêm package Microsoft.Extensions.Options: dotnet add package Microsoft.Extensions.Options
             */
            //services.AddSingleton<MyService>();

            //services.Configure<MyServiceOptions>(
            //    (options) =>
            //    {
            //        options.data1 = "Hello Everybody";
            //        options.data2 = 2023;
            //    }
            //    );

            #endregion

            #region Sử dụng cấu hình từ File cho DI Container
            /**
             * Trước tiên thêm package Microsoft.Extensions.Configuration và Microsoft.Extensions.Options.ConfigurationExtensions
             */
            var configBuilder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())      // file config ở thư mục hiện tại
           .AddJsonFile("appsettings.json");                  // nạp config định dạng JSON
            var configurationroot = configBuilder.Build();                // Tạo configurationroot

            ServiceCollection services1 = new ServiceCollection();

            services1.AddOptions();
            services1.Configure<MyServiceOptions>(configurationroot.GetSection("MyServiceOptions"));

            services1.AddSingleton<MyService>();

            var provider = services1.BuildServiceProvider();

            var myservice = provider.GetService<MyService>();
            myservice.PrintData();

            //services.AddSingleton<MyService>();

            //services.Configure<MyServiceOptions>(
            //    (options) =>
            //    {
            //        options.data1 = "Hello Everybody";
            //        options.data2 = 2023;
            //    }
            //    );

            #endregion


            //var provider = services.BuildServiceProvider();
            //goi phuong thuc ra su dung 
            //var a = provider.GetService<TenService>();
            /*var classC = provider.GetService<ClassC>();*/

            //for (int i = 0; i < 5; i++)
            //{
            //    IClassC c = provider.GetService<IClassC>();
            //    Console.WriteLine(c.GetHashCode());
            //}

            //vi du tao mot scope moi
            //using (var scope = provider.CreateScope())
            //{
            //    var provider1 = scope.ServiceProvider;
            //    for (int i = 0; i < 5; i++)
            //    {
            //        IClassC c = provider1.GetService<IClassC>();
            //        Console.WriteLine(c.GetHashCode());
            //    }
            //}

            //ClassA a = provider.GetService<ClassA>();
            //a.ActionA();
            //var myService = provider.GetService<MyService>();
            //myService.PrintData();

        }
    }
}
