using MichelMichels.QuestPDF.LineBug;
using QuestPDF.Fluent;

var document = new LineDocument();
document.GeneratePdf("line.pdf");

Console.WriteLine("Done.");

