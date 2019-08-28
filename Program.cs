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
			String path = Path.Combine( Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
			UriBuilder builder = new UriBuilder("file", "", 0, path);
			String uri = builder.Uri.ToString();
			// Creamos un nuevo descargador pasándole una ubicación.
			Downloader downloader = new Downloader(uri);
			// Pedimos al descargador que descargue el contenido
			string content;
			content = downloader.Download();
			// creamos un objeto TagFinder ya que ahora sus metodos son de instancia y no de clase
			TagFinder objeto = new TagFinder();
			// agregamos a una lista los tags y los atributos, para eso llamamos a ambos metodos 
			var lista = objeto.findTags(content);
			var lista1 = objeto.FindAtributos(content);
			// utilizando la clase ImprimirEtiquetas que tiene un solo metodo de clase imprimimos la lista
			ImprimirEtiquetas.Imprimir(lista1);
			//EncontrarEtiquetas.Tags(lista1);
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