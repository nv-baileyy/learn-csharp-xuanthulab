using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;
public class RequestProcess
{
    public static string FormProcess(HttpRequest request)
    {

        string res = "";
        if (request.Method == "POST")
        {
            var _form = request.Form;
            string name = _form["name"].FirstOrDefault() ?? "";
            string mail = _form["mail"].FirstOrDefault() ?? "";
            string pass = _form["password"].FirstOrDefault() ?? "";
            foreach (var ele in _form.Files)
            {
                string fileName = ele.FileName;
                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    ele.CopyToAsync(stream);
                    res += $"File: {fileName}\n";
                }

            }
            res += $"name: {name}, mail: {mail}, pass: {pass}";
        }
        var tex = System.IO.File.ReadAllText("formtest.html");
        System.Console.WriteLine(tex);
        var html = string.Format(tex, "Nguyen Van Hai", "hai@mail.com", "1234567");
        return html + res;
    }
    public static string RequestInformation(HttpRequest request)
    {
        var sb = new StringBuilder();

        // Lấy http scheme (http|https)
        var scheme = request.Scheme;
        sb.Append("scheme \t" + scheme + "\n");

        // HOST Header
        var host = (request.Host.HasValue ? request.Host.Value : "no host");
        sb.Append("host \t" + host + "\n");


        // Lấy pathbase (URL Path - cho Map)
        var pathbase = request.PathBase.ToString();
        sb.Append("pathbase\t" + pathbase + "\n");

        // Lấy Path (URL Path)
        var path = request.Path.ToString();
        sb.Append("path \n" + path);

        // Lấy chuỗi query của URL
        var QueryString = request.QueryString.HasValue ? request.QueryString.Value : "no query string";
        sb.Append(("QueryString\t" + QueryString + "\n"));

        // Lấy phương thức
        var method = request.Method;
        sb.Append(("Method\t" + method + "\n"));

        // Lấy giao thức
        var Protocol = request.Protocol;
        sb.Append(("Protocol\t" + Protocol + "\n"));

        // Lấy ContentType
        var ContentType = request.ContentType;
        sb.Append(("ContentType\t" + ContentType + "\n"));

        // Lấy danh sách các Header và giá trị  của nó, dùng Linq để lấy
        // Header gửi đến lưu trong thuộc tính Header  kiểu Dictionary
        var listheaderString = request.Headers.Select((header) => $"{header.Key}: {header.Value}\n");
        var headerhmtl = string.Join("", listheaderString); // nối danh sách thành 1
        sb.Append(("Header\t" + headerhmtl + "\n"));

        // Lấy danh sách các Header và giá trị  của nó, dùng Linq để lấy
        var listcokie = request.Cookies.Select((header) => $"{header.Key}: {header.Value}\n");
        var cockiesHtml = string.Join("", listcokie);
        sb.Append(("Cookies\t" + cockiesHtml + "\n"));


        // Lấy tên và giá trí query
        var listquery = request.Query.Select((header) => $"{header.Key}: {header.Value}\n");
        var queryhtml = string.Join("", listquery);
        sb.Append(("Các Query\t" + queryhtml + "\n"));

        //Kiểm tra thử query tên abc có không
        Microsoft.Extensions.Primitives.StringValues abc;
        bool existabc = request.Query.TryGetValue("abc", out abc);
        string queryVal = existabc ? abc.FirstOrDefault() : "không có giá trị";
        sb.Append(("abc query\t" + queryVal.ToString() + "\n"));

        string info = "Thông tin Request" + sb.ToString();
        return info;
    }
}