# C# Dependency Injection with Interfaces

## Learning Objectives
- Use interfaces to improve maintainability of an application
- Use interfaces to reduce concrete dependency of classes
- Explain that interfaces are a blueprint for concrete implementations

## Set up instructions
- Fork this repository and clone the forked version to your machine
- Open the tdd-oop-interface-dependency-injection.sln in Visual Studio.

## Introduction

Let's take a look at one of the most important aspects of object-oriented programming: *Interfaces*.

To do this, we'll go back to a previous exercise. Consider the `Scrabble` challenge. One implementation is provided below, spend some time reading through it and understanding how it works:

```c#
public class Alphabet {
        public Dictionary<Char, int> getLetterScores()
        {
            Dictionary<Char, int> words = new Dictionary<Char, int>();
            words.Add('a', 1);
            words.Add('b', 3);
            ...
            return words;
        }
}

public class Scrabble {
    Dictionary<Char, int> letterScores;

    public Scrabble() {
        Alphabet a = new Alphabet();
        this.letterScores = a.getLetterScores();
    }

    public int score(String word) {
        int total = 0;

        foreach (char ch in word.ToCharArray()) {
            if (this.letterScores.ContainsKey(ch)) {
                int score = this.letterScores[ch];
                total += score;
            }
        }

        return total;
    }
}
```

An `Alphabet` class is injected into the `Scrabble` class. The Scrabble class uses the Alphabet class to get the numeric point value for a single character. This works fine for the English alphabet, but what if we wanted our Scrabble class to go international? As it is right now, we would have to keep adding every type of letter into a single Alphabet class. That would be difficult to maintain.

Instead of injecting a concrete class, we can inject something known as an *interface*. An interface is a blueprint for classes, it's like a contract. It essentially provides a promise that the classes that implement the interface **will** contain certain methods that return specific values.

Here's a simple example using a Computer and a PowerSupply:

```c#
interface PowerSupply {
    int getWattage();
}
```

We can inject that interface into a Computer class as normal:

```c#
class Computer {
    PowerSupply psu;
    
    public Computer(PowerSupply psu) {
        this.psu = psu;
    }
    
    public String turnOn() {
        if (this.psu.getWattage() < 100) {
            return "PSU not powerful enough";
        }
        
        return "Turned on";
    }
}
```

Now we can decide exactly what type of power supply we want to inject into our computer class!

```c#
class CorsairPowerSupply implements PowerSupply {
    int getWattage() {
        return 520;
    }
}

class KnockOffPowerSupply implements PowerSupply {
    int getWattage() {
        return 32;
    }
}

class Program {
    public static void main() {
        PowerSupply psu1 = new KnockOffPowerSupply();
        Computer myFirstPc = new Computer(psu1);

        myFirstPc.turnOn(); // outputs "PSU not powerful enough"

        PowerSupply psu2 = new CorsairPowerSupply();
        Computer mySecondPc = new Computer(psu2);

        mySecondPc.turnOn(); // outputs "Turned on"
    }
}
```

What we've essentially built is one blueprint (the PowerSupply interface) that defines the methods that **will** be available on any class that implements it, and two concrete classes that implement the interface. Both have the same method signature and return type, but they return different values.

The computer class shouldn't care about the exact type of the power supply, all it should care about is that the `getWattage` method exists and returns an int.

## Exercise

It's time to revisit the scrabble challenge! There is a solution already provided in the `tdd-oop-interface-dependency-injection.CSharp.Main` directory. Right now, it has a dependency on an external class: `Alphabet`.

Your task is to improve the solution using dependency injection with an interface. This time, you'll need to modify the tests as you implement your solution. You might even need to write new tests!

## Requirements

- The scrabble class must not instantiate any other class directly
- Any class that gets injected into the scrabble class must be an interface
- The logic for the `score` method must not change
- We must be able to score words for the following languages:
  - English
  - Russian
  - Greek
- Don't worry about dealing with actual Russian & Greek words, we only care about sequences of individual lower-cased characters for the sake of this exercise
- You can find a table listing characters and scores for Russian and Greek below:
  - [Greek](./GREEK_LETTER_SCORES.md)
  - [Russian](./RUSSIAN_LETTER_SCORES.md)

