using Api.Dtos.FoundPetPosts;
using Domain;
using FindPetOwner;

namespace Api.Dtos
{
    public class FoundPetPostPutPostDto
    {
        public UserIdDto CreatedBy { get; set; }
        public ICollection<PictureDto> Pictures { get; set; } = null;
        public string Phone { get; set; }
        public string Availability { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public PostStatus PostStatus { get; set; }
        public long CipId { get; set; }
    }
}
