/*
 *  实现视频加密功能
 *  
 */
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Modelu.Tools
{
    public class BufferLockKey
    {
        public int count;

        public List<string> randomBuffer;

        public List<string> correctBuffer;

        public BufferLockKey()
        {

        }

        public BufferLockKey(int _count)
        {
            count = _count;
            randomBuffer = new List<string>();
            correctBuffer = new List<string>();

            randomBuffer = GenerateKey();
        }

        /// <summary>
        /// 生成一个指定长度的随机buffer
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<string> GenerateKey()
        {
            List<string> strs = new List<string>();
            for (int i = 0; i < count; i++)
            {
                string buf = Random.Range(0, 256).ToString();
                strs.Add(buf);
            }
            return strs;
        }
    }

    public class LockFile
    {
        /// <summary>
        /// 任意文件转换成byte数组的数据
        /// </summary>
        /// <param name="fileUrl">.media文件的路径</param>
        /// <returns></returns>
        public static byte[] ReadDataFromFile(string fileUrl)
        {
            FileStream fs = new FileStream(fileUrl, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fs.Length];

            fs.Read(buffer, 0, buffer.Length);
            fs.Close();
            return buffer;
        }

        /// <summary>
        /// 将数据输出成文件
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <param name="buffer"></param>
        public static void WriteByteToFile(string fileUrl, byte[] buffer)
        {
            FileStream fs = new FileStream(fileUrl, FileMode.Create);
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();
            Debug.Log("写入完成");
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileUrl"></param>
        public static void DeleteFile(string fileUrl)
        {
            if (File.Exists(fileUrl))
                File.Delete(fileUrl);
        }

        /// <summary>
        /// 数据加密
        /// </summary>
        /// <param name="buffer">初始buffer</param>
        /// <param name="key">加密后的buffer</param>
        /// <returns></returns>
        private static byte[] BufferLock(byte[] buffer, BufferLockKey key)
        {
            for (int i = 0; i < key.count; i++)
            {
                //保存正确的值
                key.correctBuffer.Add(buffer[i].ToString());

                //加密原数据
                buffer[i] = byte.Parse(key.randomBuffer[i]);
            }
            Debug.Log("加密完成");
            return buffer;
        }

        /// <summary>
        /// 数据解密
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static byte[] BufferUnlock(byte[] buffer, BufferLockKey key)
        {
            for (int i = 0; i < key.count; i++)
            {
                buffer[i] = byte.Parse(key.correctBuffer[i]);
            }
            Debug.Log("解密完成");
            return buffer;
        }

        public static void Lock(string path, string fileName, int count, string newPath, string newFileName, bool isDeleteOriginal = false)
        {
            byte[] buffer = ReadDataFromFile(path + "/" + fileName);
            BufferLockKey key = new BufferLockKey(count);
            buffer = BufferLock(buffer, key);
            WriteByteToFile(newPath + "/" + newFileName + ".media", buffer);
            ES3.Save(newFileName, key);

            if (isDeleteOriginal)
            {
                File.Delete(path + "/" + fileName);
            }
        }

        public static byte[] UnLock(string path, string fileName)
        {
            BufferLockKey key = new BufferLockKey();
            key = ES3.Load<BufferLockKey>(fileName);
            byte[] buffer = ReadDataFromFile(path + "/" + fileName + ".media");
            buffer = BufferUnlock(buffer, key);
            return buffer;
        }
    }
}