using SingleTableSqlQuery.BusinessLogic;
namespace SingleTableSqlQuery
{
  public class CommandAcceptor
  {
    public static string AcceptCommand(string command)
    {
      ISqlCommand sqlCmd = CommandFactory.GetCommandObject(command);
      sqlCmd.BuildQuery();
      return sqlCmd.Query;
    }
  }
}
