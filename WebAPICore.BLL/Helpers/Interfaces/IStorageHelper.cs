using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICore.BLL.Helpers.Interfaces
{
    public interface IStorageHelper
    {
        Task<bool> WriteByteToFileAsync(string audioFileName, byte[] audioFileContent);
        Task<byte[]> ReadFileAsync(string audioFileName);
        Task<bool> DeleteFile(string audioFileName);
    }
}
