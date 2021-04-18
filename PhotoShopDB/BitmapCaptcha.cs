using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PhotoShopDB
{
    class BitmapCaptcha : Captcha
    {

        public BitmapCaptcha(int len, int wid, int hei)
        {
            width = wid;
            height = hei;
            count = len;
        }
        public BitmapCaptcha(int len) : this(len, 75, 50) { }
        public BitmapCaptcha() : this(5) { }

        int width;
        int height;
        public BitmapImage CaptchaImage { get; set; }
        public override void Generate()
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(width, height);

            ////Вычислим позицию текста
            //int Xpos = rnd.Next(0, width-10);
            //int Ypos = rnd.Next(5, height - 10);
            int Xpos = 0;
            int Ypos = rnd.Next(0, height - 20);

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);

            //Пусть фон картинки будет серым
            g.Clear(Color.White);

            //Сгенерируем текст
            CaptchaText = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < count; ++i)
                CaptchaText += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(CaptchaText,
                         new Font("Ink Free", 15),
                         PickBrush(),
                         new PointF(Xpos, Ypos));

            //Добавим немного помех
            /////Линии из углов
            g.DrawLine(Pens.Black,
                       new Point(0, 0),
                       new Point(width - 1, height - 1));
            g.DrawLine(Pens.Black,
                       new Point(0, height - 1),
                       new Point(width - 1, 0));
            ////Белые точки
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    if (rnd.Next() % 10 == 0)
                        result.SetPixel(i, j, Color.FromArgb(255, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));

            CaptchaImage = ToBitmapImage(result);
        }
        public override bool Check(string inputString)
        {
            return base.Check(inputString);
        }
        private Brush PickBrush()
        {
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }
        public BitmapImage ToBitmapImage(Bitmap bmp)
        {
            using (var memory = new MemoryStream())
            {
                bmp.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}
