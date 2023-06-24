using ComfortStoreLibrary.Models;
using MessagingToolkit.QRCode.Codec;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для BarcodeWin.xaml
    /// </summary>
    public partial class BarcodeWin : Window
    {
        Order contextOrder;
        QRCodeEncoder encoder = new QRCodeEncoder();
        Bitmap bitmap;
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public BarcodeWin(Order order)
        {
            InitializeComponent();
            contextOrder = order;
            DataContext = contextOrder;
        }

        private void QRGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string qrtext = QrTxt.Text.Trim();
                if (qrtext.Length > 0)
                {
                    encoder.QRCodeScale = 8;
                    bitmap = encoder.Encode(QrTxt.Text);
                    ImageQR.Source = ConvertImage.ToBitmapImage(bitmap);
                }
                else
                {
                    MessageBox.Show("Не указан идентификатор заказа", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при генерировании QR-кода: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void QRSave_Click(object sender, RoutedEventArgs e)
        {
            saveFileDialog.Filter = "PNG|*.png";
            saveFileDialog.FileName = QrTxt.Text;
            if (saveFileDialog.ShowDialog() == true)
            {
                if (bitmap != null)
                {
                    bitmap.Save(string.Concat(saveFileDialog.FileName, ".png"), ImageFormat.Png);
                }
            }
        }

        
    }
}
