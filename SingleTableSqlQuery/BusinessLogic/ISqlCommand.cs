namespace SingleTableSqlQuery.BusinessLogic
{
  public interface ISqlCommand
  {
    string Query { set; get; }
    void BuildQuery();    
  }
}
