namespace MultipleTablesSqlQuery.Model
{
  public class Equal:IOperator
  {
    public Equal(string sqlOperator)
    {
      OperatorName = sqlOperator;
      OperatorSymbol = "=";
    }
    public string OperatorName { get; set; }
    public string OperatorSymbol { get; set; }
    public string OperatorQuery(string colValue)
    {
      return OperatorSymbol + " '" + colValue + "'";
    }
  }
}
