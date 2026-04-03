namespace Simulation.Criteria;

internal sealed class FunctionalNeurologicalDisorderCriteria1 : IDiagnosticCriteria
{
    public string Name => "DSM-5-TR FND Exclusion";

    public bool MeetsCriteria(PatientPresentation p)
        => p.HasNeurologicalPresentation &&         // Criterion A: One or more symptoms of altered voluntary motor or sensory function
           p.IsIncompatibleWithKnownNeurology &&    // Criterion B: Rule-in Clinical findings provide evidence of incompatibility with recognized neurological/medical conditions
           p.HasNoBetterExplanation &&              // Criterion C: Not better explained by another medical or mental disorder
           p.CausesSignificantDistressOrImpairment; // Criterion D: Causes clinically significant distress or impairment (or warrants medical evaluation)
}