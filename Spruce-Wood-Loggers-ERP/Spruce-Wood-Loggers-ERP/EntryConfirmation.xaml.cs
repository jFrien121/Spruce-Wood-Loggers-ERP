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

        public EntryConfirmation()
        {
            InitializeComponent();
            CurrentBatch.setGrade(Grade.UNGRADED);
            SetEntryText();
        }

        private void SetEntryText()
        {
            Entry_Description.Text = CurrentBatch.getThickness() + "\" x " + CurrentBatch.getWidth() + "\" x " 
                + CurrentBatch.getLength() + "' x " + CurrentBatch.getNumPieces() + " pieces ("
                + CurrentBatch.getGrade() + ")";
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
            Batch currBatch = new Batch(DateTime.Now, CurrentBatch.getThickness(), 
                CurrentBatch.getWidth(), CurrentBatch.getLength(), CurrentBatch.getGrade(), CurrentBatch.getNumPieces());
            BatchPersistence.SaveBatch(currBatch);
            this.Close();
        }

        private void Ungraded_Button_Click(object sender, RoutedEventArgs e)
        {
            Ungraded_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedSecondaryButton");
            Grade1_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
            Grade2_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
            Grade3_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
            CurrentBatch.setGrade(Grade.UNGRADED);
            SetEntryText();
        }

        private void Grade1_Button_Click(object sender, RoutedEventArgs e)
        {
            Grade1_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedSecondaryButton");
            Ungraded_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
            Grade2_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
            Grade3_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
            CurrentBatch.setGrade(Grade.ONE);
            SetEntryText();
        }

        private void Grade2_Button_Click(object sender, RoutedEventArgs e)
        {
            Grade2_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedSecondaryButton");
            Ungraded_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
            Grade1_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
            Grade3_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
            CurrentBatch.setGrade(Grade.TWO);
            SetEntryText();
        }

        private void Grade3_Button_Click(object sender, RoutedEventArgs e)
        {
            Grade3_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedSecondaryButton");
            Ungraded_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
            Grade1_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
            Grade2_Button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
            CurrentBatch.setGrade(Grade.THREE);
            SetEntryText();
        }
    }
}
