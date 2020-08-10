using System;
using System.Collections.Generic;
using System.Text;

namespace Biing2WPF.Biing2.MemoryReaders
{
    public interface IBaseReader
    {
        T ResolveOne<T>(uint index) where T: struct;
        List<T> ResolveAll<T>() where T: struct;
    }
}
