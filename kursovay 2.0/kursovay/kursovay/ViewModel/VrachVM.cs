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

    public class VrachVM
    {
        public Vrach EditVrach { get; set; }
        public CommandVM SaveVrach { get; set; }

        private CurrentPageControl currentPageControl;
        public VrachVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditVrach = new Vrach();
            InitCommand();
        }
        public VrachVM(Vrach editVrach, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditVrach = editVrach;
            InitCommand();
        }

        private void InitCommand()
        {
            SaveVrach = new CommandVM(() => {
                var model = SqlModel.GetInstance();
                if (EditVrach.ID == 0)
                    model.Insert(EditVrach);
                else
                    model.Update(EditVrach);
                currentPageControl.Back();
            });
        }
    }
}
    

   
 



