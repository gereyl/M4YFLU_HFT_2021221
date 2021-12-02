using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Models
{
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerId { get; set; }
        [Required]
        public string Name { get; set; }

        public bool Gender { get; set; } // True : male, False : female

        public string City { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }

        public override bool Equals(object obj)
        {
            Owner other = obj as Owner;
            return this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() * this.OwnerId;
        }

        public override string ToString()
        {
            return this.Name;
        }


    }
}
