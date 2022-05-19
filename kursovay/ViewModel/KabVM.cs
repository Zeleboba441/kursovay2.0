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
    public class KabVM
    {
        public Kab EditKab { get; set; }
        public CommandVM SaveKabinet{ get; set; }

        private CurrentPageControl currentPageControl;
        public KabVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditKab = new Kab();
            InitCommand();
        }
        public KabVM(Kab editKab, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditKab = editKab;
            InitCommand();
        }

        private void InitCommand()
        {
            SaveKabinet = new CommandVM(() => {
                var model = SqlModel.GetInstance();
                if (EditKab.ID == 0)
                    model.Insert(EditKab);
                else
                    model.Update(EditKab);
                currentPageControl.Back();
            });
        }
    }
}
