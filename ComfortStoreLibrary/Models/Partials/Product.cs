using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ComfortStoreLibrary.Models
{
    public partial class Product
    {
        public byte[] MainImage
        {
            get
            {
                var firstPhoto = this.ProductPhoto.FirstOrDefault();
                if(firstPhoto != null)
                {
                    return firstPhoto.Image;
                }
                return null;
            }
        }

        public Visibility Visibility
        { 
            get
            {
                var selWare = this.Warehouse.FirstOrDefault(x => x.ProductId == Id);
                if (selWare.Count == 0)
                {
                    return Visibility.Collapsed;
                }
                else { return Visibility.Visible; }
            }
        }
        public string IsAvalible
        {
            get
            {
                
                var selWare = this.Warehouse.FirstOrDefault(x => x.ProductId == Id);
                if (selWare.Count == 0)
                {
                    return $"Нет в наличии";
                }
                else { return $"В наличии"; }
            }
        }

        public  SolidColorBrush ColorAv
        {
            get
            {
                var selWare = this.Warehouse.FirstOrDefault(x => x.ProductId == Id);
                if (selWare.Count == 0)
                {
                    return Brushes.Red;
                }
                else { return Brushes.Green; }
            }
        }

        public SolidColorBrush ColorBl
        {
            get
            {
                var selWare = this.Warehouse.FirstOrDefault(x => x.ProductId == Id);
                if (selWare.Count == 0)
                {
                    return Brushes.LightGray;
                }
                else { return Brushes.Transparent; }
            }
           
        }

        
    }

    public class BuscketItem
    {
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
