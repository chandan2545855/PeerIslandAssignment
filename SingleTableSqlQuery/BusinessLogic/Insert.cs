using SingleTableSqlQuery.Model;
using System;
using System.Collections.Generic;
using UtilityHelper;
using System.Linq;

namespace SingleTableSqlQuery.BusinessLogic
{
  public class Insert :BuildSqlQuery,ISqlCommand
  {
    public string Query { set; get; }
    public void BuildQuery()
    {
      SqlQuery sQuery = ReadJsonFile();
      List<string> colNameList = sQuery.Columns.Select(item => item.Name).ToList();
      string columnNames = String.Join(",",colNameList);
      List<string> colValueList = sQuery.Columns.Select(item => item.Value).ToList();
      string columnValues = String.Join(",", colValueList);
      Query = sQuery.Operation + " into " + sQuery.TableName + "(" + columnNames + ") values(" + columnValues + ")";     
    }
    public override SqlQuery ReadJsonFile()
    {
      string json = JsonFileReader.ReadFile("SingleTableSqlJsonInsert.txt");
      return Deserialize.DeserializeToObject<SqlQuery>(json);
    }
  }
}
