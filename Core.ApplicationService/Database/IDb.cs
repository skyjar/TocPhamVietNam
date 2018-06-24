namespace Core.ApplicationServices.Database
{
    public interface IDb
    {
        object GetContext { get; }
    }
}