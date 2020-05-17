using Google.Cloud.Storage.V1;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GM.GoogleCLoud
{
    class GoogleBucket
    {
        StorageClient storageClient;

        public GoogleBucket()
        {
            storageClient = StorageClient.Create();
        }

        public void UploadFile(string bucketName, string localPath,
            string objectName = null, string contentType = null)
        {
            using (var file = File.OpenRead(localPath))
            {
                objectName = objectName ?? Path.GetFileName(localPath);
                storageClient.UploadObject(bucketName, objectName, contentType, file);
                Console.WriteLine($"GoogleBucket.cs - Uploaded {objectName}.");
            }
        }
        public void DownloadObject(string bucketName, string objectName,
            string localPath = null)
        {
            localPath = localPath ?? Path.GetFileName(objectName);
            using (var outputFile = File.OpenWrite(localPath))
            {
                storageClient.DownloadObject(bucketName, objectName, outputFile);
            }
            Console.WriteLine($"GoogleBucket.cs - downloaded {objectName} to {localPath}.");
        }

        void CreateBucket()
        {
            // Your Google Cloud Platform project ID.
            string projectId = "YOUR-PROJECT-ID";

            // The name for the new bucket.
            string bucketName = projectId + "-test-bucket";
            try
            {
                // Creates the new bucket.
                storageClient.CreateBucket(projectId, bucketName);
                Console.WriteLine($"GoogleBucket.cs - Bucket {bucketName} created.");
            }
            catch (Google.GoogleApiException e)
            when (e.Error.Code == 409)
            {
                // The bucket already exists.  That's fine.
                Console.WriteLine("GoogleBucket.cs - " + e.Error.Message);
            }
        }

        // Check if object of this name is the bucket.
        public bool IsObjectInBucket(string bucketName, string filename)
        {
            return IsObjectInBucket(bucketName, filename, filename);
        }

        // Check if object which starts with this prefix and matches the regular expression is in the bucket.
        public bool IsObjectInBucket(string bucketName, string prefix, string regex)
        // prefix -	Prefix to match. Only objects with names that start with this string will be returned from cloud.
        // regex - Regular Expression to match with those objects returned.
        {
            var listFiles = storageClient.ListObjects(bucketName,
                prefix).Where(p => Regex.IsMatch(p.Name, regex));
                // IsMatch(String, String) 	- Indicates if regular expression finds match in input string.
            if (listFiles.Any())
            {
                return true;
            }
            return false;
        }
    }
}
