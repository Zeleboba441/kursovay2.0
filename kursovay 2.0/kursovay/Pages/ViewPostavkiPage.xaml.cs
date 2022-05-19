﻿using kursovay.DTO;
using kursovay.Tools;
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
    /// Interaction logic for ViewPostavkiPage.xaml
    /// </summary>
    public partial class ViewPostavkiPage : Page
    {

        
            public ViewPostavkiPage(Vrach selectVrachView)
            {
                InitializeComponent();
                DataContext = new ViewPostavkiVM(selectVrachView );
            }


        
    }
}
