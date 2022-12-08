using AspNetCoreHero.ToastNotification.Abstractions;
using FileSaver.DBContext;
using FileSaver.Models;
using GemBox.Document;
using Microsoft.AspNetCore.Mvc;

namespace FileSaver.Controllers
{
    public class FileController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly INotyfService toastNotification;
        public FileController(ApplicationDBContext context, INotyfService notification)
        {
            _context = context;
            toastNotification = notification;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFile(Filess file)
        {
            if (ModelState.IsValid)
            {
                file.FileContent = CreateRTF(file.FileContent);

                _context.Add(file);
                _context.SaveChanges();
                toastNotification.Success("New File added");
                return RedirectToAction("ViewFile");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ViewFile()
        {
            var files = _context.Files.ToList();

            foreach (var file in files)
            {
                file.FileContent = RtfPipe.Rtf.ToHtml(file.FileContent);
            }
            return View(files);
        }

        public string CreateRTF(string htmlText)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            var htmlLoadOptions = new HtmlLoadOptions();
            using (var htmlStream = new MemoryStream(htmlLoadOptions.Encoding.GetBytes(htmlText)))
            {
                // Load input HTML text as stream.
                var document = DocumentModel.Load(htmlStream, htmlLoadOptions);
                // Save output RTF file.
                document.Save("tempfile.rtf");
            }

            var docContent  = System.IO.File.ReadAllText("tempfile.rtf");
            System.IO.File.Delete("tempfile.rtf");

            return docContent;

        }
    }
}
