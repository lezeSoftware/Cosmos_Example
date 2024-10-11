using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosKernel1
{
    public abstract class ProgramClass
    {
        public string PID { get; private set; }

        public string Identifier { get; set; }
        public int MemoryStartIndex { get; private set; }

        public abstract void Run();
    }

    public class Calculator : ProgramClass
    {
        public Calculator() 
        {
            Identifier = "Calculator";
        }

        public override void Run()
        {
            Console.WriteLine("3 +4 = 7");
        }
    }
}
