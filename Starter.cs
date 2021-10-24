using MultipleTablesSqlQuery;
using SingleTableSqlQuery;
using System;

namespace PeerIslandAssignment
{
  class Starter
  {
    static void Main(string[] args)
    {
      //Console.WriteLine("Single Table Insert: ");
      //Console.WriteLine(CommandAcceptor.AcceptCommand("Insert"));
      //Console.WriteLine("Single Table Select: ");
      //Console.WriteLine(CommandAcceptor.AcceptCommand("Select"));
      //Console.WriteLine("Single Table Update: ");
      //Console.WriteLine(CommandAcceptor.AcceptCommand("Update"));
      //Console.WriteLine("Single Table Delete: ");
      //Console.WriteLine(CommandAcceptor.AcceptCommand("Delete"));

      Console.WriteLine("Multiple Tables Select: ");
      Console.WriteLine(CommandAccepter.AcceptCommand("Select"));
      Console.ReadLine();
    }
  }
}
