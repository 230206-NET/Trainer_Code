// Inheritance in JS is through prototypal inheritance.
// MDN Doc: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Inheritance_and_the_prototype_chain
const obj = {
    a: 1,
    b: 2,
    foo() {
        console.log('bar')
    },
    __proto__ : {
        b: 3,
        c: 5
    }
};

// console.log(obj.a, obj.b ,obj.c, obj.d);

// Want to inherit some methods/properties? Set that as your prototype!
// const animal = {
//     species: 'animal',
//     getSpecies() {
//         return this.species;
//     }
// }

// const cat = {
//     species: 'feline'
// }

// cat.__proto__ = animal;
// console.log(cat.species);
// console.log(cat.getSpecies());

// // Now, the more familiar OOP Syntax
// // ES6 introduced Class syntax in js that is more familiar with oop programmers. However, it doesn't introduce any new feature, it is simply a reworking of prototypal inheritance.
// MDN Doc: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes

// class Animal {
//     species;
    
//     constructor(species = 'animal') {
//         this.species = species;
//     }
//     getSpecies() {
//         return this.species;
//     }
// }

// Classes are special functions in JS
// a class can have the following members: Constructor, getter, setter, fields, methods
class Animal {
    // Fields
    species = 'animal';
    // Private field
    #privateInfo = 'i am private';
    // Can't overload constructor
    constructor(species = 'animal') {
        this.species = species;
    }

    // Method
    move() {
        console.log('animal moves');
        console.log(this.#privateInfo);
    }
}

// mammal = new Animal();

// console.log(mammal.species);
// mammal.move();
// console.log(mammal.#privateInfo);

class Cat extends Animal {
    coatLength;
    #_name;
    constructor(species = 'feline', coatLength) {
        super(species);
        this.coatLength = coatLength;
    }
    get name() { return this.#_name }
    set name(value) {this.#_name = value;}
    move() {
        super.move();
        console.log(`this ${this.species} slinks`)
    }
}

const auryn = new Cat();
auryn.name = 'aurynie';
console.log(auryn.name);
auryn.move();