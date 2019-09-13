using System.Collections;

/* ------------------------------------------------------------------------------------------------------------------------
NOMBRE: TagFinder
DESCRIPCION: esta clase se encarga de encontar los tags y los atributos de un codigo HTML y guardarlos en una lista
             para esto, la clase TagFinder tiene 2 metodos, el metodo findTags recibe un codigo HTML y devuelve los
             tags en una lista. El metodo findAtributes recibe un codigo HTML y agrega los atributos a la misma lista.
PATRON EXPERT: 
SRP: esta clase tiene la responsabilidad de encontrar tags y atributos de un codigo HTML, tiene solo una razon de cambio.
---------------------------------------------------------------------------------------------------------------------------
 */

namespace ExerciseOne
{

         public class TagFinder
         {
                  ArrayList tagsAndAtributes = new ArrayList();

                  /// <summary>
                  /// el metodo findTags recibe un codigo HTML y guarda los tags en la lista tagsAndAtributes.
                  /// </summary>
                  /// <param name="content">codigo HTML en forma de string para ser recorrido</param>
                  /// <returns></returns>        
                  public ArrayList findTags(string content)
                  {
                           string[] contentList = content.Split(new[] { '\r', '\n' }); //Separa el archivo por lineas 
                           char inicio = '<';
                           char fin = '>';
                           char espacio = ' ';
                           char barra = '/';

                           foreach (string linea in contentList)
                           { //recorre lineas
                                    string tag = "";
                                    bool found = false; //indica si se encontro una tag

                                    foreach (char caracter in linea)
                                    { //se fija caracter por caracter de content

                                             if (caracter.Equals(fin) || caracter.Equals(espacio) || found && caracter.Equals(barra))
                                             { //Si es un tag terminando, un espacio, o el siguiente caracter despeus de un < es un /, pone found false, y continua a la siguiente linea.
                                                      found = false;
                                                      continue;
                                             }

                                             if (found)
                                             { //si se encontro un <, escribe los caracteres al string tag.
                                                      tag += caracter;
                                             }

                                             if (caracter.Equals(inicio))
                                             { //se fija si un tag empieza

                                                      found = true;
                                             }
                                    }
                                    tagsAndAtributes.Add(tag);
                           }
                           return tagsAndAtributes;
                  }

                  /// <summary>
                  /// El metodo findAtributes recibe un codigo HTML y agrega los atributos a la misma lista (tagsAndAtributes).
                  /// </summary>
                  /// <param name="content">codigo HTML en forma de string para ser recorrido</param>
                  /// <returns></returns>
                  public ArrayList FindAtributes(string content)
                  {
                           string[] contentList = content.Split(new[] { '\r', '\n' }); //Separa el archivo por lineas 
                           char inicio = '<';
                           char fin = '>';
                           char espacio = ' ';
                           char barra = '/';

                           foreach (string linea in contentList)
                           { //recorre lineas 
                                    string tag = "";
                                    bool found = false; //indica si se encontro una tag
                                    bool FoundAtribute = false; //indica si se encontro un atributo

                                    foreach (char caracter in linea)
                                    { //se fija caracter por caracter de content

                                             if (caracter.Equals(fin) || found && caracter.Equals(barra))
                                             { //Si es un tag terminando, o el siguiente caracter despeus de un < es un /, pone found false.
                                                      found = false;
                                             }
                                             if (caracter.Equals(fin) || caracter.Equals(barra) || (FoundAtribute && caracter.Equals(espacio)))
                                             { //Si es un tag terminando, una barra, o si FoundAtributes es True y se encontro otro espacio, pone FoundAtributes false. 
                                                      if (FoundAtribute && caracter.Equals(espacio))
                                                      {
                                                               tag += "\n"; // separa los atributos que esten en una misma linea
                                                      }
                                                      FoundAtribute = false;
                                             }

                                             if (found && FoundAtribute && caracter != '"')
                                             { //si se encontro un <, un " " y caracter no es un espacio, escribe los caracteres al string tag.
                                                      tag += caracter;
                                             }

                                             if (caracter.Equals(inicio))
                                             { //se fija si un tag empieza

                                                      found = true;
                                             }
                                             if (caracter.Equals(espacio) && found) // si se abrio el tag con < y se encontro un ' ', pone FoundAtributes true.
                                             {
                                                      FoundAtribute = true;
                                             }
                                    }
                                    tagsAndAtributes.Add(tag);
                           }
                           return tagsAndAtributes;
                  }
         }
}