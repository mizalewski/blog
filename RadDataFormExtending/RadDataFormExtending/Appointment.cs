using System;

namespace RadDataFormExtending
{
    /// <summary>
    /// Appointment.
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person" /> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="birthday">The birthday.</param>
        public Appointment(string customerName, DateTime date)
        {
            this.CustomerName = customerName;
            this.Date = date;
        }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>The name of the customer.</value>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }
    }
}
