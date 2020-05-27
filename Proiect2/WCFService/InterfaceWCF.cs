using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MyPhotos;
using MyPhotos.Dto;

namespace WCFService
{
    [ServiceContract]
    interface InterfaceFiles
    {
        [OperationContract]
        Task<Files> AddNewFile(CreateFileDto fileRequest);

        [OperationContract]
        List<string> GetAllFilesPaths();

        [OperationContract]
        List<string> GetFilesByProperty(string propertyName, string propertyValue);

        [OperationContract]
        List<string> GetFilesByRelation(string relation_type);

        [OperationContract]
        void ModifyFile(CreateFileDto fileRequest);
    }

    [ServiceContract]
    interface InterfaceUsers
    {
        [OperationContract]
        Task<Persons> AddNewPerson(string firstname, string lastname, string relation);

    }

    [ServiceContract]
    interface InterfaceProperties
    {
        [OperationContract]
        Task<Properties> AddNewProperty(string name, string value);

        [OperationContract]
        Properties Check_If_Property_Exists(string propertyName);

    }

    [ServiceContract]
    interface IMyPhotos : InterfaceFiles, InterfaceUsers, InterfaceProperties
    {
    }

}
