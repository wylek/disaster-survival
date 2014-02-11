using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using DisasSurvivApp.HelperClasses;
using System.Diagnostics;

namespace DisasSurvivApp
{
    public partial class SearchFB : PhoneApplicationPage
    {
        public SearchFB()
        {
            InitializeComponent();
        }

        #region Event Handlers
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            bool bWeAreLoggedIn = !string.IsNullOrEmpty(App.AccessToken);
            btnLogin.IsEnabled = !bWeAreLoggedIn;	//reverse logic
            btnGetUserData.IsEnabled = bWeAreLoggedIn;
            btnPostToWall.IsEnabled = bWeAreLoggedIn;
            btnShowFriends.IsEnabled = bWeAreLoggedIn;
            txtStatus.Text = bWeAreLoggedIn ? "Use the above buttons to access facebook" : "Login to enable facebook funtions";
            txtError.Text = bWeAreLoggedIn ? App.AccessToken : "OK";
            fbUserGrid.DataContext = m_CurFacebookUser;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FBLogin.xaml", UriKind.Relative));
        }
        private WebClient m_wcGetUserData;

        private void btnGetUserData_Click(object sender, RoutedEventArgs e)
        {
            if (m_wcGetUserData == null)
            {
                m_wcGetUserData = new WebClient();
                m_wcGetUserData.DownloadStringCompleted += new DownloadStringCompletedEventHandler(m_wcGetUserData_DownloadStringCompleted);
            }
            try
            {
                m_wcGetUserData.DownloadStringAsync(FBUri.GetQueryUserUri(App.AccessToken));
                UpdateUIStatus("Loading user data", "OK");
            }
            catch (Exception eX)
            {
                UpdateUIStatus("Could not load user data", eX.Message);
            }
        }

        private void UpdateUIStatus(string strStatus, string strError = null)
        {
            txtStatus.Text = strStatus;
            txtError.Text = strError ?? "OK";
        }

        private void btnPostToWall_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FBPost.xaml", UriKind.Relative));
        }

        private void btnShowFriends_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FBFriends.xaml", UriKind.Relative));
        }
        #endregion

        private static FBUser m_CurFacebookUser;
        void m_wcGetUserData_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                m_CurFacebookUser = null;
                UpdateUIStatus("Error loading user data", e.Error.Message);
                return;
            }
            try
            {
                m_CurFacebookUser = JsonStringSerializer.Deserialize<FBUser>(e.Result);
                fbUserGrid.DataContext = m_CurFacebookUser;
                UpdateUIStatus("User data loaded");
            }
            catch (Exception eX)
            {
                m_CurFacebookUser = null;
                UpdateUIStatus("Error parsing user data", eX.Message);
            }
        }
    }
}