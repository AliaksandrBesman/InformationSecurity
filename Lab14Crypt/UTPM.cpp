#pragma hdrstop
#include "UTPM.h"
#pragma package(smart_init)
int TPM::GetOutput(int** AInputs)
{
	Output = 1;
	for (int i = 0; i < K; i++)
		Output *= Perceptrons[i].GetOutput(AInputs[i]);
	return Output;
}
void TPM::Synchronize()
{
	for (int i = 0; i < K; i++)
		Perceptrons[i].AktualizeWeights(Output);
}
int TPM::Distance(const TPM& ATPM)
{
	int Result = 0;
	for (int i = 0; i < K; i++) {
		int distance = Perceptrons[i].Distance(ATPM.Perceptrons[i]);
		Result += distance;
	}

	return Result;
}