using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.Collections.Generic;

namespace MonoGame.Tests.ContentPipeline
{
    class TestImporterContext : ContentImporterContext
    {
        readonly string _intermediateDirectory;
        readonly string _outputDirectory;
        readonly TestContentBuildLogger _logger;
        List<string> _dependencies;

        public TestImporterContext(string intermediateDirectory, string outputDirectory)
        {
            _intermediateDirectory = intermediateDirectory;
            _outputDirectory = outputDirectory;
            _logger = new TestContentBuildLogger();
            _dependencies = new List<string>();
        }

        public List<string> Dependencies => _dependencies;

        public override string IntermediateDirectory => _intermediateDirectory;

        public override ContentBuildLogger Logger => _logger;

        public override string OutputDirectory => _outputDirectory;

        public override void AddDependency(string filename)
        {
            _dependencies.Add(filename);
        }
    }
}
