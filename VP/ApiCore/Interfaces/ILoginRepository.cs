namespace ApiCore.Interfaces
{
    //Using the CQS pattern
    public interface ILoginRepository
        : ILoginCommands,
        ILoginQueries
    {
    }
}
