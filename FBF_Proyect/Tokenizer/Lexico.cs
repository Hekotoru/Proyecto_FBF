using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Franci
{
    class Lexico
    {
        const int TOKREC = 5;               //Indica el número de tokens a reconocer. Para este ejemplo su valor es 6.
        const int MAXTOKENS = 500;          //Es una constante que limita el número de parejas token-lexema a reconocer.
        string[] _lexemas;                  //Arreglo unidimensional de cadenas. Contiene cada uno de los lexemas reconocidos.
        string[] _tokens;                   //Es un arreglo unidimensional de cadenas. Contiene cada uno de los tokens reconocidos.
        string _lexema;                     //Es una cadena que contiene al lexema de un token reconocido en cada acción de aceptación que realice el analizador léxico.
        int _noTokens;                      //Atributo entero que contiene el número de parejas token-lexema reconocidos durante el proceso del análisis léxico.
        int _i;                             //Constituye un puntero al caracter i-ésimo del texto de entrada, que está leyendo para su análisis, el programa analizador léxico.
        int _iniToken;                      //Es un puntero al primer caracter donde empieza el siguiente reconocimiento de la pareja token-lexema.

        Automata oAFD;                      //Es un objeto que contiene la representación de los AFD’s utilizados.

        public Lexico() // constructor por defecto
        {
            _lexemas = new string[MAXTOKENS];
            _tokens = new string[MAXTOKENS];
            oAFD = new Automata();
            _i = 0;
            _iniToken = 0;
            _noTokens = 0;
        }


        public int NoTokens
        {
            get { return _noTokens; }
        }
        public string[] Lexema
        {
            get { return _lexemas; }
        }
        public string[] Token
        {
            get { return _tokens; }
        }
        
        /// <summary>
        /// Inicializa desde 0 antes de econtrar los  ID()
        /// </summary>
        public void Inicia()
        {
            _i = 0;
            _iniToken = 0;
            _noTokens = 0;
        }

        public void Analiza(string texto)
        {

            bool recAuto;
            int noAuto;
            
            while (_i < texto.Length)
              {
                recAuto = false;
                noAuto = 0;

                    for (; noAuto < TOKREC && !recAuto;)

                        if (oAFD.Reconoce(texto, _iniToken, ref _i, noAuto))
                                recAuto = true;
                        else
                            noAuto++;
                        if (recAuto)
                        {

                        _lexema = texto.Substring(_iniToken, _i - _iniToken);
                           
                            switch (noAuto)
                            {
                                //-------------- Automata delim-------------
                            
                                case 0: // _tokens[_noTokens] = "delim";
                                break;
                                //-------------- Automata id--------------
                                case 1:  
                                    if(EsId())
                                      _tokens[_noTokens] = "id";
                                    else
                                    _tokens[_noTokens] = _lexema;
                                 break;

                                //-------------- Automata num--------------
                                case 2: _tokens[_noTokens] = "num";
                                break;
                                //-------------- Automata otros-------------
                            
                                case 3: _tokens[_noTokens] = _lexema;
                                break;
                                //-------------- Automata cad--------------
                           
                                case 4: _tokens[_noTokens] = "cad";
                                break;
                            }

                        if (noAuto != 0)
                        _lexemas[_noTokens++] = _lexema;
                         }
                        else
                        _i++;
                            _iniToken = _i;
                    }
            }

        /// <summary>
        /// Determina si se almacena al token id o a la palabra reservada su lexema
        /// </summary>
        /// <returns>True si es un ID, false si es un palabra reservada</returns>
        private bool EsId()
        {
            string[] palres ={ "create", "table", "insert","into", "select", "from", "int", "string" };
            for (int i = 0; i < palres.Length; i++)
                if (_lexema == palres[i])
                    return false;
              return true;
        }

    }
}
