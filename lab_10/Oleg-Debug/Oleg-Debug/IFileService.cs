using System.Collections.Generic;

namespace Oleg_Debug
{
    public interface IFileService<T> where T:class
    {
        IEnumerable<T> ReadFile(string fileName);
        void SaveData(IEnumerable<T> data, string fileName);
    }
}