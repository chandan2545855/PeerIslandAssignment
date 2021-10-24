using System.Collections.Generic;

namespace MultipleTablesSqlQuery.Model
{
  public class Condition
  {
    public string Operator { set; get; }
    public List<Column> Columns { set; get; }

    
  }
}
