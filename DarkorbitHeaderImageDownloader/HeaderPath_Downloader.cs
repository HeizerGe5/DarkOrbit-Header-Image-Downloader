using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net;
using System.Threading;

namespace ImageDownloader
{
    class HeaderPath_Downloader
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 600; i++)
            {
                try
                {
                    string imageUrl = @"https://darkorbit-22.bpsecure.com/do_img/global/header/ships/model" + i + ".png";
                    string saveLocation = @"D:\Darkorbit\Header Ships\Ship_" + i + ".png";
                    byte[] imageBytes;

                    HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
                    WebResponse imageResponse = imageRequest.GetResponse();
                    Stream responseStream = imageResponse.GetResponseStream();

                    using (BinaryReader br = new BinaryReader(responseStream))
                    {
                        imageBytes = br.ReadBytes(500000);
                        br.Close();
                    }
                    FileStream fs = new FileStream(saveLocation, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    responseStream.Close();
                    imageResponse.Close();
                    bw.Write(imageBytes);
                }
                catch (WebException ex)
                {
                    HttpWebResponse webResponse = (HttpWebResponse)ex.Response;
                    if (webResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        continue;
                    }
                }
            } 
        } 
    }
}