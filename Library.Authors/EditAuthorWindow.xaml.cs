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
using Library.Models;

namespace Library.Authors
{
    /// <summary>
    /// Lógica de interacción para EditAuthorWindow.xaml
    /// </summary>
    public partial class EditAuthorWindow : Window
    {       
            public Author Author { get; set; }

            public EditAuthorWindow(Author author)
            {
                InitializeComponent();
                Author = author;
                DataContext = Author;
                FirstNameTextBox.Focus();
                FirstNameTextBox.SelectAll();
            }

            private void SaveButton_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = true;
            }

            private void CancelButton_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = true;
            }
        
    }
}
