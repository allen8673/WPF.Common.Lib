using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Common.Service.Model
{
    public class ObjectCatcher
    {
        private string CatchJsonObject { get; set; }
        JsonSerializerSettings SerializerSettings { get; set; }
        public void Catch<T>(T obj, params string[] ignoreProperties)
        {
            var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
            jsonResolver.IgnoreProperty(typeof(T), ignoreProperties);
            SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = jsonResolver
            };
            CatchJsonObject = JsonConvert.SerializeObject(obj, SerializerSettings);
        }

        public void Catch(object obj, Type targetType, params string[] ignoreProperties)
        {
            var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
            jsonResolver.IgnoreProperty(targetType, ignoreProperties);
            SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = jsonResolver
            };
            CatchJsonObject = JsonConvert.SerializeObject(obj, SerializerSettings);
        }

        public void CatchByProperties<T>(T obj, params string[] properties)
        {
            var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
            jsonResolver.IgnoreProperty(typeof(T), typeof(T).GetProperties().Where(p => !properties.Contains(p.Name)).Select(p => p.Name).ToArray());
            SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = jsonResolver
            };
            CatchJsonObject = JsonConvert.SerializeObject(obj, SerializerSettings);
        }

        public void CatchByProperties(object obj, Type targetType, params string[] properties)
        {
            var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
            jsonResolver.IgnoreProperty(targetType, targetType.GetProperties().Where(p => !properties.Contains(p.Name)).Select(p => p.Name).ToArray());
            SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = jsonResolver
            };
            CatchJsonObject = JsonConvert.SerializeObject(obj, SerializerSettings);
        }

        public bool IsEquals<T>(T obj) => JsonConvert.SerializeObject(obj, SerializerSettings) == CatchJsonObject;

        public class PropertyRenameAndIgnoreSerializerContractResolver : DefaultContractResolver
        {
            private readonly Dictionary<Type, HashSet<string>> _ignores;
            private readonly Dictionary<Type, Dictionary<string, string>> _renames;

            public PropertyRenameAndIgnoreSerializerContractResolver()
            {
                _ignores = new Dictionary<Type, HashSet<string>>();
                _renames = new Dictionary<Type, Dictionary<string, string>>();
            }

            public void IgnoreProperty(Type type, params string[] jsonPropertyNames)
            {
                if (!_ignores.ContainsKey(type))
                    _ignores[type] = new HashSet<string>();

                foreach (var prop in jsonPropertyNames)
                    _ignores[type].Add(prop);
            }

            public void RenameProperty(Type type, string propertyName, string newJsonPropertyName)
            {
                if (!_renames.ContainsKey(type))
                    _renames[type] = new Dictionary<string, string>();

                _renames[type][propertyName] = newJsonPropertyName;
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);

                if (IsIgnored(property.DeclaringType, member.Name))
                {
                    property.ShouldSerialize = i => false;
                    property.Ignored = true;
                }

                if (IsRenamed(property.DeclaringType, property.PropertyName, out var newJsonPropertyName))
                    property.PropertyName = newJsonPropertyName;

                return property;
            }

            private bool IsIgnored(Type type, string jsonPropertyName)
            {
                if (!_ignores.ContainsKey(type))
                    return false;

                return _ignores[type].Contains(jsonPropertyName);
            }

            private bool IsRenamed(Type type, string jsonPropertyName, out string newJsonPropertyName)
            {
                Dictionary<string, string> renames;

                if (!_renames.TryGetValue(type, out renames) || !renames.TryGetValue(jsonPropertyName, out newJsonPropertyName))
                {
                    newJsonPropertyName = null;
                    return false;
                }

                return true;
            }
        }
    }
}
