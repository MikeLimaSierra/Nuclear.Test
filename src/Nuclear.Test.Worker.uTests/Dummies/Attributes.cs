using System;

namespace Nuclear.Test.Worker.Dummies {
    class DummyAttribute : Attribute { }

    class DummyOnePropAttribute : Attribute {

        public String Name { get; set; }

    }

    class DummyTwoPropsAttribute : Attribute {

        public Int32 Size { get; set; }

        public String Name { get; set; }

    }

    class DummyMixedPropsAttribute : Attribute {

        public Int32 Size { get; set; }

        public String Name { get; set; }

        internal String InternalName { get; set; }

        protected String ProtectedName { get; set; }

        private String PrivateName { get; set; }

    }
}
