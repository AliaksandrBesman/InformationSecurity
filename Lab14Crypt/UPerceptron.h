#ifndef UPerceptronH
#define UPerceptronH
#include <stdlib.h>
#include <iostream>
class Perceptron
{
	int* Weights; //������ �����
	int* Inputs; //������ �����������
	int Output; //����
	void RandomWeights(); //��������� �����
public:
	Perceptron(); //�����������
	~Perceptron(); //����������
	int GetOutput(int* AInputs); //�������� �����
	void AktualizeWeights(int OutputTPM); //�������� �����
	int Distance(const Perceptron& p); //������� ����� ����� �������������

	void PrintWeights(int position) { //����� ����� �������� �����������
		std::cout << "Weights of " << position << " perceptron :";
		for (int i = 0; i < 7; i++) {
			std::cout << Weights[i] << " ";
		}

		std::cout << std::endl;
	}
};
#endif