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
    public class ReagentVM
    {
        public Reagent EditReagent { get; set; }
        public CommandVM SaveReagent { get; set; }
        public CommandVM MainMenu { get; set; }

        private CurrentPageControl currentPageControl;
        public ReagentVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditReagent = new Reagent();
            InitCommand();
        }
        public ReagentVM(Reagent editReagent, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditReagent = editReagent;
            InitCommand();
        }

        private void InitCommand()
        {
            SaveReagent = new CommandVM(() =>
            {
                var model = SqlModel.GetInstance();
                if (EditReagent.ID == 0)
                    model.Insert(EditReagent);

            });
            MainMenu = new CommandVM(() =>
            {

                currentPageControl.Back();
            }); 
            
        }
    }
}
