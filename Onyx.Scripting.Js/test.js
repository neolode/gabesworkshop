import OnyxJS;

//available functions
//MockUp.test() -- prints a test message
//MockUp.printl(s) -- prints the variable on a line and imediatly gose to the next line
//MockUp.print(s) -- prints a variable
//MockUp.wait_key() -- vaits 4 user input

//OnyxJS
//+-Core.console
//x0.console.write(<expression>)	-- prints an expression result
//x0.console.writel(<expression>)	-- prints an expression result and imediatly goes to a new line
//x0.console.waitKey()				-- vaits 4 user input

var string="string test";
MockUp.printl(string);

MockUp.wait_key();
MockUp.test();//this procedure is located in MockUp.cs

var string=function(){return "lamda";};//
MockUp.printl(string());//inline don't work 

MockUp.wait_key();

function z(){return "ze Z";}

MockUp.printl(z());

MockUp.printl(xz());// method from included files :D

x0.console.Write('x0 is born');

MockUp.wait_key();