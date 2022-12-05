# The Ballscript Editor | An Interactive Esoteric Programming Language

The Ballscript Editor is a Turing Complete sandbox environment where you can write full programs simply by placing operator objects and data types in the scene. 

Editor Demonstration on [YouTube](https://youtu.be/-0In2M8IfN8).

### Installation Instructions

The Ballscript Editor is available for Windows and Linux (64 bit x86).

Windows Instructions:
1. Go to the [releases page](https://github.com/conifer0us/ballscript/releases).
2. Download ballscript_windows.zip from the latest release.
3. Uzip the folder.
4. The Editor can be opened by running ballscript.exe

Linux Instructions:
1. Go to the [releases page](https://github.com/conifer0us/ballscript/releases).
2. Download ballscript_linux.zip from the latest release.
3. Unzip the folder.
4. In terminal, move to the unzip location and type "chmod +x ballscript.x86_64".
5. The editor can be opened by running ballscript.x86_64.

## Data Types and Variables

There are 4 Data Types, and there (currently) is only 1 Variable Type. Data Types appear as balls that store and display values of their respective types. Each data type has a specific color which its data balls and variables show. Variables (really constants, as they do not change) have the same color as their respective data type and appear as boxes that display their value.

Here are the 4 Data Types:

1. Integer: Appears as a light purple. The only data type to have both a variable and ball associated with it, the IntBall and IntVar. 
2. Float: Appears as pink. Can store floating point values. 
3. Boolean: Appears yellow. Can store Boolean values which are represented on the ball as T or F.
4. String: Appears blue. Can store String values.

## Language Operators

In Ballscript, language operators are represented as blocks and can be generally broken down into three categories: arithmetic, control flow, and special operators.

### Arithmetic Operators

Arithmetic Operators appear as blocks with white backgrounds that have text written on them corresponding to their operation. Remember when working with arithmetic operators that the result of the calculation that is performed on input data will be output as a data ball below the operator. When the operator outputs the ball, it sends the ball straight down away from the operator.  

Arithmetic Operators also include a type-checking system. When a data ball collides with an arithmetic operator, it will be destroyed. However, the data stored in the ball will only cause the operator to perform its action if the ball is of the correct type. For example, feeding a Boolean Ball into an addition operator will destroy the boolean ball, but it will not have any affect on the addition operator. 

#### Binary Arithmetic Operators 

There are five kinds of binary arithmetic operators: addition, subtraction, multiplication, division, and modulus. When working with these arithmetic operators, you must conisder type checking, order of operations, and unallowed inputs.

For type checking, all of these binary arithmetic operators can take in both integers and floats and can mix and match them. Putting an integer and a float ball into an addition operator will cause it to perform addition on the two numbers. The output data ball can be either a float or an integer depending on which is simpler. In other words, feeding 3.5 and 3.5 into an addition operator will output a 7 integer ball below the operator. The block recognized that the result of the operation could be represented as an integer and so output an integer ball.

For order of operations, consider the subtraction operator. If integer ball A is fed into the operator followed by integer ball B, the output will be an integer ball with value (A-B). In other words, the operator remembers which data value was input first and will use that as the first number when the operation is performed. Operators like subtraction, therefore, must be used carefully because putting the inputs in in the wrong order will cause the expected output to be negated.

There are also unallowed inputs. Specifically, putting a 0 ball into a division or modulus operator as the second operator, the 0 ball will be destroyed but nothing will be output. This is an unallowed input since the division and modulus operators are programmed to recognize 0 as an improper second input. 

#### The Unary Boolean Arithmetic Operator

There is one unary arithmetic operator included in the Ballscript Editor. This is the Boolean NOT operation. It only accepts Boolean data balls and will output the other Boolean value as a data ball below the operator. 

### Condition-Checking and Control Flow Operators

There are 2 Condition-Checking Operators and 4 Control Flow Operators.

#### Condition-Checking Operators
Condition-Checking operators output boolean values depending on certain conditions of other values. They appear as white boxes with small descriptions of the conditions they check written in text on the front. Like the arithmetic operators, they take in a value of a certain type on top and output a value of a certain type on the bottom.
 
 1. The =0 Operator: Takes in an integer or a float value. It outputs a True Boolean ball if the number input is equal to 0. If not, it outputs a False Boolean ball.
 2. The <0 Operator: Takes in an integer or a float value. It outputs a True Boolean ball if the number input is less than 0. If not, it outputs a False Boolean ball.

#### Control Flow Operators
Control Flow Operators take in values of any kind and perform actions on them according to the rules of an operator. These four operators all appear as boxes with certain types of arrows on them. With the exception of the Conditional Operator, all have a white background. These are the 4 types of control flow operators:

1. Redirect Blocks: These operators have an arrow pointing in one direction. When a data ball of any kind hits this block, the ball will be placed on the side of the block that the arrow is pointing to. In addition, the ball will begin moving in that direction. 

2. Splitter Blocks: These operators have a double-sided arrow pointing either left-right or up-down. When a ball hits this block from any direction, the initial ball is destroyed. Then, the block clones the input ball and places the two copies on each side of the arrow. The two copies are sent flying away from the block. 

3. Teleporter Blocks: These blocks have two parts: an origin and a destination. The origin looks like an underlined triangle, and the destination looks like a redirect block. When a ball of any kind hits the origin, it is placed at the location of the destination. Crucially, the destination is a fully functional redirect block. When the ball from the origin is placed at the destination, it is redirected according to the rules of the redirect block at the destination. This means that a teleport block has the potential to place a ball at any point in the editor moving in any direction.

4. Conditional Blocks: These blocks are perhaps the most important control flow blocks. They store a Boolean value and redirect data balls according to that value. When a conditional block is green, it currently stores the true value. If it is red, it stores a false value. The false version of the conditional block points in the opposite direction as compared to the true version. In other words, the conditional block functions like a redirect block where it can change to the opposite direction when its boolean value is changed. When a True or False ball goes into the conditional block, the value stored in that ball is taken on by the conditional block. So, if the block is pointed in the red direction when it is hit by a True ball, the block will flip to point in the opposite, green direction. 

### Special Operators

There are 3 Special Operators that interact with special features of the editor: the stack and standard output. When the editor is first opened, the first thing that is seen is the garbage-collecting infinite black rectangle that stretches in both directions. Under this on the left of the screen, there is the ball stack. This acts like a normal memory stack, with a push operation that puts a ball at the end of the stack and a pop operation that returns the ball most recently added to the stack. In addition to the stack, there is an output feature. Locked to the bottom left of the screen is an output box. With these features of the editor in mind, here are the 3 Ballscript Special Operators:

1. The Push Operator appears as a white box with PUSH written on it. This operator places any input data ball at the left-hand end of the stack. The ball is removed from the main space of the editor. 
2. The Pop Operator appears as a white box with POP written on it. This operator takes in any data ball, destroys that data ball, and returns the most recent item from the stack out of the bottom.
3. The Output Operator appears as a light purple box with OUT written on it. When a ball goes into an output operator, a string representation of the ball's data is placed in the output box on a new line.

## Editor Usage

### System Expectations and General Use

When you open the editor, it is expected that you will be working with a mouse and keyboard. A track pad works but does not feel as nice to use. To move around the scene, the editor can be right-clicked and dragged. To zoom in or out on the editor, the mouse scrollwheel can be used. Notice that your "Placement Mode" is initialized to "None." This means that you can only move around the scene. Your left click therefore will do nothing. The action of left clicking is changed with your placement mode. When you select the "Delete" mode, for example, your left click will delete any selected object from the scene.

### Object Placement

The rest of the Placement Modes correspond to the objects just discussed. You can additionally customize your placement by following menus that appear in the top right of the screen. When data elements (data balls or variable blocks) are selected, a menu will appear in the top right to enter the value of that data. When you are placing down a Boolean Ball, for example, you can enter "T" into the box in the top right, and the balls placed will carry the True value. When placing control flow blocks, you will be able to specify a direction. For redirect, the direction is self-explanatory. For teleportation, the direction is the direction of the destination redirect block. For conditionals, the direction is the True direction. For splitter blocks, up and down do the same thing, placing a vertical splitter. Likewise, right and left do the same thing.

These menu options do not apply equally to every operator. Operators like arithmetic operators do not have any customization options. They are simply placed in the scene. Teleportation operators must be placed by two clicks, one to place the source and another to place the destination. The direction only matters for the destination redirect block. 

When placing operators, they are locked to a grid and cannot collide with one another. When placing data balls, they are not confined to the grid, but they are placed on and move in the grid when they are output from an operator. 

### The Three Editor-Controlling Buttons

There are three buttons at the bottom right of the editor that can be used to control the editor.

1. Reset: This button removes all data balls from the scene (including in the stack) and resets every conditional block to true.
2. Remove Balls: This button removes all data balls from the scene.
3. Remove All: This button removes everything, all operators and balls from the scene.

## A Note About Bugs and Bad Quality of Life Features

There are still a few issues in this program. One, removing all balls from the scene or deleting balls in the stack does not yet register with the stack API that I have implemented. If your program is entirely self-contained and places all of its own objects in the stack, there will be no issue with this other than a visual bug where the first element in the stack will be placed slightly to the left of the edge of the stack. This is not much of an issue, but it can be encountered.

In addition, there is still a lof of functionality with the Teleporters that needs to be implemented. While they work as expected here, they are not nice to use and cannot be reliably deleted. There is no visual indication of what teleporter source is attached to what destination redirect. Deleting the source or destination of a teleporter does not remove its corresponding object from the scene.

## Project Vision

In the future, I hope to implement more advanced memory features besides a stack that involve direct memory indexing. In addition, I would like for users to be able to program custom-designed functions that can be executed in a visual call-stack.

There are also a ton of settings and quality of life changes that need to be made. The addition of new operators to control strings is a must. More condition checking blocks would be very helpful too. Once all of this is done, saving and later accessing your program is very important as well.

Once the Editor is in a good state, I would like to roll this out as some sort of game. The program would challenge users to solve increasingly complex programming challenges in the Ballscript Editor and, using a new standard input system, be able to dynamically check output to see if the program is successful or not.

Then, I would like to integrate this with my own text based language. When a user writes a Ballscript program in their favorite text editor, it will compile to a scene that can be opened and viewed in action in the editor. Once this is done, Ballscript will be a great learning tool that allows people to visualize their programs as they transfer data between functions in real time.
