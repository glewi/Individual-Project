using System;
using System.Runtime.Remoting.Messaging;

namespace PlotterConversionSystem
{
    public class Program
    {
        public static int Main(string[] args)
        {
            // Create some default paths that are used if no arguments are passed to the program.
            string defaultinputtestpath = @"test.svg";
            string defaultoutputtestpath = @"output.hpgl";
            
            // Store if the compile process was successfull.
            bool flag;

            // Catch any argument exceptions thrown.
            try
            {
                // If an invalid number of arguments are passed.
                if (args.Length < 2)
                {
                    // Used to validate if the program ran properly.
                    flag = CompilerFaçade.Compile(defaultinputtestpath, defaultoutputtestpath);
                }
                else if (args.Length > 2)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    flag = CompilerFaçade.Compile(args[0], args[1]);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Invalid Number of Arguments Passed");
            }
            finally
            {
                flag = false;
            }

            if (flag == true)
            {
                // Exit successfully.
                return 0;
            }
            else
            {
                // Exit unsuccessfully.
                return 1;
            }
        }
    }
}
