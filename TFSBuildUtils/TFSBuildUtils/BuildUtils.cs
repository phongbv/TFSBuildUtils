using Newtonsoft.Json;
using Syncfusion.XlsIO;
using System;
using System.IO;
using System.Net;

namespace TFSBuildUtils
{
    public class BuildUtils
    {
        //static string file = "Template.xlsx";

        //public static void Main(string file)
        public static void UpdateReportFile(string file, string projectUrl, int buildId)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new System.ArgumentException($"'{nameof(file)}' cannot be null or empty", nameof(file));
            }

            if (string.IsNullOrEmpty(projectUrl))
            {
                throw new System.ArgumentException($"'{nameof(projectUrl)}' cannot be null or empty", nameof(projectUrl));
            }
            Console.WriteLine(projectUrl + $"/_apis/build/builds/{buildId}/workitems?api-version=2.0");

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzUxOTQzQDMxMzgyZTMzMmUzMENzWmZTWVhsVnd4aHM2dUkwRTVFM1lCNHpNVEVuVmVyWmE3NFNkcnVoNVU9");
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(file);
                IWorksheet worksheet = workbook.Worksheets[0];
                var totalRow = worksheet.Rows.Length;
                var rowIndex = totalRow + 1;
                //Console.WriteLine("Send req");
                string str = RequestUtil.SendRequest(projectUrl + $"/_apis/build/builds/{buildId}/workitems?api-version=2.0");
                //Console.WriteLine(str);
                var buildWorkItem = JsonConvert.DeserializeObject<BuildWorkItemResponse>(str);
                Console.WriteLine($"Tổng số work item đang gắn vào bản build {buildId} là {buildWorkItem.RelatedItem.Count}");
                if (buildWorkItem.RelatedItem.Count == 0) return;
                worksheet.InsertRow(totalRow + 1, buildWorkItem.RelatedItem.Count);
                foreach (var item in buildWorkItem.RelatedItem)
                {
                    var workItem = JsonConvert.DeserializeObject<WorkItemInfo>(RequestUtil.SendRequest(item.url));
                    InsertText(worksheet, $"A{rowIndex}", buildId + "");
                    InsertText(worksheet, $"B{rowIndex}", DateTime.Today.ToString("yyyy-MM-dd"));
                    InsertText(worksheet, $"C{rowIndex}", workItem.id + "", workItem?.Links?.Html?.Href);
                    InsertText(worksheet, $"D{rowIndex}", workItem.Fields.WorkItemType + "");
                    InsertText(worksheet, $"E{rowIndex}", workItem.Fields.Title + "");
                    InsertText(worksheet, $"F{rowIndex}", workItem.Fields.AreaPath + "");

                    InsertText(worksheet, $"G{rowIndex}", workItem.Fields.AssignedToTester + "");
                    InsertText(worksheet, $"H{rowIndex}", workItem.Fields.AssignedTo + "");
                    InsertText(worksheet, $"I{rowIndex}", workItem.Fields.State + "");
                    //worksheet.Range[$"A{rowIndex}"].Text = workItem.id+"";
                    //worksheet.Range[$"B{rowIndex}"].Text = workItem.Fields.Title+"";
                    //worksheet.Range[$"C{rowIndex}"].Text = workItem.Fields.AreaPath+"";
                    //worksheet.Range[$"D{rowIndex}"].Text = workItem.Fields.HandleBy+"";
                    //worksheet.Range[$"E{rowIndex}"].Text = workItem.Fields.AssignedToTester+"";
                    //worksheet.Range[$"F{rowIndex}"].Text = workItem.Fields.AssignedTo+"";
                    //worksheet.Range[$"G{rowIndex}"].Text = workItem.Fields.State+"";
                    rowIndex++;
                }
                //worksheet.Range[0, 0, worksheet.Rows.Length - 1, worksheet.Cells.Length -1 ].BorderInside();
                workbook.Save();
                //WriteLine(worksheet.Rows.Length);

            }
            //ReadKey();
        }
        private static void InsertText(IWorksheet worksheet, string cellId, string content, string hyperLink = null)
        {
            var cell = worksheet.Range[cellId];

            if (string.IsNullOrEmpty(hyperLink) == false)
            {
                IHyperLink hyperlink = worksheet.HyperLinks.Add(cell);
                hyperlink.Type = ExcelHyperLinkType.Url;
                hyperlink.Address = hyperLink;
                hyperlink.ScreenTip = hyperLink;
                hyperlink.TextToDisplay = content;
            }
            else
            {
                cell.Text = content;
            }
            cell.WrapText = true;
            //cell.Borders.Value = ExcelLineStyle.al

        }


    }

    public class RequestUtil
    {
        public static string SendRequest(string url)
        {
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Close the response.
                response.Close();
                // Display the content.
                return responseFromServer;
            }


        }
    }
}
