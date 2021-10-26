
namespace WebApplication.Models.ViewModel
{
    public class LayoutViewModel
    {
        public string ViewTitle => "Aiko Digital";

    }
    
    public class LayoutViewModel<T> : LayoutViewModel
    {
        public string ViewTitle { get; set; }
        
        public T PageModel { get; }
        
        public LayoutViewModel(T pageModel)
        {
            PageModel = pageModel;
        }

        protected LayoutViewModel()
        {
        }
    }
}