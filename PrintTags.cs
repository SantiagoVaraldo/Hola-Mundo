using System;
using System.Collections;

namespace ExerciseOne
{
         public class PrintTags
         {
                  // metodo de clase (static), imprime una lista de tags 
                  public static void Print(ArrayList lista)
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