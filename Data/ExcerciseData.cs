using System.Text.Json.Serialization;

namespace ExcerciseApi.Data
{
    /// <summary>
    /// Represents the excercise data table.
    /// </summary>
    public class ExcerciseData
    {
        /// <summary>
        /// The customer identifier.
        /// </summary>
        [JsonPropertyName("customer_id")]
        public int CustomerId { get; set; }

        /// <summary>
        /// The event date.
        /// </summary>
        [JsonPropertyName("event_date")]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// The roll cover thickness measurment.
        /// </summary>
        [JsonPropertyName("cover_thickness")]
        public decimal CoverThickness { get; set; }
    }
}
