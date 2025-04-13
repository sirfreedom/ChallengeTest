using System;
using System.Drawing;
using System.IO;

namespace ImageHelper
{
    public class ImageHelper
    {


		public string ImageToBase64(Image image)
		{
			var imageStream = new MemoryStream();
			try
			{
				image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Bmp);
				imageStream.Position = 0;
				var imageBytes = imageStream.ToArray();
				var ImageBase64 = Convert.ToBase64String(imageBytes);
				return ImageBase64;
			}
			catch (Exception)
			{
				return "Error converting image to base64!";
			}
		}


		public byte[] StreamToByte(Stream oStream, int Lenght)
		{
			byte[] b;

			using (BinaryReader br = new BinaryReader(oStream))
			{
				b = br.ReadBytes(Lenght);
			}
			return b;
		}


		public string StreamToBase64(Stream oStream, int FileLenght)
		{
			string sBase64 = string.Empty;
			byte[] fileInBytes = new byte[FileLenght];
			using (BinaryReader theReader = new BinaryReader(oStream))
			{
				fileInBytes = theReader.ReadBytes(FileLenght);
			}
			sBase64 = Convert.ToBase64String(fileInBytes);
			return sBase64;
		}

		public byte[] ImageToByteArray(Image imageIn)
		{
			using (var ms = new MemoryStream())
			{
				imageIn.Save(ms, imageIn.RawFormat);
				return ms.ToArray();
			}
		}

		public Image resizeImage(Image img, int width, int height)
		{
			Bitmap b = new Bitmap(width, height);
			Graphics g = Graphics.FromImage((Image)b);

			g.DrawImage(img, 0, 0, width, height);
			g.Dispose();

			return (Image)b;
		}

		public Image StreamToImage(Stream stream) 
		{
			Image oImage;
			try
			{
				oImage = Bitmap.FromStream(stream);
			}
			catch (Exception ex) {
				throw ex;
			}
			return oImage;
		}


	}
}
