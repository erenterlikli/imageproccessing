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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        Bitmap bitmap1;
        Image img;
        string[] resimtur = { ".PNG", ".JPEG", ".JPG", ".BMP" }; //hangi türde resimlerin resize yapılacağını listeledik.
        private void InitializeBitmap()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();  //gözat butonuna tıklayınca bir pencere açıldı.
                bitmap1 = (Bitmap)Bitmap.FromFile(ofd.FileName);
                resimYeri.SizeMode = PictureBoxSizeMode.AutoSize;
                resimYeri.Image = bitmap1;
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error." +
                    "Check the path to the bitmap.");
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap yeni = new Bitmap(img.Width, img.Height);
            Graphics g = Graphics.FromImage(yeni);
            g.RotateTransform(float.Parse(textBox1.Text));
            g.DrawImage(img, float.Parse(textBox2.Text), float.Parse(textBox3.Text));
            resimYeri.Image = yeni;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();  //gözat butonuna tıklayınca bir pencere açıldı.
            ofd.Filter = "images | *.png; *.jpg; *jpeg; *.bmp"; //yine resimlerimizin türü aynı. Form1deki gibi.
            if (ofd.ShowDialog() == DialogResult.OK) //Penceremiz açılıyorsa
            {
                button2.Text = ofd.FileName; //Resmi seçmek için yer çıkacak.
                img = Image.FromFile(ofd.FileName); //Resmi seçince direkt linki de yazacak yukarıdaki textbox'ta.
                resimYeri.Image = img;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); //resmin yeni halini kaydedeceğimiz yer için.
            if (fbd.ShowDialog() == DialogResult.OK)
                button4.Text = fbd.SelectedPath;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int i = button2.Text.LastIndexOf("\\");
            int j = button2.Text.LastIndexOf(".");
            ((Bitmap)resimYeri.Image).Save(button4.Text + "\\" + button2.Text.Substring(i + 1)); ;
            ((Button)sender).Enabled = false; //Butona basıldığı zaman artık kaydedilebilecek. 
            MessageBox.Show("Resim kaydedildi!");
            
        
        }

       
    }
}
