﻿using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace RTC.Storage
{
    public enum StorageType
    {
        Roaming, Local, Temporary
    }

    public class ObjectStorageHelper<T>
    {
        private readonly ApplicationData _appData = ApplicationData.Current;
        private readonly XmlSerializer _serializer;
        private readonly StorageType _storageType;

        private static string fileName(T obj, string handle)
        {
            //var str = String.Concat(handle, String.Format("{0}", obj.GetType().ToString()));
            //return str;
            return "CalculationResult.xml";
        }

        /// <summary>
        /// Generic class to simplify the storage and retrieval of data to/from Windows.Storage.ApplicationData
        /// </summary>
        /// <param name="storageType"></param>
        public ObjectStorageHelper(StorageType storageType)
        {
            _serializer = new XmlSerializer(typeof(T));
            _storageType = storageType;
        }

        /// <summary>
        /// Delete a stored instance of T from Windows.Storage.ApplicationData
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAsync()
        {
            var fileName = ObjectStorageHelper<T>.fileName(Activator.CreateInstance<T>(), String.Empty);
            await DeleteAsync(fileName);
        }
        /// <summary>
        /// Delete a stored instance of T with a specified handle from Windows.Storage.ApplicationData.
        /// Specification of a handle supports storage and deletion of different instances of T.
        /// </summary>
        /// <param name="handle">User-defined handle for the stored object</param>
        public async Task DeleteAsync(string handle)
        {
            if (handle == null)
                throw new ArgumentNullException("Handle");
            var fileName = ObjectStorageHelper<T>.fileName(Activator.CreateInstance<T>(), handle);
            var folder = getFolder(_storageType);

            var file = await getFileIfExistsAsync(folder, fileName);
            if (file != null)
                await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
        }
        /// <summary>
        /// Store an instance of T to Windows.Storage.ApplicationData with a specified handle.
        /// Specification of a handle supports storage and deletion of different instances of T.
        /// </summary>
        /// <param name="obj">Object to be saved</param>
        /// <param name="handle">User-defined handle for the stored object</param>
        public async Task SaveAsync(T obj, string handle)
        {
            if (obj == null)
                throw new ArgumentNullException("Obj");
            if (handle == null)
                throw new ArgumentNullException("Handle");

            StorageFile file = null;
            var fileName = ObjectStorageHelper<T>.fileName(Activator.CreateInstance<T>(), handle);
            var folder = getFolder(_storageType);
            file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            var writeStream = await file.OpenAsync(FileAccessMode.ReadWrite);

            using (var outStream = Task.Run(() => writeStream.AsStreamForWrite()).Result)
            {
                _serializer.Serialize(outStream, obj);
                await outStream.FlushAsync();
            }

        }
        /// <summary>
        /// Save an instance of T to Windows.Storage.ApplicationData.
        /// </summary>
        /// <param name="obj">Object to be saved</param>
        /// <param name="Handle">User-defined handle for the stored object</param>
        public async Task SaveAsync(T obj)
        {
            string fileName = ObjectStorageHelper<T>.fileName(obj, String.Empty);
            await SaveAsync(obj, fileName);
        }
        /// <summary>
        /// Retrieve a stored instance of T with a specified handle from Windows.Storage.ApplicationData.
        /// Specification of a handle supports storage and deletion of different instances of T.
        /// </summary>
        /// <param name="handle">User-defined handle for the stored object</param>
        public async Task<T> LoadAsync(string handle)
        {
            if (handle == null)
                throw new ArgumentNullException("Handle");

            var fileName = ObjectStorageHelper<T>.fileName(Activator.CreateInstance<T>(), handle);
            try
            {
                var folder = getFolder(_storageType);
                var file = await folder.GetFileAsync(fileName);
                var readStream = await file.OpenAsync(FileAccessMode.Read);
                using (var inStream = Task.Run(() => readStream.AsStreamForRead()).Result)
                {
                    return (T)_serializer.Deserialize(inStream);
                }
            }
            catch (FileNotFoundException)
            {
                //file not existing is perfectly valid so simply return the default 
                return default(T);
                //Interesting thread here: How to detect if a file exists (http://social.msdn.microsoft.com/Forums/en-US/winappswithcsharp/thread/1eb71a80-c59c-4146-aeb6-fefd69f4b4bb)
                //throw;
            }
        }
        /// <summary>
        /// Retrieve a stored instance of T from Windows.Storage.ApplicationData.
        /// </summary>
        public async Task<T> LoadAsync()
        {
            var fileName = ObjectStorageHelper<T>.fileName(Activator.CreateInstance<T>(), String.Empty);
            return await LoadAsync(fileName);
        }

        private StorageFolder getFolder(StorageType storageType)
        {
            StorageFolder folder;
            switch (storageType)
            {
                case StorageType.Roaming:
                    folder = _appData.RoamingFolder;
                    break;
                case StorageType.Local:
                    folder = _appData.LocalFolder;
                    break;
                case StorageType.Temporary:
                    folder = _appData.TemporaryFolder;
                    break;
                default:
                    throw new Exception(String.Format("Unknown StorageType: {0}", storageType));
            }
            return folder;
        }

        private static async Task<StorageFile> getFileIfExistsAsync(IStorageFolder folder, string fileName)
        {
            try
            {
                return await folder.GetFileAsync(fileName);
            }
            catch
            {
                return null;
            }
        }
    }
}