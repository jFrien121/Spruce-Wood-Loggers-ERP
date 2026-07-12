using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace Spruce_Wood_Loggers_ERP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Spruce_Wood_Loggers_Cut_Tracker : Window
    {

        static List<double> widths = [3, 4, 6, 8, 10];
        static List<double> thicknesses = [1, 2, 3, 4];
        static List<double> lengths = [4, 4.5, 6, 7, 8, 9, 10, 12, 14, 16];

        public Spruce_Wood_Loggers_Cut_Tracker()
        {
            InitializeComponent();

            initGrid();
        }

        public void initGrid()
        {
            int numColumns = widths.Count * thicknesses.Count();

            for (int i = 0; i < numColumns; i++)
            {
                ColumnDefinition newCol = new ColumnDefinition();
                //newCol.Width = GridLength.;
                MainGrid.ColumnDefinitions.Add(newCol);

                double widthIndex = i / thicknesses.Count();

                // Set up each column header
                TextBlock header = new TextBlock
                {
                    Text = $"{widths[(int)Math.Floor(widthIndex)]}\" x {thicknesses[i % thicknesses.Count]}\"",
                    FontSize = 10,
                    TextAlignment = TextAlignment.Center,
                    Foreground = Brushes.White
                };

                header.Margin = new Thickness(0, 5, 0, 2);

                Grid.SetRow(header, 0);
                Grid.SetColumn(header, i + 1);

                MainGrid.Children.Add(header);
            }

            for (int i = 0; i < lengths.Count; i++)
            {
                RowDefinition newRow = new RowDefinition();
                //newRow.Height = GridLength.Auto;
                MainGrid.RowDefinitions.Add(newRow);

                // Set up each column header
                TextBlock header = new TextBlock
                {
                    Text = $"{lengths[i]}'",
                    FontSize = 10,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextAlignment = TextAlignment.Right,
                    Foreground = Brushes.White
                };

                header.Margin = new Thickness(4, 0, 3, 0);

                Grid.SetRow(header, i + 1);
                Grid.SetColumn(header, 0);

                MainGrid.Children.Add(header);
            }

            // Initialize grid of buttons
            for (int i = 0; i < lengths.Count; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    // Set button settings
                    var button = new System.Windows.Controls.Button
                    {
                        Margin = new Thickness(3),
                        IsEnabled = true, // This will be replaced by the binding below
                        Padding = new Thickness(2),
                        ToolTip = "MaterialDesignRaisedLightButton with Round Corners"
                    };

                    // Set in place in grid
                    Grid.SetRow(button, i + 1);
                    Grid.SetColumn(button, j + 1);

                    double widthIndex = j / thicknesses.Count();

                    // Set style
                    MaterialDesignThemes.Wpf.ButtonAssist.SetCornerRadius(button, new CornerRadius(5));

                    if (widthIndex % 2 == 0)
                    {
                        button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedLightButton");
                    }
                    else
                    {
                        button.Style = (Style)Application.Current.FindResource("MaterialDesignRaisedButton");
                    }

                    // The following code essentialy means that the isEnabled property
                    // looks to be set by the Window, not individually
                    // TODO: Decide if this is something we actually want/ if it is important
                    //button.SetBinding(
                    //    UIElement.IsEnabledProperty,
                    //    new Binding("DataContext.ControlsEnabled")
                    //    {
                    //        RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor)
                    //        {
                    //            AncestorType = typeof(Window)
                    //        }
                    //    });
                    
                    int thicknessIndex = j % thicknesses.Count;

                    // Set up text
                    button.Content = new TextBlock
                    {

                        Text = $"{widths[(int)Math.Floor(widthIndex)]}\" x {thicknesses[thicknessIndex]}\"\n x {lengths[i]}'",
                        FontSize = 8,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Center
                        
                    };

                    MainGrid.Children.Add(button);

                }
            }
        }
    }
}