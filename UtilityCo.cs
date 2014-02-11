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

namespace DisasSurvivApp
{
    public class UtilityCo
    {
        // Open-closed principle (OCP) for utility companies: open for extension, but existing
        // feature set closed for modification.

        UtilityCo ticket;

        public UtilityCo()
        {
            ticket = new UtilityCo();
        }

        public void sendReport()
        {
        }

        public void checkReport()
        {
        }

        public void cancelReport()
        {
        }

    }
}
