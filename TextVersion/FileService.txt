using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Agri_EnergyConnect.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        /// <summary>
        /// Retrieves the web-accessible relative paths of files in the specified subfolder (relative to wwwroot).
        /// </summary>
        public List<string> GetFilePaths(string subfolderPath)
        {
            var webRootDir = _env.WebRootPath;

            // Combine the web root path with the relative subfolder path
            var absolutePath = Path.Combine(webRootDir, subfolderPath);

            // If the directory doesn't exist, return an empty list
            if (!Directory.Exists(absolutePath))
            {
                return new List<string>();
            }

            // Get all file paths and convert them to relative URLs
            var filePaths = Directory.GetFiles(absolutePath);

            return filePaths.Select(fp =>
                "/" + subfolderPath.Replace("\\", "/") + "/" + Path.GetFileName(fp)
            ).ToList();
        }

        /// <summary>
        /// Uploads a file to a specified directory under wwwroot and returns its unique name.
        /// </summary>
        public string UploadFile(IFormFile photo, string subfolderPath = "")
        {
            if (photo == null || photo.Length == 0)
                return null;

            var webRootDir = _env.WebRootPath;
            var uploadsFolder = Path.Combine(webRootDir, subfolderPath);

            // Ensure the directory exists
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Generate a unique file name
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Copy file to destination
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(stream);
            }

            return uniqueFileName;
        }

        /// <summary>
        /// Deletes a file from a specified directory under wwwroot.
        /// </summary>
        public bool DeleteFile(string fileName, string subfolderPath)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return false;

            var filePath = Path.Combine(_env.WebRootPath, subfolderPath, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }

            return false;
        }
    }
}
