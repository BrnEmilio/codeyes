using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace codeyes.msc.each.Models
{
    public class CreatePost
    {
        public string ImageCaption { set; get; }
        public IFormFile MyImage { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime DateTime { set; get; }
    }
}