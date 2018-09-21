using PostViewerApp.Data;
using PostViewerApp.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostViewerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommentPage : ContentPage
	{
        public ObservableCollection<Comment> CommentsList { get; }

        DataRetriever _dr;
        int? userId;

        public CommentPage()
        {
            InitializeComponent();

            Title = "Comments";
            CommentsList = new ObservableCollection<Comment>();
            CommentsListView.ItemsSource = CommentsList;

            CommentsListView.ItemSelected += CommentsListView_ItemSelected;

            _dr = new DataRetriever();
            AddToolbarItem();

            CommentsListView.IsVisible = false;
            ActivityIndicator.IsVisible = true;
        }

        private void CommentsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Comment comment = e.SelectedItem as Comment;
                Device.OpenUri(new Uri("mailto:" + comment.Email));
            }

            // clear selection
            CommentsListView.SelectedItem = null;
        }

        public CommentPage(Post post)
            : this()
        {
            LoadData(post.Id);
            userId = post.UserId;
        }

        private void AddToolbarItem()
        {
            ToolbarItems.Add(new ToolbarItem("", "profile.png", () =>
            {
                LoadProfile(userId);
            }));
        }

        private void LoadData(int? postId)
        {
            CommentsList.Clear();

            List<Comment> comments = _dr.GetComments(postId);

            ActivityIndicator.IsRunning = false;
            ActivityIndicator.IsVisible = false;
            CommentsListView.IsVisible = true;

            foreach (Comment c in comments)
            {
                CommentsList.Add(c);
            }
        }

        private void LoadProfile(int? userId)
        {
            User user = _dr.GetUser(userId);
            UserProfile userProfile = new UserProfile(user);
            Navigation.PushAsync(userProfile);
        }
    }
}