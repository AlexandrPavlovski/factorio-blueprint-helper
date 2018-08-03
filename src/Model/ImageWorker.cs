using ImageProcessor.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model
{
    public class ImageWorker
    {
        private DirectBitmap dbmp;
        private string _filePath;

        public FastBitmap Bitmap { get; private set; }

        public ImageWorker(string filePath)
        {
            _filePath = filePath;
            Bitmap = new FastBitmap(Image.FromFile(filePath));
            dbmp = new DirectBitmap(Bitmap.Width, Bitmap.Height);
        }

        public void RoundToLampColors()
        {
            for (int x = 0; x < Bitmap.Width; x++)
                for (int y = 0; y < Bitmap.Height; y++)
                {
                    Color newPix = GetClosestLampColor(x, y);
                    dbmp.SetPixel(x, y, newPix);
                }
        }

        public Color GetClosestLampColor(int x, int y)
        {
            return GetClosestLampColor(Bitmap.GetPixel(x, y));
        }

        public Color GetClosestLampColor(Color pixel)
        {
            Color closest = Color.Transparent;
            float minDist = float.MaxValue;

            foreach (var col in LampColors.AllColors)
            {
                int r = pixel.R - col.R;
                int g = pixel.G - col.G;
                int b = pixel.B - col.B;

                int dSq = r * r + g * g + b * b;
                if (dSq < minDist)
                {
                    minDist = dSq;
                    closest = col;
                }
            }

            return closest;
        }

        public void SaveOnDisk()
        {
            //((Image)_bitmap).Save(_filePath.Substring(0, _filePath.Length - 4) + "_edited.bmp", ImageFormat.Bmp);
            dbmp.Bitmap.Save(_filePath.Substring(0, _filePath.Length - 4) + "_edited.bmp", ImageFormat.Bmp);
        }
    }

    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
