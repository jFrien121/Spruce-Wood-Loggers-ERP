using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

/**
 * EntryConfirmation
 * 
 * Window that confirms the final details of a cut entry before saving
 * it to the database
 */

namespace Spruce_Wood_Loggers_ERP
{
    /// <summary>
    /// Interaction logic for EntryConfirmation.xaml
    /// </summary>
    public partial class EntryConfirmation : Window
    {
        private double width;
        private double thickness;
        private double length;
        private Grade grade;
        private int numPieces;

        public EntryConfirmation(double thickness, double width, double length)
        {
            InitializeComponent();

            this.width = width;
            this.thickness = thickness;
            this.length = length;
            this.grade = Grade.UNGRADED;
            this.numPieces = 240;

            SetEntryText();
        }

        private void SetEntryText()
        {
            Entry_Description.Text = this.thickness + "\" x " + this.width + "\" x " + this.length + "' x " + this.numPieces + " pieces ("
                + GradeToString() + ")";
        }

        private string GradeToString()
        {
            switch (this.grade)
            {
                case Grade.UNGRADED: return "Ungraded";
                case Grade.ONE: return "#1";
                case Grade.TWO: return "#2";
                case Grade.THREE: return "#3";
            }

            return "Ungraded";
        }

        // Prohibits non-numeric input for the number of pieces TextBox

        private static readonly Regex _regex = new("[^0-9]+");

        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }

        private void NumberOnly_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));

                if (_regex.IsMatch(text))
                    e.CancelCommand();
            }
            else
            {
                e.CancelCommand();
            }
        }

        // Cancel the entry
        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Owner.Opacity = 1;
            this.Close();
        }

        // Save the entry to the database
        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            Batch currBatch = new Batch(DateTime.Now, this.thickness, this.width, this.length, GradeToString(), this.numPieces);
            BatchPersistence.SaveBatch(currBatch);
            Owner.Opacity = 1;
            this.Close();
        }
    }
}
