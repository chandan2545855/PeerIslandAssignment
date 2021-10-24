using System.Collections.Generic;

namespace MultipleTablesSqlQuery.Model
{
  public class Join
  {
    public string Type { set; get; }
    public List<Condition> Conditions { set; get; }
  }
}
