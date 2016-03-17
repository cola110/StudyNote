// #include "c1.h"

// #include ""
// typedef int ElemType;
// #include "c1-1.h"
// #pragma once
// #include "bo1-1.cpp"

#include "c1.h"
#include "c1-1.h"
Status InitTriplet(Triplet &T, ElemType v1, ElemType v2, ElemType v3)
{
	// ������Ԫ����T
	if (!(T = (ElemType *)malloc(3 * sizeof(ElemType))))
	{
		exit(OVERFLOW);
	}

	T[0] = v1, T[1] = v2, T[2] = v3;
	return OK;
};

Status DestroyTriplet(Triplet &T)
{
	free(T);
	T = NULL;
	return OK;
}

Status Get(Triplet T, int i, ElemType &e)
{
	if (i < 1 || i>3)
	{
		return ERROR;
	}
	e = T[i - 1];
	return OK;
};

Status Put(Triplet T, int i, ElemType e)
{
	if (i < 1 || i>3)
	{
		return ERROR;
	}

	T[i - 1] = e;
	return OK;
};

Status IsAscending(Triplet T)
{
	return (T[0] <= T[1] && T[1] <= T[2]);
};

Status IsDescending(Triplet T)
{
	return (T[0] >= T[1] && T[1] >= T[2]);
};

Status Max(Triplet T, ElemType &e)
{
	e = T[0] >= T[1] ? (T[0] >= T[2] ? T[0] : T[2]) : (T[1] >= T[2] ? T[1] : T[2]);
	return OK;
};

Status Min(Triplet T, ElemType &e)
{
	e = T[0] <= T[1] ? (T[0] <= T[2] ? T[0] : T[2]) : (T[1] <= T[2] ? T[1] : T[2]);
	return OK;
};

int main()
{
	Triplet T;
	ElemType m;
	Status i;

	i = InitTriplet(T, 5, 7, 9);

	printf("���ó�ʼ��������i=%d(1:�ɹ�) T��3��ֵΪ", i);
	std::cout << T[0] << "" << T[1] << "" << T[2] << std::endl;
	i = Get(T, 2, m);
	return 0;
}