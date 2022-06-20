using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<EmployeeModel> empList;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Employee").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<EmployeeModel>>().Result;
            return View(empList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new EmployeeModel());
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Employee/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<EmployeeModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(EmployeeModel emp)
        {
            if (emp.EmployeeID == 0)
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Employee", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("Employee/" + emp.EmployeeID, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("Employee/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}