using System;

using Nuclear.Creation;

namespace Nuclear.Test.Worker.Factories {

    /// <summary>
    /// Defines an extension to <see cref="IFactory"/>.
    /// </summary>
    internal static class IFactoryExtensions {

        /// <summary>
        /// Returns a new instance of <see cref="ICreator{Object, Type}"/>.
        /// </summary>
        /// <returns>A  new instance of <see cref="ICreator{Object, Type}"/>.</returns>
        public static ICreator<Object, Type> TestInstances(this IFactory _) => Factory.Instance.Creator.Create((Type in1) => Create(in1));

        internal static Object Create(Type type) => Activator.CreateInstance(type, true);

        /// <summary>
        /// Returns a new instance of <see cref="ResultsFactory"/>.
        /// </summary>
        /// <returns>A  new instance of <see cref="ResultsFactory"/>.</returns>
        public static ResultsFactory ResultEntries(this IFactory _) => new Internal.ResultsFactory();

    }
}
