using Application.Exceptions;
using Application.Interfaces;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Shared.Services
{
    public class FileService : IFileService
    {

        public ILogger<FileService> _logger { get; }


        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Metodo que cria uma pasta
        /// </summary>
        /// <param name="nomePasta">nome da pasta a ser criada</param>
        public async Task<bool> CriarPasta(String nomePasta)
        {
            try
            {
                Directory.CreateDirectory(nomePasta);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma expção: " + ex.Message);
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> ConterBase64TOimage(string filePath, string content)
        {
            try
            {
                if (await EnsureFolder(filePath))
                {
                    var base64Data = Regex.Match(content, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                    var bytes = Convert.FromBase64String(base64Data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        BinaryWriter writer = new BinaryWriter(imageFile);
                        imageFile.Write(bytes, 0, bytes.Length);
                        //imageFile.Flush();
                    }

                    return await Task.FromResult(true);

                }

                return await Task.FromResult(false);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        private async Task<bool> EnsureFolder(string path)
        {
            try
            {
                string directoryName = Path.GetDirectoryName(path);
                // If path is a file name only, directory name will be an empty string
                if (directoryName.Length > 0)
                {
                    // Create all directories on the path that don't already exist
                    Directory.CreateDirectory(directoryName);
                }

                return await Task.FromResult(true);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        /// <summary>
        /// Método que retorna um Pdf com base no nome do ficheiro
        /// </summary>
        /// <param name="sFilename"></param>
        /// <returns></returns>
        //private  MemoryStream ReturnCompatiblePdf(string sFilename)
        //{

        //    MemoryStream output_stream = null;
        //    using (iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(sFilename))
        //    {

        //        output_stream = new MemoryStream();

        //        // we retrieve the total number of pages
        //        int n = reader.NumberOfPages;
        //        // step 1: creation of a document-object
        //        iTextSharp.text.Document document = new iTextSharp.text.Document(reader.GetPageSizeWithRotation(1));
        //        // step 2: we create a writer that listens to the document
        //        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, output_stream);
        //        // write pdf that pdfsharp can understand
        //        writer.SetPdfVersion(iTextSharp.text.pdf.PdfWriter.PDF_VERSION_1_4);
        //        // step 3: we open the document
        //        document.Open();
        //        iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
        //        iTextSharp.text.pdf.PdfImportedPage page;

        //        int rotation;

        //        int i = 0;
        //        while (i < n)
        //        {
        //            i += 1;
        //            document.SetPageSize(reader.GetPageSizeWithRotation(i));
        //            document.NewPage();
        //            page = writer.GetImportedPage(reader, i);
        //            rotation = reader.GetPageRotation(i);
        //            if (rotation == 90 || rotation == 270)
        //                cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(i).Height);
        //            else
        //                cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0);
        //        }

        //        // ---- Keep the stream open!
        //        writer.CloseStream = false;

        //        // step 5: we close the document
        //        document.Close();
        //    }

        //    return output_stream;
        //}


        public async Task<bool> ConterBase64TOFile(string filePath, string content)
        {
            try
            {
                byte[] imgByteArray = Convert.FromBase64String(content);

                File.WriteAllBytes(filePath, imgByteArray);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
              
            }
        }
        /// <summary>
        /// Metodo que faz o merge  dos documentos 
        /// </summary>
        /// <param name="targetPath">A directoria onde sera guardado o ficheiro final</param>
        /// <param name="pdfs">A Lista de docuemntos  em PDF</param>
        //public  void MergePDF(string targetPath, params string[] pdfs)
        //{

        //    string url = string.Empty;
        //    using (PdfDocument targetDoc = new PdfDocument())
        //    {
        //        foreach (string pdf in pdfs)
        //        {
        //            if (pdf != null)
        //            {
        //                using (MemoryStream memoryStream = ReturnCompatiblePdf(pdf))
        //                {

        //                    PdfDocument DocPdf = PdfReader.Open(memoryStream, PdfDocumentOpenMode.Import);

        //                    for (int i = 0; i < DocPdf.PageCount; i++)
        //                    {
        //                        targetDoc.AddPage(DocPdf.Pages[i]);
        //                    }
        //                }
        //            }

        //        }
        //        targetDoc.Save(targetPath);
        //    }
        //}
    }
}
