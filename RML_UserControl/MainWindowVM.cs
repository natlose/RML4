using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RML_UserControl
{
    class MainWindowVM : ViewModelBase
    {
        private Person megrendelo;

        public Person Megrendelo
        {
            get { return megrendelo; }
            set
            {
                megrendelo = value;
                OnPropertyChanged();
            }
        }

        private Person vallalkozo;

        public Person Vallalkozo
        {
            get { return vallalkozo; }
            set
            {
                vallalkozo = value;
                OnPropertyChanged();
            }
        }

        public void LoadData()
        {
            using (MyData mydata = new MyData())
            {
                Megrendelo =  //ne a mögöttes megrendelo mezőbe írj, mert akkor nem fut le Megrendelo.set, nem lesz OnPropertyChanged()!
                (
                    from p in mydata.Persons
                    where p.FirstName == "Ferenc" && p.LastName == "Kis"
                    select p
                ).Single();
                Vallalkozo =
                (
                    from p in mydata.Persons
                    where p.FirstName == "Viktória" && p.LastName == "Debreceni"
                    select p
                ).Single();
            }
        }
    }
}
