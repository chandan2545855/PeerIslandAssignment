using SingleTableSqlQuery.Model;
using System;
using UtilityHelper;

namespace SingleTableSqlQuery.BusinessLogic
{
  public class Delete : BuildSqlQuery,ISqlCommand
  {
    public string Query { set; get; }
    public void BuildQuery()
    {
      SqlQuery sQuery = ReadJsonFile();
      Query = "Delete from "+ sQuery.TableName;
      string conditions = "";
      if (sQuery.Conditions?.Count > 0)
      {
        foreach (Condition condition in sQuery.Conditions)
        {
          if (String.IsNullOrEmpty(conditions))
          {
            conditions = condition.ToString();
          }
          else
          {
            conditions += " and " + condition.ToString();
          }
        }
      }
      if (!string.IsNullOrEmpty(conditions))
        Query += " where " + conditions;
    }
    public override SqlQuery ReadJsonFile()
    {
      string json = JsonFileReader.ReadFile("SingleTableSqlJsonDelete.txt");
      return Deserialize.DeserializeToObject<SqlQuery>(json);
    }
  }
}
