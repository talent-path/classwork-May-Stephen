
let answer = 0;

let randomNum = function() {
    let min = 1000;
    let max = 9999;
    answer =  Math.trunc(Math.random() * (max-min) + min);
    console.log(answer);

}

let createArray = function() {
   let arrAnswer = Array.from(String(answer), Number);
    console.log(arrAnswer);

}

let checkIfCorrectNum = function(guess) {
    document.getElementById(guess)

}