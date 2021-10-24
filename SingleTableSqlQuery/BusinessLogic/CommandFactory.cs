namespace SingleTableSqlQuery.BusinessLogic
{
 public class CommandFactory
  {
    public static ISqlCommand GetCommandObject(string command)
    {
      switch(command)
      {
        case "Insert": return new Insert();
        case "Update": return new Update();
        case "Delete": return new Delete();
        case "Select": return new Select();
        default: return null;
      }
    }
  }
}
