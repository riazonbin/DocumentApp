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

        public byte[] DownloadDocumentFromDb(string fileName)
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

        public void UploadFileToDb(string fileName, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                _gridFS.UploadFromStream(fileName, fs);
            }
        }
        #endregion

        #region Download
        public void DownloadFileToProject(GridFSFileInfo file)
        {
            using (FileStream fs = new FileStream($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/documents/")}{file.Filename}", FileMode.CreateNew))
            {
                _gridFS.DownloadToStreamByName(file.Filename, fs);
            }
        }

        //public void DownloadFileToProject(IBrowserFile file)
        //{
        //    try
        //    {
        //        using (FileStream fs = new FileStream($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/documents/")}{file.Name}", FileMode.CreateNew))
        //        {
        //            _gridFS.DownloadToStreamByName(file.Name, fs);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        _logger.LogError("Image already exists");
        //    }
        //}
        #endregion

        public bool FileExists(string filename)
        {
            return _gridFS.Find(FilterDefinition<GridFSFileInfo>.Empty).ToEnumerable().Any(x => x.Filename == filename);
        }
    }
}
