using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComfortStoreLibrary.Models
{
    public partial class Order
    {

        public Visibility AdressVisible
        {
            get
            {
                if (DeliveryTypeId == 1)
                {
                    return Visibility.Collapsed;

                }
                else
                { return Visibility.Visible; }

            }
        }
        public Visibility AdressVisible1
        {
            get
            {
                if (DeliveryTypeId == 2)
                {
                    return Visibility.Collapsed;

                }
                else
                { return Visibility.Visible; }

            }
        }
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
