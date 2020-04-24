namespace PlotterConversionSystem
{
    public class Program
    {
        private static string inputtestpath = @"test.svg";
        private static string outputtestpath = @"output.hpgl";

        public static int Main(string[] args)
        {
            bool flag = CompilerFaçade.Compile(inputtestpath, outputtestpath);
            
            if (flag == true)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
