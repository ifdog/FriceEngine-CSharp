﻿

using System.Drawing;
using System.IO;
using System.Net;
using FriceEngine.Object;

namespace FriceEngine.Resource
{
	public interface IFResource
	{
	}

	public class ColorResource
	{
		public Color Color;

		public ColorResource(Color color)
		{
			Color = color;
		}

		public ColorResource(int argb)
		{
			Color = Color.FromArgb(argb);
		}

		public ColorResource(string name)
		{
			Color = Color.FromName(name);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ColorResource)) return false;
			return ((ColorResource) obj).Color.Equals(Color);
		}

		protected bool Equals(ColorResource other)
		{
			return Color.Equals(other.Color);
		}

		public override int GetHashCode()
		{
			return Color.GetHashCode();
		}

	    public static ColorResource From(int argb) => new ColorResource(argb);
	    public static ColorResource From(Color color) => new ColorResource(color);

		public static readonly ColorResource Blue = new ColorResource(Color.Blue);
		public static readonly ColorResource Red = new ColorResource(Color.Red);
		public static readonly ColorResource Green = new ColorResource(Color.Green);
		public static readonly ColorResource Pink = new ColorResource(Color.Pink);
		public static readonly ColorResource Yellow = new ColorResource(Color.Yellow);
		public static readonly ColorResource Black = new ColorResource(Color.Black);
		public static readonly ColorResource White = new ColorResource(Color.White);
		public static readonly ColorResource Wheat = new ColorResource(Color.Wheat);
		public static readonly ColorResource Orange = new ColorResource(Color.Orange);
		public static readonly ColorResource Gray = new ColorResource(Color.Gray);
        public static readonly ColorResource DrakGray = new ColorResource(Color.DarkGray);
		public static readonly ColorResource ShitYellow = new ColorResource(Color.Gray);
		public static readonly ColorResource IntelliJIdea黑 = new ColorResource(0x2B2B2B);
		public static readonly ColorResource Colorless = new ColorResource(0);
		public static readonly ColorResource 小埋色 = new ColorResource(0xFFAC2B);
		public static readonly ColorResource 基佬紫 = new ColorResource(0x781895);
		public static readonly ColorResource 吾王蓝 = Blue;
		public static readonly ColorResource 教主黄 = Yellow;
		public static readonly ColorResource 宝强绿 = Green;
		public static readonly ColorResource 冰封绿 = 宝强绿;
		public static readonly ColorResource 高坂穗乃果 = Orange;
		public static readonly ColorResource 如果奇迹有颜色那么一定是橙色 = 高坂穗乃果;
		public static readonly ColorResource 南小鸟 = Gray;
		public static readonly ColorResource 园田海未 = 吾王蓝;
		public static readonly ColorResource 洵濑绘理 = new ColorResource(0x0FFFFF);
		public static readonly ColorResource 星空凛 = 教主黄;
		public static readonly ColorResource 西木野真姬 = Red;
		public static readonly ColorResource 东条希 = 基佬紫;
		public static readonly ColorResource 小泉花阳 = new ColorResource(0x1BA61C);
		public static readonly ColorResource 矢泽妮可 = Pink;
		public static readonly ColorResource 屎黄色 = ShitYellow;
		public static readonly ColorResource 天依蓝 = new ColorResource(0x66CCFF);
		public static readonly ColorResource 清真绿 = new ColorResource(0x038B43);
		public static readonly ColorResource 如果真爱有颜色那么一定是黄色 = 教主黄;
		public static readonly ColorResource 杀老师 = 如果真爱有颜色那么一定是黄色;
		public static readonly ColorResource 潮田渚 = 园田海未;
		public static readonly ColorResource 茅野枫 = 冰封绿;
		public static readonly ColorResource 赤羽业 = 西木野真姬;
	}

    public static class ImageResource
    {
        public static ImageObject FromFile(string path,double x,double y,int width = -1,int height = -1)
        {
            ImageObject img = new ImageObject(new Bitmap(path, true), x, y);
            if (width > 0) img.Width = width;
            if (height > 0) img.Height = height;
            return img;
        }

        public static ImageObject FromWeb(string url, double x, double y,int width =-1,int height =-1)
        {
            HttpWebResponse r = WebRequest.Create(url).GetResponse() as HttpWebResponse;
            using (Stream imageStream = r?.GetResponseStream())
            {
                ImageObject img = imageStream == null ? null : new ImageObject(new Bitmap(imageStream, true), x, y);
                if (width > 0 && img != null) img.Width = width;
                if (height > 0 && img != null) img.Height = height;
                return img;
            }
        }
    }
}
