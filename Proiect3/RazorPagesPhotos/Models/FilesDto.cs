using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesPhotos.Models
{
	public class FilesDto
	{
        public int Id { get; set; }
        public string abs_path { get; set; }
        public string created_date { get; set; }
        public string @event { get; set; }
        public string event_date { get; set; }
        public string event_location { get; set; }
        public string description { get; set; }
        public virtual ICollection<PropertiesDto> Properties { get; set; }
    }
}
