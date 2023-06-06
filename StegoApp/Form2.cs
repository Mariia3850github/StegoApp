using Microsoft.Win32;
using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace stego_app
{
    public partial class Стегоанализ : Form
    {
        Bitmap image;
        Bitmap histo_freq;
        Bitmap histo_hi2;
        const int blocksize = 4;
        //readonly int[] maskplus = { 0, 1,1,0 };
        //readonly int[] maskminus = { 0,-1,-1,0 };
        string fname = "";

        public Стегоанализ(string name = "")
        {
           
            InitializeComponent();
            if (name != "")
            {
                fname = name;
                try
                {
                    image = new Bitmap(fname);
                    this.pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    _ = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static double ChiSquarePval(double x, int df)
        {
            // x = a computed chi-square value.
            // df = degrees of freedom.
            // output = prob. x value occurred by chance.
            // ACM 299.
            if (x <= 0.0 || df < 1)
                throw new Exception("Bad arg in ChiSquarePval()");
            double y = 0.0;
            double c;
            bool even; // Is df even?
            double a = 0.5 * x;
            if (df % 2 == 0) even = true; else even = false;
            if (df > 1) y = Exp(-a); // ACM update remark (4)
            double s;
            if (even == true) s = y;
            else s = 2.0 * Gauss(-Math.Sqrt(x));
            if (df > 2)
            {
                x = 0.5 * (df - 1.0);
                double z;
                if (even == true) z = 1.0; else z = 0.5;
                double ee;
                if (a > 40.0) // ACM remark (5)
                {
                    if (even == true) ee = 0.0;
                    else ee = 0.5723649429247000870717135;
                    c = Math.Log(a); // log base e
                    while (z <= x)
                    {
                        ee = Math.Log(z) + ee;
                        s += Exp(c * z - a - ee); // ACM update remark (6)
                        z++;
                    }
                    return s;
                } // a > 40.0
                else
                {
                    if (even == true) ee = 1.0;
                    else
                        ee = 0.5641895835477562869480795 / Math.Sqrt(a);
                    c = 0.0;
                    while (z <= x)
                    {
                        ee *= (a / z); // ACM update remark (7)
                        c += ee;
                        z++;
                    }
                    return c * y + s;
                }
            } // df > 2
            else
            {
                return s;
            }
        } // ChiSquarePval()
        private static double Exp(double x)
        {
            //if (x < -40.0) // ACM update remark (8)
            //    return 0.0;
            //else
                return Math.Exp(x);
        }
        public static double Gauss(double z)
        {
            // input = z-value (-inf to +inf)
            // output = p under Normal curve from -inf to z
            // ACM Algorithm #209
            double y; // 209 scratch variable
            double p; // result. called ‘z’ in 209
            double w; // 209 scratch variable
            if (z == 0.0)
                p = 0.0;
            else
            {
                y = Math.Abs(z) / 2;
                if (y >= 3.0)
                {
                    p = 1.0;
                }
                else if (y < 1.0)
                {
                    w = y * y;
                    p = ((((((((0.000124818987 * w
                      - 0.001075204047) * w + 0.005198775019) * w
                      - 0.019198292004) * w + 0.059054035642) * w
                      - 0.151968751364) * w + 0.319152932694) * w
                      - 0.531923007300) * w + 0.797884560593) * y
                      * 2.0;
                }
                else
                {
                    y -= 2.0;
                    p = (((((((((((((-0.000045255659 * y
                      + 0.000152529290) * y - 0.000019538132) * y
                      - 0.000676904986) * y + 0.001390604284) * y
                      - 0.000794620820) * y - 0.002034254874) * y
                     + 0.006549791214) * y - 0.010557625006) * y
                     + 0.011630447319) * y - 0.009279453341) * y
                     + 0.005353579108) * y - 0.002141268741) * y
                     + 0.000535310849) * y + 0.999936657524;
                }
            }
            if (z > 0.0)
                return (p + 1.0) / 2;
            else
                return (1.0 - p) / 2;
        } // Gauss()

        public static double ChiFromFreqs(int[] observed,  double[] expected)
        {
            double sum = 0.0;
            for (int i = 0; i < observed.Length; ++i)
            {
                sum += ((observed[i] - expected[i]) *
                  (observed[i] - expected[i])) / expected[i];
            }
            return sum;
        }

        public static double[] ExpectedFromProbs(double[] probs, int N)
        {
            double[] expected = new double[probs.Length];
            for (int i = 0; i < probs.Length; ++i)
                expected[i] = probs[i] * N;
            return expected;
        }
        public static double ChiFromProbs(int[] observed, double[] probs)
        {
            int n = observed.Length;
            int sumObs = 0;
            for (int i = 0; i < n; ++i)
                sumObs += observed[i];
            double[] expected = ExpectedFromProbs(probs, sumObs);
            return ChiFromFreqs(observed, expected);
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonLoad_Click(object sender, EventArgs e)
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
                    LogFile.tolog("Open File for analys" + open_dialog.FileName);
                    image = new Bitmap(open_dialog.FileName);
                    this.pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();

                    RegistryKey currentUserKey = Registry.CurrentUser;
                    RegistryKey helloKey = currentUserKey.OpenSubKey("Stego_App", true);
                    if (helloKey == null)
                    {
                        helloKey = currentUserKey.CreateSubKey("Stego_App", true);
                    }
                    var w=Convert.ToInt32(helloKey.GetValue("pic_num",0));
                    w++;
                    helloKey.SetValue("pic_num", w);
                    string fname = open_dialog.FileName;
                    string s_num=w.ToString();
                    helloKey.SetValue("picname"+s_num, fname);
                    helloKey.Close();


                }
                catch
                {
                    _ = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private double Func(double x)
        {
            return Math.Exp(-x / 2) * Math.Pow(x, 127);
            //return (Math.Pow(x, 253) * Math.Exp(-x / 2)) / (Math.Pow(2, 127) * fact(126));
        }

        private double Integral(double a, double b)
        {
            const int N = 100;
            double h = (b - a) / N;
            double x = a;
            double s = 0;
            double P = 1.0 / 6.42607e250;
            for (int i=0; i<N-1; i++)
            {
                s += h * Func(x+h)*P;
                x += h;
            }
            return s;
        }
        private double Hi2_128_sol( int[] arr,int offset)
        {
            const int N = 128;
            double hi2=0;
            double[] ln = new double[N];
            double[] ln_ = new double[N];

            for (int k = 0; k < N; k++)
            {
                ln[k] = (double)arr[2 * k+offset];
                ln_[k] = ((double)arr[2 * k+offset] + (double) arr[2 * k + 1+offset]) / 2.0;
            }
            for (int i = 0; i < N; i++)
            {
                if (ln_[i] != 0)
                  hi2 += (ln[i] - ln_[i])* (ln[i] - ln_[i]) / (ln_[i]);
               //     hi2 += (ln[i] - ln_[i]) * (ln[i] - ln_[i]) / (ln[i]>ln_[i]?ln[i]:ln_[i]);
            }
            //for (int i=0; i<N; i++)
            //{
            //    Console.WriteLine(i.ToString()+ "  "+ ln[i].ToString()+"    "+ln_[i].ToString()+"      "+ arr[2 * i + offset]+" "+ arr[2 * i + 1 + offset] +
            //        "     "+ ((ln[i] - ln_[i]) * (ln[i] - ln_[i]) / (ln[i] > ln_[i] ? ln[i] : ln_[i])).ToString());
            //}
            //Console.WriteLine(hi2+ "\n");
            return hi2;
        }
        private double Hi2_256_sol(int[] arr,int offset)
        {
            const int N = 256;
            double hi2 = 0;
            double[] ln = new double[N];
            double[] ln_ = new double[N];

            for (int k = 0; k < N-1; k++)
            {
                ln[k] = (double)arr[k+offset];
                ln_[k] = ((double)arr[k+offset] + arr[k + 1+offset]) / 2.0;
            }
           
            for (int i = 0; i < 256; i++)
            {
                if (ln[i] != 0)
                    hi2 += Math.Pow(ln[i] - ln_[i], 2) / (ln_[i]);
            }
            int[] l_orig = new int[N];
            for (int i= 0; i<N; i++) {
                l_orig[i]= arr[i];
            }
            return hi2;
        }

        //******************************************
        private int Flip ( byte c, int mask=0)
        {
            switch (mask)
            {
                case 0:
                    return c;
                case 1:
                    return (c ^ 1);
                case -1:
                    return ((c + 1) ^ 1 - 1);
            }
            return (c);
        }

        private int Disc_func( byte[] block,int k, int[] mask)
        {
            int[] flipped=new int[blocksize];
            for (int i = 0; i < blocksize; ++i)
            {
                flipped[i] = Flip(block[i+k], mask[i]);
            }
            int result = 0;
            for (int i = 0; i < blocksize - 1; ++i)
            {
                if (flipped[i] < flipped[i + 1])
                {
                    result += (flipped[i + 1] - flipped[i]);
                }
                else
                {
                    result += (flipped[i] - flipped[i + 1]);
                }
            }
            return result;
        }
        
        private (int,int,int) Count_rs(Bitmap image,int[] mask)
        {
            int r = 0;
            int s = 0;
            int u = 0;
            for (int color = 0; color < 3; ++color)
            {
                int i = 0;
                int size = image.Height * image.Width;
                byte[] data = new byte[size];

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color pixelin = image.GetPixel(x, y);
                        switch (color)
                        {
                            case 0:
                                data[i++] = pixelin.R;
                                break;
                            case 1:
                                data[i++] = pixelin.G;
                                break;
                            case 2:
                                data[i++] = pixelin.B;
                                break;
                        }
                    }

                }
                for (int k = 0; k + blocksize <= size; k += blocksize)
                {
                    int[] mask0 = { 0, 0, 0, 0 };
                    int f_original = Disc_func(data,k,mask0);
                    int f_flipped = Disc_func(data,k, mask);
                    if (f_flipped > f_original) r++;
                    if (f_flipped < f_original) s++;
                    if (f_flipped == f_original) u++;
                }
            }
            return (r, s, u);
 
        }
        public double Rs_attack(int[] maskplus, int[] maskminus)
        {
            Rectangle cloneRect = new Rectangle(0, 0, image.Width,image.Height);
            System.Drawing.Imaging.PixelFormat format =
                image.PixelFormat;
            Bitmap imgRS = image.Clone(cloneRect, format);

            (int rplus0,int splus0,int uplus0) =Count_rs(imgRS, maskplus);
            (int rminus0, int sminus0, int uminus0) = Count_rs(imgRS, maskminus);
            //RSattack2.Text = "R+: " + Convert.ToString(rplus0) + ", S+: " + Convert.ToString(splus0) + ", U+: " + Convert.ToString(uplus0);
            //RSattack3.Text = "R-: " + Convert.ToString(rminus0) + ", S-: " + Convert.ToString(sminus0) + ", U-: " + Convert.ToString(uminus0);

            for (int j = 0; j < image.Height; j++)
                for (int i = 0; i < image.Width; i++)
                {
                    Color pixelout = image.GetPixel(i, j);
                    //byte a_ = pixelout.A;
                    //a_ ^= 1;
                    byte r_ = pixelout.R;
                    r_ ^= 1;
                    byte g_ = pixelout.G;
                    g_ ^= 1;
                    byte b_ = pixelout.B;
                    b_ ^= 1;
                    //if (((uint)m & 1) == 1)
                    //    m--;
                    //else
                    //    m++;
                    //imgRS.SetPixel(i, j, Color.FromArgb(a_,r_,g_,b_));
                    imgRS.SetPixel(i, j, Color.FromArgb(pixelout.A, r_, g_, b_));

                }

            (int rplus1, int splus1, int uplus1) = Count_rs(imgRS, maskplus);
            (int rminus1, int sminus1, int uminus1) = Count_rs(imgRS, maskminus);
            //RSattack4.Text = "R+: " + Convert.ToString(rplus1) + ", S+: " + Convert.ToString(splus1) + ", U+: " + Convert.ToString(uplus1);
            //RSattack5.Text = "R-: " + Convert.ToString(rminus1) + ", S-: " + Convert.ToString(sminus1) + ", U-: " + Convert.ToString(uminus1);

            double d0=rplus0 - splus0;
            double d1=rplus1 - splus1;
            double dminus0 = rminus0 - sminus0;
            double dminus1 = rminus1 - sminus1;
            double a = 2 * (d0 + d1);
            double b = dminus0 - dminus1 - d1 - 3 * d0;
            double c=d0 - dminus0;
            double x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            double x2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            if (Math.Abs(x1) > Math.Abs(x2))
                x1 = x2;

            double p = x1 / (x1 - 0.5);
            return p;
            //labelP.Text = "P= "+p.ToString();

        }
        //******************************************
        private void ButtonAnalys_Click(object sender, EventArgs e)
        {
            const int SIZE = 256 * 3;
            int X = image.Width;
            int Y = image.Height;
            int[] arr = new int[SIZE];
            int[] arr_str = new int[SIZE];
            double[] hi2_str = new double[Y*3];
            LogFile.tolog("Start Hi-square analyse");
            Array.Clear(arr, 0, SIZE);
            Array.Clear(arr_str, 0, SIZE);
            histo_freq = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            pictureBox3.Width = Y * 3 + 50;
            histo_hi2=new Bitmap(pictureBox3.Width+1, pictureBox3.Height+1);

            labelP.Visible = false;
            labelP1.Visible = false;
            labelP2.Visible = false;
            labelP3.Visible = false;
            pictureBox2.Image = histo_freq;
            pictureBox3.Image = histo_hi2;
            for (int j = 0; j < Y; j++)
            {
                for (int i = 0; i < X; i++)
                {
                    Color pixelout = image.GetPixel(i, j);
                    //arr[pixelout.A]++;
                    arr[pixelout.R]++;
                    arr[pixelout.G + 256]++;
                    arr[pixelout.B + 512]++;
                }
            }
            for (int j = 0; j < Y; j++)
            {
                Array.Clear(arr_str, 0, SIZE);
                for (int i = 0; i < X; i++)
                {
                    Color pixelout = image.GetPixel(i, j);
                    //arr[pixelout.A]++;                    
                    arr_str[pixelout.R]++;
                    arr_str[pixelout.G + 256]++;
                    arr_str[pixelout.B + 512]++;
                }
                hi2_str[j+0] = Hi2_128_sol(arr_str, 0);
                hi2_str[j+Y] = Hi2_128_sol(arr_str, 256);
                hi2_str[j+2*Y] = Hi2_128_sol(arr_str, 512);
            }

            int base0 = (pictureBox2.Height - 20);
            int max = arr[0];
            for (int i = 1; i < SIZE; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            double scale = (double)max / base0; 
            pictureBox2.BackColor = Color.Black;

            int base1 = (pictureBox3.Height - 20);
            int max_hi2 = Convert.ToInt32(hi2_str[0]);
            for (int i = 1; i < Y*3; i++)
            {
                if (hi2_str[i] > max_hi2)
                    max_hi2 = Convert.ToInt32(hi2_str[i]);
            }
            double scale_hi2 = (double)max_hi2 / base1;
            pictureBox3.BackColor = Color.Black;

            //double hi2 = Hi2_128_sol(arr,0);
            //double hi2_2=Hi2_256_sol(arr,0);
            //double S = Integral(0,hi2);
            //double P = 1.0 -  S;
            //double PP = ChiSquarePval(hi2, 255);

            //hi2_Red.Text = "Вероятность наличия вложения в канале Red = " + (PP).ToString();
            //hi2_Red.Text = "Значение Chi2 по каналу Red = " + (hi2).ToString();



            //hi2 = Hi2_128_sol(arr,256);
            //S = Integral(0, hi2);
            //P = 1.0 - S;
            //PP = ChiSquarePval(hi2, 255);
            //hi2_Green.Text = "Вероятность наличия вложения в канале Green = " + (PP).ToString();
            //hi2_Green.Text = "Значение Chi2 по каналу Green = " + (hi2).ToString();

            //hi2 = Hi2_128_sol(arr,512);
            //S = Integral(0, hi2);
            //P = 1.0 - S; Integral(0, hi2);
            //PP = ChiSquarePval(hi2, 255);
            //hi2_Blue.Text = "Вероятность наличия вложения в канале Blue = " + (PP).ToString();
            //hi2_Blue.Text = "Значение Chi2 по каналу Blue = " + (hi2).ToString();

            for (int i = 0; i < SIZE; i++)
            {
                histo_freq.SetPixel(i + 10, base0, Color.Yellow);
                var color=(i<256)?Color.Red: (i<512)?Color.LightGreen: (i<768)? Color.Blue: Color.Yellow;
                //var color = (i < 256) ? Color.Red: (i < 512) ? Color.Green: Color.Blue;
                //var color = Color.White;
                histo_freq.SetPixel(i + 10,   base0+1 - (int)(arr[i] / scale), color);
                histo_freq.SetPixel(i + 10-1, base0+1 - (int)(arr[i] / scale), color);
                histo_freq.SetPixel(i + 10+1, base0+1 - (int)(arr[i] / scale), color);
                histo_freq.SetPixel(i + 10,   base0+1 - (int)(arr[i] / scale)+1, color);
                histo_freq.SetPixel(i + 10,   base0+1 - (int)(arr[i] / scale)-1, color);
            }
            for (int i = 0; i < Y*3; i++)
            {
                histo_hi2.SetPixel(i + 10, base1, Color.Yellow);
                var color = (i < Y) ? Color.Red : (i < 2*Y) ? Color.LightGreen : (i < 3*Y) ?  Color.Blue: Color.Yellow;
                //var color = (i < 256) ? Color.Red: (i < 512) ? Color.Green: Color.Blue;
                //var color = Color.White;
                histo_hi2.SetPixel(i + 10, base1 + 1 - (int)(hi2_str[i] / scale_hi2), color);
                histo_hi2.SetPixel(i + 10 - 1, base1 + 1 - (int)(hi2_str[i] / scale_hi2), color);
                histo_hi2.SetPixel(i + 10 + 1, base1 + 1 - (int)(hi2_str[i] / scale_hi2), color);
                histo_hi2.SetPixel(i + 10, base1 + 1 - (int)(hi2_str[i] / scale_hi2) + 1, color);
                if ((base1 + 1 - (int)(hi2_str[i] / scale_hi2) - 1) >0 )
                        histo_hi2.SetPixel(i + 10, base1 + 1 - (int)(hi2_str[i] / scale_hi2) - 1, color);
            }
            LogFile.tolog("Ending Hi-square analyse. Begin RS-analyse");
            int[] mplus = { 0, 1, 1, 0 };
            int[] mminus = { 0, -1, -1, 0 };
            double p= Rs_attack(mplus,mminus);
            labelP.Visible = true;
            labelP1.Visible = true;
            labelP2.Visible = true;
            labelP3.Visible = true;
            labelP.Text = "P (0,1,1,0) = " + p.ToString();
            int[] mplus1 = { 1,0,0,1};
            int[] mminus1 = { -1,0,0,-1 };
            p = Rs_attack(mplus1, mminus1);
            labelP1.Text = "P (1,0,0,1) = " + p.ToString();
            int[] mplus2 = { 1, 0, 1, 0 };
            int[] mminus2 = { -1, 0, -1, 0 };
            p = Rs_attack(mplus2, mminus2);
            labelP2.Text = "P (1,0,1,0) = " + p.ToString();
            int[] mplus3 = { 0, 1, 0, 1 };
            int[] mminus3 = { 0, -1, 0, 1 };
            p = Rs_attack(mplus3, mminus3);
            labelP3.Text = "P (0,1,0,1) = " + p.ToString();
            LogFile.tolog("Ending RS-analyse");
        }

        
    }
}
