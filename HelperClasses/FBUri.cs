using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;


namespace DisasSurvivApp.HelperClasses
{
    public static class FBUri
    {

        #region AppID
        private static string m_strAppID = "206339969389218";
        #endregion

        #region AppSecret - only needed because of the fragment bug
        private static string m_strAppSecret = "f7192809a188d4ff8a667141ec25de96";
        #endregion
        //the correct url - but not working due to the WebBrowser fragment bug
        //private static string m_strLoginURL = "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri=http://www.facebook.com/connect/login_success.html&type=user_agent&display=touch&scope=publish_stream,user_hometown";
        private static string m_strLoginURL = "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri=http://www.facebook.com/connect/login_success.html&display=touch&scope=publish_stream,user_hometown";
        private static string m_strGetAccessTokenURL = "https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri=http://www.facebook.com/connect/login_success.html&client_secret={1}&code={2}";

        private static string m_strQueryUserURL = "https://graph.facebook.com/me?fields=id,name,gender,link,hometown,picture&locale=en_US&access_token={0}";
        public static Uri GetQueryUserUri(string strAccressToken)
        {
            return (new Uri(string.Format(m_strQueryUserURL, strAccressToken), UriKind.Absolute));
        }

        public static Uri GetLoginUri()
        {
            return (new Uri(string.Format(m_strLoginURL, m_strAppID, "http://www.facebook.com/connect/login_success.html&type=user_agent&display=touch&scope=publish_stream,user_hometown"), UriKind.Absolute));
        }
        public static Uri GetTokenLoadUri(string strCode)
        {
            return (new Uri(string.Format(m_strGetAccessTokenURL, m_strAppID, m_strAppSecret, strCode), UriKind.Absolute));
        }

        private static string m_strLoadFriendsURL = "https://graph.facebook.com/me/friends?access_token={0}";
        public static Uri GetLoadFriendsUri(string strAccressToken)
        {
            return (new Uri(string.Format(m_strLoadFriendsURL, strAccressToken), UriKind.Absolute));
        }

        private static string m_strPostMessageURL = "https://graph.facebook.com/me/feed";
        public static Uri GetPostMessageUri()
        {
            return (new Uri(m_strPostMessageURL, UriKind.Absolute));
        }
    }

}

