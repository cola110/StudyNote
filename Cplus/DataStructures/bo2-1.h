#include "c1.h"
// typedef int ElemType;
#include "c2-1.h"

void InitList(SqList &L);

void DestroyList(SqList &L);

void ClearList(SqList &L);

Status ListEmpty(SqList L);

int ListLength(SqList L);

Status GetElem(SqList L, int i, ElemType &e);

int LocateElem(SqList L, ElemType e, Status(*compare)(ElemType, ElemType));

Status PriorElem(SqList L, ElemType cur_e, ElemType &pre_e);

Status NextElem(SqList L, ElemType cur_e, ElemType &next_e);

Status ListInsert(SqList &L, int i, ElemType e);

Status ListDelete(SqList &L, int i, ElemType &e);

void ListTraverse(SqList L, void(*vi)(ElemType&));