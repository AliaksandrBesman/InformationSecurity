#pragma hdrstop
#include "UPerceptron.h"
#include "UTPM.h"
#include <random>
#include <iostream>
using namespace std;
#pragma package(smart_init)
Perceptron::Perceptron()
{
	Weights = new int[N];
	RandomWeights();
}
Perceptron::~Perceptron()
{
	delete[]Weights;
}
int Perceptron::GetOutput(int* AInputs)
{
	Inputs = AInputs;
	Output = 0;
	for (int i = 0; i < N; i++)
		Output += Inputs[i] * Weights[i];
	if (Output >= 0) Output = 1;
	else
		Output = -1;
	return Output;
}
void Perceptron::RandomWeights()
{
	for (int i = 0; i < N; i++)
		Weights[i] = L - rand()% (2 * L);
}
void Perceptron::AktualizeWeights(int OutputTPM)
{
	if (OutputTPM == Output)
		for (int i = 0; i < N; i++)
		{
			Weights[i] += Output * Inputs[i];
			if (Weights[i] > L) Weights[i] = L;
			else
				if (Weights[i] < -L) Weights[i] = -L;
		}
}
int Perceptron::Distance(const Perceptron& P)
{
	int Result = 0;
	for (int i = 0; i < N; i++)
		Result += abs(Weights[i] - P.Weights[i]);
	return Result;
}