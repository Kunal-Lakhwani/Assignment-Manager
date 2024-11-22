using Assignment_Management.Data;
using Assignment_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace Assignment_Management.Pages.Admin
{
    public class VerifyStudentsModel : PageModel
    {
        private readonly Assignment_ManagementContext _context;

        [BindProperty]
        public IList<Student> StagedVerifications { get; set; }

        public VerifyStudentsModel(Assignment_ManagementContext context)
        {
            _context = context;
            StagedVerifications = new List<Student>();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostUploadCSV(IFormFile StudCSV)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (StudCSV == null || StudCSV.Length == 0)
            {
                return BadRequest("File is empty");
            }
            using (TextFieldParser parser = new TextFieldParser(StudCSV.OpenReadStream()))
            {

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                List<Student> records = new List<Student>();
                List<string> pwdLst = new List<string>();
                // Skip header row
                if (!parser.EndOfData)
                {
                    parser.ReadLine();
                }

                while (!parser.EndOfData)
                {
                    string pwd = AccountUtil.GeneratePassword();
                    pwdLst.Add(pwd);
                    string salt = AccountUtil.GenerateSalt();
                    string hash = AccountUtil.GetHash(pwd, salt);
                    // Google forms field 0 is always timestamp
                    string[] fields = parser.ReadFields();
                    records.Add(new Student() { MailID = fields[1], PRN = long.Parse(fields[2]), FirstName = fields[3], MiddleName = fields[4], LastName = fields[5], salt = salt, hash = hash });
                }
                StagedVerifications = records;
                HttpContext.Session.SetString("StudentsLst", JsonConvert.SerializeObject(records));
                HttpContext.Session.SetString("StudentPwdLst", JsonConvert.SerializeObject(pwdLst));
            }
            return Page();
        }

        public async Task<IActionResult> OnPostSaveData() {
            List<Student> records = JsonConvert.DeserializeObject<List<Student>>(HttpContext.Session.GetString("StudentsLst"));
            List<string> pwdLst = JsonConvert.DeserializeObject<List<string>>(HttpContext.Session.GetString("StudentPwdLst"));
            for (int i = 0; i < records.Count; i++)
            {
                _context.Student.Add(records[i]);
                AccountUtil.SendMail(records[i].MailID, "You have been verified", $"Hello {records[i].FirstName},\n We are sending this mail to inform you that your account has been verified for MSU Assignment Management portal.\nPlease use the verified E-Mail along with your password {pwdLst[i]}, to Login to the website.");
            }
            _context.SaveChanges();
            return Page();
        }
    }
}
