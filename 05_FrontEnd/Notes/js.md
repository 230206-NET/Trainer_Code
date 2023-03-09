# Javascript

Javascript to Java is Hamster is to Ham

[Brandan Eich "What is JS"](https://www.youtube.com/watch?v=ICfxulXvhsk)
Javascript is a dynamic programming language. It is interpreted by browser engines at run time (Nowadays, they do JIT compiling). This is the language of choice for browsers. Server side JS is Node.js
The js standard is known as ECMAScript (current: ES2023)
ES2015 ES6

## Javascript Types
- Dynamic, Weak Typing
- String: "double quote" or 'single quote' "this 'is still' one string"
- Undefined 
- Number 0, -1, 3.33
- Boolean
- Object {key: value}
- Null
- Symbol

- BigInt

- 'SUNBONS'

## Comparison
- == : type coerces
- === : strict comparison (compares not only the values, but also the type)

## Scopes
- global scope (in browsers, window)
- function scope
- block scope

## Different keywords to declare variables
- var : the old school way (don't use this)
    - var's minimum scope is function scope
Introduced in ES6:
- let : for storing any value that may change in the future
- const : for storing values that you don't plan on changing
- advantage of let over var is that let is block scoped

## Truthy and Falsey values
- Falsey values: FUN0NE (False, Undefined, Null, 0, NaN, EmptyString)
- 0 is falsey, anything not 0 is truthy
- "" is falsey, any non-empty string is truthy
- undefined, null are both falsey
- NaN (in fact a number type) is falsey

## DOM (Document Object Model)
Is a data structure (Tree) that represents an html page. This is how JS interacts with HTML elements. DOM is available in JS as document object

## Events
JS primarily interacts with HTML/DOM through events. Browsers keeps track of many different types of events and developers can attach their event handlers (js function made to respond to a certain event) to these events

### Event Propagation
### Bubbling and Capturing
Capturing -> Target -> Bubblign
Once the event reaches the target element, it "bubbles" up to the window. As it bubbles up, it can trigger all of its parents related event handler. When this behavior is not desired, we call event.stopPropagation() function.

## Making HTTP Calls
- XML Http Request (Part of AJAX)
- Fetch API

## JS Object vs JSON (JavaScript Object Notation)
JSON is a notation to transport data derived from JS objects.
JSON is more strict in formatting than js objects:
- the keys must be string
- strings must use double quotes
- there cannot be trailing comma (the comma at the end of the last property)

## Storage
- cookie
- Web Storage API
    - Local Storage
        - this persists through sessions
    - Session Storage
        - gets wiped when the user closes the tab

## Modules
https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Modules
https://github.com/mdn/js-examples/tree/master/module-examples/basic-modules
- `type="module"` in script tag
- specify what you want to import
- specify what you want to export 


## Inheritance
### Prototypal Inheritance
https://developer.mozilla.org/en-US/docs/Web/JavaScript/Inheritance_and_the_prototype_chain
### Classes and OOP in JS
https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes
Few differences
- Must declare all properties in constructor
- no access modifiers
- you'll most likely want to call the base class' constructor using `super` keyword 

## This keyword in JS
https://www.w3schools.com/js/js_this.asp
https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/this
The meaning of `this` changes depending on context...
you can also change the context using .call(), .apply(), .bind() methods

## Hoisting
JS keeps a lexical environment (a phone book for all variable/function names) that it creates during "compilation" stage (before it runs the code). Depending on how you declare your variable/functions, different things get hoisted.
- Function Declaration: both the function name and the definition gets hoisted (aka registered in lexical environment) which means, you can use this function before the declaration line appears
    `function iamAFunction() {}`
- var keyword: only the variable name is hoisted, the actual content is not initialized until it reaches the initialization step. If you try to use it earlier than the declaration, you will get undefined
    `var foo = 'bar';`
- let: it is still being hoisted, but the program will prevent you from using the variable before initialization step.
    `let bar = 'foo';`

- To prevent any additional headaches, declare and initialize your variables/functions before you use them.