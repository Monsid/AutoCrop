using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCrop
{
    public partial class Form1 : Form
    {
        int startHue = 0;
        float startSat = 0;
        float startBright = 0;
        float endHue = 360;
        float endSat = 1;
        float endBright = 1;
        List<string> imagesInFolder = new List<string>();
        string outputFolderPath = "";
        int imageCount;

        Bitmap backup;
        public Form1()
        {
            InitializeComponent();
            textBoxHue.Text = "" + 360;
            textBoxSat.Text = "" + 1;
            textBoxBright.Text = "" + 1;
            scrollEndHue.Value = 91;
            scrollEndSat.Value = 91;
            scrollEndBright.Value = 91;
        }
        public class PostColourImage
        {
            Bitmap colouredImage;
            int firstX;
            int lastX;
            int firstY;
            int lastY;
            List<int> xList = new List<int>();
            List<int> yList = new List<int>();

            public Bitmap ColouredImage { get => colouredImage; set => colouredImage = value; }
            public int FirstX { get => firstX; set => firstX = value; }
            public int LastX { get => lastX; set => lastX = value; }
            public int FirstY { get => firstY; set => firstY = value; }
            public int LastY { get => lastY; set => lastY = value; }
            public List<int> XList { get => xList; set => xList = value; }
            public List<int> YList { get => yList; set => yList = value; }

        }


        /*Note unsafe keyword*/
        public unsafe PostColourImage ThresholdUA(PostColourImage _image)
        {
            Bitmap b = new Bitmap(_image.ColouredImage);//note this has several overloads, including a path to an image

            BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.ColouredImage.Width, _image.ColouredImage.Height), ImageLockMode.ReadWrite, b.PixelFormat);

            int bitsPerPixel = Image.GetPixelFormatSize(bData.PixelFormat);

            /*This time we convert the IntPtr to a ptr*/
            byte* scan0 = (byte*)bData.Scan0.ToPointer();

            for (int i = 0; i < bData.Height; ++i)
            {
                for (int j = 0; j < bData.Width; ++j)
                {
                    byte* data = scan0 + i * bData.Stride + j * (byte)bitsPerPixel / 8;

                    int blue = data[0];
                    int green = data[1];
                    int red = data[2];

                    // calculate new pixel value
                    var hue = getHue(red, green, blue);
                    var saturation = getSaturation(red, green, blue);
                    var luminance = getLuminance(red, green, blue);

                    if (hue > startHue && saturation > startSat && luminance > startBright)
                    {
                        if (hue < endHue && saturation < endSat && luminance < endBright)
                        {
                            data[2] = 255;
                            data[1] = 0;
                            data[0] = 0;
                            _image.XList.Add(j);
                            _image.YList.Add(i);
                        }
                    }
                    //data is a pointer to the first byte of the 3-byte color data
                }
            }
            try
            {
                _image.XList.Sort(); _image.YList.Sort();
                _image.FirstX = _image.XList[0];
                _image.FirstY = _image.YList[0];
                _image.LastX = _image.XList[_image.XList.Count - 1] - _image.FirstX;
                _image.LastY = _image.YList[_image.YList.Count - 1] - _image.FirstY;
                b.UnlockBits(bData);
                _image.ColouredImage = b;
                return _image;
            }
            catch
            {
                return _image;
            }
        }


        public double getLuminance(double red, double green, double blue)
        {//http://www.niwa.nu/2013/05/math-behind-colorspace-conversions-rgb-hsl/

            red = red / 255;
            green = green / 255;
            blue = blue / 255;

            var min = Math.Min(red, green);
            min = Math.Min(min, blue);

            var max = Math.Max(red, green);
            max = Math.Max(max, blue);

            var luminanceValue = (max + min) / 2;
            return luminanceValue;
        }

        public double getSaturation(double red, double green, double blue)
        {//http://www.niwa.nu/2013/05/math-behind-colorspace-conversions-rgb-hsl/

            red = red / 255;
            green = green / 255;
            blue = blue / 255;

            var min = Math.Min(red, green);
            min = Math.Min(min, blue);

            var max = Math.Max(red, green);
            max = Math.Max(max, blue);

            var luminanceValue = (max + min) / 2;
            var saturation = 0.0;
            if (luminanceValue < 0.5)
            {
                saturation = (max - min) / (max + min);
            }
            else if (luminanceValue > 0.5)
            {
                saturation = (max - min) / (2.0 - max + min);
            }

            return saturation;
        }

        public double getHue(double red, double green, double blue)
        {//http://www.niwa.nu/2013/05/math-behind-colorspace-conversions-rgb-hsl/
            double theHue = 0.0;

            red = red / 255;
            green = green / 255;
            blue = blue / 255;


            var min = Math.Min(red, green);
            min = Math.Min(min, blue);
            var max = Math.Max(red, green);
            max = Math.Max(max, blue);

            if (max == red)
            {
                theHue = (green - blue) / (max - min);
            }
            else if (max == green)
            {
                theHue = 2.0 + (blue - red) / (max - min);
            }
            else if (max == blue)
            {
                theHue = 4.0 + (red - green) / (max - min);
            }
            theHue = theHue * 60;
            if (theHue < 0)
            {
                theHue = theHue + 360;
            }
            return theHue;
        }




        private PostColourImage ColourImage(Bitmap workingImg)
        {

            /*
             * take the colourisation and use to draw a rectangle.
             * find pixel by colour function if possible if not make one with for loop
             * start x will be lowest x found(startpos) start y will be lowest y found
             * width will be highest x found - startx , height will be highest y value - starty
             */
            PostColourImage retImage = new PostColourImage();
            List<int> xList = new List<int>();
            List<int> yList = new List<int>();

            //loop  each pixel of image in picturebox checcking for pixel that meets a set condition according to params, if it meets colour it red for now.
            if (workingImg.Width > 1200 || workingImg.Height > 1000)
            {
                var newwidth = 0;
                var newheight = 0;
                if (workingImg.Width > 2800 || workingImg.Height > 2000)
                {
                    newwidth = workingImg.Width / 4;
                    newheight = workingImg.Height / 4;
                }
                newwidth = workingImg.Width / 2;
                newheight = workingImg.Height / 2;
                workingImg = new Bitmap(workingImg, new Size(newwidth, newheight));
                workingImg.SetResolution(50, 50);
                retImage.ColouredImage = new Bitmap(workingImg);
            }
            retImage.ColouredImage = new Bitmap(workingImg);
            //retImage.ProcessUsingLockbits(backup,startHue,startSat,startBright,endHue,endSat, endBright);

            retImage = ThresholdUA(retImage);

            //retImage.ProcessUsingLockbits(retImage.ColouredImage, startHue, startSat, startBright, endHue, endSat, endBright);

            return retImage;
        }



        private void ColourPictureBox()
        {
            if (backup != null)
            {
                Bitmap bmp = new Bitmap(backup);
                PostColourImage preImage = new PostColourImage();

                //loop  each pixel of image in picturebox checcking for pixel that meets a set condition according to params, if it meets colour it red for now.
                if (bmp.Width > 1200 || bmp.Height > 1000)
                {
                    var newwidth = 0;
                    var newheight = 0;
                    if (bmp.Width > 2800 || bmp.Height > 2000)
                    {
                        newwidth = bmp.Width / 4;
                        newheight = bmp.Height / 4;
                    }
                    newwidth = bmp.Width / 2;
                    newheight = bmp.Height / 2;
                    bmp = new Bitmap(bmp, new Size(newwidth, newheight));
                    bmp.SetResolution(50, 50);
                    backup = new Bitmap(bmp, new Size(newwidth, newheight));
                    backup.SetResolution(50, 50);
                }
                preImage.ColouredImage = new Bitmap(bmp);
                //retImage.ProcessUsingLockbits(backup,startHue,startSat,startBright,endHue,endSat, endBright);

                pictureBox1.Image = ThresholdUA(preImage).ColouredImage;



            }
        }


        private void ShowRectangle(PostColourImage postColour, Bitmap originalImage, string imageName, string outputFolderPath)
        {
            /*
             * take post process object and make a rectangle with the points
             * scale the rectangle with the pictureboximage
             * draw a rectangle and return
             */
            //scaled points with the original image

            Rectangle firstRect = new Rectangle((int)postColour.FirstX, (int)postColour.FirstY, (int)postColour.LastX, (int)postColour.LastY);
            Rectangle rectforcrop = ConvertToLargeRect(firstRect, new Size(originalImage.Width, originalImage.Height), new Size(postColour.ColouredImage.Width, postColour.ColouredImage.Height));
            Bitmap cropImg = new Bitmap(originalImage);
            using (Graphics g = Graphics.FromImage(cropImg))
            {
                Pen blackPen = new Pen(Color.Red, 5);
                g.DrawRectangle(blackPen, rectforcrop);
            }
            pictureBox1.Image = cropImg;


        }



        private void CropImage(PostColourImage postColour, Bitmap originalImage, string imageName, string outputFolderPath)
        {
            /*
             * take post process object and make a rectangle with the points
             * scale the rectangle with the originalImage
             * crop the original image and return
             */
            //scaled points with the original image

            Rectangle firstRect = new Rectangle((int)postColour.FirstX, (int)postColour.FirstY, (int)postColour.LastX, (int)postColour.LastY);
            Rectangle rectforcrop = ConvertToLargeRect(firstRect, new Size(originalImage.Width, originalImage.Height), new Size(postColour.ColouredImage.Width, postColour.ColouredImage.Height));
            using (Bitmap cropImg = new Bitmap((int)rectforcrop.Width, (int)rectforcrop.Height))
            {

                using (Graphics g = Graphics.FromImage(cropImg))
                {
                    g.DrawImage(originalImage, new Rectangle(0, 0, cropImg.Width, cropImg.Height),
                                     rectforcrop,
                                     GraphicsUnit.Pixel);
                }
                cropImg.Save(outputFolderPath + "//" + imageName + "crop.jpg");
            }

        }
        Rectangle ConvertToLargeRect(Rectangle smallRect, Size largeImageSize, Size smallImageSize)
        {
            double xScale = (double)largeImageSize.Width / smallImageSize.Width;
            double yScale = (double)largeImageSize.Height / smallImageSize.Height;
            int x = (int)(smallRect.X * xScale + 0.5);
            int y = (int)(smallRect.Y * yScale + 0.5);
            int right = (int)(smallRect.Right * xScale + 0.5);
            int bottom = (int)(smallRect.Bottom * yScale + 0.5);
            return new Rectangle(x, y, right - x, bottom - y);
        }
        private void buttonCropImage_Click(object sender, EventArgs e)
        {
            try
            {
                using (Bitmap selectedImg = new Bitmap(listBox1.SelectedItem.ToString()))
                {
                    //C:\Users\Administrator\Pictures\output
                    var colourImgObject = ColourImage(selectedImg);
                    CropImage(colourImgObject, selectedImg, "firsttest", foldernameOutput.Text);
                }
            }
            catch
            {
                MessageBox.Show("Nothing Selected in the listbox.");
            }

        }
        private void buttonCrop_Click(object sender, EventArgs e)
        {
            foreach (string imgpath in imagesInFolder)
            {
                using (Bitmap selectedImg = new Bitmap(imgpath))
                {
                    //C:\Users\Administrator\Pictures\output
                    PostColourImage colourImgObject = ColourImage(selectedImg);
                    CropImage(colourImgObject, selectedImg, imgpath.Substring(imgpath.LastIndexOf("\\")), foldernameOutput.Text);
                }
            }
        }



        private void buttonGo_Click(object sender, EventArgs e)
        {

            ColourPictureBox();
        }

        private void scrollStartHue_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                var calc = (float)scrollStartHue.Value / (float)91 * (float)360;
                startHue = (int)calc;
                ColourPictureBox();
                textBoxStartHue.Text = "" + startHue;
            }

        }

        private void scrollEndHue_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                var calc = (float)scrollEndHue.Value / (float)91 * (float)360;
                endHue = (int)calc;
                ColourPictureBox();
                textBoxHue.Text = "" + endHue;
            }

        }

        private void scrollStartSat_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                var calc = (float)scrollStartSat.Value / (float)91;
                startSat = (float)calc;
                ColourPictureBox();
                textBoxStartSat.Text = "" + startSat;
            }

        }

        private void scrollEndSat_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                var calc = (float)scrollEndSat.Value / (float)91;
                endSat = (float)calc;
                ColourPictureBox();
                textBoxSat.Text = "" + endSat;
            }

        }

        private void scrollStartBright_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                var calc = (float)scrollStartBright.Value / (float)91;
                startBright = (float)calc;
                ColourPictureBox();
                textBoxStartBright.Text = "" + startBright;
            }
        }

        private void scrollEndBright_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                var calc = (float)scrollEndBright.Value / (float)91;
                endBright = (float)calc;
                ColourPictureBox();
                textBoxBright.Text = "" + endBright;
            }

        }

        private void folderPath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string folderpath = folderPath.Text;
                var actualpath = Path.GetDirectoryName(folderpath + @"\");
                var files = Directory.EnumerateFiles(actualpath, "*.jpg").OrderBy(filename => filename);

                imagesInFolder = files.ToList<string>();
                using (NaturalComparer comparer = new NaturalComparer())
                {
                    imagesInFolder.Sort(comparer);
                }
                pictureBox1.Image = new Bitmap(imagesInFolder[0]);
                backup = new Bitmap(imagesInFolder[0]);
                listBox1.Items.Clear();
                foreach (string item in imagesInFolder)
                {
                    listBox1.Items.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("Invalid Folder Path");
                folderPath.Text = "";
            }
        }
        private void foldernameOutput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                outputFolderPath = foldernameOutput.Text;
            }
            catch
            {
                MessageBox.Show("Invalid Folder Path");
                folderPath.Text = "";
            }
        }

        /*var calc = (float)hScrollBar1.Value / (float)91 * (float)360;
            startHue = (int)calc;
            textBoxStartHue.Text = "" + startHue;
        */
        public class NaturalComparer : Comparer<string>, IDisposable
        {
            private Dictionary<string, string[]> table;

            public NaturalComparer()
            {
                table = new Dictionary<string, string[]>();
            }

            public void Dispose()
            {
                table.Clear();
                table = null;
            }

            public override int Compare(string x, string y)
            {
                if (x == y)
                {
                    return 0;
                }
                string[] x1, y1;
                if (!table.TryGetValue(x, out x1))
                {
                    x1 = Regex.Split(x.Replace(" ", ""), "([0-9]+)");
                    table.Add(x, x1);
                }
                if (!table.TryGetValue(y, out y1))
                {
                    y1 = Regex.Split(y.Replace(" ", ""), "([0-9]+)");
                    table.Add(y, y1);
                }

                for (int i = 0; i < x1.Length && i < y1.Length; i++)
                {
                    if (x1[i] != y1[i])
                    {
                        return PartCompare(x1[i], y1[i]);
                    }
                }
                if (y1.Length > x1.Length)
                {
                    return 1;
                }
                else if (x1.Length > y1.Length)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            private static int PartCompare(string left, string right)
            {
                int x, y;
                if (!int.TryParse(left, out x))
                {
                    return left.CompareTo(right);
                }

                if (!int.TryParse(right, out y))
                {
                    return left.CompareTo(right);
                }

                return x.CompareTo(y);
            }
        }

        private void FolderBrowse_Click(object sender, EventArgs e)
        {
            imageCount = 0;

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderPath.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;


                var files = Directory.EnumerateFiles(folderDlg.SelectedPath, "*.jpg").OrderBy(filename => filename);

                imagesInFolder = files.ToList<string>();
                using (NaturalComparer comparer = new NaturalComparer())
                {
                    imagesInFolder.Sort(comparer);
                }
            }
            pictureBox1.Image = new Bitmap(imagesInFolder[0]);
            backup = new Bitmap(imagesInFolder[0]);
            listBox1.Items.Clear();
            foreach (string item in imagesInFolder)
            {
                listBox1.Items.Add(item);
            }

        }

        private void FolderBrowseOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                foldernameOutput.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
                outputFolderPath = folderDlg.SelectedPath;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                backup = new Bitmap(listBox1.SelectedItem.ToString());
                pictureBox1.Image = new Bitmap(listBox1.SelectedItem.ToString());
            }
            catch
            {

            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {

            try
            {
                listBox1.SelectedIndex--;
                backup = new Bitmap(listBox1.SelectedItem.ToString());
                pictureBox1.Image = new Bitmap(listBox1.SelectedItem.ToString());
            }
            catch
            {

            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.SelectedIndex++;
                backup = new Bitmap(listBox1.SelectedItem.ToString());
                pictureBox1.Image = new Bitmap(listBox1.SelectedItem.ToString());
            }
            catch
            {

            }

        }

        private void TestRectangle_Click(object sender, EventArgs e)
        {
            /*
             * produce the rectangle on click based on results attained
             * take the rectangle and draw it
             * maybe shade it in if have time || shade outside
             */
            var selectedImg = listBox1.SelectedItem.ToString();
            var colourImgObject = ColourImage(new Bitmap(selectedImg));
            ShowRectangle(colourImgObject, new Bitmap(selectedImg), "firsttest", foldernameOutput.Text);

        }
    }
}
