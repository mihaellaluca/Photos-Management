using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesPhotos.Models
{
	public class PropertiesDto
	{
        public int Id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public virtual ICollection<FilesDto> Files { get; set; }
    }
}
