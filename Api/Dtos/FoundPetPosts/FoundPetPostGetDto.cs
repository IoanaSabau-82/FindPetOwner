using Api.Dtos.FoundPetPosts;
using Domain;
using FindPetOwner;

namespace Api.Dtos
{
    public class FoundPetPostGetDto
    {
        public Guid Id { get; set; }
        public PostCreatedByGetDto CreatedBy { get; set; }
        public ICollection<PictureDto> Pictures { get; set; }
        public string Phone { get; set; }
        public string Availability { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public PostStatus PostStatus{ get; set; }
        public long CipId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
