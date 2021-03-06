﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANX.Framework.Content.Pipeline.Graphics;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content.Pipeline.Processors
{
    public class ModelMeshContent
    {
        public BoundingSphere BoundingSphere
        {
            get;
            internal set;
        }

        public ModelMeshPartContentCollection MeshParts
        {
            get;
            internal set;
        }

        public string Name
        {
            get;
            internal set;
        }

        public ModelBoneContent ParentBone
        {
            get;
            internal set;
        }

        public MeshContent SourceMesh
        {
            get;
            internal set;
        }

        public Object Tag
        {
            get;
            set;
        }

        public ModelMeshContent()
        {
            MeshParts = new ModelMeshPartContentCollection();
        }
    }
}
