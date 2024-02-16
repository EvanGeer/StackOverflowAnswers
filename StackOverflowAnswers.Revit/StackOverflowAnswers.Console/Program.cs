// See https://aka.ms/new-console-template for more information
using StackOverflowAnswers;

Console.WriteLine("Hello, World!");

I c0 = new C0();
I c1 = new C1();
var c1_as_C1 = new C1();
I d1a = new D1a();
I d1b = new D1b();
c0.M();
c1.M();
//c1_as_C1.M(); // does not work
d1a.M();
d1b.M();