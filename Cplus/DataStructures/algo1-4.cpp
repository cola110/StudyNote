#include "c1.h"

int a(int i)
{
	if (i == 1)
	{
		printf("ÍË³ö³ÌĞò\n");
		exit(1);
	}
	return i;
}

int _main(char *argv)
{
	int i;
	printf("ÇëÊäÈëi£º");
	scanf("%d", &i);
	printf("a(i)=%d\n", a(i));
	return 0;
}