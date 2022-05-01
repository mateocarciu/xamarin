using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XamarinApp.Database;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class VMAddRendezVous : INotifyPropertyChanged
    {
        private RendezVous _rendezVous { get; set; }

        public RendezVous rdv
        {
            get { return _rendezVous; }
            set
            {
                _rendezVous = value;
                OnPropertyChanged();
            }
        }

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

        private string _btnSaveLabel { get; set; }
        public string btnSaveLabel
        {
            get { return _btnSaveLabel; }
            set
            {
                _btnSaveLabel = value;
                OnPropertyChanged();
            }
        }

        public Command btnSaveRendezVous { get; set; }
        public Command btnClearRendezVous { get; set; }
        public VMAddRendezVous(RendezVous obj)
        {
            if (obj == null || obj.ID == 0)
                ClearRendezVous();

            else
            {
                rdv = obj;
                btnSaveLabel = "MODIFIER";
            }
            btnSaveRendezVous = new Command(SaveRendezVous);
            btnClearRendezVous = new Command(ClearRendezVous);
        }

        public void SaveRendezVous()
        {
            try
            {
                RendezVousDatabase RendezVousDatabase = new RendezVousDatabase();
                int i = RendezVousDatabase.SaveRendezVous(rdv).Result;

                if (i == 1)
                {

                    if (btnSaveLabel.Equals("AJOUTER"))
                    {
                        ClearRendezVous();
                        lblInfo = "Le rdv à bien été ajouté";
                    }
                    else
                    {
                        ClearRendezVous();
                        lblInfo = "Votre rdv à bien été modifié";
                    }
                }
                else
                    lblInfo = "Ajout impossible";
            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
        }

        public void ClearRendezVous()
        {
            rdv = new RendezVous();
            rdv.ID = rdv.ID;
            rdv.Name = rdv.Name;
            rdv.Commercial = rdv.Commercial;
            rdv.Date = rdv.Date;
            rdv.Heure = rdv.Heure;
            lblInfo = "";
            btnSaveLabel = "AJOUTER";
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