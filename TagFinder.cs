using System;
using System.IO;
using System.Net;
using System.Collections;

namespace ExerciseOne
{
	
	public class TagFinder
	{
        ArrayList tagsAndAtributes = new ArrayList();
        public ArrayList findTags(string content){
            //Separa el archivo por lineas
            string[] contentList = content.Split(new [] { '\r', '\n' }); 
            char inicio = '<';
            char fin = '>';
            char espacio = ' ';
            char barra = '/';

            //recorre lineas
            foreach (string linea in contentList){ 
                string tag = "";
                bool found = false;        //indica si se encontro una tag
                    
                foreach (char caracter in linea) {  //se fija caracter por caracter de content
                
                    if (caracter.Equals(fin) || caracter.Equals(espacio) || found && caracter.Equals(barra)){ //Si es un tag terminando, un espacio, o el siguiente caracter despeus de un < es un /, pone found false, y continua a la siguiente linea.
                        found = false;
                        continue;
                    }
                    
                    if (found){ //si se encontro un <, escribe los caracteres al string tag.
                        tag += caracter;
                    }

                    if (caracter.Equals(inicio)) { //se fija si un tag empieza
                        
                        found = true;
                    }
                }
                tagsAndAtributes.Add(tag);
            }
            return tagsAndAtributes;
        }
        public ArrayList FindAtributos(string content)
        {
             //Separa el archivo por lineas
            string[] contentList = content.Split(new [] { '\r', '\n' }); 
            char inicio = '<';
            char fin = '>';
            char espacio = ' ';
            char barra = '/';

            //recorre lineas
            foreach (string linea in contentList){ 
                string tag = "";
                bool found = false;
                bool FoundAtributo = false;        //indica si se encontro una tag
                    
                foreach (char caracter in linea) {  //se fija caracter por caracter de content

                
                    if (caracter.Equals(fin) || found && caracter.Equals(barra)){ //Si es un tag terminando, un espacio, o el siguiente caracter despeus de un < es un /, pone found false, y continua a la siguiente linea.
                        found = false;
                        //continue;
                    }
                    if (caracter.Equals(fin) || caracter.Equals(barra) || (FoundAtributo && caracter.Equals(espacio))){ //Si es un tag terminando, un espacio, o el siguiente caracter despeus de un < es un /, pone found false, y continua a la siguiente linea.
                        if (FoundAtributo && caracter.Equals(espacio))
                        {
                            tag+= "\n";
                        }
                        FoundAtributo = false;
                        //continue;
                    }
                    
                    if (found && FoundAtributo && caracter!= '"'){ //si se encontro un <, escribe los caracteres al string tag.
                        tag += caracter;
                    }

                    if (caracter.Equals(inicio)) { //se fija si un tag empieza
                        
                        found = true;
                    }
                    if (caracter.Equals(espacio)&&found)
                    {
                        FoundAtributo = true;
                    }
                }
                tagsAndAtributes.Add(tag);
            }
            return tagsAndAtributes;
        }
	}
}