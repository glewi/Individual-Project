using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterConversionSystem.TokenDefinitions.TinySVG
{
    public class TinySvgPolyline : IToken
    {
        // The token ID generated at object instantiation.  Cannot be changed, only read.
        private readonly byte tokenID = checked((byte)SymbolTable.Polyline);
        private StringBuilder builder = new StringBuilder();
        private string path = null;
        
        private string ParsePath(string path)
        {
            foreach(char c in path)
            {   
                if (c != ' ')
                {
                    builder.Append(c);
                }
                else if (c == ' ' && c+1 != ' ')
                {
                    builder.Append(c);
                }
            }            
            return builder.ToString();
        }
        
        public TinySvgPolyline(params string[] attributes)
        {
            SetStringParameters(attributes);
        }

        public byte GetID()
        {
            return tokenID;
        }

        public Dictionary<string, string> GetNamedParameters()
        {
            return new Dictionary<string, string>
            {
                {"path", path }
            };
        }

        public string[] GetParameters()
        {   
            return null;
        }

        public void SetStringParameters(params string[] parameters)
        {
            try
            {
                path = ParsePath(parameters[0]);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
