// Typescript introduces a few more features to Javascript's OOP

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