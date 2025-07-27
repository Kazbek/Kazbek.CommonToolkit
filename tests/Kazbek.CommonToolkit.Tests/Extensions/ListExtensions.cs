using Kazbek.CommonToolkit.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazbek.CommonToolkit.Tests.Extensions
{
    [TestClass]
    public sealed class ListExtensions
    {
        [TestMethod]
        public void SynchronizeWith1()
        {
            List<SourceDto> source = [
                new SourceDto { Id = 2, Value = 2},
                new SourceDto { Id = 3, Value = 3},
                new SourceDto { Id = 4, Value = 4},
                ];

            List<TargetDro> target = [
                new TargetDro { TId = 1, TValue = 1},
                new TargetDro { TId = 2, TValue = 2},
                new TargetDro { TId = 3, TValue = 3},
                new TargetDro { TId = 5, TValue = 5},
                new TargetDro { TId = 6, TValue = 6},
                ];

            var s2 = source.First(t => t.Id == 2);

            source.SynchronizeWith(target, (a, b) => a.Id == b.TId, t => new SourceDto { Id = t.TId, Value = t.TValue });
            Assert.AreEqual(target.Count, source.Count);
            Assert.AreEqual(5, source.Count);

            Assert.AreEqual(s2, source.First(t => t.Id == 2));

            Assert.IsTrue(source.Any(s => s.Id == 1));
            Assert.IsTrue(source.Any(s => s.Id == 2));
            Assert.IsTrue(source.Any(s => s.Id == 3));
            Assert.IsTrue(source.Any(s => s.Id == 5));
            Assert.IsTrue(source.Any(s => s.Id == 6));
        }

        private class SourceDto
        {
            public int Id { get; set; }
            public int Value { get; set; }
        }

        private class TargetDro
        {
            public int TId { get; set; }
            public int TValue { get; set; }
        }
    }
}
