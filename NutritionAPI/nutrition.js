let resultDiv = document.getElementById("results");


const findFood = function() {
    //reset function

    let food = $("#search").val();

    $.get(
        `https://api.nal.usda.gov/fdc/v1/foods/search?api_key=SohihGmRVzAtcLPY0c3Yo2SQsWE8V2992IbSe4VT&query=${food}`,
        function(data, textStatus, jqXHR) {
            let carbs = `${data.foods[0].foodNutrients[2].value}`;
            document.getElementById("carbs").textContent = carbs;
            console.log(data); 
            console.log(carbs); 
            
    }
    );
    

}