using ConsoleTables;
using Simulation.Criteria;
using System.Collections.Concurrent;

namespace Simulation;

class Program
{
    const int Total = 68_000_000;

    static readonly PatientDataGenerator Generator = new();
    static readonly ConversionDisorderCriteria Cd = new();
    static readonly FunctionalNeurologicalDisorderCriteria1 Fnd1 = new();
    static readonly FunctionalNeurologicalDisorderCriteria2 Fnd2 = new();
    static readonly ConsoleTable Table = new("Criteria", "Cases", "Prevalence");
    static readonly ConcurrentBag<PatientPresentation> Patients = Generator.Generate(Total);
    static readonly IDiagnosticCriteria[] Criterias =
    [
        Cd,
        Fnd1,
        Fnd2
    ];

    static void Main()
    {
        AllCriterias();
        BothFndAndCd();
        Render();
    }

    static void AllCriterias()
    {
        foreach (var criteria in Criterias)
        {
            var count = Patients.Count(criteria.MeetsCriteria);
            AddRow(criteria.Name, count);
        }
    }

    static void BothFndAndCd()
    {
        var count = Patients.Count(p =>
            Cd.MeetsCriteria(p) &&
            Fnd1.MeetsCriteria(p));

        AddRow("Both FND and CD", count);
    }

    static void AddRow(string name, int count)
    {
        var prevalence = Total > 0 ? (count * 100.0 / Total) : 0;
        Table.AddRow(name, count.ToString("N0"), $"{prevalence:F3}%");
    }

    static void Render()
    {
        Table.Write(Format.Minimal);
    }
}