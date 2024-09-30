using Canvas.MAUI.ViewModel;

namespace Canvas.MAUI
{
    public partial class FirstPage : ContentPage
    {
       

        public FirstPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void GoToLawyersPage(object sender, EventArgs e)
        {
            Navigation.PushAsync( new MainPage());

        }

        private void GoToClientsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());

        }
    }
}