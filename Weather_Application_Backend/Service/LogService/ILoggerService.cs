namespace Weather_Application_Backend.Service.LogService
{
    public interface ILoggerService
    {
        Task log(string message);
    }
}
