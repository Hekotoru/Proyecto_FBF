using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBF_Proyect.Tokenizer
{
    public class TokenInfo
    {
        public String Regex { get; private set; }
        public int Token { get; private set; }

        public TokenInfo(String regex, int token)
        {
            this.Regex = regex;
            this.Token = token;
        }
    }
}
