using System;
using System.Collections.Generic;
using System.Reflection;

namespace Extensions
{
    public static class ExtensionReflection
    {
        public static object GetPropertyValue(this object myObject, string propertyName)
        {
            return myObject.GetType().GetValue(myObject, propertyName);
        }
        public static object GetArrayPropertyValue(this object myObject, int index)
        {
            return myObject.GetType().GetProperties()[index].GetValue(myObject, null);
        }
        public static MethodInfo MakeGenericMethod(this Type myClass, string methodName, params Type[] typeArguments)
        {
            return myClass.GetMethod(methodName).MakeGenericMethod(typeArguments);
        }
        public static PropertyInfo[] GetProperties(this object myObject)
        {
            return myObject.GetType().GetProperties();
        }

        public static object GetValue(this object myClass, PropertyInfo property)
        {
            return myClass.GetPropertyValue(property.Name);
        }

        public static object GetValue(this Type myType,object myObject, string propertyName)
        {
            return myType.GetProperty(propertyName).GetValue(myObject, null);
        }

        public static bool IsGenericList(this Type property)
        {
            return property.IsGenericType || (property.GetGenericTypeDefinition() == typeof (List<>));
        }

        public static IEnumerable<object> GetPropertyValueAsIEnumerableObjectList(this object myObject,string propertyName)
        {
            return myObject.GetPropertyValue(propertyName) as IEnumerable<object>;
        }

    }
}
