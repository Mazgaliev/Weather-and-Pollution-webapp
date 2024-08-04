namespace Weather_Application_Backend.Jobs
{
    public class ScrapeAirMoeppMKJob
    {


        /// <summary>
        /// Scrapes data from https://air.moepp.gov.mk/
        /// </summary>
        /// <returns></returns>
        public Task scrapeData() 
        {

            System.Console.WriteLine("Some wild data that occurs every minute lmfao");
            return Task.CompletedTask;
        }
    }
}
