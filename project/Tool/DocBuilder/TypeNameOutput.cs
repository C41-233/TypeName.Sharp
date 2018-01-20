using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using TypeName;

namespace DocBuilder
{
    internal class TypeNameOutput
    {

        private class TypeInfo
        {

            public string Value { get; }
            public string Name => type.Name;
            public string FullName => type.FullName;
            public string String => type.ToString();
            public string SourceName => type.GetSourceName();
            public string SourceFullName => type.GetSourceFullName();

            private readonly Type type;

            public TypeInfo(string value, Type type)
            {
                Value = value;
                this.type = type;
            }
        }

        private readonly List<TypeInfo> types = new List<TypeInfo>();

        public void Add<T>(string name)
        {
            Add(name, typeof(T));
        }

        public void Add(string name, Type type)
        {
            types.Add(new TypeInfo(name, type));
        }

        public void Save(string filename)
        {
            var array = new JArray();
            foreach (var type in types)
            {
                var entry = new JObject
                {
                    {"value", type.Value},
                    {"name", type.Name},
                    {"fullname", type.FullName},
                    {"tostring", type.String},
                    {"sourcename", type.SourceName},
                    {"sourcefullname", type.SourceFullName}
                };
                array.Add(entry);
            }
            File.WriteAllText(filename, array.ToString(), Encoding.UTF8);
        }


    }
}
