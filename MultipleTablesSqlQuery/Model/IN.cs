namespace MultipleTablesSqlQuery.Model
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

    public string OperatorQuery( string colValue)
    {
      return  OperatorSymbol + "(" + colValue + ")";
    }
  }
}
