using System.Windows;
using WpfHotel.ViewModels;

namespace WpfHotel.Views
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        public Manager()
        {
            InitializeComponent();
            this.DataContext = new ManagerViewModel(this);
        }

        public Manager(string userName)
        {
            InitializeComponent();
            this.DataContext = new ManagerViewModel(this, userName);
        }
    }
}
