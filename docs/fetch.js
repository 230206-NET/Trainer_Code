import { getCatPic } from "./catPicAPI.js";

fetch('https://uselessfacts.jsph.pl/api/v2/facts/random').then((res) => res.json()).then(data => {
    const randomFactDiv = document.getElementById('random-fact-container');
    
    const factText = document.createElement('p');
    factText.innerText = data.text;

    const linkToSource = document.createElement('a');
    linkToSource.innerText = 'link to source';
    linkToSource.href = data.source_url;

    randomFactDiv.appendChild(factText);
    randomFactDiv.appendChild(linkToSource);
});

window.getCatPic = getCatPic;