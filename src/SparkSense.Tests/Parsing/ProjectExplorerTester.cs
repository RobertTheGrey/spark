﻿using System;
using NUnit.Framework;
using Spark.FileSystem;
using Spark.Parser;
using Spark.Parser.Syntax;
using EnvDTE;
using System.Runtime.InteropServices;

namespace SparkSense.Tests.Parsing
{
    [TestFixture]
    public class ProjectExplorerTester
    {
        private const string IRRELEVANT_FILE_CONTENT = "Irrelevant content";
        private const string ROOT_VIEW_PATH = "SparkSense.Tests.Views";
        private DefaultSyntaxProvider _syntaxProvider;
        private ViewLoader _viewLoader;

        [SetUp]
        public void Setup()
        {
            _syntaxProvider = new DefaultSyntaxProvider(new ParserSettings());
            _viewLoader = new ViewLoader { ViewFolder = new FileSystemViewFolder(ROOT_VIEW_PATH), SyntaxProvider = _syntaxProvider };
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowIfTheProjectEnvironmentIsNull()
        {
            new SparkSense.Parsing.ProjectExplorer(null);
        }

        [Test, Ignore("Need to abstract the DTE away somewhere")]
        public void ShouldBuildAMapOfAllViewsInTheSolution()
        {
            var projectEnvironment = (DTE)Marshal.GetActiveObject("VisualStudio.DTE.10.0");

            var projectExplorer = new SparkSense.Parsing.ProjectExplorer(projectEnvironment);
            var viewMap = projectExplorer.ViewMap;

            viewMap.ForEach(s => Console.WriteLine(s));

            Assert.Contains("Shared\\Application.spark", viewMap);
        }
    }
}