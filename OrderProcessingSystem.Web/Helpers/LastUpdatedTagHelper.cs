using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace OrderProcessingSystem.Web.Helpers
{
    /// <summary>
    /// Tag helper to change text color to red if order is not updated in last 3 days.
    /// </summary>
    [HtmlTargetElement("span", Attributes = "last-updated")]
    public class LastUpdatedTagHelper : TagHelper
    {
        public DateTime LastUpdated { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (LastUpdated < DateTime.Now.AddDays(-3))
            {
                output.Attributes.SetAttribute("class", "text-danger pull-right");
            }
        }
    }
}