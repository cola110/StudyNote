#include <stdio.h>
void fa(int a)
{
	a++;
	printf("fa中：a=%d\n", a);
}

void fb(int &a)
{
	a++;
	printf("fb中：a=%d\n", a);
}

int _main(char **argc)
{
	int n = 1;
	printf("main中：fa之前：n=%d\n", n);
	fa(n);
	printf("main中：fa之后：n=%d\n", n);
	fb(n);
	printf("main中：fb之后：n=%d\n", n);

	return 0;
}