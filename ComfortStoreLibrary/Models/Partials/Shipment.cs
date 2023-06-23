using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComfortStoreLibrary.Models
{
    partial class Shipment
    {
        public Visibility DateVisible
        {
            get
            {
                if (DateToCome == null)
                {
                    return Visibility.Collapsed;

                }
                else
                { return Visibility.Visible; }

            }
        }
    }
}
