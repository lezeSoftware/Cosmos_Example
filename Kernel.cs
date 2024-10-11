using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        Memory mem = new Memory();

        ProgramClass[] ProgramMemory = new ProgramClass[6];

        string versionString = "Version 0.1";
        DateTime momentOfStart;

        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
            momentOfStart = DateTime.Now;
        }

        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();

            string[] args = input.Split(' ');

            switch(args[0])
            {
                case "help":
                    {
                        Help();
                        break;
                    }
                case "version":
                    {
                        Console.WriteLine(versionString);
                        break;
                    }
                case "echo":
                    {
                        EchoFunction(args);
                        break;
                    }
                case "runtime":
                    {
                        Console.WriteLine(RunTime());
                        break;
                    }
                case "calc":
                    {
                        Calculator calcProgramm = new Calculator();
                        ProgramMemory[0] = calcProgramm;

                        Console.WriteLine("Info Program[0] = " + ProgramMemory[0].Identifier);
                        ProgramMemory[0].Run();
                        break;

                    }
                case "tempsave":
                    {
                        mem.WriteAt(0, 255);
                        Console.WriteLine(mem.ReadAt(0).ToString());



                        break;
                    }
                default:
                    {
                        Console.WriteLine("Unknown command! Enter \"help\" for more information!");
                        break;
                    }
            }

            // help
            // version
            // echo

            Console.Write("Text typed: ");
            Console.WriteLine(input);
        }

        private void EchoFunction(string[] payload)
        {
            if(payload.Length > 1)
            {
                
                Console.WriteLine("Input: " + payload[1]);
            }
            else
            {
                Console.WriteLine(" Nothing to show");
            }

        }

        private void Help()
        {
            Console.WriteLine("Mögliche Befehle:\n " +
                " \"version\"  \tAusgabe Versionsnummer.\n" +
                " \"echo\" \t Ausgabe Text. \n" +
                " \"runtime\" \t Ausgabe Systemlaufzeit \n"); 
        }

        private string RunTime() 
        {
            TimeSpan span =  DateTime.Now -momentOfStart ;
            return String.Format("System running for {0} Hours {1} Minutes {2} Seconds", span.Hours, span.Minutes, span.Seconds);
        }
    }
}
