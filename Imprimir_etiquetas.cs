using System;
using System.IO;
using System.Net;
using System.Collections;

namespace ExerciseOne
{
         public class ImprimirEtiquetas
         {
                  // metodo de clase (static), imprime una lista
                  public static void Imprimir(ArrayList lista)
                  {
                           foreach(string linea in lista)
                           {
                                    if (linea != "")
                                    {
                                             Console.WriteLine(linea);
                                    }
                           }
                  }
         }
}