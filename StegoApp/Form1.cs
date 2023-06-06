using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Win32;

namespace stego_app
{

    public partial class Form1 : Form
    {
        public int LSB_bits = 1;
        public bool rbutton_LSB = true;
        public bool rbutton_LSB2 = false;
        public bool rbutton_Gray = false;

        Bitmap image_secret;
        Bitmap image_container;
        Bitmap image_compose;

        public static ulong GrayEncode(ulong n)
        {
            return n ^ (n >> 1);
        }

        public static ulong GrayDecode(ulong n)
        {
            ulong i = 1 << 8 * 64 - 2; //long is 64-bit
            ulong p, b = p = n & i;

            while ((i >>= 1) > 0)
                b |= p = n & i ^ p >> 1;
            return b;
        }
        public Form1()
        {
            InitializeComponent();
            LogFile.tolog("Application Started");

            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.OpenSubKey("Stego_App",true);
            if (helloKey != null)
            {
                var num = helloKey.GetValue("win_key");
                int num_win = Convert.ToInt16(num);
                if (num_win > 0)
                {
                    var contname = helloKey.GetValue("contname");
                    var secname = helloKey.GetValue("secname");
                    if (contname != null ) {
                        try
                        {
                            image_container = new Bitmap(contname.ToString());
                           // image_compose = new Bitmap(secname.ToString());
                            //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                            this.pictureBox1.Size = image_container.Size;
                            pictureBox1.Image = image_container;
                            pictureBox1.Invalidate();
                            LogFile.tolog("Container Image restored");

                        }
                        catch
                        {
                            _ = MessageBox.Show("Невозможно открыть предыдущий файл",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (secname != null)
                    {
                        try
                        {
                            image_secret = new Bitmap(contname.ToString());
                            //image_compose = new Bitmap(secname.ToString());
                            //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                            this.pictureBox2.Size = image_secret.Size;
                            pictureBox2.Image = image_secret;
                            pictureBox2.Invalidate();
                            LogFile.tolog("Secret Image restored");

                        }
                        catch
                        {
                            _ = MessageBox.Show("Невозможно открыть предыдущий файл",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                    var w = Convert.ToInt32(helloKey.GetValue("pic_num", 0));
                    for (int i=1; i<=w; i++)
                    {
                        var name_rec = helloKey.GetValue("picname"+i.ToString());
                        string fname = name_rec.ToString();
                        Стегоанализ AnalyseForm = new Стегоанализ(fname);
                        AnalyseForm.Show();
                        LogFile.tolog("Image from "+fname+" for analyse restored");
                    }                    
                    helloKey.Close();
                }
                helloKey.Close();
            }
            
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseWheel);
        }
        private void Panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            return;
            //int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            //if (numberOfTextLinesToMove > 0)
            //{
            //    pictureBox1.Width /= 2;
            //    pictureBox1.Height /= 2;
            //}
            //else
            //{
            //    pictureBox1.Width *= 2;
            //    pictureBox1.Height *= 2;
            //}
            //pictureBox1.Refresh();

            //panel1.Invalidate();
        }
        private void LoadContainerBtn_Click(object sender, EventArgs e)
        {
            // Bitmap image_container; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog
            {
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*" //формат загружаемого файла
            }; //создание диалогового окна для выбора файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    LogFile.tolog("Open File  to container" + open_dialog.FileName);
                    image_container = new Bitmap(open_dialog.FileName);
                    image_compose = new Bitmap(open_dialog.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    this.pictureBox1.Size = image_container.Size;
                    pictureBox1.Image = image_container;
                    pictureBox1.Invalidate();
                    RegistryKey currentUserKey = Registry.CurrentUser;
                    RegistryKey helloKey = currentUserKey.OpenSubKey("Stego_App", true);
                    if (helloKey == null)
                    {
                        helloKey = currentUserKey.CreateSubKey("Stego_App", true);
                    }                  
                    helloKey.SetValue("win_key", 1);
                    helloKey.SetValue("contname", open_dialog.FileName);
                    helloKey.Close();

                }
                catch
                {
                    _ = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ImgContainerPlus_Click
            (object sender, EventArgs e)
        {
            LogFile.tolog("Container Image enlarged");
            pictureBox1.Width *=2;
            pictureBox1.Height *= 2;
            pictureBox1.Refresh();
        }

        private void ImgContainerMinus_Click(object sender, EventArgs e)
        {
            LogFile.tolog("Container Image reduced");
            pictureBox1.Width /= 2;
            pictureBox1.Height /= 2;
            pictureBox1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LoadSecret_Click(object sender, EventArgs e)
        {
            // Bitmap image_secret; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog
            {
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*" //формат загружаемого файла
            }; //создание диалогового окна для выбора файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    LogFile.tolog("Open File  to secret" + open_dialog.FileName);
                    image_secret = new Bitmap(open_dialog.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    this.pictureBox2.Size = image_secret.Size;
                    pictureBox2.Image = image_secret;
                    pictureBox2.Invalidate();
                    RegistryKey currentUserKey = Registry.CurrentUser;
                    //RegistryKey currentUserKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                    RegistryKey helloKey = currentUserKey.OpenSubKey("Stego_App",true);
                    if (helloKey == null)
                    {
                        helloKey = currentUserKey.CreateSubKey("Stego_App",true);
                    }
                    var w = helloKey.GetValue("win_key");
                    if (w != null) 
                    {
                        helloKey.DeleteValue("win_key");

                    }
                    helloKey.SetValue("win_key", 2);
                    helloKey.SetValue("secname", open_dialog.FileName);
                    helloKey.Close();

                }
                catch
                {
                    _ = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ImgSecretPlus_Click(object sender, EventArgs e)
        {
            LogFile.tolog("Secret Image enlarged");
            pictureBox2.Width *= 2;
            pictureBox2.Height *= 2;
            pictureBox2.Refresh();
        }

        private void ImgSecretMinus_Click(object sender, EventArgs e)
        {
            LogFile.tolog("Secret Image reduced");
            pictureBox2.Width /= 2;
            pictureBox2.Height /= 2;
            pictureBox2.Refresh();
        }

        private void Save_file_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    
                    pictureBox3.Image.Save(myStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] ar = new byte[myStream.Length];
                    myStream.Write(ar, 0, ar.Length);

                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
            LogFile.tolog("Save composed File " + saveFileDialog1.FileName);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Start_calc_Click(object sender, EventArgs e) //Кнопка ВСТРОИТЬ
        {
            int x, y;
            int x_cont, y_cont;
            int n;
            int coeff = 8 / LSB_bits;

            if (rbutton_LSB) coeff = 8 / 1;
            else if (rbutton_LSB2) coeff = 8 / 2;

            if (image_container ==null || image_secret == null)
            {
                string caption = "Ошибка";
                LogFile.tolog("ERROR Files not opened");
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Необходимы изображения и контейнера и секрета", caption, buttons);
                return;
            }
            if (image_container.Width * image_container.Height  < image_secret.Width * image_secret.Height * coeff)
            {
                string caption = "Ошибка";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Слишком маленький размер контейнера", caption, buttons);
                LogFile.tolog("ERROR Secret too big");
            }
            else
            {
                Bitmap image_compose_tmp;

                if (rbutton_LSB)
                {
                    LogFile.tolog("LSB1 method started");
                    // Loop through the images pixels to reset color.
                    for (y = 0; y < image_secret.Height; y++)
                    {
                        for (x = 0; x < image_secret.Width; x++)
                        {
                            Color pixelin = image_secret.GetPixel(x, y);
                            
                            byte r_ = pixelin.R;
                            byte g_ = pixelin.G;
                            byte b_ = pixelin.B;
                            byte a_ = pixelin.A;
                            byte mask0 = 0b11111110;
                            byte mask1 = 0b00000001;
                            
                            n = (y * image_secret.Width + x)*coeff;
                            y_cont = n  / image_container.Width;
                            x_cont = n  % image_container.Width;
                            Color pixelout = image_container.GetPixel(x_cont, y_cont);
                            byte r = (byte)((pixelout.R & mask0) | (byte)(r_ & mask1));
                            byte g = (byte)((pixelout.G & mask0) | (byte)(g_ & mask1));
                            byte b = (byte)((pixelout.B & mask0) | (byte)(b_ & mask1));
                            byte a = (byte)((pixelout.A & mask0) | (byte)(a_ & mask1));
                            image_compose.SetPixel(x_cont, y_cont,Color.FromArgb(a,r,g,b) );

                            r_ >>= 1;
                            g_ >>= 1;
                            b_ >>= 1;
                            a_ >>= 1;
                            y_cont = (n+1)/ image_container.Width;
                            x_cont = (n+1) % image_container.Width;
                            pixelout = image_container.GetPixel(x_cont, y_cont);
                            r = (byte)((pixelout.R & mask0) | (byte)(r_ & mask1));
                            g = (byte)((pixelout.G & mask0) | (byte)(g_ & mask1));
                            b = (byte)((pixelout.B & mask0) | (byte)(b_ & mask1));
                            a = (byte)((pixelout.A & mask0) | (byte)(a_ & mask1));
                            image_compose.SetPixel(x_cont, y_cont, Color.FromArgb(a, r, g, b));

                            r_ >>= 1;
                            g_ >>= 1;
                            b_ >>= 1;
                            a_ >>= 1;
                            y_cont = (n + 2) / image_container.Width;
                            x_cont = (n + 2) % image_container.Width;
                            pixelout = image_container.GetPixel(x_cont, y_cont);
                            r = (byte)((pixelout.R & mask0) | (byte)(r_ & mask1));
                            g = (byte)((pixelout.G & mask0) | (byte)(g_ & mask1));
                            b = (byte)((pixelout.B & mask0) | (byte)(b_ & mask1));
                            a = (byte)((pixelout.A & mask0) | (byte)(a_ & mask1));
                            image_compose.SetPixel(x_cont, y_cont, Color.FromArgb(a, r, g, b));

                            r_ >>= 1;
                            g_ >>= 1;
                            b_ >>= 1;
                            a_ >>= 1;
                            y_cont = (n + 3) / image_container.Width;
                            x_cont = (n + 3) % image_container.Width;
                            pixelout = image_container.GetPixel(x_cont, y_cont);
                            r = (byte)((pixelout.R & mask0) | (byte)(r_ & mask1));
                            g = (byte)((pixelout.G & mask0) | (byte)(g_ & mask1));
                            b = (byte)((pixelout.B & mask0) | (byte)(b_ & mask1));
                            a = (byte)((pixelout.A & mask0) | (byte)(a_ & mask1));
                            image_compose.SetPixel(x_cont, y_cont, Color.FromArgb(a, r, g, b));

                            r_ >>= 1;
                            g_ >>= 1;
                            b_ >>= 1;
                            a_ >>= 1;
                            y_cont = (n + 4) / image_container.Width;
                            x_cont = (n + 4) % image_container.Width;
                            pixelout = image_container.GetPixel(x_cont, y_cont);
                            r = (byte)((pixelout.R & mask0) | (byte)(r_ & mask1));
                            g = (byte)((pixelout.G & mask0) | (byte)(g_ & mask1));
                            b = (byte)((pixelout.B & mask0) | (byte)(b_ & mask1));
                            a = (byte)((pixelout.A & mask0) | (byte)(a_ & mask1));
                            image_compose.SetPixel(x_cont, y_cont, Color.FromArgb(a, r, g, b));

                            r_ >>= 1;
                            g_ >>= 1;
                            b_ >>= 1;
                            a_ >>= 1;
                            y_cont = (n + 5) / image_container.Width;
                            x_cont = (n + 5) % image_container.Width;
                            pixelout = image_container.GetPixel(x_cont, y_cont);
                            r = (byte)((pixelout.R & mask0) | (byte)(r_ & mask1));
                            g = (byte)((pixelout.G & mask0) | (byte)(g_ & mask1));
                            b = (byte)((pixelout.B & mask0) | (byte)(b_ & mask1));
                            a = (byte)((pixelout.A & mask0) | (byte)(a_ & mask1));
                            image_compose.SetPixel(x_cont, y_cont, Color.FromArgb(a, r, g, b));

                            r_ >>= 1;
                            g_ >>= 1;
                            b_ >>= 1;
                            a_ >>= 1;
                            y_cont = (n + 6) / image_container.Width;
                            x_cont = (n + 6) % image_container.Width;
                            pixelout = image_container.GetPixel(x_cont, y_cont);
                            r = (byte)((pixelout.R & mask0) | (byte)(r_ & mask1));
                            g = (byte)((pixelout.G & mask0) | (byte)(g_ & mask1));
                            b = (byte)((pixelout.B & mask0) | (byte)(b_ & mask1));
                            a = (byte)((pixelout.A & mask0) | (byte)(a_ & mask1));
                            image_compose.SetPixel(x_cont, y_cont, Color.FromArgb(a, r, g, b));

                            r_ >>= 1;
                            g_ >>= 1;
                            b_ >>= 1;
                            a_ >>= 1;
                            y_cont = (n + 7) / image_container.Width;
                            x_cont = (n + 7) % image_container.Width;
                            pixelout = image_container.GetPixel(x_cont, y_cont);
                            r = (byte)((pixelout.R & mask0) | (byte)(r_ & mask1));
                            g = (byte)((pixelout.G & mask0) | (byte)(g_ & mask1));
                            b = (byte)((pixelout.B & mask0) | (byte)(b_ & mask1));
                            a = (byte)((pixelout.A & mask0) | (byte)(a_ & mask1));
                            image_compose.SetPixel(x_cont, y_cont, Color.FromArgb(a, r, g, b));

                        }
                    }
                }

                if (rbutton_LSB2)
                {
                    LogFile.tolog("LSB2 method started");
                    // Loop through the images pixels to reset color.
                    for (y = 0; y < image_secret.Height; y++)
                    {
                        for (x = 0; x < image_secret.Width; x++)
                        {
                            Color pixelin = image_secret.GetPixel(x, y);

                            byte r_ = pixelin.R;
                            byte g_ = pixelin.G;
                            byte b_ = pixelin.B;
                            byte a_ = pixelin.A;
                            byte mask0 = 0b11111100;
                            byte mask1 = 0b00000011;

                            n = (y * image_secret.Width + x) * coeff;
                            y_cont = n / image_container.Width;
                            x_cont = n % image_container.Width;
                            Color pixelout = image_container.GetPixel(x_cont, y_cont);
                            byte r = (byte)((pixelout.R & mask0) | (byte)(r_ & mask1));
                            byte g = (byte)((pixelout.G & mask0) | (byte)(g_ & mask1));
                            byte b = (byte)((pixelout.B & mask0) | (byte)(b_ & mask1));
                            byte a = (byte)((pixelout.A & mask0) | (byte)(a_ & mask1));
                            image_compose.SetPixel(x_cont, y_cont, Color.FromArgb(a, r, g, b));

                            r_ >>= 2;
                            g_ >>= 2;
                            b_ >>= 2;
                            a_ >>= 2;
                            y_cont = (n + 1) / image_container.Width;
                            x_cont = (n + 1) % image_container.Width;
                            pixelout = image_container.GetPixel(x_cont, y_cont);
                            r = (byte)((pixelout.R & mask0) | (byte)(r_ & mask1));
                            g = (byte)((pixelout.G & mask0) | (byte)(g_ & mask1));
                            b = (byte)((pixelout.B & mask0) | (byte)(b_ & mask1));
                            a = (byte)((pixelout.A & mask0) | (byte)(a_ & mask1));
                            image_compose.SetPixel(x_cont, y_cont, Color.FromArgb(a, r, g, b));

                            r_ >>= 2;
                            g_ >>= 2;
                            b_ >>= 2;
                            a_ >>= 2;
                            y_cont = (n + 2) / image_container.Width;
                            x_cont = (n + 2) % image_container.Width;
                            pixelout = image_container.GetPixel(x_cont, y_cont);
                            r = (byte)((pixelout.R & mask0) | (byte)(r_ & mask1));
                            g = (byte)((pixelout.G & mask0) | (byte)(g_ & mask1));
                            b = (byte)((pixelout.B & mask0) | (byte)(b_ & mask1));
                            a = (byte)((pixelout.A & mask0) | (byte)(a_ & mask1));
                            image_compose.SetPixel(x_cont, y_cont, Color.FromArgb(a, r, g, b));

                            r_ >>= 2;
                            g_ >>= 2;
                            b_ >>= 2;
                            a_ >>= 2;
                            y_cont = (n + 3) / image_container.Width;
                            x_cont = (n + 3) % image_container.Width;
                            pixelout = image_container.GetPixel(x_cont, y_cont);
                            r = (byte)((pixelout.R & mask0) | (byte)(r_ & mask1));
                            g = (byte)((pixelout.G & mask0) | (byte)(g_ & mask1));
                            b = (byte)((pixelout.B & mask0) | (byte)(b_ & mask1));
                            a = (byte)((pixelout.A & mask0) | (byte)(a_ & mask1));
                            image_compose.SetPixel(x_cont, y_cont, Color.FromArgb(a, r, g, b));

                        }
                    }
                }

                else if (rbutton_Gray)
                {
                    LogFile.tolog("Gray method started");
                    if (pictureBox1.Image.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed &&

                        pictureBox2.Image.PixelFormat == System.Drawing.Imaging.PixelFormat.Format1bppIndexed)
                    {
                        image_compose_tmp= image_container.Clone( new Rectangle(0, 0, image_container.Width, image_container.Height),   PixelFormat.Format24bppRgb);
                        int cnt = 0;
                        for ( y=0; y< image_container.Height; y++)
                        {
                            for ( x=0; x<image_container.Width; x++)
                            {
                                if (cnt < image_secret.Height * image_secret.Width)
                                {
                                    Color px_c = image_container.GetPixel(x, y);
                                    Color px_s = image_secret.GetPixel(cnt % image_secret.Width, cnt / image_secret.Width);
                                    byte px =(byte) GrayDecode((ulong)((byte) GrayEncode(px_c.R) |((byte) ((byte)(px_s.R) & 0b0000001) >> 0)));
                                    //if (px != px_c.R) Console.WriteLine(px_c.R.ToString() + " " + px.ToString());
                                    Color px_out = Color.FromArgb(255, px, px, px);
                                    image_compose_tmp.SetPixel(x, y, px_out);
                                }
                                cnt++;
                            }
                        }
                        //image_compose = image_compose_tmp.Clone(new Rectangle(0, 0, image_compose_tmp.Width, image_compose_tmp.Height), PixelFormat.Format8bppIndexed);
                        image_compose = image_compose_tmp.Clone(new Rectangle(0, 0, image_compose_tmp.Width, image_compose_tmp.Height), PixelFormat.Format24bppRgb);

                    }
                    else
                    {
                        string caption = "Ошибка";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show("Метод Грея требует наличия контейнера в формате 8bitGrayScale (Format8bppIndexed) и секрета в формате бинарного изображения (Format1bppIndexed)", caption, buttons);
                    }

                }
               
                this.pictureBox3.Size = image_compose.Size;
                pictureBox3.Image = image_compose;
                pictureBox3.Invalidate();

            }

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            LogFile.tolog("New method selected - LSB1");
            LSB_bits = 1;
            rbutton_LSB = true;
            rbutton_LSB2 = false;
            rbutton_Gray = false;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            LogFile.tolog("New method selected - Gray");
            rbutton_Gray = true;
            rbutton_LSB = false;
            rbutton_LSB2 = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            LogFile.tolog("New method selected - LSB2");
            LSB_bits = 2;
            rbutton_LSB = false;
            rbutton_LSB2 = true;
            rbutton_Gray = false;
        }

        private void ImgComposePlus_Click(object sender, EventArgs e)
        {
            LogFile.tolog("Composed image enlarged");
            pictureBox3.Width *= 2;
            pictureBox3.Height *= 2;
            pictureBox3.Refresh();

        }

        private void ImgComposeMinus_Click(object sender, EventArgs e)
        {
            LogFile.tolog("Composed image reduced");
            pictureBox3.Width /= 2;
            pictureBox3.Height /= 2;
            pictureBox3.Refresh();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void AnalyseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogFile.tolog("Analyse form created");
            Стегоанализ AnalyseForm= new Стегоанализ(); 
            AnalyseForm.Show();

        }

        private void CodingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogFile.tolog("Application Finished");
            RegistryKey currentUserKey = Registry.CurrentUser;
            if (currentUserKey != null)
            {
                currentUserKey.DeleteSubKeyTree("Stego_App");
            }
            currentUserKey.Close();
            LogFile.tolog("Application Finished");
            Application.Exit();
        }
    }
}
