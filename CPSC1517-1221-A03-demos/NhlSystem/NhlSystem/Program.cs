/* Test Plan for Person
 * 
 * Test Case                    Test Data                   Expected Result
 * ---------                    ---------                   ---------------
 * Valid Fullname               FullName: Connor McDavid    FullName = Connor McDavid
 *  
 * Null Fullname                Fullname: null              ArgumentNullException
 * 
 * Empty Fullname               FullName: ""                ArgumentNullException
 * 
 * Whitespace Fullname          FullName: "  "              ArgumentNullException
 * 
 * Full Less than 3 characters  FullName: AB                ArgumentException
 * 
 */

//Test Case 1: Valid FullName
using NhlSystem;

var validPerson = new Person("Connor McDavid");

Console.WriteLine(validPerson.FullName); //the value should be Connor McDavid

//Test Case 2: Null FullName
try
{
	var nullPerson = new Person(null);
	Console.WriteLine(nullPerson.FullName);
}
catch (ArgumentNullException ex)
{
	Console.WriteLine(ex.ParamName); //output should be "Full Name cannot be left empty"
}

//Test Case 3: Empty FullName
try
{
    var emptyPerson = new Person("");
    Console.WriteLine(emptyPerson.FullName);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); //output should be "Full Name cannot be left empty"
}

//Test Case 4: Whitespace Name
try
{
    var whiteSpacePerson = new Person("     ");
    Console.WriteLine(whiteSpacePerson.FullName);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); //output should be "Full Name cannot be left empty"
}

//Test Case 5: Short name
try
{
    var shortPerson = new Person("AB");
    Console.WriteLine(shortPerson.FullName);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}