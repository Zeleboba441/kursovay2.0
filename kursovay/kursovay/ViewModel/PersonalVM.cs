using kursovay.DTO;
using kursovay.Model;
using kursovay.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovay.ViewModel
{

    public class PersonalVM
    {
        public Personal EditPersonal { get; set; }
        public CommandVM SavePersonal { get; set; }
        public CommandVM MainMenu { get; set; }

        private CurrentPageControl currentPageControl;
        public PersonalVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditPersonal = new Personal();
            InitCommand();
        }
        public PersonalVM(Personal editPersonal, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditPersonal = editPersonal;
            InitCommand();
        }

        private void InitCommand()
        {
            SavePersonal = new CommandVM(() =>
            {
                var model = SqlModel.GetInstance();
                if (EditPersonal.ID == 0)
                    model.Insert(EditPersonal);

            });
            MainMenu = new CommandVM(() =>
            {

                currentPageControl.Back();
            });

        }
    }
}
