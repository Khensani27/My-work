using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FinalYearWeb.Controllers
{
    public class DeliveryPersonController
    {
        private Base<Employee> employee;

        public DeliveryPersonController()
        {
            employee = new Base<Employee>();
        }

        public async Task<HttpResponseMessage> addDriver(string url, Object obj)
        {
            HttpResponseMessage response = await employee.Create(url, obj);
            return response;
        }

        public async Task<List<Employee>> GetAllEmployees(string url)
        {
            return await employee.GetAll(url);
        }

        public async Task<Employee> GetEmployee(string url)
        {
            return await employee.Get(url);
        }

        public async Task<HttpResponseMessage> EditEmployee(string url, Object obj)
        {
            return await employee.Edit(url, obj);
        }

        public async Task<bool> RemoveEmployee(string url, Object obj)
        {
            return await employee.Delete(url, obj);
        }

        /*  public async Task<DriverModel> LoginDriver(string username, string password)
          {
              DriverModel driver = await service.Get("Driver/getDriverLogin?email=" + username + "&password=" + password);
              return driver;
          }*/

    }
}