# Idea:
A way to dynamically run code snippets at any order at runtime.

# Code formatting overview:
- First two and last two digits are the identifier.
- Middle chunk is parameter.
- Codes are separated with a `.`

# Current modules:
- (00) For: The start of a for loop. Its paramaters is one number, saying how many times to loop. It is nestable.
- (01) ForEnd: The end of a for loop.
- (02) DebugLog: Logs any passed parameter. You must use "quotes" in your parameter if you want to include a period "." character. The quotes will be removed from the output. It just writes on one line.

# Example:
- `.00300.02Hello World02.01001` Prints out Hello World 3 times.
- `.00300.00300.02Hello World02.01001.01001` Prints out Hello World 9 times.
- `.00300.02".00300.02Hello World02.01001"02.01001` Prints out the code `.00300.02Hello World02.01001` three times.

# Guide video:
![](./Guide%20Video.mp4)