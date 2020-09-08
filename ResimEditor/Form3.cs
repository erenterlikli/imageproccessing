using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResimEditor
{
    public partial class Form3 : Form
    {
        Rectangle Rect; //Resmin kısmı
        Point LocationXY; //Resmi kırparken yataydan ve dikeyden yer seçeceğiz. Oranın ilk koordinatları.
        Point LocationXY2; //Kırpma işlemi için kırpacağımız yerin son koordinatları.
        bool IsMouseDown = false; //Mouse ile kırpma yapacağımız için mouse aşağıya sürüklendi mi bunu sorguluyor.
        public Form3()

        {
            InitializeComponent();
        }


        private void normalResim_Click(object sender, EventArgs e)
        {

        }

        private void normalResim_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true; //Yukarıda false demiştik. Eğer bu olay yapılırsa o zaman şunlar olsun:
            LocationXY = e.Location; //lokasyon belirliyoruz.

        }

        private void normalResim_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true) // eğer mouse hareket ederse buraya göre yapılacak.
            {
                LocationXY2 = e.Location; //Çünkü mouse hareket ettiği için aşağı kısma kırpmayı sonlandırmak için geçilmiştir muhtemelen.
                Refresh();
            }
        }
        private void normalResim_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true) //eğer mouse yukarı hareket ediyorsa
            {
                LocationXY2 = e.Location; //Kırpmanın son kısmını alıyoruz.
                IsMouseDown = false;
                if (Rect != null)
                {
                    Bitmap bit = new Bitmap(normalResim.Image, normalResim.Width, normalResim.Height); //Bitmap için bir nesne oluşturduk.
                    Bitmap kırpma = new Bitmap(Rect.Width, Rect.Height); //yine nesne oluşturduk bu sefer boy en için.
                    Graphics g = Graphics.FromImage(kırpma);
                    g.DrawImage(bit, 0, 0, Rect, GraphicsUnit.Pixel);
                    //kırpılmısResim.Image = kırpma;
                    kırpılmısResim.Image = kırpma;

                }
            }
        }

        private void normalResim_Paint(object sender, PaintEventArgs e)
        {
            if (Rect != null) //Eğer resim koyulacak kısım boş değilse
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRect()); //Bu sınıfı daha önce resize'da da kullanmıştık.

            }
        }
        private Rectangle GetRect()
        {
            Rect = new Rectangle(); //Rectangle'dan nesne oluşturduk.
            Rect.X = Math.Min(LocationXY.X, LocationXY2.X); //X değeri için hem alt hem de üst konumlarımızı math kütüphanesiyle yazdık.
            Rect.Y = Math.Min(LocationXY.Y, LocationXY2.Y); //Y değeri için hem alt hem de üst konumlarımızı math kütüphanesiyle yazdık.
            //Sonuçta seçtiğimiz resmin konumları olduğu için burada resmin ilk kısmıyla son kısmı arasındaki farkı 
            //da görmemiz gerek, bunu x kısmı için yazdık. Yani genişlik için.
            Rect.Width = Math.Abs(LocationXY.X - LocationXY2.X);
            // Bu sefer de aynı işlemi y kısmı için yaptık yani yükseklik. Bir de Math.Abs kısmı ondalık çıksın diye.
            Rect.Height = Math.Abs(LocationXY.Y - LocationXY2.Y);
            return Rect;
        }

        private void kırpılmısResim_Click(object sender, EventArgs e)
        {

        }

        private void btnDosyadan_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.bmp, *jpg, *jpeg, *png)|  *.bmp;*.jpg;*jpeg;*png"; //seçilecek resmin türleri.
            if(ofd.ShowDialog()==DialogResult.OK) //eğer bu dosya seçim yeri doğru sonuç veriyorsa
            {
                normalResim.Image = Image.FromFile(ofd.FileName, true); // o zaman burdan resim seçebiliriz. 
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(kırpılmısResim.Image!=null)  //kırptığımız resim alanı boş değilse
            {
                SaveFileDialog kaydet = new SaveFileDialog();
                kaydet.Filter= "Image Files(*.bmp, *jpg, *jpeg, *png)|  *.bmp; *.jpg; *jpeg; *png"; //kayıt için de formatlarımız belli

                if(kaydet.ShowDialog()==DialogResult.OK)
                {
                    if(kaydet.FileName.EndsWith(".bmp")) //eğer kaydedeceğimiz resim bmp formatındaysa.
                    {
                        kırpılmısResim.Image.Save(kaydet.FileName, ImageFormat.Bmp); //kırpılmış resim adıyla birlikte bmp olarak kaydedilsin.
                    }
                    else if (kaydet.FileName.EndsWith(".jpeg"))//eğer kaydedeceğimiz resim jpeg formatındaysa.
                    {
                        kırpılmısResim.Image.Save(kaydet.FileName, ImageFormat.Jpeg);//kırpılmış resim adıyla birlikte jpeg olarak kaydedilsin.
                    }
                    else if (kaydet.FileName.EndsWith(".png"))//eğer kaydedeceğimiz resim png formatındaysa.
                    {
                        kırpılmısResim.Image.Save(kaydet.FileName, ImageFormat.Png); //kırpılmış resim adıyla birlikte png olarak kaydedilsin.
                    }
                    MessageBox.Show("Resim kaydedildi!");
                }
                }
            else
            {
                MessageBox.Show("Kaydedilecek resim seçmediniz!");
            }
        }
    }
}
