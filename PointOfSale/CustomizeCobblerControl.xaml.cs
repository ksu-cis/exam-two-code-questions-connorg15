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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExamTwoCodeQuestions.Data;
namespace ExamTwoQuestions.PointOfSale
{
    /// <summary>
    /// Interaction logic for CustomizeCobblerControl.xaml
    /// </summary>
    public partial class CustomizeCobblerControl : UserControl
    {
        public CustomizeCobblerControl()
        {
            InitializeComponent();
        }

        void Radio_Load(object sender, RoutedEventArgs e)
        {
            if (DataContext is Cobbler cobbler)
            {
                switch (cobbler.Fruit)
                {
                    case FruitFilling.Blueberry:
                        BlueberryButton.IsChecked = true;
                        break;
                    case FruitFilling.Cherry:
                        CherryButton.IsChecked = true;
                        break;
                    case FruitFilling.Peach:
                        PeachButton.IsChecked = true;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        void Filling_Selection_Clicked(object sender, RoutedEventArgs e)
        {
            if(DataContext is Cobbler cobbler)
            {
                if(sender is RadioButton radioButton)
                {
                    switch (radioButton.Tag)
                    {
                        case "Blueerry":
                            cobbler.Fruit = FruitFilling.Blueberry;
                            break;
                        case "Cherry":
                            cobbler.Fruit = FruitFilling.Cherry;
                            break;
                        case "Peach":
                            cobbler.Fruit = FruitFilling.Peach;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }
        }
    }
}
