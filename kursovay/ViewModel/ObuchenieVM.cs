using kursovay.DTO;
using kursovay.Model;
using kursovay.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kursovay.ViewModel
{
   public class ObuchenieVM : BaseVM
    {
        public Obuchenie EditObuchenie { get; }
        public CommandVM SaveObuchenie { get; set; }

        public List<ObucheniePer> SelectPostavkiByVrach { get; set; }

        private Vrach selectVrachView;
        public Vrach SelectVrachView
        {
            get => selectVrachView;
            set
            {
                selectVrachView = value;
                SelectPostavkiByVrach = SqlModel.GetInstance().SelectPersonalByVrach(selectVrachView);
                Signal();
            }
        }

        public Vrach SelectVrachs
        {
            get => selectVrachs;
            set
            {
                selectVrachs = value;
                Signal();
            }
        }

        public Personal SelectPersonals
        {
            get => selectPersonals;
            set
            {
                selectPersonals = value;
                Signal();
            }
        }
        

        public List<Vrach> Vrachs { get; set; }
        public List<Personal> Personals { get; set; }
        
        public CommandVM MainMenu { get; set; }
        public CommandVM ObuchenieVis { get; set; }

        private CurrentPageControl currentPageControl;
        private Vrach selectVrachs;
        private Personal selectPersonals;

        public ObuchenieVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditObuchenie = new Obuchenie { ID = -1 };
            Init();
        }

        public ObuchenieVM(Obuchenie editObuchenie, CurrentPageControl currentPageControl)
        {
            EditObuchenie = editObuchenie;
            this.currentPageControl = currentPageControl;
            Init();
            SelectVrachs = Vrachs.FirstOrDefault(s => s.ID == editObuchenie.VrachID);
            SelectPersonals = Personals.FirstOrDefault(s => s.ID == editObuchenie.PersonalID);
            
        }

        private void Init()
        {
            Personals = SqlModel.GetInstance().PersonalSelect(0, 100);
            Vrachs = SqlModel.GetInstance().VrachSelect(0, 100);
            SaveObuchenie = new CommandVM(() => {
                if (SelectVrachs == null || SelectPersonals == null)
                {
                    MessageBox.Show("Не всё");
                    return;
                }
                EditObuchenie.VrachID = SelectVrachs.ID;
                EditObuchenie.PersonalID = SelectPersonals.ID;
                
                var model = SqlModel.GetInstance();
                if (EditObuchenie.ID == -1)
                    model.Insert(EditObuchenie);
                else
                    model.Update(EditObuchenie);


            });
            MainMenu = new CommandVM(() =>
            {
                currentPageControl.Back();
            });

            ObuchenieVis = new CommandVM(() =>
            {
                currentPageControl.Back();
            });

        }
    }
}

