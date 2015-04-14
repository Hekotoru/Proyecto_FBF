using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Franci
{
    class Automata
    {
        string _textoIma;       //Es una referencia a un string. Es asignado al valor del texto de entrada.
        int _edoAct;            //Permite saber en todo momento el valor del estado actual del AFD, que está siendo utilizado en un determinado momento, por el analizador léxico.
        
        char SigCar(ref int i)
        {


            if (i == _textoIma.Length)
            {
                i++;
                return ' ';
            }

            else
            {
                return _textoIma[i++];
            }
        }

        public bool Reconoce(string texto, int iniToken, ref int i, int noAuto)
        {
            char c;
            _textoIma = texto;
            string lenguaje;


            switch (noAuto)
            {   
                ///Automata delimitador
                case 0: _edoAct = 0;
                    break;
                    
                /// Automata id
                case 1: _edoAct = 3;
                    break;
                
                /// Automata Numeros
                case 2: _edoAct = 6;
                    break;

                ///Automata Otros
                case 3: _edoAct = 9;
                    break;

                ///Automa cadena
                case 4: _edoAct = 11;
                    break;
           }


            while(i <= _textoIma.Length)
                switch (_edoAct)
                {
                    case 0: c = SigCar(ref i);
                        if ((lenguaje = " \n\r\t").IndexOf(c) >= 0)
                        {
                            _edoAct = 1;
                        }

                        else 
                        {
                            i = iniToken;
                            return false;
                        }

                        break;

                    case 1: c = SigCar(ref i);

                            if ((lenguaje = " \n\r\t").IndexOf(c) >= 0)
                            _edoAct = 1;
                       
                            else 
                        
                             if ((lenguaje="!\"#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_'abcdefghijklmnopqrstuvwxyz{|}~€‚ƒ„…†‡ˆ‰Š‹OEŽ''“”•–—˜™š›oežŸ ¡¢£¤¥¦§¨©ª«¬-®¯°±²³´μ¶·¸¹º»¼½¾¿\f").IndexOf(c)>=0) _edoAct=2; else
                                { 
                                 i=iniToken;
                                 return false;
                                }
                        break; 


                    case 2: i--;
                            
                         return true;
                       
                        //break;

                    case 3: c=SigCar(ref i);
                            if((lenguaje="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz").IndexOf(c)>=0)
                                _edoAct=4;
                            else
                            { 
                                i=iniToken;
                                return false; 
                            }
                        break;

                    case 4 : c=SigCar(ref i);
                            
                            if((lenguaje="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz").IndexOf(c)>=0) 
                            _edoAct=4; 
                        
                            else
                            if ((lenguaje="0123456789").IndexOf(c)>=0)
                                _edoAct=4; 
                        
                            else 
                             if ((lenguaje="_").IndexOf(c)>=0) 
                                 _edoAct=4;
                        
                            else
                              if ((lenguaje=" !\"#$%&\'()*+,-./:;<=>?@[\\]^`{|}~€‚ƒ„…†‡ˆ‰Š‹OEŽ‘’“”•–—˜™š›oežŸ ¡¢£¤¥¦§¨©ª«¬-®¯°±²³´μ¶·¸¹º»¼½¾¿\n\t\r\f").IndexOf(c)>=0) 
                                  _edoAct=5; 
                          
                             else
                              { 
                                  i=iniToken;
                                  return false; 
                              }
                        break;
                    
                    case 5 : i--;
                        
                        return true;
                      
                        //break;

                   case 6 : c=SigCar(ref i);

                        if ((lenguaje="0123456789").IndexOf(c)>=0)
                            _edoAct=7; 
                        else
                        { 
                            i=iniToken;
                            return false; 
                        }
                      break;

                   case 7 : c=SigCar(ref i);
                        if ((lenguaje="0123456789").IndexOf(c)>=0)
                            _edoAct=7; 
                        
                        else
                            if ((lenguaje=" !\"#$%&\'()*+,-./:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~€‚ƒ„…†‡ˆ‰Š‹OEŽ‘’“”•–—˜™š›oežŸ ¡¢£¤¥¦§¨©ª«¬-®¯°±²³´μ¶·¸¹º»¼½¾¿\n\t\r\f").IndexOf(c)>=0) 
                                _edoAct=8; 
                            else
                            { 
                                i=iniToken; return false; 
                            }
                      break;


                   case 8 : i--;
                          return true;
                      //break;

                    case 9 : c=SigCar(ref i);

                             if ((lenguaje="=").IndexOf(c)>=0) _edoAct=10;
                        
                            else
                                if ((lenguaje=";").IndexOf(c)>=0) _edoAct=10;
                       
                            else
                                if ((lenguaje=",").IndexOf(c)>=0) _edoAct=10;
                       
                            else
                                if ((lenguaje=".").IndexOf(c)>=0) _edoAct=10;
                        
                            else
                                if ((lenguaje="+").IndexOf(c)>=0) _edoAct=10;
                        
                            else
                                if ((lenguaje="-").IndexOf(c)>=0) _edoAct=10;
                       
                            else
                                if ((lenguaje="*").IndexOf(c)>=0) _edoAct=10;
                       
                            else
                                if ((lenguaje="/").IndexOf(c)>=0) _edoAct=10;
                       
                            else
                                if ((lenguaje="(").IndexOf(c)>=0) _edoAct=10;
                        
                            else
                                if ((lenguaje=")").IndexOf(c)>=0) _edoAct=10;
                                                                             
                            else
                            { 
                                i=iniToken;
                                return false; 
                            }
                      
                         break;

                    case 10 : 
                        return true;
                        // break;

                    case 11 : c=SigCar(ref i);
                        
                        if ((lenguaje="\"").IndexOf(c)>=0) _edoAct=12;
                        
                        else
                            { 
                                i=iniToken;
                                return false; 
                            }
                        break;

                     case 12 : c=SigCar(ref i);

                        if ((lenguaje="\"").IndexOf(c)>=0) _edoAct=13;
                        
                        else
                         if ((lenguaje=" !#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~€‚ƒ„…†‡ˆ‰Š‹OEŽ‘’“”•–—˜™š›oežŸ ¡¢£¤¥¦§¨©ª«¬-®¯°±²³´μ¶·¸¹º»¼½¾¿\n\t\r\f").IndexOf(c)>=0) 
                                _edoAct=12; 
                            
                        else
                         { 
                           i=iniToken;
                           return false; 
                         }

                       break;
                    
                    case 13 : return true;

                      // break;
                        
                }


                switch (_edoAct)
                {
                case 2: // Autómata delim
                case 5: // Autómata id
                case 8: // Autómata num
                    --i;
                       return true;
                }
            
            return false;
        }
       
    }
                       


}











