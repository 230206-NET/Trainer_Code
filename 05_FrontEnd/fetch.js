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
// In Fetch API, they use Promise to handle asynchronous operations, this is akin to Task in C#
// let catPicId = ''
function getCatPic() {
    fetch('https://api.thecatapi.com/v1/images/search').then((res) => res.json()).then(data => {
        const catpicDiv = document.querySelector('#cat-pic-container');
    
        const imgTag = document.getElementById('cat-image');

        if(!imgTag) {
            const catImg = document.createElement('img');
            catImg.id = 'cat-image'
            catImg.className = 'image-container'
            catImg.src = data[0].url;
            catpicDiv.appendChild(catImg);
            
            const upButton = document.createElement('button');
            upButton.id = 'up-vote'
            upButton.innerText = 'Up Vote'
            upButton.onclick = function(e) {
                return sendVotes(data[0].id, 1);
            }
            catpicDiv.appendChild(upButton)

            const downButton = document.createElement('button');
            downButton.innerText = 'Down Vote'
            downButton.id = 'down-vote'
            downButton.onclick = (e) => sendVotes(data[0].id, -1);
            catpicDiv.appendChild(downButton)
        }
        else {
            imgTag.src = data[0].url;
            document.getElementById('up-vote').onclick = (e) => sendVotes(data[0].id, 1)
            document.getElementById('down-vote').onclick = (e) => sendVotes(data[0].id, -1)
        }
    })
}

function sendVotes(imgId, voteValue) {
    if(!imgId) return;
    // make a post call with the vote value
    const apiKey = '633db2f9-8706-4329-bcb4-352e765361b4'
    const reqBody = {
        image_id : imgId,
        value : voteValue
    }
    console.log(reqBody);
    // fetch('https://api.thecatapi.com/v1/votes', {
    //     method: "POST",
    //     headers: {
    //         "Content-Type": "application/json",
    //         'x-api-key': apiKey
    //     },
    //     body: JSON.stringify(reqBody)
    // }).then((res) => res.json()).then(data => console.log(data))
}