// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
    public sealed class ModelMeshPartContent
    {
        private IndexCollection _indexBuffer;
        private MaterialContent _material;
        private int _numVertices;
        private int _primitiveCount;
        private int _startIndex;
        private VertexBufferContent _vertexBuffer;
        private int _vertexOffset;

        internal ModelMeshPartContent() { }

        internal ModelMeshPartContent(VertexBufferContent vertexBuffer, IndexCollection indices, int vertexOffset,
                                      int numVertices, int startIndex, int primitiveCount)
        {
            _vertexBuffer = vertexBuffer;
            _indexBuffer = indices;
            _vertexOffset = vertexOffset;
            _numVertices = numVertices;
            _startIndex = startIndex;
            _primitiveCount = primitiveCount;
        }

        public IndexCollection IndexBuffer => _indexBuffer;

        public MaterialContent Material
        {
            get => _material;
            set => _material = value;
        }

        public int NumVertices => _numVertices;

        public int PrimitiveCount => _primitiveCount;

        public int StartIndex => _startIndex;

        public object Tag { get; set; }

        public VertexBufferContent VertexBuffer => _vertexBuffer;

        public int VertexOffset => _vertexOffset;
    }
}
