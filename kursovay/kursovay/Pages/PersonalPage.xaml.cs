using kursovay.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kursovay.Pages
{
    /// <summary>
    /// Логика взаимодействия для VrachPage.xaml
    /// </summary>
    public partial class PersonalPage : Page
    {

        public PersonalPage(PersonalVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }


    }
}

