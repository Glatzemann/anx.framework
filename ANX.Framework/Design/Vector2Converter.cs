using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using ANX.Framework.NonXNA.Development;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Design
{
#if !WINDOWSMETRO      //TODO: search replacement for Win8
    [Developer("GinieDP")]
    [TestState(TestStateAttribute.TestState.Tested)]
    public class Vector2Converter : MathTypeConverter
    {
        public Vector2Converter()
        {
            base.propertyDescriptions = MathTypeConverter.CreateFieldDescriptor<Vector2>("X", "Y");
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            float[] values = ConvertFromString<float>(context, culture, value as String);
            if (values != null && values.Length == 2)
            {
                return new Vector2(values[0], values[1]);
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            if (value is Vector2)
            {
                Vector2 vecValue = (Vector2)value;

                if (destinationType == typeof(string))
                    return ConvertToString<float>(context, culture, new float[] { vecValue.X, vecValue.Y });

                if (IsTypeInstanceDescriptor(destinationType))
                    return CreateInstanceDescriptor<Vector2>(new object[] { vecValue.X, vecValue.Y });
            }
            
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
                throw new ArgumentNullException("propertyValues");

            return new Vector2((float)propertyValues["X"], (float)propertyValues["Y"]);
        }
    }

#endif
}
