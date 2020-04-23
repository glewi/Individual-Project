using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterConversionSystem.TokenDefinitions
{
    public interface IToken
    {
        byte GetID();
        Dictionary<string, string> GetNamedParameters();
        string[] GetParameters();
        void SetStringParameters(params string[] parameters);
    }
}
