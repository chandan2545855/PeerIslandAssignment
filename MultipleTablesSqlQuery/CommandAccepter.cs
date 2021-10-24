using MultipleTablesSqlQuery.BusinessLogic;

namespace MultipleTablesSqlQuery
{
  public class CommandAccepter
  {
    public static string AcceptCommand(string command)
    {
      ISqlCommand sqlCmd = CommandFactory.GetCommandObject(command);
      sqlCmd.BuildQuery();
      return sqlCmd.Query;
    }
  }
}
