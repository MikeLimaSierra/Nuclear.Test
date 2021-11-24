using System;

using Nuclear.Creation;
using Nuclear.Test.Link;

namespace Nuclear.Test.Factories.Internal {
    internal class LinkFactory : Factories.LinkFactory {

        #region fields

        private readonly ICreator<IClientLink, String> _cLinkFactory =
            Factory.Instance.Creator.Create<IClientLink, String>(
                (in1) => new ClientLink(in1));

        private readonly ICreator<IServerLink, String> _sLinkFactory =
            Factory.Instance.Creator.Create<IServerLink, String>(
                (in1) => new ServerLink(in1));

        private readonly ICreator<IMessage, String> _messageFactory =
            Factory.Instance.Creator.Create<IMessage, String>(
                (in1) => new Message(in1));

        #endregion

        #region methods

        public override void Create(out IClientLink obj)
            => _cLinkFactory.Create(out obj, Guid.NewGuid().ToString());

        public override Boolean TryCreate(out IClientLink obj)
            => _cLinkFactory.TryCreate(out obj, Guid.NewGuid().ToString());

        public override Boolean TryCreate(out IClientLink obj, out Exception ex)
            => _cLinkFactory.TryCreate(out obj, Guid.NewGuid().ToString(), out ex);

        public override void Create(out IClientLink obj, String in1)
            => _cLinkFactory.Create(out obj, in1);

        public override Boolean TryCreate(out IClientLink obj, String in1)
            => _cLinkFactory.TryCreate(out obj, in1);

        public override Boolean TryCreate(out IClientLink obj, String in1, out Exception ex)
            => _cLinkFactory.TryCreate(out obj, in1, out ex);

        public override void Create(out IServerLink obj)
            => _sLinkFactory.Create(out obj, Guid.NewGuid().ToString());

        public override Boolean TryCreate(out IServerLink obj)
            => _sLinkFactory.TryCreate(out obj, Guid.NewGuid().ToString());

        public override Boolean TryCreate(out IServerLink obj, out Exception ex)
            => _sLinkFactory.TryCreate(out obj, Guid.NewGuid().ToString(), out ex);

        public override void Create(out IServerLink obj, String in1)
            => _sLinkFactory.Create(out obj, in1);

        public override Boolean TryCreate(out IServerLink obj, String in1)
            => _sLinkFactory.TryCreate(out obj, in1);

        public override Boolean TryCreate(out IServerLink obj, String in1, out Exception ex)
            => _sLinkFactory.TryCreate(out obj, in1, out ex);

        public override void Create(out IMessage obj, String in1)
            => _messageFactory.Create(out obj, in1);

        public override Boolean TryCreate(out IMessage obj, String in1)
            => _messageFactory.TryCreate(out obj, in1);

        public override Boolean TryCreate(out IMessage obj, String in1, out Exception ex)
            => _messageFactory.TryCreate(out obj, in1, out ex);

        #endregion

    }
}
