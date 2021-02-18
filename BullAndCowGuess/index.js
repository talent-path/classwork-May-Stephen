let answer = 0;
let arrAnswer = [];
let arrGuess = [];



const randomNum = function() {
    let min = 1023;
    let max = 9877;
    answer =  Math.trunc(Math.random() * (max-min) + min);
    console.log(answer);
    createArray(answer);
    
}

let createArray = function(answer) {
    arrAnswer = Array.from(String(answer), Number);
    console.log(arrAnswer);
    if (new Set(arrAnswer).size !== arrAnswer.length) {
        randomNum();
    }
}

randomNum();



let checkGuess = function() {
    let guess = document.getElementById("guess").value;
    arrGuess = Array.from(String(guess), Number);

    console.log(arrGuess);
    compareNum(arrGuess);

}

let compareNum = function(arrGuess) {
    for (let i = 0; i < 4; i++) {
    
            if (arrAnswer[i] === arrGuess[i]) {
                document.getElementById("box" + (i+1)).style.backgroundColor = "#00FF00";
                console.log("digit in spot " + i + " is in the right spot");
                document.getElementById("box" + (i+1)).innerText = arrGuess[i];
            }
            else if (arrAnswer.includes(arrGuess[i])) {
                document.getElementById("box" + (i+1)).style.backgroundColor = "yellow";
                console.log("digit in spot " + i + " is in the answer, but a different spot")
                document.getElementById("box" + (i+1)).innerText = arrGuess[i];
            }  
            else {
                document.getElementById("box" + (i+1)).style.backgroundColor = "red";
                document.getElementById("box" + (i+1)).innerText = arrGuess[i];
        }
    }

}