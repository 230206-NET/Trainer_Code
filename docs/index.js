const btnClickHandler = function(e) {
    console.log(e);
}
// const domPracticeDiv = document.getElementById('dom-manipulation-practice');

const domPracticeDiv = document.querySelector('#dom-manipulation-practice');

let counter = 0;
const counterSpan = document.createElement('span')
counterSpan.id = 'counter-span'
counterSpan.innerText = counter;

const clickBtn = document.createElement('button');

clickBtn.innerText = "for reals click me"
clickBtn.id = 'dom-click-btn'
clickBtn.onclick = (e) => {
    counter += 1;
    console.log(counter);
    counterSpan.innerText = counter;
}

domPracticeDiv.appendChild(clickBtn);
domPracticeDiv.appendChild(counterSpan);

function callBackFn(result) {
    console.log(result);
    console.log('im handling the result of this')
}

function asyncFunction(cbFn) {
    console.log('I do some async operation, i need to be waited for the actual result to come back');
    let result = {};
    cbFn(result)
}

asyncFunction(callBackFn)

asyncFunction(function() {
    console.log('handling result')
})