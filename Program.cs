using System;
using System.Collections.Generic;
using RestSharp;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace csharp_test;
class Program{

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
        return response.Content;
    }
    else{
        string message= "No data returned by the Api, make sure that you have an internet connection and that you have entered the city name correctly";
        return message;
    }

}
}