
let resultDiv = document.getElementById("results");


let reset = function() {
    let children = resultDiv.childNodes;
    let allChildren = [...children];

    for ( let child of allChildren) {
        if(child.class === "cards") {
            child.remove();
        }
    }

}

const getByName = function() {
    reset();
    let name = $("#search").val();

    $.get(
    `https://api.pokemontcg.io/v2/cards?q=name:${name}`,
    function(data, textStatus, jqXHR) {
        let count = `${data.count}`;
        
        for( i = 0; i < count; i++) {
                $("#pokemonName").text(`${data.data[0].name}`);           
                let cardImage = document.createElement("img");
                    cardImage.id = "card" + i;
                    cardImage.class = "cards";
                    let imageUrl = `${data.data[i].images.small}`;
                    cardImage.src = imageUrl;
                    cardImage.style.margin = "17px";
                    document.getElementById("results").appendChild(cardImage);
            }
        }
    );
    i = 0;
}

const getByType = function() {
    reset();
    let type = $("#typeSelect").val();
    $.get(
        `https://api.pokemontcg.io/v2/cards?q=types:${type}`,
        function(data, textStatus, jqXHR) {
            let count = `${data.count}`;

            for( i = 0; i < count; i++) {
                let cardImage = document.createElement("img");
                    cardImage.id = "card" + i;
                    cardImage.class = "cards";
                    cardImage.style.margin = "17px";
                    let imageUrl = `${data.data[i].images.small}`;
                    cardImage.src = imageUrl;
                    document.getElementById("results").appendChild(cardImage);
            }
        }
        
    );
    
}


