using System.Collections.Generic;
using System.Threading.Tasks;
using RazorPagesPhotos.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReferencePhotos;



namespace RazorPagesPhotos
{
    public class IndexModel : PageModel
    {
        MyPhotosClient service = new MyPhotosClient();
        public List<FilesDto> Photos { get; set; }
        public List<PropertiesDto> Properties { get; set; }
        public string NumeProprietate { get; set; }
        public string ValoareProprietate { get; set; }

        public IndexModel()
        {
            Photos = new List<FilesDto>();
            Properties = new List<PropertiesDto>();
        }

        public async Task OnGetAsync()
        {
            var files = await service.GetAllFilesPathsAsync();
            // var allFilesObjects = await service.GetAllFiles(); 
            

            foreach (var item in files)
            {
                FilesDto pd = new FilesDto();
                pd.abs_path = item;
                pd.description = "Description";
                pd.@event = "Event";
                pd.event_date = "25-10-2019";
                pd.event_location = "Location";
                Photos.Add(pd);
            }


            // Get All Unique Properties

            // var allProperties = await service.GetAllProperties();
            /*            foreach (var item in allProperties)
                        {
                            PropertiesDto pd = new PropertiesDto();
                            pd.name = item.name;
                            pd.value = item.value;
                            Properties.Add(pd);
                        }*/



            // Cautarea pozelor in functie de proprietate:

            // var photos = await service.GetFilesByProperty(NumeProprietate, ValoareCautata);




        }


    }
}