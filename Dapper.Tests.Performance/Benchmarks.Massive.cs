using BenchmarkDotNet.Attributes;
using Massive;
using System.Linq;

namespace Dapper.Tests.Performance
{
    public class MassiveBenchmarks : BenchmarkBase
    {
        private DynamicModel _model;

        [Setup]
        public void Setup()
        {
            BaseSetup();
            _model = new DynamicModel(ConnectionString);
        }

        [Benchmark(Description = "Massive: Query (dynamic)", OperationsPerInvoke = Iterations)]
        public dynamic Query()
        {
            Step();
            return _model.Query("select * from Posts where Id = @0", _connection, i).First();
        }
    }
}