using MyPhotos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPhotos.Dto;
using MyPhotos.PhotoService;

namespace WCFService
{
	public class MyPhotos : IMyPhotos
	{

		public MyPhotos()
		{

		}
		public PhotoService photoService = new PhotoService();
		public MyPhotos(PhotoModelContainer context)
		{
			context = new PhotoModelContainer();
		}

		Task<Files> InterfaceFiles.AddNewFile(CreateFileDto file)
		{
			// call functions from MyPhotos.PhotoService
			List<PropertyDto> newProperties = new List<PropertyDto>();
			List<PersonsDto> newPersons = new List<PersonsDto>();
			var request = new CreateFileDto()
			{
				abs_path = file.abs_path,
				created_date = file.created_date,
				@event = file.@event,
				event_date = file.event_date,
				event_location = file.event_location,
				description = file.description,
				newProperties = file.newProperties,
				newPersons = file.newPersons
			};

			var newFile = photoService.AddNewFile(request);
			return newFile;
		}
		public Task<Persons> AddNewPerson(string firstname, string lastname, string relation)
		{
			throw new NotImplementedException();
		}

		public List<string> GetAllFilesPaths()
		{
			return photoService.GetAllFilesPaths();
		}

		public List<string> GetFilesByProperty(string propertyName, string propertyValue)
		{
			return photoService.GetFilesByProperty(propertyName, propertyValue);
		}

		public List<string> GetFilesByRelation(string relation_type)
		{
			return photoService.GetFilesByRelation(relation_type);
		}

		public void ModifyFile(CreateFileDto file)
		{
			photoService.ModifyFile(file);
		}

		public Task<Properties> AddNewProperty(string name, string value)
		{
			throw new NotImplementedException();
		}

		public Properties Check_If_Property_Exists(string propertyName)
		{
			throw new NotImplementedException();
		}
	}
}
