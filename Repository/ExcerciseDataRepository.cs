using ExcerciseApi.Data;

namespace ExcerciseApi.Repository
{
    /// <summary>
    /// Implmentation of the data repository.
    /// </summary>
    public class ExcerciseDataRepository : IExcerciseDataRepository
    {
        /// <summary>
        /// Application configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the data repository.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        public ExcerciseDataRepository(IConfiguration configuration) => _configuration = configuration;

        /// <summary>
        /// Queries data by customer between two dates.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="startDate">The starting date filter.</param>
        /// <param name="endDate">The ending date filter.</param>
        /// <returns>The list of selected data.</returns>
        public List<ExcerciseData> GetByCustomerBetweenDates(int customerId, DateTime startDate, DateTime endDate)
        {
            using (var context = new ExcerciseApiDataContext(_configuration))
            {
                var excerciseData = context.ExcerciseData.Where(e => 
                    e.CustomerId == customerId
                    && e.EventDate >= startDate
                    && e.EventDate < endDate)
                .ToList();

                return excerciseData;
            }
        }
    }
}
