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
        /// Saves an image file to a specified target folder. If the folder does not exist, it will be created.
        /// </summary>
        /// <param name="hinhAnhPath">The full path of the image file to be copied.</param>
        /// <param name="targetFolder">The destination folder where the image should be saved.</param>
        /// <remarks>
        /// This method checks whether the target folder exists and creates it if necessary.  
        /// Then it attempts to copy the image file to the folder, overwriting it if a file with the same name already exists.  
        /// Debug messages are written to help trace the execution flow and potential errors.
        /// </remarks>
        /// <example>
        /// <code>
        /// SaveImages(@"C:\Images\sample.jpg", @"C:\Backup\Images");
        /// </code>
        /// </example>

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
        /// Overwrites a JSON file with a single object wrapped in a "Data" property.
        /// </summary>
        /// <typeparam name="T">The type of the object to be serialized and written to the JSON file.</typeparam>
        /// <param name="obj">The object instance to serialize and write to the JSON file.</param>
        /// <param name="filePath">The full path of the JSON file to be written, including the file name and extension.</param>
        /// <returns>
        /// Returns <c>true</c> if the operation completes successfully; otherwise, <c>false</c> if an error occurs.
        /// </returns>
        /// <remarks>
        /// If the directory does not exist, it will be created automatically.
        /// The object will be serialized as a JSON array containing one item with a "Data" property.
        /// The method will overwrite the entire file content regardless of any existing data.
        /// The resulting JSON is formatted with indentation for readability.
        /// </remarks>
        public bool WriteObjectJsonFile<T>(T obj, string filePath)
        {
            try
            {
                var directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Tạo object dạng { Data = obj }
                var newEntry = new { Data = obj };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                // Tạo danh sách mới chỉ chứa một phần tử duy nhất
                var entries = new List<object> { newEntry };

                // Ghi đè toàn bộ dữ liệu vào file
                string updatedJson = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(filePath, updatedJson);

                Debug.WriteLine("✅ JSON file has been overwritten successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("❌ Error writing JSON: " + ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Appends an object to a JSON file at the specified path, or creates a new file if it doesn't exist.
        /// </summary>
        /// <typeparam name="T">The type of the object to be serialized and written to the JSON file.</typeparam>
        /// <param name="obj">The object instance to serialize and add to the JSON file.</param>
        /// <param name="filePath">The full file path where the JSON file will be saved, including the file name and extension.</param>
        /// <returns>
        /// Returns <c>true</c> if the operation is successful; otherwise, returns <c>false</c> if an error occurs.
        /// </returns>
        /// <remarks>
        /// If the directory of the file does not exist, it will be created automatically.
        /// The object will be wrapped in a parent object with a "Data" property before being serialized.
        /// If the file already exists and contains a valid JSON array, the object will be added to the array.
        /// If the file is empty or invalid, it will be overwritten with the new object.
        /// The JSON output will be indented for readability.
        /// </remarks>
        public bool AppendObjectJsonFile<T>(T obj, string filePath)
        {
            try
            {
                var directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var newEntry = new { Data = obj };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                List<object> entries = new List<object>();

                if (File.Exists(filePath))
                {
                    string existingJson = File.ReadAllText(filePath);

                    try
                    {
                        var existingEntries = JsonSerializer.Deserialize<List<JsonElement>>(existingJson, options);
                        if (existingEntries != null)
                        {
                            entries = existingEntries.Cast<object>().ToList();
                        }
                    }
                    catch
                    {
                        Debug.WriteLine("⚠️ Existing file is not a valid JSON array. Overwriting.");
                    }
                }

                entries.Add(newEntry);

                string updatedJson = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(filePath, updatedJson);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("❌ Error writing JSON: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Removes objects from a JSON file based on a specified condition defined by a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the object that is being removed.</typeparam>
        /// <param name="filePath">The full path to the JSON file from which objects will be removed.</param>
        /// <param name="matchPredicate">A delegate (Func) that defines the condition to match objects for removal. It is applied to the "Data" property of each object.</param>
        /// <returns>
        /// Returns <c>true</c> if matching objects were removed successfully; otherwise, returns <c>false</c> if no objects were removed or an error occurred.
        /// </returns>
        /// <remarks>
        /// This method reads the JSON file, deserializes it into a list of JSON elements, and removes entries that satisfy the provided predicate.
        /// If no matching entries are found, a warning is logged. The updated JSON content is then written back to the file.
        /// </remarks>

        public bool RemoveObjectFromJsonFile<T>(string filePath, Func<JsonElement, bool> matchPredicate)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Debug.WriteLine($"⚠️ JSON file does not exist: {filePath}");
                    return false;
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };

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

                // Tìm và xóa các mục thỏa mãn điều kiện matchPredicate
                int removedCount = entries.RemoveAll(e =>
                {
                    if (e.TryGetProperty("Data", out var dataProperty))
                    {
                        return matchPredicate(dataProperty); // Sử dụng matchPredicate để kiểm tra
                    }
                    return false;
                });

                if (removedCount == 0)
                {
                    Debug.WriteLine("⚠️ No matching entry found to remove.");
                    return false;
                }

                // Ghi lại file sau khi xóa
                string updatedJson = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(filePath, updatedJson);

                Debug.WriteLine($"✅ Removed {removedCount} matching entries from the JSON file.");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error when removing JSON entry: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Updates an object inside a JSON file based on a custom matching condition.
        /// </summary>
        /// <typeparam name="T">The type of the object to be updated.</typeparam>
        /// <param name="objToUpdate">The new object that will replace the existing matching object in the file.</param>
        /// <param name="filePath">The path to the JSON file containing a list of objects.</param>
        /// <param name="matchPredicate">
        /// A delegate function that defines the matching condition. 
        /// It takes a <see cref="JsonElement"/> representing the "Data" object from each entry in the JSON array.
        /// Returns <c>true</c> if the entry matches the object to update.
        /// </param>
        /// <returns>
        /// Returns <c>true</c> if the object was found and successfully updated; otherwise, returns <c>false</c>.
        /// </returns>
        /// <remarks>
        /// The JSON file is expected to contain an array of objects, where each object has a property named <c>"Data"</c>.
        /// The method deserializes the JSON array, searches for the entry where the <paramref name="matchPredicate"/> returns true,
        /// and replaces that entry with the updated object.
        /// Uses <see cref="System.Text.Json"/> for serialization and deserialization.
        /// </remarks>
        public bool UpdateObjectInJsonFileById<T>(T objToUpdate, string filePath, Func<JsonElement, bool> matchPredicate)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Debug.WriteLine($"⚠️ JSON file does not exist: {filePath}");
                    return false;
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };

                string existingJson = File.ReadAllText(filePath);
                List<JsonElement> entries = JsonSerializer.Deserialize<List<JsonElement>>(existingJson, options)
                    ?? new List<JsonElement>();

                bool updated = false;

                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].TryGetProperty("Data", out var dataProperty))
                    {
                        if (matchPredicate(dataProperty)) // 👈 So sánh bằng điều kiện custom
                        {
                            var updatedEntry = new { Data = objToUpdate };
                            entries[i] = JsonSerializer.Deserialize<JsonElement>(
                                JsonSerializer.Serialize(updatedEntry, options)
                            );
                            updated = true;
                            break;
                        }
                    }
                }

                if (!updated)
                {
                    Debug.WriteLine("⚠️ No matching entry found to update.");
                    return false;
                }

                string updatedJson = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(filePath, updatedJson);

                Debug.WriteLine("✅ Object updated successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error when updating JSON entry: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if an object exists in a JSON file based on a specified predicate for the object's properties.
        /// </summary>
        /// <param name="filePath">The full path of the JSON file to check.</param>
        /// <param name="matchPredicate">A function that defines the condition to match against properties inside the "Data" field of each entry.</param>
        /// <returns>
        /// Returns <c>true</c> if the object matching the predicate is found in the JSON file; otherwise, returns <c>false</c> if not found or an error occurs.
        /// </returns>
        /// <remarks>
        /// This method deserializes the JSON file into a list of objects, checks each object’s "Data" property against the provided predicate, 
        /// and returns <c>true</c> if a match is found. If no match is found, it returns <c>false</c>.
        /// </remarks>
        public bool IsExistsObjectInJsonFile<T>(string filePath, Func<JsonElement, bool> matchPredicate)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Debug.WriteLine($"⚠️ JSON file does not exist: {filePath}");
                    return false;
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };

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

                // Duyệt qua tất cả các mục trong file JSON và kiểm tra điều kiện matchPredicate
                foreach (var entry in entries)
                {
                    if (entry.TryGetProperty("Data", out var dataProperty))
                    {
                        // Dùng matchPredicate để kiểm tra thuộc tính tùy chọn trong Data
                        if (matchPredicate(dataProperty))
                        {
                            Debug.WriteLine("✅ Object found in JSON file.");
                            return true;
                        }
                    }
                }

                Debug.WriteLine("⚠️ Object not found in JSON file.");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error checking JSON file: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Reads a JSON file and deserializes its content into a list of objects of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of objects to deserialize from the JSON file.</typeparam>
        /// <param name="filePath">The full path to the JSON file.</param>
        /// <returns>
        /// A list of objects of type <typeparamref name="T"/>.
        /// If the file does not exist or an error occurs, an empty list is returned.
        /// </returns>
        /// <remarks>
        /// The method assumes that the JSON file contains an array of objects,
        /// each having a property named "Data" that holds the actual object data.
        /// Example of expected JSON format:
        /// [
        ///     { "Data": { "Id": 1, "Name": "Item 1" } },
        ///     { "Data": { "Id": 2, "Name": "Item 2" } }
        /// ]
        /// </remarks>

        public List<T> ReadObjectsFromJsonFile<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Debug.WriteLine($"⚠️ JSON file does not exist: {filePath}");
                    return new List<T>();
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string json = File.ReadAllText(filePath);
                List<JsonElement> entries = JsonSerializer.Deserialize<List<JsonElement>>(json, options) ?? new List<JsonElement>();

                var result = new List<T>();
                foreach (var entry in entries)
                {
                    if (entry.TryGetProperty("Data", out var dataProperty))
                    {
                        T obj = JsonSerializer.Deserialize<T>(dataProperty.GetRawText(), options);
                        result.Add(obj);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error reading JSON file: {ex.Message}");
                return new List<T>();
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

        /// <summary>
        /// Checks whether a specified file is located within a given folder, including any of its subdirectories.
        /// </summary>
        /// <param name="filePath">The full or relative path of the file to check.</param>
        /// <param name="folderPath">The full or relative path of the folder to check against.</param>
        /// <returns>
        /// Returns <c>true</c> if the file is located inside the specified folder or any of its subfolders;
        /// otherwise, returns <c>false</c>.
        /// </returns>
        /// <remarks>
        /// The method converts both <paramref name="filePath"/> and <paramref name="folderPath"/> to their
        /// absolute (full) paths before comparison.
        /// A directory separator character is appended to the end of the folder path if it is not already present
        /// to avoid incorrect partial matching.
        /// If an exception occurs (e.g., invalid path), the method catches it and returns <c>false</c>.
        /// </remarks>
        public bool IsFileInFolder(string filePath, string folderPath)
        {
            try
            {
                string fullFilePath = Path.GetFullPath(filePath);
                string fullFolderPath = Path.GetFullPath(folderPath);

                // Ensure the folder path ends with a directory separator (e.g., '\')
                if (!fullFolderPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    fullFolderPath += Path.DirectorySeparatorChar;
                }

                return fullFilePath.StartsWith(fullFolderPath);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes all files inside the specified folder.
        /// </summary>
        /// <param name="folderPath">The path to the folder whose files should be deleted.</param>
        /// <returns>
        /// Returns <c>true</c> if all files were deleted successfully (or folder is empty); 
        /// returns <c>false</c> if the folder doesn't exist or an error occurred.
        /// </returns>
        /// <remarks>
        /// This method only deletes files directly inside the specified folder.
        /// It does not delete subdirectories or their contents.
        /// </remarks>
        public bool DeleteAllFilesInFolder(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    string[] files = Directory.GetFiles(folderPath);

                    foreach (string file in files)
                    {
                        File.Delete(file);
                        Debug.WriteLine($"🗑️ Deleted file: {file}");
                    }

                    Debug.WriteLine($"✅ All files in folder '{folderPath}' have been deleted.");
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
                Debug.WriteLine($"❌ Error deleting files in folder '{folderPath}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks whether a specified folder exists at the given path.
        /// </summary>
        /// <param name="folderPath">The full path of the folder to check.</param>
        /// <returns>True if the folder exists; otherwise, false.</returns>
        public bool FolderExists(string folderPath)
        {
            return Directory.Exists(folderPath);
        }

        /// <summary>
        /// Copies a file to a specified destination folder and renames it with a new file name.
        /// </summary>
        /// <param name="sourceFilePath">The full path to the source file that needs to be copied.</param>
        /// <param name="destinationFolder">The full path to the destination folder where the file will be copied.</param>
        /// <param name="newFileName">The new name for the copied file, including the file extension (e.g., "newfile.txt").</param>
        /// <returns>
        /// Returns the full path to the newly copied and renamed file if successful.
        /// Returns an empty string if the copy or rename operation fails.
        /// </returns>
        public string CopyAndRenameFile(string sourceFilePath, string destinationFolder, string newFileName)
        {
            try
            {
                if (!File.Exists(sourceFilePath))
                {
                    return string.Empty;
                }
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }
                string destinationFilePath = Path.Combine(destinationFolder, newFileName);

                File.Copy(sourceFilePath, destinationFilePath, true);

                return destinationFilePath;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
