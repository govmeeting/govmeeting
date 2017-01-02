using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ninject;
using Govmeeting.Backend.ReadTranscript;

namespace Govmeeting.Backend.ReadTranscript.Tests
{
    [TestFixture()]
    public class ReadTranscriptFieldsTests
    {
        [Test()]
        public void Backend_ReadTranscript_ReadNextField()
        {
            // ARRANGE

            List<string> nextLines = new List<string>
            {
               "Body: Anyville Town Council",
               "Interim Town Parks Commisioner: Pete Lamb",
               "Topic: Fire equipment purchase ",
               "Speaker:  Louise Dinkins ",
               "This equipment is badly needed.",
               "Speaker: Joe Hammer",
               @"We need to consider the costs involved
in purchasing this equipment."
            };

            StandardKernel kernel = new StandardKernel();
            kernel.Bind<IReadLinesFromFile>().To<ReadLinesFromFile_stub>().WithConstructorArgument("nextLines", nextLines);
            ReadTranscriptFields rT = kernel.Get<ReadTranscriptFields>();

            // ACT

            Field field1 = rT.ReadNextField();
            Field field2 = rT.ReadNextField();
            Field field3 = rT.ReadNextField();
            Field field4 = rT.ReadNextField();
            Field field5 = rT.ReadNextFieldOrText();
            Field field6 = rT.ReadNextFieldOrText();
            Field field7 = rT.ReadNextFieldOrText();

            
            // ASSERT

            Assert.That(field1.Name, Is.EqualTo("Body"));
            Assert.That(field1.Value, Is.EqualTo("Anyville Town Council"));

            Assert.That(field2.Name, Is.EqualTo("Interim Town Parks Commisioner"));
            Assert.That(field2.Value, Is.EqualTo("Pete Lamb"));

            Assert.That(field3.Value, Is.EqualTo("Fire equipment purchase"), "Extra space past value should be removed.");
            Assert.That(field4.Value, Is.EqualTo("Louise Dinkins"), "Extra space each side of value should be removed.");


            Assert.That(field5.Name, Is.EqualTo("Text"), "If no field name, it should use Text.");
            Assert.That(field5.Value, Is.EqualTo("This equipment is badly needed."));

            Assert.That(field7.Value, Is.EqualTo(@"We need to consider the costs involved
in purchasing this equipment."));
        }
        /*
        [Test()]
        public void PushLineTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void LinenumTest()
        {
            Assert.Fail();
        }
        */
    }
}
