namespace SingleTableSqlQuery.Model
{
  public class OperatorFactory
  {
    public static IOperator GetOperatorObject(string sqlOperator)
    {
      switch(sqlOperator)
      {
        case "In": return new IN(sqlOperator);
        case "Like": return new Like(sqlOperator);
        case "Between": return new Between(sqlOperator);
        case "NotEqual": return new NotEqual(sqlOperator);
        case "Equal": return new Equal(sqlOperator);
        case "GreaterThanEqual": return new GreaterThanEqual(sqlOperator);
        case "LessThanEqual": return new LessThanEqual(sqlOperator);
        default: return null;
      }
    }
  }
}
