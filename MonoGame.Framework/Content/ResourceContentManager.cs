﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;

namespace Microsoft.Xna.Framework.Content
{
    public class ResourceContentManager : ContentManager
    {
        private ResourceManager resource;

        public ResourceContentManager(IServiceProvider servicesProvider, ResourceManager resource)
            : base(servicesProvider)
        {
            this.resource = resource ?? throw new ArgumentNullException("resource");
        }

        protected override Stream OpenStream(string assetName)
        {
            object obj = resource.GetObject(assetName);
            if (obj == null)
            {
                throw new ContentLoadException("Resource not found");
            }
            if (!(obj is byte[]))
            {
                throw new ContentLoadException("Resource is not in binary format");
            }
            return new MemoryStream(obj as byte[]);
        }
    }
}
