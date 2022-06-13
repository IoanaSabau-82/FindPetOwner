using Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IBlobService
    {
        //Task<string> UploadAsync(Stream fileStream, string fileName, string contentType);
        Task<string> UploadAsync(Stream fileStream, string fileName, string contentType);

        Task<BlobInfoDto> GetPictureAsync(string name);

        Task <IEnumerable<string>> GetAllAsync();

        Task DeletePictureAsync (string fileName);
    }
}
