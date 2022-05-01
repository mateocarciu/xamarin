using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRendezVous : ContentPage
    {
        public AddRendezVous(RendezVous rdv)
        {
            try
            {
                InitializeComponent();
                VMAddRendezVous vm = new VMAddRendezVous(rdv);
                this.BindingContext = vm;
            }
            catch (Exception)
            {

            }

        }
    }
}