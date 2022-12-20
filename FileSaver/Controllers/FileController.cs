using AspNetCoreHero.ToastNotification.Abstractions;
using CsvHelper;
using FileSaver.DBContext;
using FileSaver.Models;
using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SpreadsheetLight;
using System.Data;
using System.Globalization;
using System.Reflection;

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

        public IActionResult StoreSpreadSheet()
        {
            try
            {
                List<CSVData> fileData = WithCSVHelper();

                var dt = ToDataTable(fileData);

                SqlConnection con = new SqlConnection(@"Server = DESKTOP-PQF1NAD; Initial Catalog = FileTest;");

                SqlCommand columnCommand = new SqlCommand("Select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'tblSaliPracticeArea'", con);

                List<string> dbColumnList = new();

                con.Open();

                SqlDataReader reader = columnCommand.ExecuteReader();

                while (reader.Read())
                {
                    dbColumnList.Add(reader["COLUMN_NAME"].ToString());
                }
                con.Close();

                SqlBulkCopy objBulk = new SqlBulkCopy(con);

                objBulk.DestinationTableName = "tblSaliPracticeArea";

                for (int i= 0; i< dt.Columns.Count; i++)
                {
                    objBulk.ColumnMappings.Add(dt.Columns[i].ColumnName, dbColumnList[i+1]);
                }

                con.Open();
                objBulk.WriteToServer(dt);
                con.Close();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        public List<CSVData> WithCSVHelper()
        {
            List<CSVData> dataList = new();
            DateTime startTime = DateTime.Now;

            using (var reader = new StreamReader("C:\\Users\\bhara\\Desktop\\AA\\cc.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<CSVDataMap>();
                dataList = csv.GetRecords<CSVData>().ToList();
               
            }
            DateTime endTime = DateTime.Now;
            var timeTaken = (endTime - startTime).TotalSeconds;

            Console.WriteLine(dataList.Count);
            Console.WriteLine("CSVHelper Total Time: " + timeTaken);

            return dataList;

        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public IResult TestCSV()
        {
            try
            {
                WithCSVHelper();
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }


        public List<FileModel> ReadXLS()
        {
            List<FileModel> dataList = new();

            DateTime startTime = DateTime.Now;
            using (var doc = new SLDocument("C:\\Users\\bhara\\Desktop\\AA\\xls.xlsx"))
            {
                var stats = doc.GetWorksheetStatistics();

                List<FileModel> fileObj = new();

                for (int row = 2; row < stats.EndRowIndex + 1; row++)
                {
                    FileModel dataObj = new();

                    for (int column = 1; column < stats.EndColumnIndex; column++)
                    {

                        if (column == 26)
                        {
                            continue;
                        }
                        else
                        {
                            // dataObj.ID = 0;
                            switch (column)
                            {
                                case (1):
                                    dataObj.Superclass = doc.GetCellValueAsString(row, column);
                                    break;
                                case (2):
                                    dataObj.Label = doc.GetCellValueAsString(row, column);
                                    break;
                                case (3):
                                    dataObj.IRI = doc.GetCellValueAsString(row, column);
                                    break;
                                case (4):
                                    dataObj.Type = doc.GetCellValueAsString(row, column);
                                    break;
                                case (5):
                                    dataObj.Sali_appealsTo = doc.GetCellValueAsString(row, column);
                                    break;
                                case (6):
                                    dataObj.Sali_hasExpense = doc.GetCellValueAsString(row, column);
                                    break;
                                case (7):
                                    dataObj.Sali_filed = doc.GetCellValueAsString(row, column);
                                    break;
                                case (8):
                                    dataObj.Sali_seeksToAchieve = doc.GetCellValueAsString(row, column);
                                    break;
                                case (9):
                                    dataObj.Sali_workedFor = doc.GetCellValueAsString(row, column);
                                    break;
                                case (10):
                                    dataObj.Sali_cited = doc.GetCellValueAsString(row, column);
                                    break;
                                case (11):
                                    dataObj.Sali_participatedIn = doc.GetCellValueAsString(row, column);
                                    break;
                                case (12):
                                    dataObj.LocatedIn = doc.GetCellValueAsString(row, column);
                                    break;
                                case (13):
                                    dataObj.SeeAlso = doc.GetCellValueAsString(row, column);
                                    break;
                                case (14):
                                    dataObj.IsAuthor = doc.GetCellValueAsString(row, column);
                                    break;
                                case (15):
                                    dataObj.SameAs = doc.GetCellValueAsString(row, column);
                                    break;
                                case (16):
                                    dataObj.Before = doc.GetCellValueAsString(row, column);
                                    break;
                                case (17):
                                    dataObj.Sali_seealso = doc.GetCellValueAsString(row, column);
                                    break;
                                case (18):
                                    dataObj.legacyIdentifier = doc.GetCellValueAsString(row, column);
                                    break;
                                case (19):
                                    dataObj.Description = doc.GetCellValueAsString(row, column);
                                    break;
                                case (20):
                                    dataObj.Identifier = doc.GetCellValueAsString(row, column);
                                    break;
                                case (21):
                                    dataObj.LinkFirst = doc.GetCellValueAsString(row, column);
                                    break;
                                case (22):
                                    dataObj.LinkSecond = doc.GetCellValueAsString(row, column);
                                    break;
                                case (23):
                                    dataObj.HasRelatedSynonym = doc.GetCellValueAsString(row, column);
                                    break;
                                case (24):
                                    dataObj.Comment = doc.GetCellValueAsString(row, column);
                                    break;
                                case (25):
                                    dataObj.IsDefinedBy = doc.GetCellValueAsString(row, column);
                                    break;
                                case (27):
                                    dataObj.Deprecated = doc.GetCellValueAsString(row, column);
                                    break;
                                case (28):
                                    dataObj.InverseOf = doc.GetCellValueAsString(row, column);
                                    break;
                                case (29):
                                    dataObj.AltLabel = doc.GetCellValueAsString(row, column);
                                    break;
                                case (30):
                                    dataObj.Definition = doc.GetCellValueAsString(row, column);
                                    break;
                                case (31):
                                    dataObj.HiddenLabel = doc.GetCellValueAsString(row, column);
                                    break;
                                case (32):
                                    dataObj.PrefLabel = doc.GetCellValueAsString(row, column);
                                    break;

                                default:
                                    Console.WriteLine("File reading Error");
                                    break;
                            }
                        }

                    }
                    dataList.Add(dataObj);
                }
                DateTime endTime = DateTime.Now;
                var timeTaken = (endTime - startTime).TotalSeconds;
                Console.WriteLine("SpreadSheetLight Total Time: " + timeTaken);
                return dataList;
            }
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

            var docContent = System.IO.File.ReadAllText("tempfile.rtf");
            System.IO.File.Delete("tempfile.rtf");

            return docContent;

        }
    }
}
