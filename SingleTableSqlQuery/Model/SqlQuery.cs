using System.Collections.Generic;

namespace SingleTableSqlQuery.Model
{
  public class SqlQuery
  {
    public string TableName { set; get; }
    public string Operation { set; get; }
    public List<Column> Columns { set; get; }
    public List<Condition> Conditions { set; get; }
  }
}
