using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Desktop01
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedUser = null;

        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void message()
        {
            MessageBox.Show($"{selectedUser.FirstName} The GPA value must be between 0 and 4", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} Is Successfuly Deleted !!!", "DELETED \a ");
            }

            else
            {
                MessageBox.Show("Plese Select The Student You Want To Delete", "Error");
            }

        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserVM(selectedUser);
                vm.title = "EDIT USER";
                var window = new AddUserWindow(vm);
                window.ShowDialog();
                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);
            }

            else
            {
                MessageBox.Show("Please Select The Student You Want To Edit !!!", "Warning!");
            }
        }

        public MainWindowVM()
        {
            users = new ObservableCollection<User>();

            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            users.Add(new User("Alexander", "Johnson", "Male", "01/02/1999", "MME", 3.18, image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.ppg", UriKind.Relative));
            users.Add(new User("Aiden", "Taylor", "Male", "07/03/2000", "MME", 3.45, image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new User("Ava", "Edwards", "Male", "15/03/2001", "CEE", 3.49, image3));
            BitmapImage image4 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User("Emily", "Anderson", "Female", "08/07/1999", "EIE", 3.46, image4));
            BitmapImage image5 = new BitmapImage(new Uri("/Model/Images/5.png", UriKind.Relative));
            users.Add(new User("Daniel", "Perez", "Male", "11/01/2001", "CE", 2.92, image5));

            BitmapImage image6 = new BitmapImage(new Uri("/Model/Images/6.png", UriKind.Relative));
            users.Add(new User("Ethan", "Davis", "Male", "22/12/1998", "CE", 3.88, image1));
            BitmapImage image7 = new BitmapImage(new Uri("/Model/Images/7.png", UriKind.Relative));
            users.Add(new User("Jackson", "Roberts", "Male", "27/03/2001", "CEE", 3.57, image2));
            BitmapImage image8 = new BitmapImage(new Uri("/Model/Images/8.png", UriKind.Relative));
            users.Add(new User("Joshua", "Baker", "Male", "21/06/1999", "MME", 3.09, image3));
            BitmapImage image9 = new BitmapImage(new Uri("/Model/Images/9.png", UriKind.Relative));
            users.Add(new User("Olivia", "Carter", "Feale", "28/02/2000", "EIE", 3.34, image4));
            BitmapImage image10 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new User("Matthew", "Miller", "Male", "12/01/2000", "CE", 3.12, image5));

        }
    }
}
