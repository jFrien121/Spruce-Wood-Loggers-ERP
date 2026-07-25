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
    /// Interaction logic for PieceSelectionWindow.xaml
    /// </summary>
    public partial class PieceSelectionWindow : Window
    {
        private double width;
        private double thickness;

        public PieceSelectionWindow(double thickness, double width)
        {
            this.width = width;
            this.thickness = thickness;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Owner.Opacity = 1;
            this.Close();
        }

        private void NumberPiecesClose_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
