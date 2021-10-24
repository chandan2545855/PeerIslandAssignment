namespace SingleTableSqlQuery.Model
{
  public class GreaterThanEqual : IOperator
  {
    public GreaterThanEqual(string sqlOperator)
    {
      OperatorName = sqlOperator;
      OperatorSymbol = ">=";
    }
    public string OperatorName { get; set; }
    public string OperatorSymbol { get; set; }

    public string OperatorQuery(string colName, string colValue)
    {
      return colName + " " + OperatorSymbol + " '" + colValue+"'";
    }
  }
}
