namespace Weather_Application_Backend.Jobs
{
    public class PredictValuesJob
    {



        /// <summary>
        /// Predicts the values for all measurements for the last 24 hours and updates the Forecast table
        /// <br></br>
        /// PM10, PM2.5, Temperature, MinTemp, MaxTemp, Windspeed, Humidity
        /// </summary>
        /// <returns></returns>
        public Task predictValues() 
        { 
            return Task.CompletedTask;
        }
    }
}
