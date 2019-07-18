using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using static S28Filler2.Definitions;
using static S28Filler2.Reader;

namespace S28Filler2
{
    public class Filler
    {

        public string baseLocation;

        string FormFile { get => $"{baseLocation}\\arquivos\\s28.pdf"; }
        string NewFile { get => $"{baseLocation}\\arquivos\\s28_preenchido.pdf"; }

        public Reader jsonReader;
        public Mapping mapeamento;
        public Filler(Reader reader, Mapping linha)
        {
            this.baseLocation = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            this.jsonReader = reader;
            this.mapeamento = linha;
        }

        public void fillStock()
        {
            fillPDFForm(eCell.EstoqueAnterior);
        }

        public void fillMonthStock(params eCell[] cells)
        {
            fillPDFForm(cells);
        }

        private void fillPDFForm(params eCell[] cells)
        {
            using (PdfReader pdfReader = new PdfReader(FormFile))
            {

                using (PdfStamper stamper = new PdfStamper(pdfReader, new FileStream(NewFile, FileMode.Create)))
                {
                    AcroFields fields = stamper.AcroFields;

                    if (cells.Length == 1 && cells[0] == eCell.EstoqueAnterior)
                    {
                        fillFieldsWithPublications(fields, jsonReader.GetStock(), eCell.EstoqueAnterior);
                        fillEmptyFieldsWithZeros(fields, eCell.EstoqueAnterior);
                    }

                    if (cells.Length == 2)
                    {
                        fillFieldsWithPublications(fields, jsonReader.GetStock(), cells[0]);
                        fillFieldsWithPublications(fields, jsonReader.GetReceived(), cells[1]);
                        fillEmptyFieldsWithZeros(fields, cells);
                    }

                    stamper.Close();
                }


            }
        }

        private void fillEmptyFieldsWithZeros(AcroFields fields, params eCell[] cells)
        {

            foreach (var publicacao in this.mapeamento.map)
            {
                eRow linhaAtual = publicacao.Key;
                if (linhaAtual != eRow.NotFound)
                {
                    foreach (var cell in cells)
                    {
                        var fieldName = GetFieldName(linhaAtual, cell);
                        var actualValue = fields.GetField(fieldName);
                        if (string.IsNullOrEmpty(actualValue))
                        {
                            fields.SetField(fieldName, "0");
                        }
                    }
                }
            }

        }

        private void fillFieldsWithPublications(AcroFields fields, List<publicacao> publications, eCell cell)
        {
            foreach (var publicacao in publications)
            {
                eRow linhaAtual = publicacao.Linha;
                if (linhaAtual != eRow.NotFound)
                {
                    var fieldName = GetFieldName(linhaAtual, cell);
                    fields.SetField(fieldName, publicacao.Quantidade);
                }
            }
        }

        private string GetFieldName(eRow linhaAtual, eCell cell)
        {
            return string.Format("fill_{0}", mapeamento.map[linhaAtual][cell]);
        }

        private void fillFieldsWithNumbers(AcroFields fields)
        {
            var i = 0;
            foreach (var field in fields.Fields)
            {
                Console.WriteLine(field.Key);
                fields.SetField(field.Key, (i++).ToString());
            }

            Console.ReadLine();
        }


    }
}
