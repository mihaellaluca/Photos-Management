using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotos.Dto
{
	public class FileDto
	{
        public string abs_path { get; set; }
        public string created_date { get; set; }
        public string @event { get; set; }
        public string event_date { get; set; }
        public string event_location { get; set; }
        public string description { get; set; }
    }
}
