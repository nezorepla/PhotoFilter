using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private Bitmap sourceImage;
    public Bitmap SourceImage
    {
        get
        {
            //BuildImage();
            return sourceImage;
        }
        set { sourceImage = value; }
    }
    private Bitmap resultImage;
    private Bitmap yedek;
    public Bitmap Yedek
    {
        get
        {
            //BuildImage();
            return yedek;
        }
        set { yedek = value; }
    }
    public Bitmap ResultImage
    {
        get
        {
            resultImage = sourceImage;
            //BuildImage();
            return resultImage;
        }
        set { resultImage = value; }
    }
    public string FOName;
    public void ResimOku(FileUpload fu)
    {

        if (fu.HasFile)
        {
            System.Drawing.Image orjinalFoto = null;
            HttpPostedFile jpeg_image_upload = fu.PostedFile;
            FOName = Path.GetFileName(fu.PostedFile.FileName);

            orjinalFoto = System.Drawing.Image.FromStream(jpeg_image_upload.InputStream);
            sourceImage = new Bitmap(orjinalFoto);
            Yedek = new Bitmap(orjinalFoto); ;
        }
    }

    void islem() {

        string path = @"C:\Users\alper\OneDrive\Resimler\bear";

       
        DirectoryInfo d = new DirectoryInfo(path);//Assuming Test is your Folder
FileInfo[] Files = d.GetFiles("*.jpg"); //Getting Text files
string str = "";
foreach(FileInfo file in Files )
{
    string originalFileName = file.FullName;
    string fileName = file.Name.Replace(" ", "-").Replace(",", "-");
        string newFileName = Path.Combine(file.DirectoryName, "yeni\\"+fileName);

        File.Move(originalFileName, newFileName);
}

        //foreach (FileInfo file in Folder.GetFiles())
        //{
        //    string originalFileName = file.FullName;
        //    string fileName = file.Name.Replace(" ", "-").Replace(",", "-");
        //    string newFileName = Path.Combine(file.DirectoryName, fileName);

        //    File.Move(originalFileName, newFileName);
        //}
    
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string hash = DateTime.Now.Ticks.ToString().Substring(5);

        islem();
       // ResimOku(FileUpload1);
        //ikiyeBol();
      //  dordeBol();
        //fSiyahOran(65); ResimKaydet("fSiyahOran65");
        //fSinCity2(200); ResimKaydet("fSinCity2_200");
    }

    public void ikiyeBol()
    {
        string hash = DateTime.Now.Ticks.ToString().Substring(5);
        int newWidth;
        int newHeight;
        Color c;
        newWidth = (sourceImage.Height);
        newHeight = (sourceImage.Width / 2);

        resultImage = new Bitmap(newWidth * 2, newHeight * 2, PixelFormat.Format24bppRgb);

        for (int i = 0; i < newWidth; i++)
        {
            for (int j = 0; j < newHeight; j++)
            {
                c = sourceImage.GetPixel(j, i);
                // resultImage.SetPixel(i, j, c);

                resultImage.SetPixel((i * 2), (j * 2), c);
                resultImage.SetPixel((i * 2), (j * 2) + 1, c);
                resultImage.SetPixel((i * 2) + 1, (j * 2), c);
                resultImage.SetPixel((i * 2) + 1, (j * 2) + 1, c);
            }
        }

        //  resultImage = fSetContrast(10, resultImage);


        resultImage.Save(@"C:\Users\alper\Pictures\alperweb\" + FOName + '_' + hash + "_2.jpg");


        resultImage = new Bitmap(newWidth * 2, newHeight * 2, PixelFormat.Format24bppRgb);


        for (int i = 0; i < newWidth; i++)
        {
            for (int j = 0; j < newHeight; j++)
            {
                c = sourceImage.GetPixel((j + newHeight), i);


                resultImage.SetPixel((i * 2), (j * 2), c);
                resultImage.SetPixel((i * 2), (j * 2) + 1, c);
                resultImage.SetPixel((i * 2) + 1, (j * 2), c);
                resultImage.SetPixel((i * 2) + 1, (j * 2) + 1, c);
            }
        }
        //  resultImage = fSetContrast(0, resultImage);
        resultImage.Save(@"C:\Users\alper\Pictures\alperweb\" + FOName + '_' + hash + "_1.jpg");


    }
    public void dordeBol()
    {
        string hash = DateTime.Now.Ticks.ToString().Substring(5);
        int newWidth;
        int newHeight;
        Color c;
        newWidth = (sourceImage.Width / 2);
        newHeight = (sourceImage.Height / 2);

        resultImage = new Bitmap(newWidth * 2, newHeight * 2, PixelFormat.Format24bppRgb);

        for (int i = 0; i < newWidth; i++)
        {
            for (int j = 0; j < newHeight; j++)
            {
                c = sourceImage.GetPixel(i, j);
                //   resultImage.SetPixel(i, j, c);
                //     resultImage.SetPixel((i * 2) + 1, (j * 2), c);
                resultImage.SetPixel((i * 2), (j * 2), c);
                resultImage.SetPixel((i * 2), (j * 2) + 1, c);
                resultImage.SetPixel((i * 2) + 1, (j * 2), c);
                resultImage.SetPixel((i * 2) + 1, (j * 2) + 1, c);

            }
        }
        resultImage.Save(@"C:\Users\alper\Pictures\alperweb\" + FOName + '_' + hash + "_1.jpg");

        resultImage = new Bitmap(newWidth * 2, newHeight * 2, PixelFormat.Format24bppRgb);

        for (int i = 0; i < newWidth; i++)
        {
            for (int j = 0; j < newHeight; j++)
            {
                c = sourceImage.GetPixel(i + newWidth, j + newHeight);
                //   resultImage.SetPixel(i, j, c);
                //     resultImage.SetPixel((i * 2) + 1, (j * 2), c);
                resultImage.SetPixel((i * 2), (j * 2), c);
                resultImage.SetPixel((i * 2), (j * 2) + 1, c);
                resultImage.SetPixel((i * 2) + 1, (j * 2), c);
                resultImage.SetPixel((i * 2) + 1, (j * 2) + 1, c);

            }
        }
        resultImage.Save(@"C:\Users\alper\Pictures\alperweb\" + FOName + '_' + hash + "_2.jpg");



        resultImage = new Bitmap(newWidth * 2, newHeight * 2, PixelFormat.Format24bppRgb);

        for (int i = 0; i < newWidth; i++)
        {
            for (int j = 0; j < newHeight; j++)
            {
                c = sourceImage.GetPixel(i + newWidth, j);
                //   resultImage.SetPixel(i, j, c);
                //     resultImage.SetPixel((i * 2) + 1, (j * 2), c);
                resultImage.SetPixel((i * 2), (j * 2), c);
                resultImage.SetPixel((i * 2), (j * 2) + 1, c);
                resultImage.SetPixel((i * 2) + 1, (j * 2), c);
                resultImage.SetPixel((i * 2) + 1, (j * 2) + 1, c);

            }
        }
        resultImage.Save(@"C:\Users\alper\Pictures\alperweb\" + FOName + '_' + hash + "_3.jpg");
        resultImage = new Bitmap(newWidth * 2, newHeight * 2, PixelFormat.Format24bppRgb);

        for (int i = 0; i < newWidth; i++)
        {
            for (int j = 0; j < newHeight; j++)
            {
                c = sourceImage.GetPixel(i, j + newHeight);
                //   resultImage.SetPixel(i, j, c);
                //     resultImage.SetPixel((i * 2) + 1, (j * 2), c);
                resultImage.SetPixel((i * 2), (j * 2), c);
                resultImage.SetPixel((i * 2), (j * 2) + 1, c);
                resultImage.SetPixel((i * 2) + 1, (j * 2), c);
                resultImage.SetPixel((i * 2) + 1, (j * 2) + 1, c);

            }
        }
        resultImage.Save(@"C:\Users\alper\Pictures\alperweb\" + FOName + '_' + hash + "_4.jpg");

    }


    public Bitmap fSetContrast(double contrast, Bitmap imaj)
    {

        if (contrast < -100) contrast = -100;
        if (contrast > 100) contrast = 100;
        contrast = (100.0 + contrast) / 100.0;
        contrast *= contrast;
        Color c;
        for (int i = 0; i < imaj.Width; i++)
        {
            for (int j = 0; j < imaj.Height; j++)
            {
                c = imaj.GetPixel(i, j);
                double pR = c.R / 255.0;
                pR -= 0.5;
                pR *= contrast;
                pR += 0.5;
                pR *= 255;
                if (pR < 0) pR = 0;
                if (pR > 255) pR = 255;

                double pG = c.G / 255.0;
                pG -= 0.5;
                pG *= contrast;
                pG += 0.5;
                pG *= 255;
                if (pG < 0) pG = 0;
                if (pG > 255) pG = 255;

                double pB = c.B / 255.0;
                pB -= 0.5;
                pB *= contrast;
                pB += 0.5;
                pB *= 255;
                if (pB < 0) pB = 0;
                if (pB > 255) pB = 255;

                imaj.SetPixel(i, j,
    Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
            }
        }
        return imaj;

    }



}
