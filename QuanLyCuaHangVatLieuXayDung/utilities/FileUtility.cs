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
        public bool WriteTupleToJsonFile<T>(T obj, float quantity, string filePath)
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
        /// Removes all entries from a JSON file that match a specific object in the "Data" field of each entry.
        /// </summary>
        /// <typeparam name="T">The type of the object to remove. Must match the type used when appending data.</typeparam>
        /// <param name="objToRemove">The object to search for and remove from the JSON file.</param>
        /// <param name="filePath">The full path to the JSON file.</param>
        /// <returns>
        /// Returns <c>true</c> if one or more matching entries were found and removed; 
        /// <c>false</c> if the file does not exist, is invalid, or no matching entries were found.
        /// </returns>
        /// <remarks>
        /// Each entry in the JSON file is expected to be an object with two fields: "Data" and "Quantity". 
        /// This method deserializes the file, compares the "Data" field of each entry to <paramref name="objToRemove"/>,
        /// and removes any entries that match.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// var product = new Product { Id = 1, Name = "Apple" };
        /// string filePath = "data.json";
        /// bool removed = RemoveTupleFromJsonFile(product, filePath);
        /// </code>
        /// </example>
        public bool RemoveTupleFromJsonFile<T>(T objToRemove, string filePath)
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

                // Serialize objToRemove để so sánh
                string objToRemoveJson = JsonSerializer.Serialize(objToRemove, options);

                int removedCount = entries.RemoveAll(e =>
                {
                    if (e.TryGetProperty("Data", out var dataProperty))
                    {
                        string dataJson = dataProperty.GetRawText();
                        return dataJson == objToRemoveJson;
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
        /// Updates the quantity value of an existing object in a JSON file based on the specified object.
        /// The JSON file must be an array of entries containing "Data" and "Quantity" fields.
        /// </summary>
        /// <typeparam name="T">The type of the object to match and update.</typeparam>
        /// <param name="objToUpdate">The object whose quantity should be updated.</param>
        /// <param name="newQuantity">The new quantity to set.</param>
        /// <param name="filePath">The full path to the JSON file.</param>
        /// <returns>Returns <c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
        public bool UpdateQuantityInJsonFile<T>(T objToUpdate, float newQuantity, string filePath)
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

                string objToUpdateJson = JsonSerializer.Serialize(objToUpdate, options);
                bool updated = false;

                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].TryGetProperty("Data", out var dataProperty))
                    {
                        string dataJson = dataProperty.GetRawText();
                        if (dataJson == objToUpdateJson)
                        {
                            // Tạo entry mới với quantity mới
                            var updatedEntry = new
                            {
                                Data = objToUpdate,
                                Quantity = newQuantity
                            };

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

                Debug.WriteLine("✅ Quantity updated successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error when updating JSON entry: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks whether a specific object exists in a JSON file by comparing the serialized "Data" field.
        /// The JSON file must be an array of entries with "Data" and "Quantity" fields.
        /// </summary>
        /// <typeparam name="T">The type of the object to check for existence.</typeparam>
        /// <param name="objToCheck">The object to find in the JSON file.</param>
        /// <param name="filePath">The full path of the JSON file.</param>
        /// <returns>Returns <c>true</c> if the object exists in the file; otherwise, <c>false</c>.</returns>
        public bool ExistsInJsonFile<T>(T objToCheck, string filePath)
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

                string objJson = JsonSerializer.Serialize(objToCheck, options);

                foreach (var entry in entries)
                {
                    if (entry.TryGetProperty("Data", out var dataProperty))
                    {
                        if (dataProperty.GetRawText() == objJson)
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
        /// Reads a JSON file containing a list of objects with associated quantities,
        /// and returns a list of tuples of the form (T, float).
        /// </summary>
        /// <typeparam name="T">The type of the object stored in the "Data" field.</typeparam>
        /// <param name="filePath">The full path to the JSON file.</param>
        /// <returns>
        /// A list of tuples where each tuple contains an object of type T and a float quantity.
        /// Returns an empty list if the file does not exist or is invalid.
        /// </returns>
        public List<(T, float)> ReadTuplesFromJsonFile<T>(string filePath)
        {
            var result = new List<(T, float)>();

            try
            {
                if (!File.Exists(filePath))
                {
                    Debug.WriteLine($"⚠️ JSON file does not exist: {filePath}");
                    return result;
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };

                string json = File.ReadAllText(filePath);
                List<JsonElement> entries;

                try
                {
                    entries = JsonSerializer.Deserialize<List<JsonElement>>(json, options) ?? new List<JsonElement>();
                }
                catch
                {
                    Debug.WriteLine("❌ JSON file is not a valid array format.");
                    return result;
                }

                foreach (var entry in entries)
                {
                    if (entry.TryGetProperty("Data", out var dataElement) &&
                        entry.TryGetProperty("Quantity", out var quantityElement))
                    {
                        try
                        {
                            T obj = JsonSerializer.Deserialize<T>(dataElement.GetRawText(), options);
                            float quantity = quantityElement.GetSingle(); // hoặc GetDouble() rồi cast nếu cần

                            result.Add((obj, quantity));
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"⚠️ Skipped entry due to deserialization error: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error reading JSON file: {ex.Message}");
            }

            return result;
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
    }
}
