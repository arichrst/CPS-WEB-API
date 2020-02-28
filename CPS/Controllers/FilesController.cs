using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CPS.Controllers
{
    public class UploadResult {
        public string Link{get;set;}
    }

    [Route("api/[controller]")]
    public class FilesController : MastersController
    {
        [HttpPost("UploadImage")]
        public UploadResult UploadImage(IFormFile file)
        {
            string filename = Guid.NewGuid().ToString();
            var dir = Directory.GetCurrentDirectory();
            if (file.Length > 0)
            {
                try
                {
                    string extension = Path.GetExtension(file.FileName);
                    if (!Directory.Exists(dir + "/"+ "uploads" +"/"))
                    {
                        Directory.CreateDirectory(dir + "/" + "uploads" + "/");
                    }
                    using (FileStream filestream = System.IO.File.Create(dir + "/" + "uploads" + "/" + filename + extension))
                    {
                        file.CopyTo(filestream);
                        filestream.Flush();
                        var baseUrl = HttpContext.Request.Host;
                        UploadResult res = new UploadResult();
                        res.Link =  "/" + "uploads" + "/" + filename + extension;
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
            {
                return  null;
            }

        } 

        [HttpGet("DownloadReport")]
        public IActionResult DownloadReport(int routeId)
        {
            byte[] fileContents;
            var route = Db.Route.SingleOrDefault(x=>x.Id == routeId);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Laporan_Kajian");
                var imgWorksheet = package.Workbook.Worksheets.Add("Gambar_Kajian");

                // Put whatever you want here in the sheet
                // For example, for cell on row1 col1

                
                if(route != null)
                {
                worksheet.Cells["A1:D1"].Merge = true;
                worksheet.Cells[1, 1].Value = "PT. NUSAKURA STANDARINDO";
                worksheet.Cells[1, 1].Style.Font.Size = 12;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["E1:H1"].Merge = true;
                worksheet.Cells[1, 5].Value = "HASIL PENGUKURAN SISTEM PROTEKSI KATODIK";
                worksheet.Cells[1, 5].Style.WrapText = true;
                worksheet.Cells[1, 5].Style.Font.Size = 12;
                worksheet.Cells[1, 5].Style.Font.Bold = true;
                worksheet.Cells[1, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["I1:K1"].Merge = true;
                worksheet.Cells[1, 9].Value = route.Name;
                worksheet.Cells[1, 9].Style.WrapText = true;
                worksheet.Cells[1, 9].Style.Font.Size = 12;
                worksheet.Cells[1, 9].Style.Font.Bold = true;
                worksheet.Cells[1, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 9].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["A2:F2"].Merge = true;
                worksheet.Cells[2, 1].Value = "JALUR PIPA " + route.FromRegion + " - " + route.ToRegion;
                worksheet.Cells[2, 1].Style.Font.Size = 11;
                worksheet.Cells[2, 1].Style.Font.Bold = true;
                worksheet.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["G2:H2"].Merge = true;
                worksheet.Cells[2, 7].Value = "ALAT UKUR";
                worksheet.Cells[2, 7].Style.Font.Size = 11;
                worksheet.Cells[2, 7].Style.Font.Bold = true;
                worksheet.Cells[2, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["I2:K2"].Merge = true;
                worksheet.Cells[2, 9].Value = "MERK";
                worksheet.Cells[2, 9].Style.Font.Size = 11;
                worksheet.Cells[2, 9].Style.Font.Bold = true;
                worksheet.Cells[2, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["A3:D3"].Merge = true;
                worksheet.Cells[3, 1].Value = "FIELD";
                worksheet.Cells[3, 1].Style.Font.Size = 11;
                worksheet.Cells[3, 1].Style.Font.Bold = true;
                worksheet.Cells[3, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["A4:D4"].Merge = true;
                worksheet.Cells[4, 1].Value = "PANJANG PIPA";
                worksheet.Cells[4, 1].Style.Font.Size = 11;
                worksheet.Cells[4, 1].Style.Font.Bold = true;
                worksheet.Cells[4, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["A5:D5"].Merge = true;
                worksheet.Cells[5, 1].Value = "DIAMETER";
                worksheet.Cells[5, 1].Style.Font.Size = 11;
                worksheet.Cells[5, 1].Style.Font.Bold = true;
                worksheet.Cells[5, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["A6:D6"].Merge = true;
                worksheet.Cells[6, 1].Value = "TIPE PROTEKSI KATODIK";
                worksheet.Cells[6, 1].Style.Font.Size = 11;
                worksheet.Cells[6, 1].Style.Font.Bold = true;
                worksheet.Cells[6, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["A7:D7"].Merge = true;
                worksheet.Cells[7, 1].Value = "MATERIAL ANODA";
                worksheet.Cells[7, 1].Style.Font.Size = 11;
                worksheet.Cells[7, 1].Style.Font.Bold = true;
                worksheet.Cells[7, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["E3:F3"].Merge = true;
                worksheet.Cells[3, 5].Value = route.Field;
                worksheet.Cells[3, 5].Style.Font.Size = 11;
                worksheet.Cells[3, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["E4:F4"].Merge = true;
                worksheet.Cells[4, 5].Value = route.Distance + " Meter";
                worksheet.Cells[4, 5].Style.Font.Size = 11;
                worksheet.Cells[4, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["E5:F5"].Merge = true;
                worksheet.Cells[5, 5].Value = route.Diameter + " Inch";
                worksheet.Cells[5, 5].Style.Font.Size = 11;
                worksheet.Cells[5, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["E6:F6"].Merge = true;
                worksheet.Cells[6, 5].Value = route.ProtectionCatodicType;
                worksheet.Cells[6, 5].Style.Font.Size = 11;
                worksheet.Cells[6, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["E7:F7"].Merge = true;
                worksheet.Cells[7, 5].Value = route.AnodeMaterial;
                worksheet.Cells[7, 5].Style.Font.Size = 11;
                worksheet.Cells[7, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["G3:H3"].Merge = true;
                worksheet.Cells[3, 7].Style.Font.Size = 11;
                worksheet.Cells[3, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["G4:H4"].Merge = true;
                worksheet.Cells[4, 7].Style.Font.Size = 11;
                worksheet.Cells[4, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["G5:H5"].Merge = true;
                worksheet.Cells[5, 7].Style.Font.Size = 11;
                worksheet.Cells[5, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["G6:H6"].Merge = true;
                worksheet.Cells[6, 7].Style.Font.Size = 11;
                worksheet.Cells[6, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["G7:H7"].Merge = true;
                worksheet.Cells[7, 7].Style.Font.Size = 11;
                worksheet.Cells[7, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["I3:K3"].Merge = true;
                worksheet.Cells[3, 9].Style.Font.Size = 11;
                worksheet.Cells[3, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["I4:K4"].Merge = true;
                worksheet.Cells[4, 9].Style.Font.Size = 11;
                worksheet.Cells[4, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["I5:K5"].Merge = true;
                worksheet.Cells[5, 9].Style.Font.Size = 11;
                worksheet.Cells[5, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["I6:K6"].Merge = true;
                worksheet.Cells[6, 9].Style.Font.Size = 11;
                worksheet.Cells[6, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();

                worksheet.Cells["I7:K7"].Merge = true;
                worksheet.Cells[7, 9].Style.Font.Size = 11;
                worksheet.Cells[7, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.AutoFitColumns();


                worksheet.Cells["A8:A9"].Merge = true;
                worksheet.Cells[8, 1].Value = "NO";
                worksheet.Cells[8, 1].Style.Font.Size = 11;
                worksheet.Cells[8, 1].Style.Font.Bold = true;
                worksheet.Cells[8, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[8, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells["B8:B9"].Merge = true;
                worksheet.Cells[8, 2].Value = "TP NO";
                worksheet.Cells[8, 2].Style.Font.Size = 11;
                worksheet.Cells[8, 2].Style.Font.Bold = true;
                worksheet.Cells[8, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[8, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells["C8:C9"].Merge = true;
                worksheet.Cells[8, 3].Value = "LOKASI KP";
                worksheet.Cells[8, 3].Style.Font.Size = 11;
                worksheet.Cells[8, 3].Style.Font.Bold = true;
                worksheet.Cells[8, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[8, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells["D8:F8"].Merge = true;
                worksheet.Cells[8, 4].Value = "POTENSIAL STRUKTUR vs Cu/CuSO4 (-mV)";
                worksheet.Cells[8, 4].Style.Font.Size = 11;
                worksheet.Cells[8, 4].Style.Font.Bold = true;
                worksheet.Cells[8, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[8, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
               

                worksheet.Cells["D9:D9"].Merge = true;
                worksheet.Cells[9, 4].Value = "Native Pipa";
                worksheet.Cells[9, 4].Style.Font.Size = 11;
                worksheet.Cells[9, 4].Style.Font.Bold = true;
                worksheet.Cells[9, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[9, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells["E9:E9"].Merge = true;
                worksheet.Cells[9, 5].Value = "Anode";
                worksheet.Cells[9, 5].Style.Font.Size = 11;
                worksheet.Cells[9, 5].Style.Font.Bold = true;
                worksheet.Cells[9, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[9, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells["F9:F9"].Merge = true;
                worksheet.Cells[9, 6].Value = "Proteksi";
                worksheet.Cells[9, 6].Style.Font.Size = 11;
                worksheet.Cells[9, 6].Style.Font.Bold = true;
                worksheet.Cells[9, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[9, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells["G8:G8"].Merge = true;
                worksheet.Cells[8, 7].Value = "Arus Anode";
                worksheet.Cells[8, 7].Style.Font.Size = 11;
                worksheet.Cells[8, 7].Style.Font.Bold = true;
                worksheet.Cells[8, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[8, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells["G9:G9"].Merge = true;
                worksheet.Cells[9, 7].Value = "(mA))";
                worksheet.Cells[9, 7].Style.Font.Size = 11;
                worksheet.Cells[9, 7].Style.Font.Bold = true;
                worksheet.Cells[9, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[9, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells["H8:H9"].Merge = true;
                worksheet.Cells[8, 8].Value = "Kondisi Test Point";
                worksheet.Cells[8, 8].Style.Font.Size = 11;
                worksheet.Cells[8, 8].Style.Font.Bold = true;
                worksheet.Cells[8, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[8, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells["I8:I9"].Merge = true;
                worksheet.Cells[8, 9].Value = "Soil Resistivity";
                worksheet.Cells[8, 9].Style.Font.Size = 11;
                worksheet.Cells[8, 9].Style.Font.Bold = true;
                worksheet.Cells[8, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[8, 9].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells["J8:J9"].Merge = true;
                worksheet.Cells[8, 10].Value = "pH";
                worksheet.Cells[8, 10].Style.Font.Size = 11;
                worksheet.Cells[8, 10].Style.Font.Bold = true;
                worksheet.Cells[8, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[8, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells["K8:K9"].Merge = true;
                worksheet.Cells[8, 11].Value = "Korosivitas Tanah";
                worksheet.Cells[8, 11].Style.Font.Size = 11;
                worksheet.Cells[8, 11].Style.Font.Bold = true;
                worksheet.Cells[8, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[8, 11].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                int i = 1;
                int row = 10;
                var tp = Db.TestPoint.Where(c => c.RouteId == routeId);
                foreach(var item in tp)
                {
                    worksheet.Cells[row, 1].Value = i.ToString();
                    worksheet.Cells[row, 1].Style.Font.Size = 11;
                    worksheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, 2].Value = item.Name;
                    worksheet.Cells[row, 2].Style.Font.Size = 11;
                    worksheet.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, 3].Value = item.KpLocation;
                    worksheet.Cells[row, 3].Style.Font.Size = 11;
                    worksheet.Cells[row, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, 4].Value = item.NativePipe;
                    worksheet.Cells[row, 4].Style.Font.Size = 11;
                    worksheet.Cells[row, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, 5].Value = item.Anode;
                    worksheet.Cells[row, 5].Style.Font.Size = 11;
                    worksheet.Cells[row, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, 6].Value = item.Protection;
                    worksheet.Cells[row, 6].Style.Font.Size = 11;
                    worksheet.Cells[row, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, 7].Value = item.AnodePower;
                    worksheet.Cells[row, 7].Style.Font.Size = 11;
                    worksheet.Cells[row, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, 8].Value = item.Notes;
                    worksheet.Cells[row, 8].Style.Font.Size = 11;
                    worksheet.Cells[row, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, 9].Value = item.SoilResistivity;
                    worksheet.Cells[row, 9].Style.Font.Size = 11;
                    worksheet.Cells[row, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, 10].Value = item.Ph;
                    worksheet.Cells[row, 10].Style.Font.Size = 11;
                    worksheet.Cells[row, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, 11].Value = 
                    item.SoilResistivity < 500 ? "Very Corrosive" : 
                    item.SoilResistivity >= 500 && item.SoilResistivity < 1000 ? "Corrosive" :
                    item.SoilResistivity >= 1000 && item.SoilResistivity < 2000 ? "Moderately Corrosive" :
                    item.SoilResistivity >= 2000 && item.SoilResistivity < 10000 ? "Mildly Corrosive" : "Progressively Less Corrosive";
                    worksheet.Cells[row, 11].Style.Font.Size = 11;
                    worksheet.Cells[row, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    row++;
                    i++;
                }
                row++;
                    string modelRange = "A1:K" + row;
                    var modelTable = worksheet.Cells[modelRange];

                    // Assign borders
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    modelTable.AutoFitColumns();
                    package.Save();
                    int pos = 1;
                    foreach(var item in tp)
                    {
                        imgWorksheet.Cells[pos, 1].Value = item.Name;
                        imgWorksheet.Cells[pos, 1].Style.Font.Size = 14;
                        imgWorksheet.Cells[pos, 1].Style.Font.Bold = true;
                        imgWorksheet.Cells[pos, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        imgWorksheet.Cells[pos, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        /*var tpimgs = Db.Tpimage.Where(c=>c.TestPointId == item.Id);
                        var imgcounter = 2;
                        foreach(var tpimg in tpimgs){
                    
                           try{
                               string filename = tpimg.Link.Replace("http://167.71.201.121/uploads/","");
                               var fullpath = Directory.GetCurrentDirectory() + "/uploads/" + filename;
                                var excelImage = imgWorksheet.Drawings.AddPicture(tpimg.Id.ToString(),System.Drawing.Image.FromFile(fullpath) );
                            
                                excelImage.SetPosition(pos, 0, imgcounter, 0);
                            }catch(Exception){}
                            imgcounter++;
                        }*/
                        pos++;
                        
                    }
                    imgWorksheet.Cells.AutoFitColumns();
                }
                // So many things you can try but you got the idea.

                // Finally when you're done, export it to byte array.
                fileContents = package.GetAsByteArray();
            }

            if (fileContents == null || fileContents.Length == 0 || route == null)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: route.Field + "_" + route.Id + ".xlsx"
            );
        }      
    }
    

}
