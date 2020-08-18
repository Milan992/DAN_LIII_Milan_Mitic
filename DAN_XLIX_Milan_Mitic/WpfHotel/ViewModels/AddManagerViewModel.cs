using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfHotel.Model;
using WpfHotel.Views;

namespace WpfHotel.ViewModels
{
    class AddManagerViewModel : ViewModelBase
    {
        AddManager addManager;
        Service service = new Service();

        #region Constructors

        public AddManagerViewModel(AddManager addManagerOpen)
        {
            manager = new tblManager();
            account = new tblAccount();
            addManager = addManagerOpen;
            qualificationsList = service.FillQualificationsList();
        }

        #endregion

        #region Properties

        private tblAccount account;

        public tblAccount Account
        {
            get
            {
                return account;
            }
            set
            {
                account = value;
                OnPropertyChanged("Account");
            }
        }

        private string dateOfBirth;

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }


        private tblManager manager;

        public tblManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private List<string> qualificationsList;

        public List<string> QualificationsList
        {
            get
            {
                return qualificationsList;
            }
            set
            {
                qualificationsList = value;
                OnPropertyChanged("QualificationsList");
            }
        }

        #endregion

        #region Commands

        private ICommand save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }

                return save;
            }
        }

        private void SaveExecute()
        {
            try
            {
                service.AddManager(Manager, Account, DateOfBirth);
                MessageBox.Show("Manager saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (Account.FullName != null && Account.DateOfBirth != null && Account.Email != null && Account.UserName != null && Account.Pass != null
                 && Manager.HotelFloor != null && Manager.Experience != null && Manager.QualificationsLevel != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private ICommand close;

        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }

                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                addManager.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
