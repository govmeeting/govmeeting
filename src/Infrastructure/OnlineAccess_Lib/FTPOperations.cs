using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;

/*
 * http://www.c-sharpcorner.com/UploadFile/0d5b44/ftp-using-C-Sharp-net/
 */

/*
static void Main(string[] args)  
        {  
            FTPOperations ops = new FTPOperations("user", "pass", "http://mysite.com/")
            string listing = ops.ListFtpDrive();  
            ops.PostFileToFTP(@"C:\TMP\file01.txt", @"fileo1.txt");  
            ops.GetFileFromFTP(@"fileo1.txt", (@"C:\TMP\file01-copy.txt");  
        }  
 */

namespace GM.OnlineAccess
{
    public class FTPOperations
    {
        string username { get; set; }
        string password { get; set; }
        string ftpAddress { get; set; }

        public FTPOperations(string _username, string _password, string _ftpAddress)
        {
            username = _username;
            password = _password;
            ftpAddress = _ftpAddress;
        }

        public string ListFtpDrive()
        {
            // show all the contents and directories of your FTP Drive
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAddress);
                request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Credentials = new NetworkCredential(username, password);
                request.KeepAlive = false;
                request.UseBinary = true;
                request.UsePassive = true;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                StringBuilder sb = new StringBuilder();
                //Console.WriteLine(reader.ReadToEnd());
                sb.Append(reader.ReadToEnd());
                //Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);
                sb.Append($"Directory List Complete, status {response.StatusDescription}");

                reader.Close();
                response.Close();

                return sb.ToString();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message.ToString());
                return(ex.Message.ToString());
            }
        }
        public void ReadFileFromFtp(string remoteFilePath, string localFilePath)
        {
            // Get and open the following content only,
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAddress + "/" + remoteFilePath);
                request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(username, password);
                request.KeepAlive = false;
                request.UseBinary = true;
                request.UsePassive = true;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                //Console.WriteLine(reader.ReadToEnd());
                //Console.WriteLine("Download Complete", response.StatusDescription);

                StreamWriter writer = new StreamWriter(localFilePath, append: false);
                writer.Write(reader.ReadToEnd());

                reader.Close();
                writer.Close();
                response.Close();
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message.ToString());
                String status = ((FtpWebResponse)e.Response).StatusDescription;
                Console.WriteLine(status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }


        // Post a file
        public void WriteFileToFtp(string localFilePath, string remoteFilePath)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAddress + "/" + remoteFilePath);
                request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(username, password);

                // Copy the contents of the file to the request stream.  
                StreamReader sourceStream = new StreamReader(localFilePath);
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();

                request.ContentLength = fileContents.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

                response.Close();
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message.ToString());
                String status = ((FtpWebResponse)e.Response).StatusDescription;
                Console.WriteLine(status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        /*
         *     FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://Hostname.com/TestFile.txt");   
         * To read all file content.
         */

    }
}
