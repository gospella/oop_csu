using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.SerializationConfig
{
    public interface IStorage
    {
        Stream GetReadStream(string name);
        Stream GetWriteStream(string name);
    }
}
