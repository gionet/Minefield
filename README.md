# Minefield Solver  
  
## Requirement:  
  
There is a minefield of size n x m where random fields having a bomb. The safe path always exists. There is a dog named 
Totoshka which can smell if any adjacent field has a bomb. Create an algorithm with would allow Totoshka to pass 
through the minefield. [minefield.py](#minefield.py)
  
There is a girl Ally who is following Totoshka. Ally always stand on the field where Totoshka was before. Totoshka and 
Ally cannot stand on the same field. Create and algorithm for Totoshka and Ally to pass through the minefield. [minefield_ally.py](#minefield.py)  
  
Write down the C# implementation of the previous task. [minefield.cs](#minefield.cs)  

## HOW TO:  
  
- You are only allowed to change the minefields grid that consist of '#' and 'O'.  
- You are allowed to modify, add, remove rows & columns to suit your preference.  
- You are allowed to move horizontally, vertically and diagonally. (8 directions)  
- Make sure there is a successful path from start (1st row) to end (last row).  

Example below:  

## minefield.py

Expected output (success):  
![Alt text](image.png)

Expected output (fail):  
_No safe path_  
![Alt text](image-2.png)  
  
_No entrance_  
![Alt text](image-1.png)

  
## minefield_ally.py
  
Expected output (success):  
![Alt text](image-3.png)  
  
Expected output (fail):  
_Collision_  
![Alt text](image-4.png)  

  
## minefield.cs

Expected output (success):  

![Alt text](image-5.png)  
  
Expected output (fail):  

![Alt text](image-6.png)



