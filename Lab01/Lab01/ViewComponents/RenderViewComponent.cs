using Microsoft.AspNetCore.Mvc;
using Lab01.Models;

namespace Lab01.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private List<MenuItem> MenuItems = new List<MenuItem>();

        public RenderViewComponent()
        {
            MenuItems = new List<MenuItem>()
            {
                new MenuItem() { Id=1, Name="Branches", Link="/Branch/Index" },
                new MenuItem() { Id=2, Name="Students", Link="/Student/Index" },
                new MenuItem() { Id=3, Name="Subjects", Link="/Subject/Index" },
                new MenuItem() { Id=4, Name="Courses", Link="/Course/Index" }
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderLeftMenu", MenuItems);
        }
    }
}
