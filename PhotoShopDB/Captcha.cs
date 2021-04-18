using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShopDB
{
    class Captcha
    {
        protected int count;
        public string CaptchaText { get; protected set; } = "";
        public Captcha(int symbolCount)
        {
            if (symbolCount <= 0) throw new ArgumentException();
            count = symbolCount;
        }

        public Captcha() : this(5)
        { }

        public virtual void Generate()
        {
            Random rand = new Random();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                str.Append((char)rand.Next(48,123));
            }
            CaptchaText = str.ToString();
        }

        public virtual bool Check(string inputString)
        {
            return inputString.CompareTo(CaptchaText)==0;
        }
    }
}
