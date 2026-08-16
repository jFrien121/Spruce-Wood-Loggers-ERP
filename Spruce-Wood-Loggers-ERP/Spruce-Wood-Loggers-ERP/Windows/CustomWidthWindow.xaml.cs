using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Spruce_Wood_Loggers_ERP
{
    /// <summary>
    /// Interaction logic for CustomWidthWindow.xaml
    /// </summary>
    public partial class CustomWidthWindow : Window
    {
        private int selectedWidth;

        public CustomWidthWindow()
        {
            InitializeComponent();
        }

        private void PiecesWideClose_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void WidthButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var textBlock = button!.Content as TextBlock;

            this.selectedWidth = int.Parse(textBlock!.Text);
            this.DialogResult = true;
            this.Close();
        }

        public int getSelectedWidth()
        {
            return selectedWidth;
        }
    }
}
