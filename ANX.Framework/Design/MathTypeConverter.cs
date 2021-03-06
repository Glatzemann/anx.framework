#region Using Statements
using System;
using System.ComponentModel;
#if !WINDOWSMETRO
using System.ComponentModel.Design.Serialization;
#endif
using System.Globalization;
using System.Text;
using System.Linq;
using ANX.Framework.NonXNA.Reflection;
using ANX.Framework.NonXNA.Development;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Design
{
#if !WINDOWSMETRO      //TODO: search replacement for Win8
    [Developer("GinieDP, Konstantin Koch")]
    [TestState(TestStateAttribute.TestState.Untested)]
    public class MathTypeConverter : ExpandableObjectConverter
    {
        protected PropertyDescriptorCollection propertyDescriptions;

        protected bool supportStringConvert = true;

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (this.supportStringConvert && sourceType == typeof(String))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (IsTypeInstanceDescriptor(destinationType))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value,
            Attribute[] attributes)
        {
            return propertyDescriptions;
        }

        protected static PropertyDescriptorCollection CreateFieldDescriptor<T>(params string[] fields)
        {
            Type type = typeof(T);
            PropertyDescriptor[] descriptor = new PropertyDescriptor[fields.Length];
            for (int i = 0; i < fields.Length; i++)
            {
                descriptor[i] = new ANXFieldDescriptor(type.GetField(fields[i]));
            }
            return new PropertyDescriptorCollection(descriptor);
        }

        protected static PropertyDescriptorCollection CreatePropertyDescriptor<T>(params string[] fields)
        {
            Type type = typeof(T);
            PropertyDescriptor[] descriptor = new PropertyDescriptor[fields.Length];
            for (int i = 0; i < fields.Length; i++)
            {
                descriptor[i] = new ANXPropertyDescriptor(type.GetProperty(fields[i]));
            }
            return new PropertyDescriptorCollection(descriptor).Sort(fields);
        }

        protected string ConvertToString<T>(ITypeDescriptorContext context, CultureInfo culture, T[] values)
        {
            string separator = "; ";
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < values.Length; i++)
            {
                builder.Append(converter.ConvertToString(context, culture, values[i]));
                if (i < values.Length - 1)
                {
                    builder.Append(separator);
                }
            }
            return builder.ToString();
        }

        protected T[] ConvertFromString<T>(ITypeDescriptorContext context, CultureInfo culture, string value)
        {
            if (value == null)
                return null;

            value = value.Trim();

            string[] values = value.Split(';');
            T[] result = new T[values.Length];
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                for (int i = 0; i < values.Length; i++)
                {
                    result[i] = (T)converter.ConvertFromString(context, culture, values[i]);
                }
            }
            catch (Exception exc)
            {
                throw new ArgumentException(string.Format("Invalid string format. Expected a string in the format \"{0}\".", string.Join(";", propertyDescriptions.Cast<PropertyDescriptor>().Select((x) => x.DisplayName))), exc);
            }

            if (propertyDescriptions.Count != values.Length)
                throw new ArgumentException(string.Format("Invalid string format. Expected a string in the format \"{0}\".", string.Join(";", propertyDescriptions.Cast<PropertyDescriptor>().Select((x) => x.DisplayName))));

            return result;
        }

        protected InstanceDescriptor CreateInstanceDescriptor<T>(object[] parameters)
        {
            Type[] paramTypes = new Type[parameters.Length];
            for (int index = 0; index < parameters.Length; index++)
                paramTypes[index] = parameters[index].GetType();

            var constructor = TypeHelper.GetConstructor(typeof(T), paramTypes);
            return new InstanceDescriptor(constructor, parameters);
        }

        protected bool IsTypeInstanceDescriptor(Type type)
        {
            return type == typeof(InstanceDescriptor);
        }
    }

#endif
}
