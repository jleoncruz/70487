using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Windows.Storage;
using Windows.Storage.Streams;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Win8PhotoUploader
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Objects/variables for the acount, client uploading
        //capability and the blob container
        CloudStorageAccount account;
        CloudBlobClient blobClient;
        CloudBlobContainer container;

        public MainPage()
        {
            this.InitializeComponent();
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            //You could use local developent storage
            // accont = CloudStorageAccount.DevelopmentStorageAccount;
            //account = new CloudStorageAccount(
            //    new StorageCredentials("jpphotos1",
            //    "m0eZvNZU+v4Q18BBEuW764dRsHxJ50aWfXpPF2BWAa8awHUKBnFS4EThttLeeQC0xQMZ0eXCD4BQboOkM8QNcQ=="), true);

            account = new CloudStorageAccount(
                new StorageCredentials("jpphotos2",
                "+xaRUukF3gIq0Q7Al2yVF2D++5fuDvg1Tdz8fmBB259VQSf1z9Py4ESrRDrdrBHTZhcksJKNwoYV0OmhwzTpMA=="), true);

            //blobClient is used to upload photos
            blobClient = account.CreateCloudBlobClient();

            try
            {
                // The container name in Windows Azure Storage is "mypictures"
                container = blobClient.GetContainerReference("mypictures");
                await container.CreateIfNotExistsAsync();

                // Make the photos publicly visible
                BlobContainerPermissions permissions = new BlobContainerPermissions();
                permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
                await container.SetPermissionsAsync(permissions);

                // Get a reference to the local machine’s Pictures folder
                StorageFolder storageFolder = KnownFolders.PicturesLibrary;

                // Get all files in the pictures folder
                IReadOnlyList<StorageFile> storageFiles = await storageFolder.GetFilesAsync();

                CloudBlockBlob blob = null;
                // Loop through pictures
                foreach (StorageFile storageFile in storageFiles)
                {
                    using (IRandomAccessStream imageStream = await storageFile.OpenReadAsync())
                    {
                        // Name the file in the cloud the same as on local files sytem
                        blob = container.GetBlockBlobReference(storageFile.Name);
                        // Upload file to Windows Azure Storage
                        await blob.UploadFromStreamAsync(imageStream.AsStream());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
