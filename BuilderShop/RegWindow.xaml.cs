using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static BuilderShop.DBHelper;

namespace BuilderShop
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (checkData(tbLName.Text) && checkData(tbFName.Text) && checkData(tbPName.Text)
                && checkData(tbPhone.Text) && checkData(tbLogin.Text) && checkData(tbPassword.Text)
                && checkData(dpDOF.Text))
            {
                if (Convert.ToDateTime(dpDOF.Text) >= DateTime.Now)
                {
                    MessageBox.Show("Неправильная дата рожденияю", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    try
                    {
                        User patient = new User();
                        patient.LName = tbLName.Text;
                        patient.FName = tbFName.Text;
                        patient.PName = tbPName.Text;
                        patient.Phone = tbPhone.Text;
                        patient.Login = tbLogin.Text;
                        patient.Password = tbPassword.Text;
                        patient.DateOfBirth = Convert.ToDateTime(dpDOF.Text);
                        patient.IsAdmin = false;
                        Context.User.Add(patient);
                        Context.SaveChanges();
                        MessageBox.Show("Вы успешно");
                        MainWindow authWindow = new MainWindow();
                        authWindow.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool checkData(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(data))
            {
                return false;
            }
            return true;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow authWindow = new MainWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
