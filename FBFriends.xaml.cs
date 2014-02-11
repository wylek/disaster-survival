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
using System.Diagnostics;
using DisasSurvivApp.HelperClasses;

namespace DisasSurvivApp
{
    public partial class FBFriends : PhoneApplicationPage
    {
        public FBFriends()
        {
            InitializeComponent();
        }

        WebClient m_wcLoadFriendsList;
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (m_wcLoadFriendsList == null)
            {
                m_wcLoadFriendsList = new WebClient();
                m_wcLoadFriendsList.DownloadStringCompleted += new DownloadStringCompletedEventHandler(m_wcLoadFriendsList_DownloadStringCompleted);
            }
            try
            {
                m_wcLoadFriendsList.DownloadStringAsync(FBUri.GetLoadFriendsUri(App.AccessToken));
                UpdateUIStatus("Loading Friends", "OK");
            }
            catch (Exception eX)
            {
                UpdateUIStatus("Loading friends failed", eX.Message);
            }
        }
        private void UpdateUIStatus(string strStatus, string strError)
        {
            txtStatus.Text = strStatus;
            txtError.Text = strError;
        }
        void m_wcLoadFriendsList_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                UpdateUIStatus("Error loading friends", e.Error.Message);
                return;
            }
            try
            {
                lbFriends.DataContext = JsonStringSerializer.Deserialize<FBFriends>(e.Result); ;
                UpdateUIStatus("Friends loaded", "OK");
            }
            catch (Exception eX)
            {
                UpdateUIStatus("Error parsing friends list", eX.Message);
            }
        }



    }
}