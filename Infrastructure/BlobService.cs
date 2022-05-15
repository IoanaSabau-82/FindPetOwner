using Application;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class BlobService:IBlobService

    {
        private readonly string _storageConnectionString;
        public BlobService(IConfiguration configuration)
        {
            _storageConnectionString = configuration.GetConnectionString("AzureStorage");
        }
        public async Task<string> UploadAsync(Stream fileStream, string fileName, string contentType)
        {
            var container = new BlobContainerClient(_storageConnectionString, "file-container");
            var createResponse = await container.CreateIfNotExistsAsync();
            if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);
            var blob = container.GetBlobClient(fileName);
            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
            await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });
            return blob.Uri.ToString();
        }
    }
}
