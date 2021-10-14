C# S-Exression Calculator

The goal was to write an integer calculator that supports the add and multiply functions. 
The program should take an expression string as a command line argument and print out the result of evaluating the expression.

For example:
(add 471 21)

(add (multiply 2 1) 5)

FUNCTIONS

Add
The add function should accept exactly 2 sub-expressions, evaluate them and return the result of the addition

(add 1 3)
4

(add 0 (add 3 2))
6

(add 3 (add (add 4 2) 5))
14

Multiply:
The multiply function should accept exactly 2 sub-expressions , evaluate them and return the result of the multiplication

For example:
(multiply 3 2)
6

(multiply 0 (multiply 3 2))
0

(multiply 2 (multiply 3 4))
24

(multiply 5 (multiply (multiply 2 1) 2))
20
