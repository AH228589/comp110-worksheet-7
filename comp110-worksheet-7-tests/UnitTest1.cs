using comp110_worksheet_7;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace comp110_worksheet_7_tests
{
    [TestFixture]
    public class UnitTest1
    {
        string c_baseDirectory
        {
            get { return Path.Combine(TestContext.CurrentContext.TestDirectory, "..", "..", "pixelcarpack_kenney", "PNG"); }
        }

        [Test]
        public void TestBaseDirectoryExists()
        {
            // This test exists only to ensure that the base directory exists
            // If it fails, it suggests that the test framework is misconfigured
            Assert.IsTrue(Directory.Exists(c_baseDirectory));
        }

        [Test]
        public void TestGetTotalSize()
        {
            Assert.AreEqual(17038, DirectoryUtils.GetTotalSize(c_baseDirectory));
        }

        [Test]
        public void TestCountFiles()
        {
            Assert.AreEqual(75, DirectoryUtils.CountFiles(c_baseDirectory));
        }

        [Test]
        public void TestGetSmallestFile()
        {
            var result = DirectoryUtils.GetSmallestFile(c_baseDirectory);
            Assert.AreEqual(Path.GetFullPath(c_baseDirectory + "/Props/light.png"), Path.GetFullPath(result.Item1));
            Assert.AreEqual(128, result.Item2);
        }

        [Test]
        public void TestGetLargestFile()
        {
            var result = DirectoryUtils.GetLargestFile(c_baseDirectory);
            Assert.AreEqual(Path.GetFullPath(c_baseDirectory + "/Cars/hotdog.png"), Path.GetFullPath(result.Item1));
            Assert.AreEqual(338, result.Item2);
        }

        [Test]
        public void TestGetFilesOfSize253()
        {
            var result = DirectoryUtils.GetFilesOfSize(c_baseDirectory, 253).Select(Path.GetFullPath).ToList();
            result.Sort();

            var expected = new List<string>
            {
                Path.GetFullPath(c_baseDirectory + "/Cars/sedan/sedan_vintage.png"),
                Path.GetFullPath(c_baseDirectory + "/Cars/suv/suv_military.png"),
                Path.GetFullPath(c_baseDirectory + "/Cars/truck/truckcabin_vintage.png")
            };

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestGetFilesOfSize256()
        {
            Assert.AreEqual(0, DirectoryUtils.GetFilesOfSize(c_baseDirectory, 256).Count());
        }
    }
}