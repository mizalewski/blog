using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace RadDataFormExtending
{
    /// <summary>
    /// Extended data form date field.
    /// </summary>
    public class ExtendedDataFormDateField : DataFormDateField
    {
        public static readonly DependencyProperty InputModeProperty =
            DependencyProperty.Register("InputMode", typeof(InputMode), typeof(ExtendedDataFormDateField), null);

        /// <summary>
        /// Gets or sets the input mode.
        /// </summary>
        /// <value>The input mode.</value>
        public InputMode InputMode
        {
            get { return (InputMode)GetValue(InputModeProperty); }
            set { SetValue(InputModeProperty, value); }
        }

        /// <summary>
        /// Returns a control to display and edit the underlying data.
        /// </summary>
        /// <returns></returns>
        protected override Control GetControl()
        {
            RadDatePicker control = (RadDatePicker)base.GetControl();
            control.SetBinding(RadDatePicker.InputModeProperty, new Binding("InputMode") { Source = this });

            return control;
        }
    }
}
