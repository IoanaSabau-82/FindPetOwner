using Api.Dtos;
using Application;
using Application.Services;
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
    public class BlobService : IBlobService

    {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobContainerClient container;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
            container = _blobServiceClient.GetBlobContainerClient("file-container");
        }

        public async Task DeletePictureAsync(string fileName)
        {
            var blobClient = container.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public async Task<BlobInfoDto> GetPictureAsync(string name)
        {
            var blobClient = container.GetBlobClient(name);
            var blobDownloadInfo = await blobClient.DownloadAsync();
            return new BlobInfoDto()
            {
                Content = blobDownloadInfo.Value.Content,
                ContentType = blobDownloadInfo.Value.ContentType
            };
        }

        public async Task<string> UploadAsync(Stream fileStream, string fileName, string contentType)
        {
            var createResponse = await container.CreateIfNotExistsAsync();
            if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);
            var blob = container.GetBlobClient(fileName);
            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
            await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });
            return blob.Uri.ToString();
        }

        public async Task<IEnumerable<string>> GetAllAsync()
        {

            var items = new List<string>();

            await foreach (var item in container.GetBlobsAsync())
            {
                items.Add(item.Name);
            }
            return items;
        }
    }
}



