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
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using DisasSurvivApp.HelperClasses;

namespace DisasSurvivApp
{
    public partial class FBLogin : PhoneApplicationPage
    {
        public FBLogin()
        {
            InitializeComponent();
        }

        #region Event Handlers
        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.AccessToken = "TOKEN_SET";
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            wbLogin.Navigate(FBUri.GetLoginUri());
        }

        private void wbLogin_LoadCompleted(object sender,NavigationEventArgs e)
        {
            string strLoweredAddress = e.Uri.OriginalString.ToLower();
            if (strLoweredAddress.StartsWith("http://www.facebook.com/connect/login_success.html?code="))
            {
                txtStatus.Text = "Trying to retrieve access token";
                wbLogin.Navigate(FBUri.GetTokenLoadUri(e.Uri.OriginalString.Substring(56)));
                return;
            }
            string strTest = wbLogin.SaveToString();
            if (strTest.Contains("access_token"))
            {
                int nPos = strTest.IndexOf("access_token");
                string strPart = strTest.Substring(nPos + 13);
                nPos = strPart.IndexOf("</PRE>");
                strPart = strPart.Substring(0, nPos);
                //REMOVE EXPIRES IF FOUND!
                nPos = strPart.IndexOf("&expires=");
                if (nPos != -1)
                {
                    strPart = strPart.Substring(0, nPos);
                }
                App.AccessToken = strPart;
                //automaticall leave the page after login success
                NavigationService.GoBack();
                txtStatus.Text = "Authenticated - use back to see results";
                txtError.Text = "OK";
                return;
            }
        }


        #endregion

    }
}