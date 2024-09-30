using Canvas.MAUI.ViewModel;

namespace Canvas.MAUI
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void GoToClientsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync( new ClientPage());

        }

        private void GoToProjectsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProjectPage());

        }
    }
}