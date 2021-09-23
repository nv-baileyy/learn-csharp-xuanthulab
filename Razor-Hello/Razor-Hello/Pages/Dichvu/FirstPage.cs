using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class FirstPageModel : PageModel
{
    public string title = "Xin chao, day la doan code demo dung viewmodel";

    // OnGet, OnGetAbc...
    // OnPost(), OnPostAc...
    // -> Handler
    // Method OnGet() se duoc goi ngay dau tin khi vao FirstPage
    public void OnGet()
    {
        Console.WriteLine("OnGet duoc goi");
        ViewData["mydata"] = "This is ViewData demo";
        ViewData["title"] = "Trang dau tien";
    }
    // GET Url?handler=XYZ
    public void OnGetXYZ()
    {

    }
}