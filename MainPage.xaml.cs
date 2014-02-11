// This line has to be the first line in the file
#define GPS_EMULATOR // defining a compiler GPS symbol.

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
using GpsEmulatorClient;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Controls.Maps.ConfigService;
using Microsoft.Phone.Reactive;
using TweetSharp;
using System.Runtime.Serialization;
using System.ServiceModel;
using dev.virtualearth.net.webservices.v1.geocode;
using dev.virtualearth.net.webservices.v1.common;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace DisasSurvivApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        static CivicAddress address;

        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            switch (DisasSurvivApp.App.watcher.Status)
            {
                case GeoPositionStatus.NoData:
                    // The Location Service is working, but it cannot get location data.
                    // Alert the user and enable the Stop Location button.
                    statusGpsBlock.Text = "location data is not available.";
                    break;

                case GeoPositionStatus.Ready:
                    // The Location Service is working and is receiving location data.
                    // Show the current position and enable the Stop Location button.
                    statusGpsBlock.Text = "location data is available.";
                    ResolveAddressSync(addressGpsBlock);
                    break;
                case GeoPositionStatus.Disabled:
                    statusGpsBlock.Text = "Disabled";
                    break;
                case GeoPositionStatus.Initializing:
                    statusGpsBlock.Text = "Initializing";
                    break;
            }

            /* Reverse Geocode the coordinates:
            ResolveAddress(38.2135693889165, -85.7606077194214);
            addressGpsBlock.Text = App.GpsCity1;
            addressGpsBlock.Text += ", ";
            addressGpsBlock.Text += App.GpsState1;*/
        }

        private void ResolveAddress(double lat, double lon)
        {
             DisasSurvivApp.App.GpsCity1 = "Louisville";
             DisasSurvivApp.App.GpsState1 = "KY";
             DisasSurvivApp.App.GpsZipCode1 = 40202;
        }

        #region Button Handlers
        private void newsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/News.xaml", UriKind.Relative));
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Connect.xaml", UriKind.Relative));
        }

        private void weatherButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Weather.xaml", UriKind.Relative));
        }

        private void outageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Outage.xaml", UriKind.Relative));
        }
        #endregion
        
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            // Let's conserve battery power.
            //App.watcher.Stop();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Reload GPS status block
            switch (DisasSurvivApp.App.watcher.Status)
            {
                case GeoPositionStatus.NoData:
                    // The Location Service is working, but it cannot get location data.
                    // Alert the user and enable the Stop Location button.
                    statusGpsBlock.Text = "Location not available.";
                    break;

                case GeoPositionStatus.Ready:
                    // The Location Service is working and is receiving location data.
                    // Show the current position and enable the Stop Location button.
                    statusGpsBlock.Text = "Location available.";
                    break;
                case GeoPositionStatus.Disabled:
                    statusGpsBlock.Text = "Disabled";
                    break;
                case GeoPositionStatus.Initializing:
                    statusGpsBlock.Text = "Initializing";
                    break;
            }
        }
        static void resolver_ResolveAddressCompleted(object sender, ResolveAddressCompletedEventArgs e)
        {
            if (!e.Address.IsUnknown)
            {
                address.City = e.Address.City;
            }
            else
            {
                address.City = "Address Unknown!";
            }
        }
        static void ResolveAddressSync(TextBlock addressGpsBlock)
        {
            //App.watcher.MovementThreshold = 1.0; // set to one meter
            App.watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            Dispatcher dispatcher = Deployment.Current.Dispatcher;
            CivicAddressResolver resolver = new CivicAddressResolver();
            CivicAddress address = new CivicAddress();
            resolver.ResolveAddressCompleted += new EventHandler<ResolveAddressCompletedEventArgs>(resolver_ResolveAddressCompleted);

            if (App.watcher.Position.Location.IsUnknown == false)
            {
                resolver.ResolveAddressAsync(App.watcher.Position.Location);
                addressGpsBlock.Text = address.City;
            }
        }
    }
}