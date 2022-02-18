using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichelMichels.QuestPDF.LineBug
{
    public class LineDocument : IDocument
    {
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Header().Element(ComposeHeader);
            });
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        private void ComposeHeader(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Element(ComposeLineBug);
                column.Item().Element(ComposeTextSpacing);
            });
        }

        void ComposeLineBug(IContainer container)
        {
            container.Row(row =>
            {
                row
                    .RelativeItem()
                    .Background(Colors.Blue.Accent1)
                    .Column(column =>
                    {
                        column.Item().Text("Line 1");
                    });

                row
                    .RelativeItem()
                    .Background(Colors.Red.Accent1)
                    .Column(column =>
                    {
                        column.Item().Text("Line 1");
                        column.Item().Text("Line 2");

                        // This makes the code go boom
                        //column.Item().LineHorizontal(0.1f);

                        // Following line doesn't crash the program:
                        //
                        column.Item().LineHorizontal(0.1f, Unit.Millimetre);
                    });

            });
        }

        void ComposeTextSpacing(IContainer container)
        {
            container.Row(row =>
            {
                row
                    .RelativeItem()
                    .Column(column =>
                    {
                        column.Item().Text("Text without spaces in front");
                        column.Item().Text("  Text with 2 spaces");
                        column.Item().Text("    Text with 4 spaces");
                        column.Item().Text("\tText with 1 tab");
                        column.Item().Text("\t\tText with 2 tabs");
                    });
            });
        }
    }
}
