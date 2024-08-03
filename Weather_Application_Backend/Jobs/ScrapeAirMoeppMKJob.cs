namespace Weather_Application_Backend.Jobs
{
    public class ScrapeAirMoeppMKJob
    {

        public Task scrapeData() 
        {
            // scrapes data and adds it in the measurements table...

            System.Console.WriteLine("Some wild data that occurs every minute lmfao");
            return Task.CompletedTask;
        }
    }
}
