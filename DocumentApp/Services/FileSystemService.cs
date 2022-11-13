using DocumentApp.Data;
using Microsoft.AspNetCore.Components.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.Diagnostics;

namespace DocumentApp.Services
{
    public class FileSystemService
    {
        public Project currentProject;

        private readonly ILogger<FileSystemService> _logger;
        private readonly GridFSBucket _gridFS;
        public FileSystemService(ILogger<FileSystemService> logger)
        {
            _logger = logger;
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("DocumentApp");
            _gridFS = new GridFSBucket(database);
        }

        #region Upload
        public async Task UploadDocumentToDb(Stream stream, string fileName)
        {
            await _gridFS.UploadFromStreamAsync(fileName, stream);
        }

        public byte[] GetByteArrayFromFile(string fileName)
        {
            byte[] byteArray;
            try
            {
                byteArray = _gridFS.DownloadAsBytesByName(fileName);
            }
            catch
            {
                byteArray = null;
            }
            return byteArray;
        }
        #endregion

        #region Download
        //public void DownloadFileToProject(GridFSFileInfo file)
        //{
        //    using (FileStream fs = new FileStream($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/documents/")}{file.Filename}", FileMode.CreateNew))
        //    {
        //        _gridFS.DownloadToStreamByName(file.Filename, fs);
        //    }
        //}

        public void DownloadDocumentToProject(Document document)
        {
            try
            {
                System.IO.File.WriteAllBytes($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/documents/")}{document.FileName}", document.data);
            }
            catch (Exception)
            {
                _logger.LogError("File already exists");
            }
        }

        #endregion

        public bool FileExists(string filename)
        {
            return _gridFS.Find(FilterDefinition<GridFSFileInfo>.Empty).ToEnumerable().Any(x => x.Filename == filename);
        }

        public byte[] GetByteArray(string file)
        {
            return GetByteArrayFromFile(file);
        }

        public async Task LoadFiles(InputFileChangeEventArgs e, Document doc)
        {

            foreach (var file in e.GetMultipleFiles(e.FileCount))
            {
                Stream stream = file.OpenReadStream(2000000);
                await UploadDocumentToDb(stream, file.Name);
                stream.Dispose();

                doc.FileName = file.Name;
                doc.data = GetByteArray(file.Name);
            }
        }
    }
}
