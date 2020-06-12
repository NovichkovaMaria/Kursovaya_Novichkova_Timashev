using BeautySalonBusinessLogic.Enums;
using BeautySalonBusinessLogic.HelperModels;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautySalonBusinessLogic.BuisnessLogics
{
    static class SaveToPdf
    {
        public static void CreateDoc(PdfInfo info)
        {
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(info.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";
            paragraph.Style = "Normal";
            var table = document.LastSection.AddTable();
            List<string> columns = new List<string> { "6cm", "6cm", "6cm", "6cm" };

            foreach (var elem in columns)
            {
                table.AddColumn(elem);
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "ФИО клиента", "Счет", "Заказ" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            
            foreach (var cl in info.Payments)
            {
                foreach(var vm in cl)
                {
                    CreateRow(new PdfRowParameters
                    {
                        Table = table,
                        Texts = new List<string>
                        {
                            vm.ClientId.ToString(),
                            vm.Sum.ToString(),
                            vm.OrderId.ToString()
                        },
                        Style = "Normal",
                        ParagraphAlignment = ParagraphAlignment.Left
                    });
                }
            }
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }

        public static void CreateDoc(PdfInfoClient info)
        {
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(info.Title);
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";
            foreach (var order in info.Orders)
            {
                var orderLabel = section.AddParagraph("Заказ №" + order.Id + " от " + order.DateCreate.ToShortDateString());
                orderLabel.Style = "NormalTitle";
                orderLabel.Format.SpaceBefore = "1cm";
                orderLabel.Format.SpaceAfter = "0,25cm";
                var servicesLabel = section.AddParagraph("Услуги:");
                servicesLabel.Style = "NormalTitle";
                var serviceTable = document.LastSection.AddTable();
                List<string> headerWidths = new List<string> { "1cm", "3cm", "3cm", "3cm", "3cm" };
                foreach (var elem in headerWidths)
                {
                    serviceTable.AddColumn(elem);
                }
                CreateRow(new PdfRowParameters
                {
                    Table = serviceTable,
                    Texts = new List<string> { "№", "Заказ", "Название", "Описание", "Цена" },
                    Style = "NormalTitle",
                    ParagraphAlignment = ParagraphAlignment.Center
                });
                int i = 1;
                foreach (var service in order.OrderServices)
                {
                    CreateRow(new PdfRowParameters
                    {
                        Table = serviceTable,
                        Texts = new List<string> { i.ToString(), service.OrderId.ToString(), service.ServiceName, service.Desc, service.Price.ToString()},
                        Style = "Normal",
                        ParagraphAlignment = ParagraphAlignment.Left
                    });
                    i++;
                }

                CreateRow(new PdfRowParameters
                {
                    Table = serviceTable,
                    Texts = new List<string> { "", "", "", "Итого:", order.Price.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = ParagraphAlignment.Left
                });
                if (order.Status == OrderStatus.Принят)
                {
                    CreateRow(new PdfRowParameters
                    {
                        Table = serviceTable,
                        Texts = new List<string> { "", "", "", "К оплате:", order.Price.ToString() },
                        Style = "Normal",
                        ParagraphAlignment = ParagraphAlignment.Left
                    });
                }
                else
                {
                    CreateRow(new PdfRowParameters
                    {
                        Table = serviceTable,
                        Texts = new List<string> { "", "", "", "К оплате:", (order.Price - order.Sum).ToString() },
                        Style = "Normal",
                        ParagraphAlignment = ParagraphAlignment.Left
                    });
                }
                if (info.Payments[order.Id].Count == 0)
                {
                    continue;
                }
                var paymentsLabel = section.AddParagraph("Платежи:");
                paymentsLabel.Style = "NormalTitle";
                var paymentTable = document.LastSection.AddTable();
                headerWidths = new List<string> { "1cm", "3cm", "3cm" };
                foreach (var elem in headerWidths)
                {
                    paymentTable.AddColumn(elem);
                }
                CreateRow(new PdfRowParameters
                {
                    Table = paymentTable,
                    Texts = new List<string> { "№", "Дата", "Сумма" },
                    Style = "NormalTitle",
                    ParagraphAlignment = ParagraphAlignment.Center
                });
                i = 1;
                foreach (var payment in info.Payments[order.Id])
                {
                    CreateRow(new PdfRowParameters
                    {
                        Table = paymentTable,
                        Texts = new List<string> { i.ToString(), payment.DatePayment.ToString(), payment.Sum.ToString() },
                        Style = "Normal",
                        ParagraphAlignment = ParagraphAlignment.Left
                    });
                    i++;
                }
            }
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }

        private static void DefineStyles(Document document)
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;
        }
        private static void CreateRow(PdfRowParameters rowParameters)
        {
            MigraDoc.DocumentObjectModel.Tables.Row row = rowParameters.Table.AddRow();
            for (int i = 0; i < rowParameters.Texts.Count; ++i)
            {
                FillCell(new PdfCellParameters
                {
                    Cell = row.Cells[i],
                    Text = rowParameters.Texts[i],
                    Style = rowParameters.Style,
                    BorderWidth = 0.5,
                    ParagraphAlignment = rowParameters.ParagraphAlignment
                });
            }
        }
        private static void FillCell(PdfCellParameters cellParameters)
        {
            cellParameters.Cell.AddParagraph(cellParameters.Text);
            if (!string.IsNullOrEmpty(cellParameters.Style))
            {
                cellParameters.Cell.Style = cellParameters.Style;
            }
            cellParameters.Cell.Borders.Left.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Right.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Top.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Bottom.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Format.Alignment = cellParameters.ParagraphAlignment;
            cellParameters.Cell.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
