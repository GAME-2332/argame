using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Unity.VisualScripting;

namespace Util {
    public class Reflection {
        public static IEnumerable<Type> GetTypesWithAttribute(Type attributeType) {
            return GetTypesWithAttribute(Assembly.GetExecutingAssembly(), attributeType);
        }
        
        public static IEnumerable<Type> GetTypesWithAttribute(Assembly assembly, Type attributeType) {
            return
                from type in assembly.GetTypes() 
                let attributes = type.GetCustomAttributes(attributeType, true)
                where attributes != null && attributes.Length > 0
                select type;
        }
        
        public static IEnumerable<StaticField<T>> GetStaticFieldsWithAttribute<T>(Type attributeType) {
            return GetStaticFieldsWithAttribute<T>(Assembly.GetExecutingAssembly(), attributeType);
        }

        public static IEnumerable<StaticField<T>> GetStaticFieldsWithAttribute<T>(Assembly assembly, Type attributeType) {
            return
                from type in assembly.GetTypes()
                from field in type.GetFields(BindingFlags.Static)
                where field.FieldType == typeof(T)
                let attributes = field.GetCustomAttributes(attributeType, true)
                where attributes != null && attributes.Length > 0
                select new StaticField<T>(field);
        }
    }
}