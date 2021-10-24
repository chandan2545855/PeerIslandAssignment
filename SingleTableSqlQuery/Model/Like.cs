namespace SingleTableSqlQuery.Model
{
  public class Like : IOperator
  {
    public Like(string sqlOperator)
    {
      OperatorName = sqlOperator;
      OperatorSymbol = sqlOperator;
    }
    public string OperatorName { get; set; }
    public string OperatorSymbol { get; set; }

    public string OperatorQuery(string colName,string colValue)
    {
      return colName + " Like " + "'" + colValue + "'";
    }
  }
}
