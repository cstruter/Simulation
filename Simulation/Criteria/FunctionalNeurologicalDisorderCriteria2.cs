namespace Simulation.Criteria;

internal sealed class FunctionalNeurologicalDisorderCriteria2 : IDiagnosticCriteria
{
    public string Name => "DSM-5-TR FND";

    public bool MeetsCriteria(PatientPresentation p)
        => p.HasNeurologicalPresentation &&    // Criterion A: One or more symptoms of altered voluntary motor or sensory function
           p.IsIncompatibleWithKnownNeurology; // Criterion B: Rule-in Clinical findings provide evidence of incompatibility with recognized neurological/medical conditions
}