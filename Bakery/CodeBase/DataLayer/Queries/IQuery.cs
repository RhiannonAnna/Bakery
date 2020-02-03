namespace Bakery.CodeBase.DataLayer.Queries
{
    public interface IQuery<T>
    {
        T Execute();
    }
}