using System;
using System.Linq;
using System.Windows.Controls;

namespace RadDataFormExtending
{
    /// <summary>
    /// Main page.
    /// </summary>
    public partial class MainPage : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            this.DataContext = this;
            this.Appointment = new Appointment("Michał Zalewski", new DateTime(2011, 10, 26, 10, 15, 00));

            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the appointment.
        /// </summary>
        /// <value>The appointment.</value>
        public Appointment Appointment { get; set; }
    }
}
