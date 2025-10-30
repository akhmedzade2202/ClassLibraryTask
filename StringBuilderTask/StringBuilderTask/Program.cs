using StringBuilderTask;
int x = 7;
Console.WriteLine($"{x} tekdirmi? => {x.IsOdd()}");
Console.WriteLine($"{x} cutdurnu? => {x.IsEven()}");

string word = "Hello123";
word.HasDigit();

string password = "Code123A";
Console.WriteLine($"Sufre duzgundumu? => {password.CheckPassword()}");

string name = "emRaH";
name = name.Capitalize();


string text = "HelloWorld";
Console.WriteLine($"CustomSubstring(5): {text.CustomSubstring(5)}");
Console.WriteLine($"CustomSubstring(0, 5): {text.CustomSubstring(0, 5)}");
Console.WriteLine($"CustomContains('loWo'): {text.CustomContains("loWo")}");