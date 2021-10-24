using System.Collections.Generic;

namespace MultipleTablesSqlQuery.Model
{
  public class SqlOperation
  {
    public string OperationName { get; set; }
    public List<Column> Columns { get; set; }
    public List<Join> Join { get; set; }
    public List<Condition> Conditions { set; get; }
  }
}
