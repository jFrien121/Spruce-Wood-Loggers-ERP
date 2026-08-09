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
        public CustomWidthWindow()
        {
            InitializeComponent();
        }

        private void PiecesWideClose_Button_Click(object sender, RoutedEventArgs e)
        {
            Owner.Opacity = 1;
            this.Close();
        }

        private void WidthButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var textBlock = button!.Content as TextBlock;

            int liftWidth = int.Parse(textBlock!.Text);

            CurrentBatch.setLiftWidth(liftWidth);
            this.Close();
        }
    }
}
