using agriculture.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace agriculture.Controllers
{
	public class ReportController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult StaticReport()
		{
			ExcelPackage excelPackage = new ExcelPackage();
			var workbook = excelPackage.Workbook.Worksheets.Add("Dosya1");

			workbook.Cells[1, 1].Value = "Ürün Adı";
			workbook.Cells[1,2].Value= "Ürün Kategorisi";
			workbook.Cells[1,3].Value = "Ürün Stok";

			workbook.Cells[2, 1].Value = "Mercimek";
			workbook.Cells[2, 2].Value = "Bakliyat";
			workbook.Cells[2, 3].Value = "785 Kg";

            workbook.Cells[3, 1].Value = "Fasulye";
            workbook.Cells[3, 2].Value = "Bakliyat";
            workbook.Cells[3, 3].Value = "585 Kg";

            workbook.Cells[4, 1].Value = "Buğday";
            workbook.Cells[4, 2].Value = "Bakliyat";
            workbook.Cells[4, 3].Value = "725 Kg";

			var bytes = excelPackage.GetAsByteArray();

            return File(bytes,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","BakliyatRaporu.xlsx");
		}

		public List<ContactModel> ContactList()
		{
			List<ContactModel> contactModels = new List<ContactModel>();
			using (var context = new AgricultureContext())
			{
				contactModels = context.Contacts.Select(x=>new ContactModel
				{
					 ContactID = x.ContactID,
					 ContactName=x.Name,
					 ContactMessage=x.Message,
					 ContactMail=x.Mail,
				}).ToList();
				return contactModels;
			}
		}

        public IActionResult ContactReport()
		{
			using (var workbook=new XLWorkbook ())
			{
				var worksheet = workbook.Worksheets.Add("Mesaj Listesi");
				worksheet.Cell(1, 1).Value=("Mesaj ID");
				worksheet.Cell(1, 2).Value=("Mesaj Gönderen ");
				worksheet.Cell(1, 3).Value=("Mail ");
				worksheet.Cell(1, 4).Value=("Mesaj İçeriği");

				int contactRowCount = 2;

				foreach (var item in ContactList())
				{
					worksheet.Cell(contactRowCount, 1).Value=item.ContactID;
                    worksheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    worksheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    worksheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
					contactRowCount++;
                }
				using (var stream=new MemoryStream())
				{
					workbook.SaveAs(stream);
					var content =stream.ToArray();
					return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MesajRapor.xlsx");
				}
			}					
		}

		public List<AnnouncamentModel>AnnouncamentList()
		{
			List<AnnouncamentModel> announcaments = new List<AnnouncamentModel>();

			using (var context =new AgricultureContext())
			{
				announcaments=context.Announcements.Select(x=>new AnnouncamentModel
				{
					AnnouncamentID=x.AnnouncementID,
					AnnouncamentModelTitle=x.Title,
					AnnouncamentModelDescription=x.Description,
					AnnouncamentModelDate=x.Date,
					AnnouncamentModelStatus=x.Status,
				}).ToList();
				return announcaments;
					
				
			}
		}

		public IActionResult AnnouncamentReport()
		{
			using (var workbook=new XLWorkbook())
			{
				var worksheet = workbook.Worksheets.Add("Duyuru Listesi");
				worksheet.Cell(1, 1).Value = "AnnouncamentID";
				worksheet.Cell(1, 2).Value = "Başlık";
				worksheet.Cell(1, 3).Value = "Duyuru";
				worksheet.Cell(1, 4).Value = "Tarih";
				worksheet.Cell(1, 5).Value = "Durum";

				int announcamentRow = 2;
				foreach (var item in AnnouncamentList())
				{
					worksheet.Cell(announcamentRow, 1).Value = item.AnnouncamentID;
					worksheet.Cell(announcamentRow, 2).Value = item.AnnouncamentModelTitle;
					worksheet.Cell(announcamentRow, 3).Value = item.AnnouncamentModelDescription;
					worksheet.Cell(announcamentRow, 4).Value = item.AnnouncamentModelDate;
					worksheet.Cell(announcamentRow, 5).Value = item.AnnouncamentModelStatus;
					announcamentRow++;
				}
				using (var stream=new MemoryStream())
				{
					workbook.SaveAs(stream);
					var announcament = stream.ToArray();
					return File(announcament, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRaporu.xlsx");
				}
            }
          
        }
    }


}
