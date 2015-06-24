using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewValidationMvc.Helpers
{
    /// <summary>
    /// HtmlHelper extension for Bootstrap Modal
    /// </summary>
    public static class ModalExtensions
    {
        private class ModalContainer : IDisposable
        {
            private readonly TextWriter _writer;

            public ModalContainer(TextWriter writer)
            {
                _writer = writer;
            }

            public void Dispose()
            {
                _writer.WriteLine("         </div>");
                _writer.WriteLine("     </div>");
                _writer.WriteLine("</div>");
            }
        }

        public static IDisposable Modal(this HtmlHelper htmlHelper, string id, string title)
        {
            var writer = htmlHelper.ViewContext.Writer;

            writer.WriteLine("<div class=\"modal fade\" id=\"{0}\" tabindex=\"-1\" role=\"dialog\">", id);
            writer.WriteLine("  <div class=\"modal-dialog\">");
            writer.WriteLine("      <div class=\"modal-content\">");
            writer.WriteLine("          <div class=\"modal-header\">");
            writer.WriteLine("              <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>");
            writer.WriteLine("              <h4 class=\"modal-title\">{0}</h4>", title);
            writer.WriteLine("          </div>");

            return new ModalContainer(writer);
        }
    }
}