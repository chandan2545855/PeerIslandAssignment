namespace SingleTableSqlQuery.Model
{
  public class Condition
  {
    public string Operator { set; get; }
    public string ColumnName { set; get; }
    public string ColumnValue { set; get; }

    public override string ToString()
    {
      return OperatorFactory.GetOperatorObject(Operator).OperatorQuery(ColumnName,ColumnValue);      
    }
  }
}
