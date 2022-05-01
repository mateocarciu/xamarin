using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XamarinApp.Database;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class VMRendezVous : INotifyPropertyChanged
    {
        private ObservableCollection<RendezVous> _lstRendezVous { get; set; }

        public ObservableCollection<RendezVous> lstRendezVous
        {
            get { return _lstRendezVous; }
            set
            {
                _lstRendezVous = value;
                OnPropertyChanged();
            }
        }


        public Command btnAddRendezVous { get; set; }

        private string _lblInfo { get; set; }
        public string lblInfo
        {
            get { return _lblInfo; }
            set
            {
                _lblInfo = value;
                OnPropertyChanged();
            }
        }

        public VMRendezVous()
        {
            lstRendezVous = new ObservableCollection<RendezVous>();

        }

        public void GetRendezVous()
        {
            try
            {
                RendezVousDatabase RendezVousDatabase = new RendezVousDatabase();
                var rdv = RendezVousDatabase.getRendezVous().Result;

                if (rdv != null && rdv.Count > 0)
                {
                    lstRendezVous = new ObservableCollection<RendezVous>();

                    foreach (var rd in rdv)
                    {
                        lstRendezVous.Add(new RendezVous
                        {
                            ID = rd.ID,
                            Name = rd.Name,
                            Commercial = rd.Commercial,
                            Date = rd.Date,
                            Heure = rd.Heure
                        });
                    }
                }
                else
                    lstRendezVous = new ObservableCollection<RendezVous>();
                lblInfo = "Total : " + rdv.Count.ToString();
            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
        }

        public void DeleteRendezVous(RendezVous rdv)
        {
            try
            {
                RendezVousDatabase RendezVousDatabase = new RendezVousDatabase();
                var result = RendezVousDatabase.DeleteRendezVous(rdv).Result;

                if (result == 1)
                    GetRendezVous();

                else
                    lstRendezVous = new ObservableCollection<RendezVous>();
            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}