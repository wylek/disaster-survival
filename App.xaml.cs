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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
//Mine...
using GpsEmulatorClient;
using System.Device.Location;
using System.Runtime.Serialization;
using System.ServiceModel;
using dev.virtualearth.net.webservices.v1.geocode;
using dev.virtualearth.net.webservices.v1.common;
using System.Collections.ObjectModel;


namespace DisasSurvivApp
{
    public partial class App : Application
    {
        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        //GPS Emulation..
        public static IGeoPositionWatcher<GeoCoordinate> watcher;
        //public static GeocodeServiceClient geoCodeClient;

        //GPS Shared Variables:
        private static string GpsCity;
        public static string GpsCity1
        {
            get { return GpsCity; }
            set { GpsCity = value; }
        }
        private static string GpsState;
        public static string GpsState1
        {
            get { return GpsState; }
            set { GpsState = value; }
        }
        private static int GpsZipCode;
        public static int GpsZipCode1
        {
            get { return GpsZipCode; }
            set { GpsZipCode = value; }
        }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are being GPU accelerated with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;
            }

            // Standard Silverlight initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // GPS shared information initialization
            GpsCity1 = null;
            GpsState1 = null;
            GpsZipCode1 = 00000;


            // The watcher variable was previously declared as type GeoCoordinateWatcher. 
            if (watcher == null)
            {
#if GPS_EMULATOR
                watcher = new GpsEmulatorClient.GeoCoordinateWatcher(GeoPositionAccuracy.High);

#else
                    watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                    watcher.MovementThreshold = 20; // Ignore some signal noise
                watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
#endif
            }
            watcher.Start();

        } //end constructor


        //private GeocodeServiceClient geoCodeClient;
        /*public GeocodeServiceClient GeoCodeClient
        {
            get
            {
                if (null == geoCodeClient)
                {
                    var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
                    binding.MaxReceivedMessageSize = int.MaxValue;
                    binding.MaxBufferSize = int.MaxValue;
                    var serviceUri = new UriBuilder(@"http://dev.virtualearth.net/webservices/v1/geocodeservice/geocodeservice.svc");
                    serviceUri.Scheme = Uri.UriSchemeHttps;
                    serviceUri.Port = -1;
                    geoCodeClient = new GeocodeServiceClient(binding, new EndpointAddress(serviceUri.Uri));
                }
                return geoCodeClient;
            }
        }*/

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion

        #region Facebook AccessToken
        private static string m_strAccessToken;
        public static string AccessToken
        {
            get { return m_strAccessToken; }
            set { m_strAccessToken = value; }
        }
        #endregion

    }
}