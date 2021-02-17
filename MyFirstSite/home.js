let count = 0;
let board = ['0', '0', '0', '0', '0', '0', '0', '0', '0'];
function placeMarker(buttonId) 
{
 if (count % 2 == 0)
 {
 document.getElementById("button" + buttonId).style.background 
 = "url('https://www.clipartmax.com/png/middle/134-1340885_swarm-bee-x-delete-comments-tic-tac-toe-cross.png')";
 document.getElementById("button" + buttonId).style.backgroundSize = 'cover';
 document.getElementById("button" + buttonId).style.alignContent = 'center';
 buttonId
 }
 else
 {
 document.getElementById("button" + buttonId).style.background 
 = "url('https://www.clipartmax.com/png/middle/440-4408148_transparent-o-tic-tac-toe-o.png')";
 document.getElementById("button" + buttonId).style.backgroundSize = 'cover';
 document.getElementById("button" + buttonId).style.alignContent = 'center';
 }
 count++;
 console.log(buttonId);
 let toDisable = document.getElementById('button' + buttonId);
 toDisable.disabled = true;
}
 
function checkWinner(buttonId)
{
 
}