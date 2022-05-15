using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IBlobService
    {
        Task<string> UploadAsync(Stream fileStream, string fileName, string contentType);

        Task<BlobInfo> GetPictureAsync(string name);

        Task <IEnumerable<string>> GetAll();

        Task UploadPictureAsync(string filePath, string fileName);

        Task DeletePictureAsync (string fileName);
    }
}
