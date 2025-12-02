# C# .NET Bootcamp & Advanced Concepts

This repository contains a comprehensive collection of C# code examples, exercises, and projects covering the spectrum from language basics to advanced .NET framework internals. It is designed as a practical reference for mastering C# software development, memory management, and concurrency.

## 📂 Repository Structure

The codebase is organized by concept. Below is the breakdown of the modules included:

### 1. Core Language & OOP

Foundational C# syntax and Object-Oriented Programming principles.

- **Basics:** Control flow (If/Else, Loops), Arrays (Single & Multi-dimensional), and Method Overloading.
- **Object-Oriented:** Examples of **Encapsulation**, **Inheritance**, **Abstraction**, and **Polymorphism**.
- **Classes vs. Structs:** Implementation differences, including `ref struct` and `Span<T>` usage for performance.
- **Interfaces:** Implementing contracts, multiple inheritance via interfaces, and `IEnumerator` implementation.

### 2. Advanced C# Features

Modern C# features and powerful language constructs.

- **Generics:** Creating type-safe collections and generic methods (`Gudang<T>`, `Kotak<T>`).
- **Delegates & Events:**
    - Custom delegates, `Action<T>`, `Func<T>`, and Multicast delegates.
    - Event-Driven Architecture examples (Publisher-Subscriber pattern) applied to an E-Commerce system.
- **Enumerations:** Usage of `[Flags]` attributes for bitwise operations.
- **Nullable Types:** Handling null safety and value types.
- **Variable Parameters:** Deep dive into `ref`, `out`, `in`, and `params` modifiers.

### 3. Framework Fundamentals

- **String Handling:** Efficient text manipulation using `StringBuilder` vs. String concatenation.
- **Time & Date:** Working with `DateTime`, `TimeSpan`, and formatting.
- **Serialization:** JSON Serialization/Deserialization using `System.Text.Json`.
- **Assemblies:** Creating and consuming compiled `.dll` libraries.

### 4. Concurrency & Asynchrony

A detailed look at writing multi-threaded and asynchronous applications.

- **Async/Await:** Writing non-blocking code using the Task-based Asynchronous Pattern (TAP).
- **Threading:** Managing thread lifecycles, background vs. foreground threads, and locking mechanisms.
- **Tasks:** Error handling in Tasks, `TaskCompletionSource`, and `Task.Run`.
- **IO vs Compute Bound:** Performance comparisons between blocking and spinning approaches.

### 5. Memory Management & Garbage Collection (GC)

Advanced examples demonstrating how .NET manages memory.

- **IDisposable:** Implementing the `Dispose` pattern for resource cleanup.
- **GC Internals:** Triggering generations (Gen0, Gen1, Gen2) and handling `GC.AddMemoryPressure`.
- **Memory Leaks:** Simulating and fixing managed memory leaks (e.g., event subscription leaks).
- **Weak References:** caching strategies using `WeakReference` to prevent memory overflows.

### 6. Diagnostics & Testing

- **Unit Testing:** NUnit test cases, `[TestCaseSource]`, and assertions.
- **Diagnostics:** Using `Debug`, `Trace`, and Conditional Compilation (`#if DEBUG`).

## 🚀 Key Projects

### 🀄 Domino Game Project (`IndProjDomino`)

A simulation of a Domino game architecture.

- **Architecture:** Includes classes for `Player`, `Deck`, `Table` (Meja), and `Rules`.
- **Visuals:** Includes logic diagrams (`.excalidraw` and `.svg`) explaining the game flow and object interaction.

### 🧮 Calculator & Logic Exercises

- **LogicExercise:** Custom algorithmic challenges (Rule-based output generation).
- **MathElementary:** A class library with accompanying Unit Tests.

## 🛠️ Getting Started

To run any of the console applications in this repository:

1. **Prerequisites:** Ensure you have the [.NET SDK 8.0 or 9.0](https://dotnet.microsoft.com/download) installed.
2. **Navigate:** Go to the specific project folder (e.g., `ConcurrencyAsynchrony/Async`).
3. **Run:**
    
```bash
dotnet run
```
    
4. **Test:** To run the unit tests:
    
```bash
cd UnitTesting/MathElementary.Test
dotnet test
```
    

## 📝 Configuration

The projects are configured using `.csproj` files targeting `net8.0` or `net9.0`. Example configuration:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework> <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
```

---

*Created as part of the C# .NET Bootcamp Formulatrix Curriculum.*
