using System;
using System.IO;
namespace UtilityHelper
{
  public class JsonFileReader
  {
    public static string ReadFile(string path)
    {
      path = Path.Combine(Environment.CurrentDirectory,path);
      return File.ReadAllText(path);
    }
  }
}
