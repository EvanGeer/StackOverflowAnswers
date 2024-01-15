using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StackOverflowAnswers
{
    public interface I
    {
        void M(); // => Console.WriteLine("I.M");
    }

    public class C0 : I
    {
        public void M() => Console.WriteLine("C0.M");
    }

    public class C1 : I
    {
        void I.M() => Console.WriteLine("C0.M");
    }

    public class D1a : C1
    {
        public void M() => Console.WriteLine("D1a.M");
    }

    public class D1b : C1, I
    {
        public void M() => Console.WriteLine("D1b.M");
    }
}

/*
> I understand the behaviour of C0 and C1, but why does the method implementation in D1a not replace the default implementation from the interface? 

In this case what is happening is that your class `C1` is creating a somewhat hidden method `M()` by means of an explicit implementation of the interface using the default implementation. This is equivalent to the following:

``` csharp
    public class C1 : I
    {
        void I.M() => Console.WriteLine("C0.M");
    }
```

Notice if you try to call that method from C1 casted as a C1, you cannot call it: 
[![enter image description here][1]][1]

Thus, when you add a new method in the new derived class, that method is not actually implementing the interface but is truly a new method. 

> Why does adding the otherwise redundant interface declaration to D1b
> resolve the issue?

Adding the interface declaration to that class overrides the prior any explicit implementations of the interface. 

This [section of Microsoft's documentation][2] might be helpful in understanding this as well. 


  [1]: https://i.stack.imgur.com/HyaXV.png
  [2]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/default-interface-methods#concrete-methods-in-interfaces

*/