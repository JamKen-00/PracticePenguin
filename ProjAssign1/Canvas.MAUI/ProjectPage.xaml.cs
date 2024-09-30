using Canvas.MAUI.ViewModel;
using Library.Database;
using Library.Models;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;
using Microsoft.Maui.Controls;

namespace Canvas.MAUI
{
    public partial class ProjectPage : ContentPage
    {
        private Project selectedProject;
        private bool isListVisible = false;
        public static double standardRate = 10;
        public static double standardHours = 8;
        double holder = standardRate * standardHours;
        public ProjectPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        //finally got it to show the changes :))))
        private async Task RefreshPage()
        {
            var currentPage = Application.Current.MainPage;
            await currentPage.Navigation.PopAsync();
            await currentPage.Navigation.PushAsync(new ProjectPage());
        }

        private void listButtonClicked(object sender, EventArgs e)
        {
            isListVisible = !isListVisible;
            SidePanel.IsVisible = isListVisible;
        }

        //Handles selecting and showing project info
        private void ProjectSelected(object sender, ItemTappedEventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)BindingContext;
            if (e.Item == null){
                return;
            }
            if (e.Item is Project project)
            {
                selectedProject= project;
                //Show the Info
                ProjectIdLabel.Text = selectedProject.Id.ToString();
                ProjectShortNameLabel.Text = selectedProject.ShortName;
                ProjectLongNameLabel.Text = selectedProject.LongName;
                ProjectOpenDateLabel.Text = selectedProject.OpenDATE.ToString();
                ProjectEmployeeLabel.Text = "Employee: " + viewModel.Employees[0].Name + ", Rate: " + standardRate + ", Hours: " + standardHours;
                ProjectBillLabel.Text = "Rate: " + holder.ToString();
            }
            //Deselect
            ((ListView)sender).SelectedItem = null;
        }

        //Handles deleting a project
        private void DeleteProjectSelected(object sender, EventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)BindingContext;

            //Get the selected project
            if (selectedProject != null)
            {
                //Delete the selected project 
                viewModel.DeleteProject(selectedProject);
                selectedProject = null;
                ProjectIdLabel.Text = string.Empty;
                ProjectShortNameLabel.Text = string.Empty;
                ProjectLongNameLabel.Text = string.Empty;
                RefreshPage();
            }
        }
        //Handles updating a projects info
        private void UpdateProjectSelected(object sender, EventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)BindingContext;
            if (selectedProject != null)
            {
                selectedProject.Id = int.Parse(ProjectIdLabel.Text);
                selectedProject.ShortName = ProjectShortNameLabel.Text;
                selectedProject.LongName = ProjectLongNameLabel.Text;

                viewModel.UpdateProject(selectedProject.Id, selectedProject.ShortName, selectedProject.LongName);
                RefreshPage();

            }
        }

        //Handles creating a project
        private Entry newID;
        private Entry newName;
        private Entry newNotes;
        private int holderID;

        private void ProjectCreator(object sender, EventArgs e)
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
                Placeholder = "Enter Short Name...",
                HeightRequest = -40,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            newNotes = new Entry
            {
                Placeholder = "Enter Long Name",
                HeightRequest = -40,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            Button addProject = new Button
            {
                Text = "Click to add Project",
                HeightRequest = 40,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 16,
            };
            addProject.Clicked += AddTheProject;
            MainBox.Children.Add(newID);
            MainBox.Children.Add(newName);
            MainBox.Children.Add(newNotes);
            MainBox.Children.Add(addProject);

            Label projectIdLabel = new Label();
            Label projectNameLabel = new Label();
            Label projectNotesLabel = new Label();

            MainBox.Children.Add(projectIdLabel);
            MainBox.Children.Add(projectNameLabel);
            MainBox.Children.Add(projectNotesLabel);
        }

        private void AddTheProject(object sender, EventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)BindingContext;

            int id = int.Parse(newID.Text);
            string name = newName.Text;
            string notes = newNotes.Text;

            viewModel.AddProject(id, name, notes);
            RefreshPage();

        }

    }
}