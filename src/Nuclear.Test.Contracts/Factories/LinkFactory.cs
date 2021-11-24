using System;

using Nuclear.Creation;
using Nuclear.Test.Link;

namespace Nuclear.Test.Factories {

    /// <summary>
    /// Defines a factory for internal implementations.
    /// </summary>
    public abstract class LinkFactory :
        ICreator<IClientLink>,
        ICreator<IClientLink, String>,
        ICreator<IServerLink>,
        ICreator<IServerLink, String>,
        ICreator<IMessage, String> {

        public abstract void Create(out IClientLink obj);

        public abstract Boolean TryCreate(out IClientLink obj);

        public abstract Boolean TryCreate(out IClientLink obj, out Exception ex);

        public abstract void Create(out IClientLink obj, String pipeID);

        public abstract Boolean TryCreate(out IClientLink obj, String pipeID);

        public abstract Boolean TryCreate(out IClientLink obj, String pipeID, out Exception ex);

        public abstract void Create(out IServerLink obj);

        public abstract Boolean TryCreate(out IServerLink obj);

        public abstract Boolean TryCreate(out IServerLink obj, out Exception ex);

        public abstract void Create(out IServerLink obj, String pipeID);

        public abstract Boolean TryCreate(out IServerLink obj, String pipeID);

        public abstract Boolean TryCreate(out IServerLink obj, String pipeID, out Exception ex);

        public abstract void Create(out IMessage obj, String command);

        public abstract Boolean TryCreate(out IMessage obj, String command);

        public abstract Boolean TryCreate(out IMessage obj, String command, out Exception ex);

    }

}
