﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content.Pipeline.Processors
{
    public class ModelContent
    {
        public ModelBoneContentCollection Bones
        {
            get;
            private set;
        }

        public ModelMeshContentCollection Meshes
        {
            get;
            private set;
        }

        public ModelBoneContent Root
        {
            get;
            private set;
        }

        public Object Tag
        {
            get;
            set;
        }

        public ModelContent(ModelBoneContent rootBone, IList<ModelBoneContent> bones, IList<ModelMeshContent> meshes)
        {
            Root = rootBone;
            Meshes = new ModelMeshContentCollection(meshes);
            Bones = new ModelBoneContentCollection(bones);
        }
    }
}
