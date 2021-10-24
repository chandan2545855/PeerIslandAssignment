namespace SingleTableSqlQuery.Model
{
  public class IN : IOperator
  {
    public IN(string sqlOperator)
    {
      OperatorName = sqlOperator;
      OperatorSymbol = sqlOperator;
    }
    public string OperatorName { get; set; }
    public string OperatorSymbol { get; set; }

    public string OperatorQuery(string colName, string colValue)
    {
      return colName + " " + OperatorSymbol + "(" + colValue + ")";
    }
  }
}
