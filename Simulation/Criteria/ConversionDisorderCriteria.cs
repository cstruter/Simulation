namespace Simulation.Criteria;

internal sealed class ConversionDisorderCriteria : IDiagnosticCriteria
{
    public string Name => "DSM-IV CD";

    public bool MeetsCriteria(PatientPresentation p)
        =>  p.HasNeurologicalPresentation &&          // Criterion A – symptom affecting voluntary motor or sensory function
            p.StressorLinkedToSymptom &&              // Criterion B – psychological factors associated with symptom onset/exacerbation
            p.HasNoBetterExplanation &&               // Criterion C – symptom not fully explained by a medical condition
            !p.IsIntentionallyProduced &&             // Criterion D – symptom not intentionally produced (excludes factitious disorder/malingering)
            p.CausesSignificantDistressOrImpairment;  // Criterion E – symptom causes clinically significant distress or impairment
}