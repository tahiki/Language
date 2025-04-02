using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Language
{
    public partial class AddEditPage : Page
    {
        public Client CurrentClient { get; set; }
        public bool IsEditMode { get; private set; }
        public string WindowTitle => IsEditMode ? "Редактирование клиента" : "Добавление нового клиента";

        public bool IsMale
        {
            get => CurrentClient?.GenderCode == "1";
            set
            {
                if (value) 
                {
                    CurrentClient.GenderCode = "1";
                    CurrentClient.Gender = new Gender { Code = "1", Name = "Мужской" };
                }
            }
        }

        public bool IsFemale
        {
            get => CurrentClient?.GenderCode == "0";
            set
            {
                if (value) 
                {
                    CurrentClient.GenderCode = "0";
                    CurrentClient.Gender = new Gender { Code = "0", Name = "Женский" };
                }
            }
        }

        public ClientEditWindow(Client client = null)
        {
            InitializeComponent();
            
            CurrentClient = client ?? new Client 
            { 
                RegistrationDate = DateTime.Now,
                ClientService = new System.Collections.Generic.HashSet<ClientService>(),
                Tag = new System.Collections.Generic.HashSet<Tag>()
            };
            
            IsEditMode = client != null;
            DataContext = this;
        }

        private void SelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*",
                Title = "Выберите фотографию клиента"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                CurrentClient.PhotoPath = openFileDialog.FileName;
                var image = new Image();
                image.Source = new BitmapImage(new Uri(CurrentClient.PhotoPath));
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Простая валидация обязательных полей
            if (string.IsNullOrWhiteSpace(CurrentClient.LastName) || 
                string.IsNullOrWhiteSpace(CurrentClient.FirstName))
            {
                MessageBox.Show("Фамилия и имя обязательны для заполнения!", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}