using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RendezVousPage : ContentPage
    {
        VMRendezVous vm;
        public RendezVousPage()
        {
            InitializeComponent();
            vm = new VMRendezVous();
            this.BindingContext = vm;
        }


        protected override void OnAppearing()
        {
            if (vm != null)
                vm.GetRendezVous();

            base.OnAppearing();
        }

        private async void btnAddRendezVous_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRendezVous(null));
        }

        private async void lstRendezVous_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (lstRendezVous.SelectedItem != null)
                {
                    var rdv = (RendezVous)lstRendezVous.SelectedItem;
                    lstRendezVous.SelectedItem = null;
                    await Navigation.PushAsync(new AddRendezVous(rdv));
                }
            }
            catch (Exception)
            {

            }
        }

        private async void btnDeleteRendezVous_Clicked(object sender, EventArgs e)
        {
            try
            {

                string ID = (sender as Button).CommandParameter.ToString();
                if (!string.IsNullOrWhiteSpace(ID))
                {
                    var rdv = vm.lstRendezVous.Where(x => x.ID.ToString() == ID);
                    var result = await DisplayAlert("Confirmer ", "Voulez vous supprimer : " + rdv.FirstOrDefault().Name + "?", "Oui", "Non");
                    if (result)
                        vm.DeleteRendezVous(rdv.FirstOrDefault());

                }
            }
            catch (Exception)
            {

            }
        }
    }
}