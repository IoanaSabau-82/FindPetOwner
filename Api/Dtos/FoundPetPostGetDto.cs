using Domain;
using FindPetOwner;

namespace Api.Dtos
{
    public class FoundPetPostGetDto
    {
        public User CreatedBy { get; set; }
        public List<Picture> Pictures { get; set; }
        public string Phone { get; set; }
        public DateTime AvailabilityStart { get; set; }
        public DateTime AvailabilityEnd { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public PostStatus PostStatus { get; set; }
        public long CipId { get; set; }
    }
}
