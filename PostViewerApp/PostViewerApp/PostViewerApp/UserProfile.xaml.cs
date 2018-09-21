using PostViewerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostViewerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProfile : ContentPage
	{
		public UserProfile ()
		{
			InitializeComponent ();

        }

        public UserProfile(User user)
            : this()
        {
            BindingContext = user;
            Title = user.Id + "'s profile";
        }
    }
}