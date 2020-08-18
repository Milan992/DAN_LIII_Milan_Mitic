using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using WpfHotel.Views;

namespace WpfHotel.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {

        Service service = new Service();
        MainWindow main;

        #region Constructors

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
        }

        #endregion

        #region Properties

        private string userName;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        #endregion

        #region Commands

        private ICommand logIn;

        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(param => LogInExecute(), param => CanLogInExecute());
                }

                return logIn;
            }
        }

        private void LogInExecute()
        {
            try
            {
                if (service.IsOwner(UserName, Password))
                {
                    Owner owner = new Owner();
                    owner.ShowDialog();
                }
                else if (service.IsEmployee(UserName, Password))
                {
                    Employee employee = new Employee(UserName);
                    employee.ShowDialog();
                }
                else if (service.IsManager(UserName, Password))
                {
                    Manager manager = new Manager(UserName);
                    manager.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username or password incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogInExecute()
        {
            return true;
        }

        #endregion
    }
}
