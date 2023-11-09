using Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PathA
{
    public class Challenge3
    {
        public async void Run(HackTheFutureClient hackTheFutureClient)
        {
            //Get json
            Console.WriteLine("Challenge A3:");
            await hackTheFutureClient.GetAsync("api/path/a/hard/start");
            var response = await hackTheFutureClient.GetAsync("api/path/a/hard/sample");
            var contents = await response.Content.ReadAsStringAsync();

            //Deserialize json
            List<Animal> animals = JsonConvert.DeserializeObject<List<Animal>>(contents);

            List<Animal> sortedAnimals = new List<Animal>();

            sortedAnimals.Add(animals.First());
            animals.Remove(animals.First());

            while (animals.Count > 0)
            {
                if (checkMatch(animals.First(), sortedAnimals.First())){
                    sortedAnimals.Insert(0,animals.First());
                    animals.Remove(animals.First());
                } else
                {
                    sortedAnimals.Add(animals.First());
                    animals.Remove(animals.First());
                }
            }

            foreach (var animal in sortedAnimals)
            {
                Console.WriteLine(animal.Name);
                Console.WriteLine(animal.WeightInGrams);
                Console.WriteLine(animal.HeightInCm);
                Console.WriteLine(animal.AgeInDays);
                Console.WriteLine(animal.Species);
                Console.WriteLine("------");
            }                    
        }


        public bool checkMatch(Animal firstAnimal, Animal secondAnimal)
        {
                    if (firstAnimal.Name == secondAnimal.Name)
                    {
                        return true;
                    }
                    else if (firstAnimal.WeightInGrams == secondAnimal.WeightInGrams)
                    {
                        return true;
                    }
                    else if (firstAnimal.Species == secondAnimal.Species)
                    {
                        return true;
                    }
                    else if (firstAnimal.HeightInCm == secondAnimal.HeightInCm)
                    {
                        return true;
                    }
                    else if (firstAnimal.AgeInDays == secondAnimal.AgeInDays)
                    {
                        return true;
                    }
            return false;
            }       
        }
    }