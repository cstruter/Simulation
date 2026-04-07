# FND/CD Monte Carlo Simulation

A C# Monte Carlo simulation exploring how changes in diagnostic criteria affect the estimated prevalence of **Functional Neurological Disorder (FND)**, formerly known as **Conversion Disorder (CD)**.

The project compares:
- DSM-IV criteria for Conversion Disorder
- DSM-5 criteria for Functional Neurological Symptom Disorder (full criteria)
- DSM-5 "rule-in" criteria only (positive signs of incompatibility)

## Purpose

This simulation demonstrates **diagnostic expansion** when moving from DSM-IV to DSM-5 criteria. In a simulated UK-sized population of 68 million people, the model shows:

- DSM-IV criteria identify roughly **30,000** cases
- DSM-5 full criteria identify roughly **60,000** cases (≈ 2×)
- Rule-in signs only identify roughly **107,000** cases (≈ 3.5×)

The goal is to illustrate how small changes in diagnostic rules — particularly the shift toward positive rule-in signs and the removal of the mandatory psychological stressor requirement — can materially increase the number of diagnosed cases and allow greater co-occurrence with other neurological conditions.

## Features

- Probabilistic patient generation using Monte Carlo methods
- Three separate criteria implementations matching DSM-IV and DSM-5
- `PatientPresentation` class modelling key clinical traits
- Easy to modify parameters for sensitivity analysis
- Console output with summary statistics

## Repository Structure