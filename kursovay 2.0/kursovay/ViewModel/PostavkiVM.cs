using kursovay.DTO;
using kursovay.Model;
using kursovay.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kursovay.ViewModel
{
    public class PostavkiVM : BaseVM
    {
        public Postavki EditPostavki { get; }
        public CommandVM SavePostavki { get; set; }

        public List<PostavkiWithData> SelectReagentsByPostavshiks { get; set; }

        private Vrach selectVrachView;
        public Vrach SelectVrachView
        {
            get => selectVrachView;
            set
            {
                selectVrachView = value;
                SelectReagentsByPostavshiks = SqlModel.GetInstance().SelectPostavkiByVrach(selectVrachView);
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

        public Reagent SelectReagents
        {
            get => selectReagents;
            set
            {
                selectReagents = value;
                Signal();
            }
        }
        public Postavshik SelectPostavshiks
        {
            get => selectPostavshiks;
            set
            {
                selectPostavshiks = value;
                Signal();
            }
        }

        public List<Vrach> Vrachs { get; set; }
        public List<Postavshik> Postavshiks { get; set; }
        public List<Reagent> Reagents { get; set; }
        public CommandVM MainMenu { get; set; }
        public CommandVM PostavkiVis { get; set; }

        private CurrentPageControl currentPageControl;
        private Vrach selectVrachs;
        private Postavshik selectPostavshiks;
        private Reagent selectReagents;

        public PostavkiVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditPostavki = new Postavki {  ID  = -1};
            Init();
        }

        public PostavkiVM(Postavki editPostavki, CurrentPageControl currentPageControl)
        {
            EditPostavki = editPostavki;
            this.currentPageControl = currentPageControl;
            Init();
            SelectVrachs = Vrachs.FirstOrDefault(s => s.ID == editPostavki.VrachID);
            SelectPostavshiks = Postavshiks.FirstOrDefault(s => s.ID == editPostavki.PostavshikID);
            SelectReagents = Reagents.FirstOrDefault(s => s.ID == editPostavki.ReagentID);
        }

        private void Init()
        {
            Reagents = SqlModel.GetInstance().ReagentSelect(0, 100);
            Vrachs = SqlModel.GetInstance().VrachSelect(0, 100);
            Postavshiks = SqlModel.GetInstance().PostavshickSelect(0, 100);
            SavePostavki = new CommandVM(() => {
                if (SelectVrachs == null || SelectPostavshiks == null || SelectReagents == null)
                {
                    MessageBox.Show("Не всё");
                    return;
                }
                EditPostavki.VrachID = SelectVrachs.ID;
                EditPostavki.PostavshikID = SelectPostavshiks.ID;
                EditPostavki.ReagentID = SelectReagents.ID;
                var model = SqlModel.GetInstance();
                if (EditPostavki.ID == -1)
                    model.Insert(EditPostavki);
                else
                    model.Update(EditPostavki);

                
            });
            MainMenu = new CommandVM(() =>
            {
                currentPageControl.Back();
            });

            PostavkiVis = new CommandVM(() =>
            {
                currentPageControl.Back();
            });

        }
    }
}
