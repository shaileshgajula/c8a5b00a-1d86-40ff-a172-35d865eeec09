using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Locksmith.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceLocksmith" in code, svc and config file together.
    public class ServiceLocksmith : IServiceLocksmith
    {
        private readonly DataClassesLocksmithDataContext _dataBase;
        
        public ServiceLocksmith()
        {
            _dataBase = new DataClassesLocksmithDataContext();
        }        

        public List<Technician> GetTechnicianList()
        {
            var techniciansList = from tech in _dataBase.Technicians select tech;            
             return techniciansList.ToList();                                   
        }

        public List<Company> GetCompanyList()
        {
            var companyList = from comp in _dataBase.Companies select comp;
            return companyList.ToList();
        }

        public List<Job> GetJobsList()
        {
            var jobsList = from job in _dataBase.Jobs select job;
            return jobsList.ToList();
        }  

        public bool InsertNewTechnician(string firstName, string lastName, string address, string state, string city, string company, string email, string phone, string mobilePhone)
        {
            try
            {
                Technician technician = new Technician();             
                technician.Address = address;                
                technician.City = city;
                technician.Company = company;
                technician.email = email;
                technician.FirstName = firstName;
                technician.LastName = lastName;
                technician.MobilePhone = mobilePhone;
                technician.Phone = phone;
                technician.State = state;
                _dataBase.Technicians.InsertOnSubmit(technician);
                _dataBase.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public bool InsertNewComapny(string name, string address, string state, string city,string zip,string url, string email, string phone1, string phone2,string phone3 , string fax)
        {
            try
            {
                Company comapny = new Company();
                comapny.Address = address;
                comapny.City = city;
                comapny.Name = name;
                comapny.Email = email;
                comapny.Url = url;            
                comapny.Phone1 = phone1;
                comapny.Phone2 = phone2;
                comapny.Phone3 = phone3;
                comapny.Fax = fax;                
                comapny.State = state;
                comapny.Zip_Code = zip;
              
                _dataBase.Companies.InsertOnSubmit(comapny);
                _dataBase.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool InsertNewJob(string address, string city, string company, decimal cost, decimal? companyPayout, string firstName, decimal? gross, decimal? grossMinusCost,
                                 string Info, string jobPricing, string jobType, string lastName, string mobilePhone, decimal? netPay, string paymentMethod,
                                  string phone, string state, string status, decimal? SumCash, decimal? techCut, decimal? techPayout, string technician, decimal total)        
        {
            try
            {
                Job job = new Job();
                job.Address = address;
                job.City = city;
                job.Company = company;
                job.Company_Payout = companyPayout;
                job.Cost = cost;
                job.First_Name = firstName;
                job.Gross = gross;
                job.Gross_Cost = grossMinusCost;
                job.Info = Info;
                job.Job_Pricing = jobPricing;
                job.Job_Type = jobType;
                job.Last_Name = lastName;
                job.Mobile_Phone = mobilePhone;
                job.Net_pay = netPay;
                job.Payment_Method = paymentMethod;
                job.Phone = phone;
                job.State = state;
                job.Status = status;
                job.Sum_Cash = SumCash;
                job.Tech_Cut = techCut;
                job.Tech_Payout = techPayout;
                job.Technician = technician;
                job.Total = total;     

                _dataBase.Jobs.InsertOnSubmit(job);
                _dataBase.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }    
    }
}
 