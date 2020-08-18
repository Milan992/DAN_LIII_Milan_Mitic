using System.Windows;
using WpfHotel.ViewModels;

namespace WpfHotel.Views
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        public Employee()
        {
            InitializeComponent();
            this.DataContext = new EmployeeViewModel(this);
        }

        public Employee(string userName)
        {
            InitializeComponent();
            this.DataContext = new EmployeeViewModel(this, userName);
        }
    }
}
