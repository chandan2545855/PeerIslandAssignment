using SingleTableSqlQuery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using UtilityHelper;

namespace SingleTableSqlQuery.BusinessLogic
{
  public class Update : BuildSqlQuery,ISqlCommand
  {
    public string Query { set; get; }
    public void BuildQuery()
    {
      SqlQuery sQuery = ReadJsonFile();
      Query = "Update " + sQuery.TableName + " set ";
      foreach(Column column in sQuery.Columns)
      {
        Query +=column.Name + " = " + column.Value+",";
      }
      Query = Query.Substring(0, Query.Length - 1);
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
      string json = JsonFileReader.ReadFile("SingleTableSqlJsonUpdate.txt");
      return Deserialize.DeserializeToObject<SqlQuery>(json);
    }
  }
}
