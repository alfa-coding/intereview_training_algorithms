```
// Your first Lox program!
print "Hello, world!";
```

```
true;  // Not false.
false; // Not *not* false.
```

```
1234;  // An integer.
12.34; // A decimal number.
```

```
"I am a string";
"";    // The empty string.
"123"; // This is a string, not a number.
```

```
add + me;
subtract - me;
multiply * me;
divide / me;
```

```
-negateMe;
```

```
less < than;
lessThan <= orEqual;
greater > than;
greaterThan >= orEqual;
```

```
1 == 2;         // false.
"cat" != "dog"; // true.
```

```
314 == "pi"; // false.
```

```
123 == "123"; // false.
```

```
!true;  // false.
!false; // true.

true and false; // false.
true and true;  // true.

false or false; // false.
true or false;  // true.
```


```
//Precedence and grouping
var average = (min + max) / 2;
```


```
//this is a statement
print "Hello, world!";
```


```
//this is a block
{
  print "One statement.";
  print "Two statements.";
}
```

```
//these are variables. The null value is assinged by default as (nil)
var imAVariable = "here is my value";
var iAmNil;
var breakfast = "bagels";x

//once assigned, you can do
print breakfast; // "bagels".
breakfast = "beignets";
print breakfast; // "beignets".
```


```
//conditionals
if (condition) {
  print "yes";
} else {
  print "no";
}

```

```
//a while loop

var a = 1;
while (a < 10) {
  print a;
  a = a + 1;
}
```

```
//A for loop

for (var a = 1; a < 10; a = a + 1) {
  print a;
}
```

```
//function declarations and function calls
fun printSum(a, b) {
  print a + b;
}

makeBreakfast(bacon, eggs, toast);
```

```
//closures
fun addPair(a, b) {
  return a + b;
}

fun identity(a) {
  return a;
}

print identity(addPair)(1, 2); // Prints "3".
```

```
//sub functions or local functions

fun outerFunction() {
  fun localFunction() {
    print "I'm local!";
  }

  localFunction();
}
```


```
//classes

class Breakfast {
  cook() {
    print "Eggs a-fryin'!";
  }

  serve(who) {
    print "Enjoy your breakfast, " + who + ".";
  }
}
```


```
//CLASSES, as functions are 1st class citizens

// Store it in variables.
var someVariable = Breakfast;

// Pass it to functions.
someFunction(Breakfast);


// creating an instance
var breakfast = Breakfast();
print breakfast; // "Breakfast instance being printed".
```


```
//classes can have a constructors
//which initialize fields
class Breakfast {
  init(meat, bread) {
    this.meat = meat;
    this.bread = bread;
  }

  //class functions can access fields, as well as their parameters  
  serve(who) {
    print "Enjoy your " + this.meat + " and " +
        this.bread + ", " + who + ".";
   }
}



var baconAndToast = Breakfast("bacon", "toast");
baconAndToast.serve("Dear Reader");
//
```

```
//Inheritance

class Brunch < Breakfast {

  init(meat, bread, drink) {
    super.init(meat, bread);
    this.drink = drink;
  }

  drink() {
    print "How about a Bloody Mary?";
  }
}

var benedict = Brunch("ham", "English muffin");
benedict.serve("Noble Reader");
```