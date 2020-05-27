using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotos.Dto
{
	public class CreateFileDto
	{
        public string abs_path { get; set; }
        public string created_date { get; set; }
        public string @event { get; set; }
        public string event_date { get; set; }
        public string event_location { get; set; }
        public string description { get; set; }

        /*public string firstname { get; set; }
        public string relation { get; set; }
        public string lastname { get; set; }*/

        public List<PropertyDto> newProperties { get; set; }
        public List<PersonsDto> newPersons { get; set; }

 /*       public string name { get; set; }
        public string value { get; set; }*/
    }
}
