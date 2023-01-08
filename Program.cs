using System;
using System.Collections.Generic;
using RestSharp;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;

namespace csharp_test;

//deserialise the json



class Program{
 

    // a method that takes a json string as an input and returns an object belonging to the API-repsonse class that takes the json and sorts it


    static void Main(string[] args){

    Console.WriteLine("Please enter the name of the city you wish to view the weather forecast of:");
    
    try{
        string city_name = Console.ReadLine();
        Console.WriteLine("Thank you for your submission, fetching weather data!");
        string url=$"https://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={API_KEY.key}";
        
        string json_data=getweather(url);
        //var data= JsonSerializer.Deserialize<List<Repository>>(json_data);
        Console.WriteLine(json_data);
    }
    catch(NullReferenceException){
        Console.WriteLine("You did not enter anything");
    }

}

static public string getweather(string url){
    var client = new RestClient(url);
    var response = client.Execute(new RestRequest());
    if (response != null){
        var json = response.Content;
        //Api_response deserialised_json = DeserializeJson(json);
        API_Response deserialised_json = JsonConvert.DeserializeObject<API_Response>(json);
        return deserialised_json.coordinates;
    }
    else{
        string message= "No data returned by the Api, make sure that you have an internet connection and that you have entered the city name correctly";
        return message;
    }

}

    private static JsonSerializerOptions? JsonSerializerOptions()
    {
        throw new NotImplementedException();
    }
}