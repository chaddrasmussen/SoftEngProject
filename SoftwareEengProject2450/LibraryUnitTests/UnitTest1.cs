using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System.Collections.Generic;
using System.IO;

namespace LibraryUnitTests
{
    [TestClass]
    public class DataBaseReadWrite_Test
    {
        DataBaseReadWrite db = new DataBaseReadWrite("patronTest.bin","mediaTest.bin");
        SortedDictionary<uint,Media> mediaSD = new SortedDictionary<uint,Media>();
        SortedDictionary<uint, Patron> patronSD = new SortedDictionary<uint, Patron>();
        SortedDictionary<uint, Media> temp = new SortedDictionary<uint, Media>();
        SortedDictionary<uint, Patron> ptemp = new SortedDictionary<uint, Patron>();

        [TestInitialize]
        public void init()
        {
            File.Delete("patronTest.bin");
            File.Delete("mediaTest.bin");
        }

        [TestMethod]
        public void readEmptyTest()
        {
            db.readCatalog(ref mediaSD);            
            db.readPatron(ref patronSD);
        }

        [TestMethod]
        public void writeToEmptyTest()
        {
            
            mediaSD.Add(1, new Media("title", MediaType.ADULTBOOK));
            patronSD.Add(1, new Patron("Tester", 10023, "somewhere", "801-999-6666", DateTime.Today));
            db.writeCatalog(mediaSD);
            db.writePatron(patronSD);
            
            db.readCatalog(ref temp);
            db.readPatron(ref ptemp);
            Assert.AreEqual(temp.Values.ToString(), mediaSD.Values.ToString());
            Assert.AreEqual(ptemp.Values.ToString(), patronSD.Values.ToString());
        }

        [TestMethod]
        public void secondReadAndWriteTest()
        {
            mediaSD.Add(2,new Media("title 2: overdrive",MediaType.DVD));
            patronSD.Add(2,new Patron("Testee",12345,"somewhere","801-776-9987",DateTime.Today));
            db.writeCatalog(mediaSD);
            db.writePatron(patronSD);

            db.readCatalog(ref temp);
            db.readPatron(ref ptemp);
            Assert.AreEqual(temp.Values.ToString(), mediaSD.Values.ToString());
            Assert.AreEqual(ptemp.Values.ToString(), patronSD.Values.ToString());
        }

        [TestCleanup]
        public void end()
        {
            File.Delete("mediaTest.bin");
            File.Delete("patronTest.bin");
        }
    }
}
