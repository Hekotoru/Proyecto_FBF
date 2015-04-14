using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FBF_Proyect.Analyzer_Syntax
{
    public class Analyzer_Syntax
    {
        /*
         * C++ Program to check for balanced parentheses in an expression using stack.
         * Given an expression as string comprising of opening and closing characters
         * of parentheses - (), curly braces - {} and square brackets - [], we need to 
         * check whether symbols are balanced or not. 
         */

        // Function to check whether two characters are opening 
        // and closing of same type. 
        bool ArePair(char opening,char closing)
        {
            if(opening == '(' && closing == ')') return true;
            else if(opening == '{' && closing == '}') return true;
            else if(opening == '[' && closing == ']') return true;
            return false;
        }
        public bool AreParanthesesBalanced(string exp)
        {
            Stack<char>  S = new Stack<char>();
            for(int i =0;i<exp.Length;i++)
            {
                if(exp[i] == '(' || exp[i] == '{' || exp[i] == '[')
                    S.Push(exp[i]);
                else if(exp[i] == ')' || exp[i] == '}' || exp[i] == ']')
                {
                    if(S.Count ==0 || !ArePair(S.First(),exp[i]))
                        return false;
                    else
                        S.Pop();
                }
            }
            return S.Count == 0 ? true:false;
        }
 

    }
}
