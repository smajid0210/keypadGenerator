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

 '0'-'9': These keys will map to the alphabetical letters of the message.
 
 '*' : This key will map to the backspace key.
 
 '#' : This key will map to the send button.

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

## Data Structures Used:

  For mapping the keys to characters, a 2d jagged array is used. The first dimension has indexes
  0 to 9 and the second dimension is variable with sizes 1,3 or 4.

  For maintaining the output string characters as we iterate over the input, a Double Ended Queue 
  is implemented. The implementation is done using LinkedList.

  Finally, for returning the result string as output, StringBuilder is used to generate the string
  from the Double Ended Queue.

## Test Cases:

  All test cases are documented in "io/input.txt" file. When the application runs, the file is scanned
  line by line. Each line corresponds to an input. The output of each line is written in "io/output.txt"
  file. 

  Multiple corner cases were represented in the test case file. These cases are listed below-

  * : Input: "8 88777444666*664#" , Output: "TURING". This covers the case where same character can come twice
      repeatedly and has to be represented with a SPACE to signify pause.

  * : Input: "77774423626606254443#" , Output: "SHADMAN MAJID". This covers the case where the SPACE key is
      properly handled and shown in the output string.

  * : Input: "444811777702226663 33#", Output: "IT'S CODE". This covers the case where the special Single Quote
     character is handled properly and shown in the output string.

  * : Input: 44433*555**#, Output: " ". This covers the case where all characters are deleted and the empty string
      is shown properly as output.

  * : Input: "44433***555#", Output: "L". This covers the case where pressing the backspace key even when there are
      no characters in the output string, does not result in an exception and deletes no unexpected characters.

  * : Input: "4444#", Output: "Invalid input: 4444#". This covers the case where an invalid input is passed and the
      exception message is displayed properly after catching the exception in runtime. 
