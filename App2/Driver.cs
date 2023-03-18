using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace App2
{
    public class Driver
    {

        
        public string DriverSurname { get; set; }
        public string DriverName { get; set; }
        public string DriverMiddlename { get; set; }
        public string DriverPassNumber { get; set; }
        public string DriverPassSeries { get; set; }
        public string DriverPhone { get; set; }
        public string DriverJob { get; set; }
        public string DriverCompany { get; set; }
        public string DriverImageBinary { get; set; }
        public string DriverEmail { get; set; }
        public string DriverPostCode { get; set; }

        public string DriverAddress { get; set; }

        public ImageSource Photo
        {
            get
            {
                return ImageSource.FromStream(() =>
                new MemoryStream(Convert.FromBase64String(DriverImageBinary)));



            }
        }
    }
}
