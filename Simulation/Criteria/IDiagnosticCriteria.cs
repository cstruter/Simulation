namespace Simulation.Criteria;

public interface IDiagnosticCriteria
{
    string Name { get; }
    bool MeetsCriteria(PatientPresentation p);
}