using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFileService
    {
        Task<bool> CriarPasta(String nomePasta);

        Task<bool> ConterBase64TOimage(string filePath, string content);


        Task<bool> ConterBase64TOFile(string filePath, string content);

        //void MergePDF(string targetPath, params string[] pdfs);
    }
}
