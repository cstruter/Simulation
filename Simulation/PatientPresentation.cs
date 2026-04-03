namespace Simulation;

public sealed record PatientPresentation
{
    public bool StressorLinkedToSymptom { get; init; }
    public bool HasNeurologicalPresentation { get; init; }
    public bool IsIncompatibleWithKnownNeurology { get; init; }
    public bool HasNoBetterExplanation { get; init; }
    public bool HasPsychologicalStressor { get; init; }
    public bool CausesSignificantDistressOrImpairment { get; init; }
    public bool IsIntentionallyProduced { get; init; }
}