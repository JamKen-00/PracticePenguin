using Canvas.MAUI.ViewModel;
using Library.Database;
using Library.Models;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;
using Microsoft.Maui.Controls;

namespace Canvas.MAUI
{
    public partial class ClientPage : ContentPage
    {
        private Client selectedClient;
        private bool isListVisible = false;
        public ClientPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        //finally got it to show the changes :))))
        private async Task RefreshPage()
        {
            var currentPage = Application.Current.MainPage;
            await currentPage.Navigation.PopAsync();
            await currentPage.Navigation.PushAsync(new ClientPage());
        }

        private void listButtonClicked(object sender, EventArgs e)
        {
            isListVisible = !isListVisible;
            SidePanel.IsVisible = isListVisible;
        }

        //Handles selecting and showing client info
        private void ClientSelected(object sender, ItemTappedEventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)BindingContext;
            if (e.Item == null){
                return;
            }
            if (e.Item is Client client)
            {
                selectedClient = client;
                //Show the Info
                ClientIdLabel.Text = selectedClient.Id.ToString();
                ClientNameLabel.Text = selectedClient.Name;
                ClientNotesLabel.Text = selectedClient.Notes;
                ClientEmployeeLabel.Text = "Employee: " + viewModel.Employees[0].Name + ", Rate: " + viewModel.Employees[0].Rate;
            }
            //Deselect
            ((ListView)sender).SelectedItem = null;
        }

        //Handles deleting a client
        private void DeleteClientSelected(object sender, EventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)BindingContext;

            //Get the selected client
            if (selectedClient != null)
            {
                //Delete the selected client 
                viewModel.DeleteClient(selectedClient);
                selectedClient = null;
                ClientIdLabel.Text = string.Empty;
                ClientNameLabel.Text = string.Empty;
                ClientNotesLabel.Text = string.Empty;
                RefreshPage();
            }
        }
        //Handles updating a clients info
        private void UpdateClientSelected(object sender, EventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)BindingContext;
            if (selectedClient != null)
            {
                selectedClient.Id = int.Parse(ClientIdLabel.Text);
                selectedClient.Name = ClientNameLabel.Text;
                selectedClient.Notes = ClientNotesLabel.Text;

                viewModel.UpdateClient(selectedClient.Id, selectedClient.Name, selectedClient.Notes);
                RefreshPage();

            }
        }

        //Handles creating a client
        private Entry newID;
        private Entry newName;
        private Entry newNotes;
        private int holderID;

        private void ClientCreator(object sender, EventArgs e)
        {
            newID = new Entry
            {
                Placeholder = "Enter ID...",
                HeightRequest = -40,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            newName = new Entry
            {
                Placeholder = "Enter Name...",
                HeightRequest = -40,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            newNotes = new Entry
            {
                Placeholder = "Enter Notes...",
                HeightRequest = -40,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            Button addClient = new Button
            {
                Text = "Click to add Client",
                HeightRequest = 40,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 16,
            };
            addClient.Clicked += AddTheClient;
            MainBox.Children.Add(newID);
            MainBox.Children.Add(newName);
            MainBox.Children.Add(newNotes);
            MainBox.Children.Add(addClient);

            Label clientIdLabel = new Label();
            Label clientNameLabel = new Label();
            Label clientNotesLabel = new Label();

            MainBox.Children.Add(clientIdLabel);
            MainBox.Children.Add(clientNameLabel);
            MainBox.Children.Add(clientNotesLabel);
        }

        private void AddTheClient(object sender, EventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)BindingContext;

            int id = int.Parse(newID.Text);
            string name = newName.Text;
            string notes = newNotes.Text;

            viewModel.AddClient(id, name, notes);
            RefreshPage();

        }

    }
}