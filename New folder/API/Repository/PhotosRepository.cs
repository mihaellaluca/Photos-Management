using MyPhotos.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MyPhotos.Repository
{
	public class PhotosRepository
	{
		private readonly PhotoModelContainer _context;
		public PhotosRepository(PhotoModelContainer context)
		{
			_context = context;
		}

		// DATABASE ACCESS:

		public async Task<Files> AddNewFile(string abs_path, string created_date, string event_name, string event_date, string event_location, string description, List<Properties> newProperties, List<Persons> newPersons)
		{
			var newFile = new Files()
			{
				abs_path = abs_path,
				created_date = created_date,
				@event = event_name,
				event_date = event_date,
				event_location = event_location,
				description = description
			};
			 _context.Files.Add(newFile);

			foreach(var prop in newProperties)
				if (prop != null) 
					newFile.Properties.Add(prop); //asigur relatia file-property
			foreach(var pers in newPersons)
				if (pers != null) 
					newFile.Persons.Add(pers); //asigur relatia file-person
			await _context.SaveChangesAsync();
			return newFile;

		}


		public async Task<Properties> AddNewProperty(string name, string value)
		{
			var newProperty = new Properties()
			{
				name = name,
				value = value
			};

			_context.Properties.Add(newProperty);
			await _context.SaveChangesAsync();
			return newProperty;

		}

		public async Task<Persons> AddNewPerson(string firstname, string lastname, string relation)
		{
			var newPerson = new Persons()
			{
				firstname = firstname,
				lastname = lastname,
				relation = relation
			};

			_context.Persons.Add(newPerson);
			await _context.SaveChangesAsync();
			return newPerson;

		}

		public Properties Check_If_Property_Exists(string propertyName)
		{
			var prop = (from p in _context.Properties where p.name == propertyName select p).FirstOrDefault();
			return prop;
		}
		public Persons Check_If_Person_Exists(string firstname, string lastname)
		{
			var pers = (from p in _context.Persons where p.firstname == firstname && p.lastname == lastname select p).FirstOrDefault();
			return pers;
		}

		public List<Files> GetAllFiles()
		{
			return _context.Files.Include(file => file.Properties).ToList();
		}

		public List<Files> GetFilesByProperty(string name, string value)
		{
			return _context.Files.Where(file => file.Properties.Select(property => property.name).Contains(name) == true 
									&& file.Properties.Select(property => property.value).Contains(value) == true)
									.ToList();

		}

		public List<Files> GetFilesByRelation(string relation_type)
		{
			return _context.Files.Where(file => file.Persons.Select(person => person.relation).Contains(relation_type) == true).ToList();
		}


		public void ModifyFile(string abs_path, string created_date, string event_name, string event_date, string event_location, string description, List<PropertyDto> newProperties, List<PersonsDto> newPersons)
		{

			var query = from file in _context.Files where file.abs_path == abs_path select file;
			foreach (Files file in query)
			{
				if (event_name != "") file.@event = event_name;
				if (event_date != "") file.event_date = event_date;
				if (event_location != "") file.event_location = event_location;
				if (description != "") file.description = description;
		
			}

			_context.SaveChanges();
		}
		
	/*	public void DeleteFileByPath(string abs_path)
		{
			Files fileToDelete = _context.Files.Where(file => file.abs_path == abs_path).FirstOrDefault();
			List<FilesProperties> filesPropertiesLink = _context.FilesProperties.ToList();
				
			_context.Files.Remove(fileToDelete);

			_context.SaveChanges();
		}*/


	}
}
