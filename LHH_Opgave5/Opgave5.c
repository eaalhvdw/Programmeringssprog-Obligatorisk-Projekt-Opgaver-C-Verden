﻿#include <stdio.h>

void main() {    

    int number1, number2, sum;
    
    printf("\nEnter two integers: ");
    scanf("%d %d", &number1, &number2);

    sum = number1 + number2;      
    
    printf("%d + %d = %d\n", number1, number2, sum);
}