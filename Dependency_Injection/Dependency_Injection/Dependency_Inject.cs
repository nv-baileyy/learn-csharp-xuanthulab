using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Inverse of control  (Dependency Inverse)
// dependency injection:
// cơ chế: xây dưng cơ chế gọi chính xác một dependency của 1 lớp interface nào đó, thông qua class cần gọi dependency 
// inject : làm cho các dependency từ bên ngoài vào bên trong một lớp
// -- cac dependency khong duoc tao truc tiep o trong class, ma dc nap vao tu ben ngoai     
// thiet ke cac lop co kha nang bom cac lop dependency cuar no cao thong qua cac phuong thuc khoi tao (constructer)
// Thu vien DEpendency Injection
// DI Container - ServiceCollection
// -- đăng kysc dịch vụ (lơp)
// -- ServiceProvider --> get service
namespace Dependency_Injection
{
    public class Horn
    {
        int level;
        public Horn(int level) => this.level = level;
        public void Beep() => Console.WriteLine("Beep, beep, beep...");
    }
    public class Car
    {
        public Horn horn { get; set; } // --- //
        public Car(Horn _horn) => this.horn = _horn;
        public void Beep()
        {
            horn.Beep();
        }
    }
}
