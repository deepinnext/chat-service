namespace Deepin.Chatting.Application.Queries;

public abstract class QueryBase
{
    protected string BuildSqlWithSchema(string sql)
    {
        return $"set search_path to chatting; {sql}";
    }
}
