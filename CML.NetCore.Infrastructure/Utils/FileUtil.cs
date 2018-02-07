using System;
using System.Collections.Generic;
using System.IO;

namespace CML.Lib.Utils
{
    public static class FileUtil
    {
        /// <summary>
        /// 获取当前项目的基目录
        /// </summary>
        /// <returns></returns>
        public static string GetDomianPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// 判断文件是否存在本地目录
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsExistsFile(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// 文件是否不存在本地目录
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsNotExistsFile(string filePath)
        {
            return !IsExistsFile(filePath);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath"></param>
        public static void DeleteFile(string filePath)
        {
            if (IsExistsFile(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// 获取当前项目指定文件夹路径
        /// </summary>
        /// <param name="directoryArray">文件夹路径</param>
        /// <returns></returns>
        public static string CurrentDomainPath(params string[] directoryArray)
        {
            List<string> directoryList = new List<string>();
            directoryList.Add(GetDomianPath());
            directoryList.AddRange(directoryArray);
            return Path.Combine(directoryList.ToArray());
        }

        /// <summary>
        /// 本地地址拼接
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string PathCombine(params string[] path)
        {
            return Path.Combine(path);
        }

        /// <summary>
        /// 创建文件夹目录
        /// </summary>
        /// <param name="directory">文件夹目录</param>
        public static void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        /// <summary>
        /// 获取文件流
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static byte[] GetFileBytes(string filePath)
        {
            if (IsExistsFile(filePath))
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var fileBytes = new byte[stream.Length];
                    stream.Read(fileBytes, 0, fileBytes.Length);
                    return fileBytes;
                }
            }
            else { return null; }
        }

        /// <summary>
        /// 获取文件名后缀
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileExtension(this string fileName)
        {
            return Path.GetExtension(fileName);
        }
    }
}