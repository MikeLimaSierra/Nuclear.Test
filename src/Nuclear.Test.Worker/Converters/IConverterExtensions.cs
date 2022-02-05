using System;
using System.Linq;
using System.Reflection;

using Nuclear.Creation;
using Nuclear.Extensions;

namespace Nuclear.Test.Worker.Converters {

    /// <summary>
    /// Defines an extension to <see cref="IConverter"/>.
    /// </summary>
    public static class IConverterExtensions {

        /// <summary>
        /// Returns a new instance of <see cref="ICreator{String, Attribute}"/>.
        /// </summary>
        /// <returns>A  new instance of <see cref="ICreator{String, Attribute}"/>.</returns>
        public static ICreator<String, Attribute> Attributes(this IConverter _) => Factory.Instance.Creator.Create((Attribute in1) => Convert(in1));

        internal static String Convert(Attribute attr) {
            Type attrType = attr.GetType();
            IOrderedEnumerable<PropertyInfo> attrProps = attrType.GetMembers(BindingFlags.Public | BindingFlags.Instance)
                .Where(_ => _ is PropertyInfo)
                .Where(_ => _.Name != nameof(Attribute.TypeId))
                .Cast<PropertyInfo>()
                .ToList()
                .OrderBy(_ => _.Name);

            String attrName = attrType.Name.EndsWith(nameof(Attribute)) ? attrType.Name.Substring(0, attrType.Name.LastIndexOf(nameof(Attribute))) : attrType.Name;
            String propertiesString = attrProps.Any() ? $"({String.Join(", ", attrProps.Select(_ => $"{_.Name} = {_.GetMethod.Invoke(attr, new Object[0]).Format()}"))})" : String.Empty;

            return $"[{attrName}{propertiesString}]";
        }

    }
}
