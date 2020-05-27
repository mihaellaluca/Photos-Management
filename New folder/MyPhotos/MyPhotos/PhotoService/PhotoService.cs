using MyPhotos.Dto;
using MyPhotos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyPhotos.PhotoService
{
	public partial class PhotoService
	{
		private readonly PhotosRepository _photosRepository;
		private Properties newProperty;
		private Persons newPerson;
		public PhotoService()
		{
			PhotoModelContainer context = new PhotoModelContainer();
			_photosRepository = new PhotosRepository(context);

		}
		

		public async Task<Files> AddNewFile(CreateFileDto request)
		{
			//add the list of properties
			List<Properties> proprieties = new List<Properties>();
			var newProperties = request.newProperties;
			foreach (var newProp in newProperties) {
				if (newProp.name != "" && newProp.value != "")
				{
					var existentProperty = _photosRepository.Check_If_Property_Exists(newProp.name);
					if (existentProperty == null) // daca nu exista, il adaug
					{
						newProperty = await _photosRepository.AddNewProperty(newProp.name, newProp.value);
					}
					else
					{
						newProperty = existentProperty;
					}
					proprieties.Add(newProperty); 

				}
			}

			//add the list of persons tagged
			List<Persons> persons = new List<Persons>();
			var newPersons = request.newPersons;
			foreach (var newPers in newPersons)
			{
				if (newPers.firstname != "" && newPers.lastname != "")
				{
					var existentPerson = _photosRepository.Check_If_Person_Exists(newPers.firstname, newPers.lastname);
					if (existentPerson == null) // DOES NOT EXISTS THEN ADD IT TO DB
					{
						newPerson = await _photosRepository.AddNewPerson(newPers.firstname, newPers.lastname, newPers.relation);
					}
					else 
					{
						newPerson = existentPerson;
					}
					persons.Add(newPerson);
				}
			}

			var newFile = await _photosRepository.AddNewFile(request.abs_path, request.created_date, request.@event, request.event_date, request.event_location, request.description, proprieties, persons);
			return newFile;

			
		}

		public List<string> GetAllFilesPaths()
		{
			List<string> allFilesPaths = new List<string>();
			var allFiles = _photosRepository.GetAllFiles();
			foreach (var file in allFiles) {
				allFilesPaths.Add(file.abs_path);
			}

			return allFilesPaths;
		}
		public List<Files> GetAllFiles()
		{
			List<Files> allFiles = new List<Files>();
			var allFilesReturned = _photosRepository.GetAllFiles();
			foreach (var file in allFilesReturned)
			{
				allFiles.Add(file);
			}

			return allFiles;
		}

		public List<Properties> GetAllProperties()
		{
			List<Properties> proprieties = new List<Properties>();
			var allProprieties = _photosRepository.GetAllProperties();
			foreach (var p in allProprieties)
			{
				proprieties.Add(p);
			}

			return proprieties;
		}

		public List<string> GetFilesByProperty(string name, string value)
		{
			List<string> foundFilesPaths = new List<string>();
			var files =_photosRepository.GetFilesByProperty(name, value);
			foreach (var file in files)
					foundFilesPaths.Add(file.abs_path);
			return foundFilesPaths;

		}

		public List<string> GetFilesByRelation(string relation_type)
		{
			List<string> foundFilePaths = new List<string>();
			var files = _photosRepository.GetFilesByRelation(relation_type);
			foreach (var file in files)
				foundFilePaths.Add(file.abs_path);
			return foundFilePaths;
		}

		public void ModifyFile(CreateFileDto request)
		{
			_photosRepository.ModifyFile(request.abs_path, request.created_date, request.@event, request.event_date, request.event_location, request.description, request.newProperties, request.newPersons);
		}
/*		public void DeleteFileByPath(string abs_path)
		{
			_photosRepository.DeleteFileByPath(abs_path);
		}*/


	}
}
