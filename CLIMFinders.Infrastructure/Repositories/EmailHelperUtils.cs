using CLIMFinders.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using System.Text;

namespace CLIMFinders.Infrastructure.Repositories
{
    public class EmailHelperUtils(IWebHostEnvironment env): IEmailHelperUtils
    {
        private readonly IWebHostEnvironment _env = env;

        public string FillEmailContents(
            object dataToFill,
            string fileName,
            string Name
        )
        {

            var templateContent = File.ReadAllText(
                Path.Combine(_env.ContentRootPath, "wwwroot/EmailTemplates/" + fileName + ".html")
            );
             
            templateContent = templateContent.Replace("@Name", Name); 
             
            foreach (PropertyInfo prop in dataToFill.GetType().GetProperties())
            {
                var propName = "@" + Convert.ToString(prop.Name);
                var propValue = Convert.ToString(prop.GetValue(dataToFill, null)!);
                templateContent = templateContent.Replace(propName, propValue);
            }

            templateContent = templateContent.Replace("True", "Yes");
            templateContent = templateContent.Replace("False", "No");

            return templateContent;
        }
        public string FillDynamicEmailContents(Dictionary<string, string> dataToFill, string fileName, string FullName)
        {
            var templateContent = File.ReadAllText(
                Path.Combine(_env.ContentRootPath, "wwwroot/EmailTemplates/" + fileName + ".html")
            );


            templateContent = templateContent.Replace("@Name", FullName);

            StringBuilder stringBuilder = new();
            string Title = "<td width=\"33%\" style=\"-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; mso-line-height-rule:exactly;\"><p style=\"margin: 0px; font-size: 14px; text-align: center; color: #333; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-line-height-rule:exactly; line-height:1.5;\">@Title</p></td>";
            string Content = "<td style=\"-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; mso-line-height-rule:exactly;\"><p style=\"margin: 0px; font-size: 14px; text-align: center; color: #333; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-line-height-rule:exactly; line-height:1.5;\">@Content</p></td>";

            foreach (KeyValuePair<string, string> ele2 in dataToFill)
            {
                stringBuilder.Append("<tr>");
                stringBuilder.Append(Title.Replace("@Title", ele2.Key));
                stringBuilder.Append(Content.Replace("@Content", ele2.Value));
                stringBuilder.Append("</tr>");
            }

            templateContent = templateContent.Replace("@TableContent", stringBuilder.ToString());

            templateContent = templateContent.Replace("True", "Yes");
            templateContent = templateContent.Replace("False", "No");

            return templateContent;
        }

    }
}
