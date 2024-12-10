using ExcerciseApi.Data;

namespace ExcerciseApi.Repository
{
    /// <summary>
    /// Interface for the data repository
    /// </summary>
    public interface IExcerciseDataRepository
    {
        /// <summary>
        /// Queries data by customer id between two dates
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="startDate">The starting date filter.</param>
        /// <param name="endDate">The ending date filter.</param>
        /// <returns></returns>
        List<ExcerciseData> GetByCustomerBetweenDates(int customerId, DateTime startDate, DateTime endDate);
    }
}
