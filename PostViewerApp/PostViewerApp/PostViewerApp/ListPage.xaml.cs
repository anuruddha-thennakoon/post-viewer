using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PostViewerApp.Data;
using PostViewerApp.Net;

namespace PostViewerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ObservableCollection<Post> PostsList { get; }

        DataRetriever _dr;

        public ListPage()
        {
            InitializeComponent();

            Title = "Posts";
            PostsList = new ObservableCollection<Post>();
            PostsListView.ItemsSource = PostsList;
            PostsListView.ItemSelected += PostsListView_ItemSelected;

            _dr = new DataRetriever();

            PostsListView.IsVisible = false;
            ActivityIndicator.IsVisible = true;

            LoadData();
        }

        private void PostsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CommentPage details = new CommentPage(e.SelectedItem as Post);
                Navigation.PushAsync(details);
            }

            // Clear selection
            PostsListView.SelectedItem = null;
        }

        private void LoadData()
        {
            PostsList.Clear();

            List<Post> posts = _dr.GetPosts();

            ActivityIndicator.IsRunning = false;
            ActivityIndicator.IsVisible = false;
            PostsListView.IsVisible = true;

            foreach (Post p in posts)
            {
                PostsList.Add(p);
            }
        }

    }
}