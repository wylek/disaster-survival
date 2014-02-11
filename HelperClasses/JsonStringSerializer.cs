﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace DisasSurvivApp.HelperClasses
{
    //JSON de-serialization. Generic method which returns a de-serialized class.
    //Parameter = the strings we get from our Facebook API calls. 
    public static class JsonStringSerializer
    {
        public static T Deserialize<T>(string strData) where T : class
        {
            //needs System.Servicemodel.Web
            DataContractJsonSerializer dcsJson = new DataContractJsonSerializer(typeof(T));
            byte[] byteArray = Encoding.UTF8.GetBytes(strData);
            MemoryStream mS = new MemoryStream(byteArray);
            T tRet = dcsJson.ReadObject(mS) as T;
            mS.Dispose();
            return (tRet);
        }
    }

}
