using System.Collections.ObjectModel;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Media
{
    public class VisualizationData
    {
        internal readonly float[] FrequencyData;
        internal readonly float[] SampleData;

        public ReadOnlyCollection<float> Frequencies
        {
            get { return new ReadOnlyCollection<float>(FrequencyData); }
        }

        public ReadOnlyCollection<float> Samples
        {
            get { return new ReadOnlyCollection<float>(SampleData); }
        }

        public VisualizationData()
        {
            FrequencyData = new float[256];
            SampleData = new float[256];
        }
    }
}
