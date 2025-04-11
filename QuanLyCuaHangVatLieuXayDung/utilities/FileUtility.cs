using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.utilities
{

    /// <summary>
    /// Utilities related to file
    /// </summary>
    internal class FileUtility
    {
        /// <summary>
        /// Creates a new folder at the specified path if it does not already exist.
        /// </summary>
        /// <param name="folderPath">The full path of the folder to create.</param>
        /// <returns>
        /// Returns <c>true</c> if the folder was created;
        /// <c>false</c> if the folder already exists.
        /// </returns>
        public bool CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Debug.WriteLine($"📁 Folder created: '{folderPath}'");
                return true;
            }

            Debug.WriteLine($"ℹ️ Folder already exists: '{folderPath}'");
            return false;
        }

        /// <summary>
        /// Retrieves a list of image file paths from a specified folder.
        /// Supports file extensions: .jpg, .jpeg, .png, .bmp, .gif.
        /// </summary>
        /// <param name="folderPath">The path of the folder to search for image files.</param>
        /// <returns>A list of full image file paths found in the folder.</returns>
        public List<string> GetImagePathsFromFolder(string folderPath)
        {
            List<string> imagePaths = new List<string>();
            string[] supportedExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };

            if (!Directory.Exists(folderPath))
            {
                Debug.WriteLine($"⚠️ Folder '{folderPath}' does not exist.");
                return imagePaths;
            }

            foreach (string file in Directory.GetFiles(folderPath))
            {
                if (Array.Exists(supportedExtensions, ext => ext.Equals(Path.GetExtension(file), StringComparison.OrdinalIgnoreCase)))
                {
                    imagePaths.Add(file);
                    Debug.WriteLine($"✅ Image file found: {file}");
                }
            }

            Debug.WriteLine($"📁 Total images found in '{folderPath}': {imagePaths.Count}");
            return imagePaths;
        }

        /// <summary>
        /// Copies an image file from a source path to a target folder. 
        /// Creates the target folder if it does not exist.
        /// </summary>
        /// <param name="hinhAnhPath">The full path to the source image file.</param>
        /// <param name="targetFolder">The directory where the image will be copied to.</param>
        public void SaveImages(string hinhAnhPath, string targetFolder)
        {
            try
            {
                // Create target folder if it does not exist
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                    Debug.WriteLine($"📁 Folder '{targetFolder}' has been created.");
                }

                // Check if the source image file exists
                if (File.Exists(hinhAnhPath))
                {
                    string fileName = Path.GetFileName(hinhAnhPath);
                    string destinationPath = Path.Combine(targetFolder, fileName);

                    File.Copy(hinhAnhPath, destinationPath, overwrite: true);
                    Debug.WriteLine($"🖼️ Image copied from '{hinhAnhPath}' to '{destinationPath}'.");
                }
                else
                {
                    Debug.WriteLine($"⚠️ Image file '{hinhAnhPath}' not found.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error saving image from '{hinhAnhPath}' to '{targetFolder}': {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a folder at the specified path along with all its contents.
        /// </summary>
        /// <param name="folderPath">The full path of the folder to delete.</param>
        /// <returns>
        /// Returns <c>true</c> if the folder was successfully deleted;
        /// <c>false</c> if the folder does not exist or an error occurs during deletion.
        /// </returns>
        public bool DeleteFolder(string folderPath)
        {
            try
            {
                // Check if the folder exists
                if (Directory.Exists(folderPath))
                {
                    // Delete the folder and its contents
                    Directory.Delete(folderPath, recursive: true);
                    Debug.WriteLine($"✅ Folder '{folderPath}' has been deleted successfully.");
                    return true;
                }
                else
                {
                    Debug.WriteLine($"⚠️ Folder '{folderPath}' does not exist.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error deleting folder '{folderPath}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Deletes a file at the specified path if it exists.
        /// </summary>
        /// <param name="filePath">The full path of the file to delete.</param>
        /// <returns>
        /// Returns <c>true</c> if the file was successfully deleted; 
        /// <c>false</c> if the file does not exist or an error occurs during deletion.
        /// </returns>
        public bool DeleteFile(string filePath)
        {
            try
            {
                // Check if file exists
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Debug.WriteLine($"✅ File '{filePath}' has been deleted successfully.");
                    return true;
                }
                else
                {
                    Debug.WriteLine($"⚠️ File '{filePath}' does not exist.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error deleting file '{filePath}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Serializes a generic object along with a quantity value into JSON format and writes it to a specified file.
        /// Creates the file and parent directory if they do not exist.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="quantity">The quantity associated with the object.</param>
        /// <param name="filePath">The full path of the file where the JSON data will be saved.</param>
        /// <returns>
        /// Returns <c>true</c> if the file was written successfully; otherwise, <c>false</c>.
        /// </returns>

        public static bool WriteTupleToJsonFile<T>(T obj, float quantity, string filePath)
        {
            try
            {
                var directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var jsonObject = new
                {
                    Data = obj,
                    Quantity = quantity
                };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(jsonObject, options);
                File.WriteAllText(filePath, json);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("❌ Error writing JSON: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Appends an object and its quantity as a JSON entry to an existing JSON file.
        /// If the file does not exist, the method will do nothing and return false.
        /// The JSON file must contain a JSON array to append to.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="obj">The object to append.</param>
        /// <param name="quantity">The quantity associated with the object.</param>
        /// <param name="filePath">The full path of the existing JSON file.</param>
        /// <returns>Returns <c>true</c> if the append operation is successful; otherwise, <c>false</c>.</returns>
        public bool AppendTupleToJsonFile<T>(T obj, float quantity, string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Debug.WriteLine($"⚠️ JSON file does not exist: {filePath}");
                    return false;
                }

                var newEntry = new
                {
                    Data = obj,
                    Quantity = quantity
                };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                // Đọc nội dung file và deserialize thành danh sách
                string existingJson = File.ReadAllText(filePath);
                List<JsonElement> entries;

                try
                {
                    entries = JsonSerializer.Deserialize<List<JsonElement>>(existingJson, options) ?? new List<JsonElement>();
                }
                catch
                {
                    Debug.WriteLine("❌ File is not a valid JSON array.");
                    return false;
                }

                // Append new entry
                entries.Add(JsonSerializer.Deserialize<JsonElement>(JsonSerializer.Serialize(newEntry, options)));

                // Serialize lại danh sách và ghi vào file
                string updatedJson = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(filePath, updatedJson);

                Debug.WriteLine($"✅ Added data to the JSON file: {filePath}");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error when adding JSON: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks whether a file exists at the specified file path.
        /// </summary>
        /// <param name="filePath">The path of the file to check.</param>
        /// <returns>True if the file exists; otherwise, false.</returns>
        public bool IsFileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
