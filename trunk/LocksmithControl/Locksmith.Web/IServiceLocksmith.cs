using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Locksmith.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceLocksmith" in both code and config file together.
    [ServiceContract]
    public interface IServiceLocksmith
    {
        [OperationContract]
        List<Technician> GetTechnicianList();

        [OperationContract]
        bool InsertNewTechnician(string firstName, string lastName,
                                 string address, string state, string city, string company, string email, string phone, string mobilePhone);

        [OperationContract]
       List<Company> GetCompanyList();

        [OperationContract]
        bool InsertNewComapny(string name, string address, string state, string city, string zip, string url,
                                     string email, string phone1, string phone2, string phone3, string fax);

       
    }
}
