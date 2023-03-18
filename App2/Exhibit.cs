using System;
using System.Collections.Generic;
using System.IO;

using System.Text;
using Xamarin.Forms;

namespace MuseumXamarin
{
    public class Exhibit
    {
        public int ExhibitId { get; set; }
        public string Hall { get; set; }
        public string ExhibitName { get; set; }
        public DateTime ExhibitDateDelivery { get; set; }
        public string Employer { get; set; }
        public string ExhibitPhoto { get; set; }







        //public ImageSource Photo
        //{
        //    get
        //    {
        //        return ImageSource.FromStream(() =>
        //        new MemoryStream(Convert.FromBase64String(ExhibitPhoto)));



        //    }
        //}
    }
}
