using SingleTableSqlQuery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using UtilityHelper;
namespace SingleTableSqlQuery.BusinessLogic
{
  public class Select :BuildSqlQuery,ISqlCommand
  {
    public string Query { set; get; }
    public void BuildQuery()
    {
      SqlQuery sQuery=ReadJsonFile();
      List<string> colNameList = sQuery.Columns.Select(item => item.Name).ToList();
      string columnNames = String.Join(",",colNameList);
      Query = "Select " + columnNames + " from " + sQuery.TableName;
      string conditions = "";
      if (sQuery.Conditions?.Count>0)
      {        
        foreach(Condition condition in sQuery.Conditions)
        {
          if(String.IsNullOrEmpty(conditions))
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
      string json = JsonFileReader.ReadFile("SingleTableSqlJsonSelect.txt");
      return Deserialize.DeserializeToObject<SqlQuery>(json);
    }
  }
}
