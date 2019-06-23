using System;
using Nuclear.Exceptions;

namespace NetCoreSample {
    public class MyClass {

        public String Content { get; set; }

        public MyClass(String content) {
            Throw.If.Null(content, "content");

            Content = content;
        }

    }
}
