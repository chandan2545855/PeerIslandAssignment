using MultipleTablesSqlQuery.Model;
using System.Collections.Generic;
using UtilityHelper;
namespace MultipleTablesSqlQuery.BusinessLogic
{
  public class Select : BuildSqlQuery, ISqlCommand
  {
    private Dictionary<string, string> dicTableAlias = new Dictionary<string, string>();
    public string Query { get; set; }
    public void BuildQuery()
    {
      SqlOperation sOperation = ReadJsonFile();
      Query = ConstructJoin(Query, 0, sOperation.Join);
      string fetch = "SELECT ";
      fetch=ConstructFetchColumns(sOperation.Columns, 0, fetch);
      fetch = fetch.Substring(0, fetch.Length - 1);
      fetch += " FROM ";
      Query = fetch + Query;
      string cond = " Where ";
      cond = BuildCondition(sOperation.Conditions, 0, cond);
      Query += cond;
    }
    public override SqlOperation ReadJsonFile()
    {
      string json = JsonFileReader.ReadFile("MultipleTableSqlJsonSelect.txt");
      return Deserialize.DeserializeToObject<SqlOperation>(json);
    }
    private string BuildCondition(List<Condition> conds,int index,string query)
    {
      if (index == conds.Count)
           return query;
      Condition cnd = conds[index++];
      for(int count=0;count<cnd.Columns.Count;count++)
      {
        Column column = cnd.Columns[count];
        query += dicTableAlias[column.TableName] + "." + column.Name + " " +
                 OperatorFactory.GetOperatorObject(cnd.Operator).OperatorQuery(column.Value);
        if (count < cnd.Columns.Count - 1)
            query += " and ";
      }
      if (index < conds.Count)
          query += " and ";
      return BuildCondition(conds, index, query);
    }
    private string ConstructFetchColumns(List<Column> cols,int index,string query)
    {
      if (index == cols.Count)
           return query;
      Column column = cols[index++];
      query += dicTableAlias[column.TableName] + "." + column.Name+",";
      return ConstructFetchColumns(cols, index, query);
    }
    private string ConstructJoin(string query,int index,List<Join> join)
    {
      if (index == join.Count)
           return query;      
      for(int count=0;count<join[index].Conditions.Count;count++)
      {
        Condition cond = join[index].Conditions[count];
        Column col1 = cond.Columns[0];
        Column col2 = cond.Columns[1];
        bool newTableAdded = false;
        col1.TableAlias = string.IsNullOrEmpty(col1.TableAlias) ? col1.TableName.ToLower() : col1.TableAlias;
        col2.TableAlias = string.IsNullOrEmpty(col2.TableAlias) ? col2.TableName.ToLower() : col2.TableAlias;
        if (!dicTableAlias.ContainsKey(col1.TableName))
        {
          dicTableAlias.Add(col1.TableName, col1.TableAlias);
          newTableAdded = true;
        }
        if (!dicTableAlias.ContainsKey(col2.TableName))
        {
          dicTableAlias.Add(col2.TableName, col2.TableAlias);
          newTableAdded = true;
        }         
        if(newTableAdded)
        {
          if (string.IsNullOrEmpty(query))
          {
            query = col1.TableName + " " + col1.TableAlias + " " + join[index].Type + " " + col2.TableName + " " + col2.TableAlias + " ";
          }
          else
          {
            query += " " + join[index].Type + " ";
            if (!query.Contains(col1.TableName))
              query += col1.TableName + " " + col1.TableAlias;
            else
              query += col2.TableName + " " + col2.TableAlias;
          }
          query = JoinOnColumns(cond, 0, query, cond.Operator, " on ");
        }           
        else
        {
          query = JoinOnColumns(cond, 0, query, cond.Operator, " and ");
        }
      }
      return ConstructJoin(query, index + 1, join);
    }
    private string JoinOnColumns(Condition cond,int index,string query,string oprtor,string cndon)
    {
      if (index == cond.Columns.Count)
           return query;
      Column col1 = cond.Columns[index++];
      Column col2 = cond.Columns[index++];
      query +=cndon+" "+ col1.TableAlias + "." + col1.Name + " " + oprtor + " " + col2.TableAlias + "." + col2.Name;      
      return JoinOnColumns(cond, index, query, oprtor, " and ");
    }
  }
}
