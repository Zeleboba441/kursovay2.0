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
    public class ViewObuchenieVM : BaseVM
    {
                
            private Vrach SelectedVrachs;
            private Vrach selectVrachView;
            private List<ObucheniePer> selectPersonalByVrach;



            public List<Vrach> Vrachs { get; set; }
            public Vrach SelectVrachView
            {
                get => selectVrachView;
                set
                {
                    selectVrachView = value;
                    SelectPersonalByVrach = SqlModel.GetInstance().SelectPersonalByVrach(selectVrachView);
                    Signal();
                }
            }
            public List<ObucheniePer> SelectPersonalByVrach
        {
                get => selectPersonalByVrach;
                set
                {
                selectPersonalByVrach = value;
                    Signal();
                }
            }
            public PostavkiWithData SelectPostavkiWithData { get; set; }
            public CurrentPageControl CurrentPageControl { get; }

            public ViewObuchenieVM(CurrentPageControl currentPageControl)
            {
                CurrentPageControl = currentPageControl;
                SqlModel sqlModel = SqlModel.GetInstance();
                Vrachs = sqlModel.VrachSelect(0, 100);
            }

        }
    }
