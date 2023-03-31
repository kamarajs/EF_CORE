using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using CodeFirstApp.Data;
using System.Collections;
using System.Collections.Generic;
using EF.Models.CodeFirstApp;

namespace CodeFirstApp.Controllers;

public class HomeController : Controller

{
    private readonly EFCoreCodeDBContext _database;

    public HomeController(EFCoreCodeDBContext employeedb)
    {
        _database = employeedb;
    }

   public IActionResult Index()
    {

        IEnumerable<Employees> employeeDetails = _database.Employee;

        ViewBag.EmployeeData = employeeDetails;

        foreach (var data in employeeDetails)
        {
            Console.WriteLine(data.DatofBirth);
        }
        
        return View(employeeDetails);

    }
        public IActionResult AddEmployee(){

        return View();

    }

    [HttpPost]
    public IActionResult AddEmployee(Employees employee)
    {

        _database.Employee.Add(employee);

        _database.SaveChanges();

        return RedirectToAction("Index", "Home");

    }

    public IActionResult RemoveEmployee(int id)
    {

        var employeeid = _database.Employee.Find(id);

        _database.Employee.Remove(employeeid);

        _database.SaveChanges();

        return RedirectToAction("Index", "Home");

    }


    public IActionResult UpdateEmployee(int id)
    {

        ViewBag.id = Convert.ToString(id);

        IEnumerable<Employees> employeeData = _database.Employee.Where(data => data.Id == id).ToList();



        return View(employeeData);

    }

    [HttpPost]

    public IActionResult UpdateEmployee(Employees employee)
    {

        List<Employees> employeeDetails = _database.Employee.Where(data => data.Id == employee.Id).ToList();

        foreach (var items in employeeDetails)
        {

            items.Name = employee.Name;

            items.Email = employee.Email;

            items.DatofBirth = employee.DatofBirth;

            items.Salary = employee.Salary;

            items.Department = employee.Department;

            _database.Employee.Update(items);

            _database.SaveChanges();

        }



        return RedirectToAction("Index", "Home");




    }

    public IActionResult Privacy()

    {

        return View();

    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    public IActionResult Error()

    {

        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    }

}