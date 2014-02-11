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
using System.ServiceModel.Syndication;
using System.Xml;

namespace DisasSurvivApp
{
    public partial class News : PhoneApplicationPage
    {
        public News()
        {
            InitializeComponent();
        }

        private void newsLocationBlock_Loaded(object sender, RoutedEventArgs e)
        {
            newsLocationBlock.Text += App.GpsCity1.ToString();
            newsLocationBlock.Text += ", ";
            newsLocationBlock.Text += App.GpsState1.ToString();

            string url = "http://www.wave3.com/category/1178/home?clienttype=rss";
            //RSS Start Parse
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.BeginGetResponse(ResponseHandler, request);

        }

        private void ResponseHandler(IAsyncResult asyncResult)
        {
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                XmlReader reader = XmlReader.Create(response.GetResponseStream());
                SyndicationFeed newFeed = SyndicationFeed.Load(reader);
                newsBox.Dispatcher.BeginInvoke(delegate
                {
                    newsBox.ItemsSource = newFeed.Items;
                });
            }
        }

    }
}