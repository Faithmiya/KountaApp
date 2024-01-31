using KountaApp.Areas.Identity.Data;
using KountaApp.Areas.Identity.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KountaApp.Pages.Employee
{
    public class EditEmployeeModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;

        [BindProperty]
        public EditEmployee EditEmployee { get; set; }

        public EditEmployeeModel(KountaDbContext kountaDbContext)
        {
            this.kountaDbContext = kountaDbContext;
        }
        public void OnGet(int id)
        {
            var employee = kountaDbContext.Employees.Find(id);

            if (employee != null)
            {
                // convert to view model
                EditEmployee = new EditEmployee()
                {
                    // Map all fields from data model to view model
                    EmployeeId = employee.EmployeeId,
                    Position = employee.Position,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    FirstName = employee.FirstName,
                    // Include the fks
                    UserId = employee.UserId
                };
            }


        }
        public void OnPostUpdate()
        {
            if (EditEmployee != null)
            {
                var existingEmployee = kountaDbContext.Employees.Find(EditEmployee.EmployeeId);

                if (existingEmployee != null)
                {
                    // Convert view model back to data model
                    // Dont include any ids pks or fks



                    existingEmployee.FirstName = EditEmployee.FirstName;
                    existingEmployee.LastName = EditEmployee.LastName;
                    existingEmployee.Email = EditEmployee.Email;
                    existingEmployee.Phone = EditEmployee.Phone;
                    existingEmployee.Position = EditEmployee.Position;
                    kountaDbContext.SaveChanges();

                    // Message

                    ViewData["Message"] = "Employee Updated Successfully!";

                    Response.Redirect("/Employee/ListEmployee");



                }

            }
        }
        public IActionResult OnPostDelete()
        {
            // find employee 
            var existingEmployee = kountaDbContext.Employees.Find(EditEmployee.EmployeeId);

            if (existingEmployee != null)
            {
                kountaDbContext.Employees.Remove(existingEmployee);
                kountaDbContext.SaveChanges();

                return RedirectToPage("/Employee/ListEmployee");
            }

            return Page();

        }
    }
}
