using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace UI.TocHoPham.HelperExtension
{
    public static class Helper
    {
        public static string AdminAssets(this UrlHelper url, string link)
        => $"/Content/admin/{link}";

        public static string ClientAssets(this UrlHelper url, string link)
        => $"/Content/client/{link}";
        
        public static string TrundicateString(this HtmlHelper html, string input, int maxLength)
        => input != null ? (input.Length <= maxLength ? input : $"{input.Substring(0, maxLength)}...") : string.Empty;

        public static string CoverPhotoUrl => "/Content/coverPhotos";

        public static string WriteToFile(this Controller controller, HttpPostedFileBase file, string location = null)
        {
            location = location ?? CoverPhotoUrl;
            string fileName = "https://increasify.com.au/wp-content/uploads/2016/08/default-image.png";
            
            if (file != null)
            {
                string extensionName = Path.GetExtension(file.FileName);
                string finalFileName = $"{Guid.NewGuid()}{extensionName}";
                fileName = finalFileName;

                string path = Path.Combine(controller.Server.MapPath(location), fileName);
                file.SaveAs(path);
                return $"{location}/{fileName}";
            }
            return fileName;
        }
    }
}