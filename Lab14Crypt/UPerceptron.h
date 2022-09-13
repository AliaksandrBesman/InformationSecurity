#ifndef UPerceptronH
#define UPerceptronH
#include <stdlib.h>
#include <iostream>
class Perceptron
{
	int* Weights; //Массив весов
	int* Inputs; //Выходы персептрона
	int Output; //Вход
	void RandomWeights(); //Генерация весов
public:
	Perceptron(); //Конструктор
	~Perceptron(); //Деструктор
	int GetOutput(int* AInputs); //Итоговый выход
	void AktualizeWeights(int OutputTPM); //Фиксация весов
	int Distance(const Perceptron& p); //Разница между двумя персептронами

	void PrintWeights(int position) { //Вывод весов текущего персептрона
		std::cout << "Weights of " << position << " perceptron :";
		for (int i = 0; i < 7; i++) {
			std::cout << Weights[i] << " ";
		}

		std::cout << std::endl;
	}
};
#endif