namespace MultipleTablesSqlQuery.Model
{
  public class Like : IOperator
  {
    public Like(string opertor)
    {
      OperatorName = opertor;
      OperatorSymbol = opertor;
    }
    public string OperatorName { get; set; }
    public string OperatorSymbol { get; set; }

    public string OperatorQuery(string colValue)
    {
      return OperatorSymbol + " '%" + colValue + "%' ";
    }
  }
}
