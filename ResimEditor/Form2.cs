using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResimEditor
{
    public partial class Form2 : Form
    {
        Image img;
        string[] resimtur = { ".PNG", ".JPEG", ".JPG", ".BMP" }; //hangi türde resimlerin resize yapılacağını listeledik.
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();  //gözat butonuna tıklayınca bir pencere açıldı.
            ofd.Filter = "images | *.png; *.jpg; *jpeg; *.bmp"; //yine resimlerimizin türü aynı. Form1deki gibi.
            if(ofd.ShowDialog()==DialogResult.OK) //Penceremiz açılıyorsa
            {
                txtSec.Text = ofd.FileName; //Resmi seçmek için yer çıkacak.
                img = Image.FromFile(ofd.FileName); //Resmi seçince direkt linki de yazacak yukarıdaki textbox'ta.
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < resimtur.Length; i++)
                comboBox1.Items.Add(resimtur[i]); //comboboxta bu seçilen türleri gösteriyoruz ve bunlar dışında başka seçenek yok.
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); //resmin yeni halini kaydedeceğimiz yer için.
            if (fbd.ShowDialog() == DialogResult.OK)
                txtKy.Text = fbd.SelectedPath;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int w = Convert.ToInt32(txtEn.Text), h = Convert.ToInt32(txtBoy.Text); //Yeniden boyutlandırma için boy ve en(height-width) tanımladık ve bunlar sayısal değerler olacak.
            img = Resize(img, w, h); //resim, eni,boyu
            ((Button)sender).Enabled = false; //butona basıldığında yeniden boyutlandırma işini yapacak.
            MessageBox.Show("Resim yeniden boyutlandırması başarılı!"); 
          }
        Image Resize(Image image, int w,int h)
        {
            Bitmap bmp = new Bitmap(w, h); //yeni hali bitmap olarak gösteriyor ve bu boyut olarak en küçük resim formatı bmp.
            Graphics graphic = Graphics.FromImage(bmp); 
            //Graphics çizim için lazım olan bir nesnedir. Bir resim üzerinde yapılacak editler için kullandık.
            graphic.DrawImage(image, 0, 0, w, h); //Resmin eni ve boyu lazımdı bize.
            graphic.Dispose();

            return bmp;
        }
        private void button5_Click(object sender, EventArgs e)  //otomatik resize için butonları girdik
        {
            txtEn.Text = "100"; //Mesela en 100
            txtBoy.Text = "100";//Boy 100

            button3.PerformClick(); //Otomatik olarak resize yapıyor. Bizim ayrıca tıklamamıza gerek yok.
            button4.PerformClick();// Otomatik de kaydediyor.

        }
        private void button4_Click(object sender, EventArgs e)
        {
            int i = txtSec.Text.LastIndexOf("\\");
            int j = txtSec.Text.LastIndexOf(".");
            img.Save(txtKy.Text + "\\" + txtSec.Text.Substring(i+1,j-i-1) + resimtur[comboBox1.SelectedIndex]); ;
            ((Button)sender).Enabled = false; //Butona basıldığı zaman artık kaydedilebilecek. Önceki bilgilere göre combobox'tan seçilen resim formatı vs.
            MessageBox.Show("Resim kaydedildi!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtEn.Text = "200";
            txtBoy.Text = "200";

            button3.PerformClick();
            button4.PerformClick();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtEn.Text = "300";
            txtBoy.Text = "300";

            button3.PerformClick();
            button4.PerformClick();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtEn.Text = "500";
            txtBoy.Text = "500";

            button3.PerformClick();
            button4.PerformClick();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtEn.Text = "750";
            txtBoy.Text = "750";

            button3.PerformClick();
            button4.PerformClick();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtEn.Text = "1000";
            txtBoy.Text = "1000";

            button3.PerformClick();
            button4.PerformClick();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtEn.Text = "900";
            txtBoy.Text = "900";

            button3.PerformClick();
            button4.PerformClick();
        }

        private void txtKy_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
