using System.Collections.Concurrent;

namespace Simulation;

internal sealed class PatientDataGenerator(double BaseRateNeurologicalPresentation = 0.15, double HelpSeekingRate = 0.035)
{
    public ConcurrentBag<PatientPresentation> Generate(int totalPatients)
    {
        var patients = new ConcurrentBag<PatientPresentation>();
        Parallel.For(0, totalPatients, i =>
        {
            if (!Chance(BaseRateNeurologicalPresentation) || !Chance(HelpSeekingRate))
                return;

            bool isIncompatibleWithKnownNeurology = Chance(30);
            bool hasPsychologicalStressor = FlipDecision();
            var patient = new PatientPresentation
            {
                HasNeurologicalPresentation = true,
                IsIncompatibleWithKnownNeurology = isIncompatibleWithKnownNeurology,
                HasNoBetterExplanation = isIncompatibleWithKnownNeurology ? Chance(70) : Chance(20),
                CausesSignificantDistressOrImpairment = Chance(80),
                HasPsychologicalStressor = hasPsychologicalStressor,
                StressorLinkedToSymptom = hasPsychologicalStressor && Chance(60),
                IsIntentionallyProduced = Chance(1)
            };
            patients.Add(patient);
        });
        return patients;
    }

    private static bool FlipDecision() => Random.Shared.Next(2) == 0;
    private static bool Chance(int percent) => Random.Shared.Next(100) < percent;
    private static bool Chance(double rate) => Random.Shared.NextDouble() < rate;
}