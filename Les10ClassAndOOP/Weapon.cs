using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les10ClassAndOOP
{
    /**
     * Access Modify: 
     * public : co the truy cap tu bat cu dau
     * internal: chi co the truy cap khi cung mot assembly (cung mot truong trinh)
     * private: chi truy cap trong class do
     * protected: truy cap trong class va thu muc cung nhu la class con ke thua, va thu muc con
     * protected internal: truy cập được khi cùng assembly hoặc lớp kế thừa
        private protected: truy cập từ lớp chứa nó, lớp kế thừa nhưng phải cùng assembly
     * Note: Mac dinh trong c#, khi khong chi ra pham vi truy cap cua class la internal
     */

    /**
     * mac dinh khi tao class se lun co khoi tao mot constructor rong
     */

    /**
     * Destrutor: ham huy (phuong thuc huy) dc chay tu dong khi doi tuong do dc giai phong khoi bo nho
     */
    public class Weapon
    {
        // mac dinh khi khong chi ra pvtt cua bien la private
        public string name = "Ten vu khi";
        public int doSatThuong = 0;

        /**
         * Thuoc tinh
         */
        public int SatThuong {
            get
            {
                return doSatThuong;
            } set
            {
                doSatThuong = value;
            } }

        public string NoiSanXuat { get; set; }


        public Weapon()
        {
            /*Console.WriteLine("This is constructor of class Weapon! Lun thi hanh phuong thuc khoi tao dau tien");*/
        }

        public Weapon(string abc)
        {
            Console.WriteLine(abc);
        }

        public Weapon(string name, int doSatThuong) 
        {
            this.name = name;
            this.doSatThuong = doSatThuong;
        }

        public void SetDoSatThuong(int doSatThuong)
        {
            this.doSatThuong=doSatThuong;
        }

        public int GetDoSatThuong()
        {
            return this.doSatThuong;
        }

        /**
         * tu khoa this - ref: tham chieu den doi tuong khai bao
         */

        public void TanCong()
        {
            Console.WriteLine(this.name +":\t");
            for(int i = 0; i < doSatThuong; i++)
            {
                Console.Write("    *   ");
            }
            Console.WriteLine();
        }
    }
}
