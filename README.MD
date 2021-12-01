<h1>C# S-Exression Calculator</h1>

The goal was to write an integer calculator that supports the add and multiply functions. 
The program should take an expression string as a command line argument and print out the result of evaluating the expression.

For example:
(add 471 21)

(add (multiply 2 1) 5)

<h2>FUNCTIONS<h2>

  <h3>Add:</h3>
  The add function should accept exactly 2 sub-expressions, evaluate them and return the result of the addition
  
  <b>For example:<br>

  (add 1 3)
  4

  (add 0 (add 3 2))
  6

  (add 3 (add (add 4 2) 5))
  14

  <h3>Multiply:</h3>
  The multiply function should accept exactly 2 sub-expressions , evaluate them and return the result of the multiplication

  <b>For example:<br>
  
  (multiply 3 2)
  6

  (multiply 0 (multiply 3 2))
  0

  (multiply 2 (multiply 3 4))
  24

  (multiply 5 (multiply (multiply 2 1) 2))
  20
