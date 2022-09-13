#ifndef UTPMH
#define UTPMH
#include "UPerceptron.h"

const int K = 5; //���������� ������������
const int L = 5; //������������ ���?
const int N = 7; //���������� �������
class TPM
{
	Perceptron* Perceptrons; // ��������� �� ������ ������������
	int Output; //����� ����
public:
	int GetOutput(int** AInputs); //����� k-�� ����������� n-�� ������
	void Synchronize(); //������������� ������������
	int Distance(const TPM& ATPM); //����������
	void ModifyOutput(int AOutput) { Output = AOutput; }; //��������� ������
	void SetPerceptrons(Perceptron* pers) { Perceptrons = pers; }; // ��������� ������� �� �����������

	void PrintWeighs() { //����� ����� ������� �����������
		for (int i = 0; i < K; i++) {
			Perceptrons[i].PrintWeights(i);
		}
	};
};
#endif