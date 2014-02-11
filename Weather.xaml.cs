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
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using System.Device.Location;
using System.ServiceModel.Syndication;
using System.Xml;
using GpsEmulatorClient;

namespace DisasSurvivApp
{
    public partial class Weather : PhoneApplicationPage
    {


        public Weather()
        {
            InitializeComponent();
        }

        


        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            
            textBox1.Text = App.GpsState1.ToString();
            string url = "http://www.weather.gov/alerts-beta/" + textBox1.Text.ToString() + ".php?x=0";
            //RSS Start Parse
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.BeginGetResponse(ResponseHandler, request);

        }

        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://www.weather.gov/alerts-beta/" + textBox1.Text.ToString() + ".php?x=0";
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
                alertsBox.Dispatcher.BeginInvoke(delegate
                {
                    alertsBox.ItemsSource = newFeed.Items;
                });
            }
        }



    }
}