namespace PlotterConversionSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputtestpath = @"test.svg";
            string outputtestpath = @"output.hpgl";
            CompilerFaçade.Compile(inputtestpath, outputtestpath);
        }
    }
}
