# keypadGenerator
Generate correct message from Old Button Phone Keypad Inputs.

## Problem Statement

Here is an old phone keypad with alphabetical letters, a
backspace key, and a send button.

Each button has a number to identify it and pressing a button
multiple times will cycle through the letters on it allowing
each button to represent more than one letter.

For example, pressing 2 once will return ‘A’ but pressing twice in succession will return
‘B’.

You must pause for a second in order to type two characters from the same
button after each other: “222 2 22” -> “CAB”.

Create an application that reads any keypad input and converts it to the correct message.

## Algorithm

 According to the problem statement, we are considering the following keys of the phone keypad
 for extracting the message.

 0-9: These keys will map to the alphabetical letters of the message.
 * : This key will map to the backspace key.
 # : This key will map to the send button.

 Here is the algorithm to follow in order to generate the correct output message:

 1. Create and store a mapping data structure that maps the keys to the correct alphabetical letters.
    For example, 2 should map to: A, B, C. So, a map structure can be maintained like, 2: [A, B, C].

 2. Iterate over the input string. Use 2 variables to keep track of the current key and the number 
    of times same key has been pressed repeatedly (current, currentKeyCounter).

 3. If the current key is not equal to the previous key, add the character mapped to the previous
    key, to the output string. In order to find the mapped character, utilize the 2 variables in
    Step 2. For example, if current = '2' and currentKeyCounter = 1, this maps to the character 'B'.

 5. If the current key is equal to the previous key, increment the currentKeyCounter.

 6. Whenever a '*' is encountered, delete the last character from the output string and reset the
    values of current and currentKeyCounter variable.

7. When a '#' is encountered, it signifies end of the string, so set the last character of the
   string and terminate the iteration.

8. Return the output string. 
