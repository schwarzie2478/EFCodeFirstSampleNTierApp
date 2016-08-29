using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;

namespace DomainModel
{
    public class EntityResolver : DataContractResolver
    {
        const string MyEntityNamespace = "http://tempuri.com";
 
    public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            if (typeNamespace == MyEntityNamespace)
            {
                if (typeName == typeof(MyEntity).Name)
                {
                    return typeof(MyEntity);
                }
                if (typeName == typeof(YourEntity).Name)
                {
                    return typeof(YourEntity);
                }
                if (typeName == typeof(MyDistinctSubEntity).Name)
                {
                    return typeof(MyDistinctSubEntity);
                }
            }

            return knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null) ?? declaredType;
        }

        public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            if (type == typeof(MyEntity) || type == typeof(MyDistinctSubEntity) || type == typeof(YourEntity))  
            {
                XmlDictionary dictionary = new XmlDictionary();
                typeName = dictionary.Add(type.Name);
                typeNamespace = dictionary.Add(MyEntityNamespace);
                return true;
            }
            else
            {
                return knownTypeResolver.TryResolveType(type, declaredType, null, out typeName, out typeNamespace);
            }
        }
    }
}
