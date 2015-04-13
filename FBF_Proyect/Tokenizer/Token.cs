using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBF_Proyect.Tokenizer
{
    public class Token
    {
      
        public static int TERMINAL { get { return -1; } }
        public static int OPERATOR { get { return 1; } }
        public static int OPEN_BRACKET { get { return 2; }}
        public static int CLOSE_BRACKET { get { return 3; } }
        public static int STRING { get { return 4; } }
        


        public int TokenType { get; private set; }
        public String Sequence{ get; private set; }

        public Token(int token, String sequence){

            this.TokenType = token;
            this.Sequence = sequence;
        }
    }
}
