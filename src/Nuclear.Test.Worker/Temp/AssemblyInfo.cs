using System;
using System.Globalization;
using Nuclear.Exceptions;

namespace Nuclear.Test.Worker.Temp {
    class AssemblyInfo {

        #region properties

        public String Name { get; private set; }

        public Version Version { get; private set; }

        public CultureInfo Culture { get; private set; }

        public String Token { get; private set; }

        #endregion

        #region ctors

        public AssemblyInfo(String name, Version version, CultureInfo culture, String token) {
            Throw.If.String.IsNullOrWhiteSpace(name, nameof(name));
            Throw.If.Object.IsNull(version, nameof(version));
            Throw.If.Object.IsNull(culture, nameof(culture));

            Name = name;
            Version = version;
            Culture = culture;
            Token = token;
        }

        #endregion

        #region methods

        public static Boolean TryParse(String assemblyName, out AssemblyInfo assemblyInfo) {
            Throw.If.String.IsNullOrWhiteSpace(assemblyName, nameof(assemblyName));

            assemblyInfo = null;

            String[] parts = assemblyName.Split(',', StringSplitOptions.RemoveEmptyEntries);
            Throw.If.Value.IsFalse(parts.Length >= 3, nameof(assemblyName),
                $"Given assembly name '{assemblyName}' has less than 3 parts.");

            String name = ParseName(assemblyName, parts[0]);
            Version version = ParseVersion(assemblyName, parts[1]);
            CultureInfo culture = ParseCulture(assemblyName, parts[2]);
            String token = ParseToken(assemblyName, parts[3]);

            assemblyInfo = new AssemblyInfo(name, version, culture, token);

            return assemblyInfo != null;
        }

        #endregion

        #region parsing methods

        private static String ParseName(String assemblyName, String part) {
            Throw.If.String.IsNullOrWhiteSpace(part, nameof(assemblyName),
                $"Given assembly name '{assemblyName}' is missing a name.");

            return part.Trim();
        }

        private static Version ParseVersion(String assemblyName, String part) {
            Version version = null;

            Throw.If.String.IsNullOrWhiteSpace(part, nameof(assemblyName),
                $"Given assembly name '{assemblyName}' has an empty second part.");
            Throw.If.Value.IsFalse(part.Trim().StartsWith("Version=", true, CultureInfo.InvariantCulture), nameof(assemblyName),
                $"Given assembly name '{assemblyName}' is missing a version.");

            try {
                version = new Version(part.Trim().Replace("Version=", String.Empty));

            } catch(ArgumentOutOfRangeException) {
                throw new ArgumentException("Version: A major, minor, build, or revision component is less than zero.", nameof(assemblyName));

            } catch(ArgumentException) {
                throw new ArgumentException("Version: version has fewer than two components or more than four components.", nameof(assemblyName));

            } catch(FormatException) {
                throw new ArgumentException("Version: At least one component of version does not parse to an integer.", nameof(assemblyName));

            } catch(OverflowException) {
                throw new ArgumentException("Version: At least one component of version represents a number greater than System.Int32.MaxValue.", nameof(assemblyName));
            }

            return version;
        }

        private static CultureInfo ParseCulture(String assemblyName, String part) {
            CultureInfo culture = null;

            Throw.If.String.IsNullOrWhiteSpace(part, nameof(assemblyName),
                $"Given assembly name '{assemblyName}' has an empty third part.");
            Throw.If.Value.IsFalse(part.Trim().StartsWith("Culture=", true, CultureInfo.InvariantCulture), nameof(assemblyName),
                $"Given assembly name '{assemblyName}' is missing a culture.");

            String cultureValue = part.Trim().Replace("Culture=", String.Empty);

            try {
                switch(cultureValue) {
                    case "neutral":
                        culture = CultureInfo.InvariantCulture;
                        break;

                    default:
                        culture = new CultureInfo(cultureValue);
                        break;
                }

            } catch(CultureNotFoundException) {
                throw new ArgumentException("Culture: name is not a valid culture name.", nameof(assemblyName));
            }

            return culture;
        }

        private static String ParseToken(String assemblyName, String part) {
            Throw.If.String.IsNullOrWhiteSpace(part, nameof(assemblyName),
                $"Given assembly name '{assemblyName}' has an empty fourth part.");
            Throw.If.Value.IsFalse(part.Trim().StartsWith("PublicKeyToken=", true, CultureInfo.InvariantCulture), nameof(assemblyName),
                $"Given assembly name '{assemblyName}' is missing a token.");

            return part.Trim().Replace("PublicKeyToken=", String.Empty);
        }

        #endregion

    }
}
