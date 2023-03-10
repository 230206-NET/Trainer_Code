let foo : string = 'bar';

foo = 'foo';

foo = 'another string';

let bar : number = 2;

// bar = 'string'; //tsc will complain, but will still transpile

console.log('hello world!')

let arr : Array<number> = [1, 2, 3];

let stringArr : string[] = ['one', 'two', 'three'];

let objArr : {}[] = [{one: 'two'}];

function voidFn() : void {

}

function returnStr() : string | null {
    return 'string';
}

let numOrString : number | string = 9;
numOrString = 'string';

interface Cat {
    name : string,
    doB : Date | string,
    hobbies? : string[],
    color : string
}

let auryn : Cat = {
    name : 'auryn',
    doB: new Date('3-12-2012'),
    // hobbies: ['napping', 'eating', 'being an alarm clock'],
    color : 'gray'
}

function printCat(catObj : Cat) : string {
    return `This cat's name is ${catObj.name}, s/he was born on ${catObj.doB}, and their color is ${catObj.color}`;
}

console.log(printCat({name : 'juniper', doB: new Date(), color: 'tan'}));

const table : HTMLTableElement = <HTMLTableElement> document.getElementById('table');
const tHead : HTMLTableSectionElement = table.createTHead();
const headCell :HTMLTableCellElement =tHead.insertRow().insertCell(0)
headCell.textContent = 'header'
const tBody : HTMLTableSectionElement = table.createTBody()
const tr : HTMLTableRowElement =  tBody.insertRow(0);
const cell : HTMLTableCellElement = tr.insertCell(0);
cell.textContent = 'test'

// const table : HTMLTableElement = document.getElementById('table') as HTMLTableElement;

// When you're ready throw in the towel and call ts a goodbye, any keyword lets you fall back to writing js
let foobar : any = '3';
foobar = 3
foobar = {}
foobar = []
foobar = {3: 10, 2: 'a'}