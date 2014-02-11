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
using TweetSharp;

namespace DisasSurvivApp
{
    public partial class SearchTwitter : PhoneApplicationPage
    {
        public SearchTwitter()
        {
            InitializeComponent();
        }

        private void listBox1_Loaded(object sender, RoutedEventArgs e)
        {
            TwitterService service = new TwitterService("KoMx9woStVj5kla8X2ARKg", "FNIpfXVISis9esW5YAxLqpx5kK5zDdqsuNvmI1x58s");
            // Then you kick off your search with a search term:
            string search1, search2, search3;
            search1 = "storm " + App.GpsCity1.ToString();
            search2 = "outage " + App.GpsCity1.ToString();
            search3 = "shelter " + App.GpsCity1.ToString();
            service.Search(search1, ProcessIncommingSearch);
            service.Search(search2, ProcessIncommingSearch);
            service.Search(search3, ProcessIncommingSearch);
        }

        // You need a method to handle your asynchronous search result. Add the tweets via the dispatcher to get the result back into the UI thread:
        public void ProcessIncommingSearch(TwitterSearchResult searchResult, TwitterResponse response)
        {
           Dispatcher dispatcher = Deployment.Current.Dispatcher;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                foreach (var status in searchResult.Statuses)
                {
                    TwitterStatus inline = status;
                    Tweet tweet = new Tweet(inline);
                    dispatcher.BeginInvoke(() => tweets.Items.Add(tweet));
                }
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

    } // e. class
} // e. namespace