namespace SingleTableSqlQuery.Model
{
  public class Between : IOperator
  {
    public Between(string sqlOperator)
    {
      OperatorName = sqlOperator;
      OperatorSymbol = sqlOperator;
    }
    public string OperatorName { get; set; }
    public string OperatorSymbol { get; set; }

    public string OperatorQuery(string colName, string colValue)
    {
      string[] valueArray = colValue.Split(',');
      return colName + " " + OperatorSymbol + " '" + valueArray[0] + "' and '" + valueArray[1]+"'";
    }
  }
}
