
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure;

namespace VirtualDesign
{
    public class UploadService
    {
        public UploadService(String StorageConectionString)
        {
            storageConnection = StorageConectionString;
        }

        private static String storageConnection = "";

        async public static Task<String> UploadPhotoAsync(HttpPostedFileBase photoToUpload)
        {
            if (photoToUpload == null || photoToUpload.ContentLength == 0)
            {
                return null;
            }

            String fullPath = null;

            try
            {
                Stopwatch timespan = Stopwatch.StartNew();

                CloudBlobContainer container = await GetCloudBlobContainer("images");

                // Create a unique name for the images we are about to upload
                String imageName = CreateFileName(photoToUpload.FileName);

                // Upload image to Blob Storage
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(imageName);
                blockBlob.Properties.ContentType = photoToUpload.ContentType;
                await blockBlob.UploadFromStreamAsync(photoToUpload.InputStream);

                // Convert to be HTTP based URI (default storage path is HTTPS)
                fullPath = blockBlob.Uri.AbsoluteUri;

                timespan.Stop();
                Console.Write("Blob Service", "Model.UploadPhoto=", timespan.Elapsed, "imagepath={0}", fullPath);
            }
            catch (Exception ex)
            {
                Console.Write("Error upload photo blob to storage: {0}", ex.ToString());
            }

            return fullPath;
        }

        async public static Task<String> UploadFileAsync(String containerName, HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0)
            {
                return null;
            }

            String fullPath = null;

            try
            {
                Stopwatch timespan = Stopwatch.StartNew();

                CloudBlobContainer container = await GetCloudBlobContainer(containerName);

                // Create a unique name for the images we are about to upload
                String fileName = CreateFileName(file.FileName);

                // Upload image to Blob Storage
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.Properties.ContentType = file.ContentType;
                await blockBlob.UploadFromStreamAsync(file.InputStream);

                // Convert to be HTTP based URI (default storage path is HTTPS)
                fullPath = blockBlob.Uri.AbsoluteUri;

                timespan.Stop();
                Console.Write("Blob Service", "Model.UploadPhoto=", timespan.Elapsed, "imagepath={0}", fullPath);
            }
            catch (Exception ex)
            {
                Console.Write("Error upload photo blob to storage: {0}", ex.ToString());
            }

            return fullPath;
        }

        public static async Task<CloudBlobContainer> GetCloudBlobContainer(String containerName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnection);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);

            if (await blobContainer.CreateIfNotExistsAsync())
            {
                await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                Console.Write("Successfully created Blob Storage {0} Container and made it public", containerName);
            }

            return blobContainer;
        }


        private static String CreateFileName(String fileName)
        {
            return String.Format("{0}-{1}", Guid.NewGuid().ToString(), fileName);
        }

        private static String ConvertUri(Uri baseUri, String option = "")
        {
            var uriBuilder = new UriBuilder(baseUri);
            uriBuilder.Scheme = option;

            return uriBuilder.ToString();
        }


        public static String StorageConnection
        {
            get
            {
                if (storageConnection.Count() == 0)
                    return CloudConfigurationManager.GetSetting("StorageConection");

                return storageConnection;
            }
            set { storageConnection = value; }
        }
    }
}