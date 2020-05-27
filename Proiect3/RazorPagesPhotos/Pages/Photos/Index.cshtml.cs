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

        public IndexModel()
        {
            Photos = new List<FilesDto>();
        }

        public async Task OnGetAsync()
        {
            var files = await service.GetAllFilesPathsAsync();
            foreach (var item in files)
            {
                // Trebuia folosit AutoMapper. Transform Post in PostDTO
                FilesDto pd = new FilesDto();
                pd.abs_path = item;
                pd.description = "Description";
                pd.@event = "Event";
                pd.event_date = "25-10-2019";
                pd.event_location = "Location";
                Photos.Add(pd);
            }

        }
    }
}