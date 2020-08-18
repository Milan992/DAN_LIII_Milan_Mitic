using System.Windows;
using WpfHotel.ViewModels;

namespace WpfHotel.Views
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
            this.DataContext = new AddEmployeeViewModel(this);
        }
    }
}
