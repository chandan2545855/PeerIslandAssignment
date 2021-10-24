namespace SingleTableSqlQuery.Model
{
 public interface IOperator
  {
    string OperatorName { get; set; }
    string OperatorSymbol { get; set; }
    string OperatorQuery(string colName,string colValue);
  }
}
