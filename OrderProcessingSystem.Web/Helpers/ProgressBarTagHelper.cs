using System;
using Microsoft.AspNetCore.Razor.TagHelpers;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Web.Helpers
{
    /// <summary>
    /// Tag helper to show progress of order
    /// </summary>
    public class ProgressBarTagHelper : TagHelper
    {
        /// <summary>
        /// Percentage of complete at this stage
        /// </summary>
        public Int32 PercentageComplete { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "progress-bar progress-bar-success progress-bar-striped");
            output.Attributes.SetAttribute("style", "width: " + PercentageComplete + "%");
        }
    }
}