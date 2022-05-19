using kursovay.DTO;
using kursovay.Model;
using kursovay.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovay.ViewModel
{
    public class PostavshikVM
  
    {
        public Postavshik EditPostavshik { get; set; }
        public CommandVM SavePostavshik { get; set; }
        public CommandVM MainMenu { get; set; }

        private CurrentPageControl currentPageControl;
        public PostavshikVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditPostavshik = new Postavshik();
            InitCommand();
        }
        public PostavshikVM(Postavshik editPostavshik, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditPostavshik = editPostavshik;
            InitCommand();
        }

        private void InitCommand()
        {
            SavePostavshik = new CommandVM(() =>
            {
                var model = SqlModel.GetInstance();
                if (EditPostavshik.ID == 0)
                    model.Insert(EditPostavshik);

            });
            MainMenu = new CommandVM(() =>
            {

                currentPageControl.Back();
            });

        }
    }
}
