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

namespace DisasSurvivApp
{
    public partial class FBPost : PhoneApplicationPage
    {
        public FBPost()
        {
            InitializeComponent();
        }

        private WebClient m_wcPostMessage;
        private void btnPostToWall_Click(object sender, RoutedEventArgs e)
        {
            if (m_wcPostMessage == null)
            {
                m_wcPostMessage = new WebClient();
                m_wcPostMessage.UploadStringCompleted += new UploadStringCompletedEventHandler(m_wcPostMessage_UploadStringCompleted);
            }
            try
            {
                m_wcPostMessage.UploadStringAsync(FBUri.GetPostMessageUri(), "POST", m_fbPost.GetPostParameters(App.AccessToken));
            }
            catch (Exception eX)
            {
                UpdateUIStatus("Post to wall failed", eX.Message);
            }
        }
        void m_wcPostMessage_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                UpdateUIStatus("Error posting message", e.Error.Message);
                return;
            }
            try
            {
                UpdateUIStatus("Post done", e.Result);
            }
            catch (Exception eX)
            {
                UpdateUIStatus("Error handling post result", eX.Message);
            }
        }


        private FBWallPost m_fbPost;
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            m_fbPost = new FBWallPost(true);
            fbPostData.DataContext = m_fbPost;
        }
        private void UpdateUIStatus(string strStatus, string strError)
        {
            txtStatus.Text = strStatus;
            txtError.Text = strError;
        }

    }
}