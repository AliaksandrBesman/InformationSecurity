#ifndef UTPMH
#define UTPMH
#include "UPerceptron.h"

const int K = 5; //Количество персептронов
const int L = 5; //Максимальный вес?
const int N = 7; //Количество выходов
class TPM
{
	Perceptron* Perceptrons; // Указатель на массив персептронов
	int Output; //Выход сети
public:
	int GetOutput(int** AInputs); //Выход k-го персептрона n-го выхода
	void Synchronize(); //Синхронизация персептронов
	int Distance(const TPM& ATPM); //Расстояние
	void ModifyOutput(int AOutput) { Output = AOutput; }; //Изменение выхода
	void SetPerceptrons(Perceptron* pers) { Perceptrons = pers; }; // Установка каждого из персептрона

	void PrintWeighs() { //Вывод весов каждого персептрона
		for (int i = 0; i < K; i++) {
			Perceptrons[i].PrintWeights(i);
		}
	};
};
#endif