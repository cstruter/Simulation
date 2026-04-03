using ConsoleTables;
using Simulation.Criteria;

namespace Simulation;

class Program
{
    const int total = 68_000_000;
    static readonly PatientDataGenerator generator = new();
    static readonly List<IDiagnosticCriteria> criterias =
    [
        new ConversionDisorderCriteria(),
        new FunctionalNeurologicalDisorderCriteria1(),
        new FunctionalNeurologicalDisorderCriteria2()
    ];

    static void Main()
    {
        var table = new ConsoleTable("Criteria", "Cases", "Prevalence");
        var patients = generator.Generate(total);

        foreach (var criteria in criterias)
        {
            var count = patients.Count(criteria.MeetsCriteria);
            var prevalence = total > 0 ? (count * 100.0 / total) : 0;
            table.AddRow(criteria.Name, count.ToString("N0"), prevalence.ToString("F3") + "%");
        }

        var both = patients.Count(p =>
            new ConversionDisorderCriteria().MeetsCriteria(p) &&
            new FunctionalNeurologicalDisorderCriteria1().MeetsCriteria(p));

        table.AddRow("Both FND and CD", both.ToString("N0"), (both * 100.0 / total).ToString("F3") + "%");

        table.Write(Format.Minimal);
    }
}