using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SQL_Franci
{
   
    /// <summary>
    /// Analiza el lexico para ejecutar los comandos del query
    /// </summary>
    class Parse
    {
        
        private String creartabla; 

        public Parse()
        {
           creartabla = @"create table id ( [id int] ,||[id string] , )"; /// arreglar!!
        }

        /// <summary>
        /// Chueque la la sentecia de crear una tabla
        /// </summary>
        /// <param name="Tokens"> Lista de los tokens obtenidos del comando del query</param>
        /// <returns>true si esta correcta la sentencia, false si esta mal escrita</returns>
        public bool CheckSentenciaCrearTabla(Lexico Tokens)
        {
            String Sentencia = "";
            
            for (int i = 0; i < Tokens.NoTokens; i++)
            {
                if (Tokens.Token[i] != ";")
                {
                    Sentencia += Tokens.Token[i];
                    Sentencia +=" ";
                }

                if (Tokens.Token[i] == ";")
                {
                    if (Regex.IsMatch(Sentencia, creartabla))
                        return true;
                }
            }

                return false;   ////poner False-------------------------------------ARREGLAR-----------------------------------------
        }



        /*///EJEMPLO SENTENCIA ----------------------------------BORRAR-------------------------------------
         * 
         * create table Persons  
            (
                PersonID int,
                LastName string,
                FirstName string,
                Address string,
                City string
            );
         * 
         * 
         * */


        
        


    }
}
