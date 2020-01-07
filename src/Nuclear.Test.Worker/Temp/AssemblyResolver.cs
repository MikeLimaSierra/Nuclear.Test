using System;
using System.Collections.Generic;
using System.IO;

namespace Nuclear.Test.Worker.Temp {
    abstract class AssemblyResolver : IAssemblyResolver {

        #region public methods

        public abstract Boolean TryResolve(ResolveEventArgs e, out FileInfo assembly);

        public abstract Boolean TryResolve(ResolveEventArgs e, out IEnumerable<FileInfo> assemblies);

        #endregion

        #region public methods

        #endregion

    }
}
