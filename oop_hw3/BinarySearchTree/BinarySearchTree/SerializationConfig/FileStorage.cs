using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.SerializationConfig
{
    public class FileStorage : IStorage
    {
        public Stream GetReadStream(string name)
        {
            return new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        public Stream GetWriteStream(string name)
        {
            return new FileStream(name, FileMode.Create, FileAccess.Write, FileShare.None);
            ;
        }
    }
}
