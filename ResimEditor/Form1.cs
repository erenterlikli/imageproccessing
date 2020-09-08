using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; //resim dosyasına erişmek için burayı ekledik. Giriş yapılacak çünkü.
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResimEditor
{
    public partial class Form1 : Form
    {
        string seciliDosya = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var fb = new FolderBrowserDialog(); //dosyanın konumunu seçmek için açılan pencere.
                if(fb.ShowDialog()==System.Windows.Forms.DialogResult.OK) //eğer bir dosya seçildiyse
                {
                    seciliDosya = fb.SelectedPath; //Seçtiğimiz klasör artık seçilmiş olarak görünüyor.
                    textBoxDirectory.Text = seciliDosya;
                    var dirInfo = new DirectoryInfo(seciliDosya); //burada hangi dosyadaki resimlerin getirileceğini ayarladık.

                    var resimler = dirInfo.GetFiles().Where(c => (c.Extension.Equals(".jpg") || c.Extension.Equals(".jpeg") || c.Extension.Equals(".png") || c.Extension.Equals(".bmp")));
                    //Resim dosyalarına verilen izin. Mesela gif şeklinde bir resim varsa dosyada, onu görmeyecek ya da kabul etmeyecek.
                    foreach(var resim in resimler) //klasörün içindeki resimleri bir dizi olarak görüyoruz ve her bir resim dizinin bir elemanı ve her birinin bir adı var.
                    {

                        ResimListesi.Items.Add(resim.Name); //resimlerin bilgisayardaki kayıtlı olduğu isimleri gösteriyor.

                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hatalı işlem yaptınız!" + ex.Message + "" + ex.Source);
            }
        }

        private void ResimListesi_SelectedIndexChanged(object sender, EventArgs e) //resim listesinin içeriği
        {
            try
            {
                var selectedImage = ResimListesi.SelectedItems[0].ToString(); //burada açılan dosya içeriğinden resim seçme yapıyoruz. Bu da bir dizi gibi algılanıyor.
                if(!string.IsNullOrEmpty(selectedImage)&& !string.IsNullOrEmpty(seciliDosya))//seçilen resim ve seçilen dosya boş değilse o zaman seçtiğimiz dosyayı ve resmi link olarak yukarıda göstersin.
                {
                    var fullPath = Path.Combine(seciliDosya, selectedImage); //iki kısmı yani resim ve dosyayı kombine bir halde link olarak yazdı.

                    resimGosterme.Image = Image.FromFile(fullPath);  //dosya konumunda seçtiğimiz klasörün resimlerinden herhangi birine tıklayınca yandaki groupboxda resmi görebiliyoruz.
                }


            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 ff = new Form2(); //resize yapmak için ayrı bir form ekranı tanımladık ve burada butona basınca oraya gidiyor.
            ff.Show();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 ff = new Form3(); //crop işlemi için.
            ff.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 ff = new Form4(); //diğer işlemleri için.
            ff.Show();

        }
    }
}
