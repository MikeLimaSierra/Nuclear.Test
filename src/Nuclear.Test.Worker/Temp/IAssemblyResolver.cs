using System;
using System.Collections.Generic;
using System.IO;

namespace Nuclear.Test.Worker.Temp {
    interface IAssemblyResolver {

        #region methods

        Boolean TryResolve(ResolveEventArgs e, out FileInfo assembly);

        Boolean TryResolve(ResolveEventArgs e, out IEnumerable<FileInfo> assemblies);

        #endregion

    }
}
