using System.ComponentModel.DataAnnotations;

namespace Agri_EnergyConnect.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Organization { get; set; }
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string FromNameAndSurname { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return
            "Id: " + Id.ToString() + ", " +
            "Organization: " + Organization + ", " +
            "ToEmail: " + ToEmail + ", " +
            "FromEmail: " + FromEmail + ", " +
            "FromNameAndSurname: "
            + FromNameAndSurname + ", " +
            "Text: " + Text;
        }
    }
}