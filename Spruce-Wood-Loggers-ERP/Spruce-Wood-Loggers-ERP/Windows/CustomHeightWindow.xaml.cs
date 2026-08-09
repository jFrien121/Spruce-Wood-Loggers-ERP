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
    /// Interaction logic for CustomHeightWindow.xaml
    /// </summary>
    public partial class CustomHeightWindow : Window
    {
        public CustomHeightWindow()
        {
            InitializeComponent();
        }

        private void PiecesTallClose_Button_Click(object sender, RoutedEventArgs e)
        {
            Owner.Opacity = 1;
            this.Close();
        }

        private void HeightButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var textBlock = button!.Content as TextBlock;

            int height = int.Parse(textBlock!.Text);

            CurrentBatch.setLiftHeight(height);
            this.Close();
        }
    }
}
