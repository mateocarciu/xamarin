using Xamarin.Forms;
using XamarinApp.Views;

namespace XamarinApp
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage(new RendezVousPage());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}