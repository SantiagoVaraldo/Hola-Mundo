using System;
using System.IO;
using System.Reflection;

namespace ExerciseOne
{
         /// <summary>
         /// Pequeño programa para probar el funcionamiento de la clase Downloader.
         /// </summary>
         public static class Program
         {
                  //variable constante con el nombre del archivo
                  const String fileName = @"..\..\..\test.html";
                  /// <summary>
                  /// Punto de entrada
                  /// </summary>
                  public static void Main()
                  {
                           String path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
                           UriBuilder builder = new UriBuilder("file", "", 0, path);
                           String uri = builder.Uri.ToString();
                           Downloader downloader = new Downloader(uri); // Creamos un nuevo descargador pasándole una ubicación.
                           string content;
                           content = downloader.Download(); // Pedimos al descargador que descargue el contenido
                           TagFinder objeto = new TagFinder(); // creamos un objeto TagFinder 
                           var lista = objeto.findTags(content); // agregamos a una lista los tags y los atributos, para eso llamamos a ambos metodos de la clase TagFinder
                           var lista1 = objeto.FindAtributes(content);
                           PrintTags.Print(lista1); // utilizando la clase PrintTags que tiene un solo metodo de clase imprimimos la lista
                                                    /*
                                                                               Console.WriteLine("Antes de foreach");
                                                                               //Mostrar contenido aca

                                                                               foreach (var linea in TagFinder.findTags(content)){
                                                                                        Console.WriteLine(linea);
                                                                               }
                                                                               Console.WriteLine("Despues de foreach");

                                                     */



                           //Console.ReadKey();
                  }
         }
}