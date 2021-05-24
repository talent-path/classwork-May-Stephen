

const getWeather = function() {
    // this can retrieve value from the input field with the id = "zip"
    const zipcode = $("#zip").val()

    //$ calls to JQuery
    // All the info for this can be found on api.jquery.com
    $.get(
        `http://api.openweathermap.org/data/2.5/weather?zip=${zipcode},US&appid=21f06024ceaed14fe53c62b5c48d0999&units=imperial`,
        function(data, textStatus, jqXHR) {
            //getter for the city name
            $("#reportHeader").text(`Weather Report for ${data.name}` );
            $("#weatherDesc").text(data.weather[0].description);
            
            let imageUrl = `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`;
            $("#weatherIcon").attr("src", imageUrl);

            $("#currentTemp").text(`${data.main.temp} degrees`);
            
            console.log(data);
            console.log(textStatus);
            console.log(jqXHR);
        }
    );
}