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
    public class ViewPostavkiVM : BaseVM
    {

        
        private Vrach selectVrachView;
        private List<PostavkiWithData> selectPostavkiByVrach;

        public List<Vrach> Vrachs { get; set; }
        public Vrach SelectVrachView
        {
            get => selectVrachView;
            set
            {
                selectVrachView = value;
                SelectPostavkiByVrach = SqlModel.GetInstance().SelectPostavkiByVrach(selectVrachView);
                Signal();
            }
        }
        public List<PostavkiWithData> SelectPostavkiByVrach
        {
            get => selectPostavkiByVrach;
            set
            {
                selectPostavkiByVrach = value;
                Signal();
            }
        }
        public PostavkiWithData SelectPostavkiWithData { get; set; }

        public ViewPostavkiVM(Vrach selectVrachView)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Vrachs = sqlModel.VrachSelect(0, 100);
            SelectVrachView = Vrachs.FirstOrDefault(s => s.ID == selectVrachView?.ID);
        }
    }
   }
