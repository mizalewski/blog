using System;
using System.Windows;
using System.Windows.Controls;
using Silverlight_Enterprise_Library_Logging.Logging;

namespace Silverlight_Enterprise_Library_Logging
{
    public partial class MainPage : UserControl
    {
        private readonly ILogFacade logger;

        public MainPage(ILogFacade logger)
        {
            this.logger = logger;
            InitializeComponent();
        }

        public void LogMessageButtonClick(object sender, RoutedEventArgs e)
        {
            this.logger.Error(() => this.MessageTextBox.Text);
        }
    }
}
