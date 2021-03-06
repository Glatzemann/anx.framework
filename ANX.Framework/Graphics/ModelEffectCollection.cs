#region Using Statements
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections;
using ANX.Framework.NonXNA.Development;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Graphics
{
    [PercentageComplete(100)]
    [Developer("Glatzemann")]
    [TestState(TestStateAttribute.TestState.InProgress)]
    public sealed class ModelEffectCollection : ReadOnlyCollection<Effect>
    {
        private readonly List<Effect> effects;

        internal ModelEffectCollection()
            : base(new List<Effect>())
        {
            this.effects = base.Items as List<Effect>;
        }

        public new Enumerator GetEnumerator()
        {
            return new Enumerator(this.effects);
        }

        public void Add(Effect effect)
        {
            base.Items.Add(effect);
        }

        public void Remove(Effect effect)
        {
            base.Items.Remove(effect);
        }

        public struct Enumerator : IEnumerator<Effect>, IDisposable, IEnumerator
        {
            private readonly List<Effect> wrappedArray;
            private int position;

            public Effect Current
            {
                get { return this.wrappedArray[this.position]; }
            }

            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            internal Enumerator(List<Effect> wrappedArray)
            {
                this.wrappedArray = wrappedArray;
                this.position = -1;
            }

            public bool MoveNext()
            {
                this.position++;
                if (this.position >= this.wrappedArray.Count)
                {
                    this.position = this.wrappedArray.Count;
                    return false;
                }
                return true;
            }

            void IEnumerator.Reset()
            {
                this.position = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
