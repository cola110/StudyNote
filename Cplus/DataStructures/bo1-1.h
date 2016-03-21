#include "c1.h"
typedef int ElemType;
#include "c1-1.h"

Status InitTriplet(Triplet &T, ElemType v1, ElemType v2, ElemType v3);

Status DestroyTriplet(Triplet &T);

Status Get(Triplet T, int i, ElemType &e);

Status Put(Triplet T, int i, ElemType e);

Status IsAscending(Triplet T);

Status IsDescending(Triplet T);

Status Max(Triplet T, ElemType &e);

Status Min(Triplet T, ElemType &e);