using kursovay.Pages;
using kursovay.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace kursovay.ViewModel
{
    public class MainVM : BaseVM
    {
        CurrentPageControl currentPageControl;

        public Page CurrentPage
        {
            get => currentPageControl.Page;
        }

        public CommandVM Connection { get; set; }
        
        public CommandVM Vrach { get; set; }

        public CommandVM Personal { get; set; }

        public CommandVM Postavshik { get; set; }




        public Visibility CreateVrachVis
        {
            get => CurrentPage == null ? Visibility.Visible : Visibility.Collapsed;
        }
        public Visibility CreatePersonalVis
        {
            get => CurrentPage == null ? Visibility.Visible : Visibility.Collapsed;
        }
        public Visibility CreatePostavshikVis
        {
            get => CurrentPage == null ? Visibility.Visible : Visibility.Collapsed;
        }


        public MainVM()
        {
            currentPageControl = new CurrentPageControl();
            currentPageControl.PageChanged += CurrentPageControl_PageChanged;

            Connection = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ConnectionPage());
            });

       
            Vrach = new CommandVM(() =>
            {
                currentPageControl.SetPage(new VrachPage(new VrachVM(currentPageControl)));
                Signal(nameof(CreateVrachVis));
            });

            Personal = new CommandVM(() =>
            {
                currentPageControl.SetPage(new PersonalPage(new PersonalVM(currentPageControl)));
                Signal(nameof(CreatePersonalVis));
            });

            Postavshik = new CommandVM(() =>
            {
                currentPageControl.SetPage(new PostavshikPage(new PostavshikVM(currentPageControl)));
                Signal(nameof(CreatePostavshikVis));
            });
        }


        private void CurrentPageControl_PageChanged(object sender, EventArgs e)
        {
            Signal(nameof(CurrentPage));
            Signal(nameof(CreateVrachVis));
            Signal(nameof(CreatePersonalVis));
            Signal(nameof(CreatePostavshikVis));

        }

    }
}
