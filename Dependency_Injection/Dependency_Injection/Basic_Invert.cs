using System;

namespace Dependency_Injection
{
    // base : interface 
    public interface IClassB
    {
        public void ActionB() { }
    }

    public interface IClassC
    {
        public void ActionC() { }
    }
    // -------------------- //
    public class ClassC : IClassC
    {
        public ClassC() => Console.WriteLine("ClassC has created");

        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    public class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 has created");

        public void ActionC()
        {
            Console.WriteLine("Action in CLassC1");
        }
    }

    public class ClassB : IClassB
    {
        // Phụ thuộc của ClassB là ClassC
        private IClassC c_dependency;

        public ClassB(IClassC classc) => c_dependency = classc;

        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    public class CLassB1 : IClassB
    {
        private IClassC c_dependency;

        public CLassB1(IClassC classC)
        {
            Console.WriteLine("ClassB1 has created");
            c_dependency = classC;
        }

        public void ActionB()
        {
            Console.WriteLine("Action in ClassB1");
        }
    }

    public class ClassB2 : IClassB
    {
        private IClassC dependency_c;
        private string message;

        public ClassB2(IClassC _classC, string _msg)
        {
            dependency_c = _classC;
            message = _msg;
            Console.WriteLine("ClassB2 has created");
        }

        public void ActionB()
        {
            Console.WriteLine(message);
            dependency_c.ActionC();
        }
    }

    public class ClassA
    {
        // Phụ thuộc của ClassA là ClassB
        private IClassB b_dependency;

        public ClassA(IClassB classb) => b_dependency = classb;

        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }
}