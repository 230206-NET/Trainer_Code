// Typescript introduces a few more features to Javascript's OOP
// TS Doc: https://www.typescriptlang.org/docs/handbook/2/classes.html

class TSAnimal {
    readonly species : string = 'animal'
    commonName : string;

    constructor(species : number) {

    }
}

interface Speakable {
    speak(): void;
}

class TSCat extends TSAnimal implements Speakable {
    speak() {
        console.log('meow');
    }
}

// Private, protected modifiers