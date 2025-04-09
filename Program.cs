//Author:   Nazifa Nazrul Rodoshi
//Date:     2023.05.20.
//Title:    hydrological cycle of the Earth

using System;
using System.Globalization;
using TextFile;

namespace Nazifa_Assignement_2
{
    class Program
    {
        static void Main()
        {
            
            bool isFileExist = false;
            do
            {
                try
                {
                    Console.Write("Enter file's name: ");
                    string filename = Console.ReadLine();
                    TextFileReader reader = new(filename);

                    reader.ReadLine(out string line);
                    int n = int.Parse(line);

                    List<Area> areas = new();

                    for (int i = 0; i < n; ++i)
                    {
                        char[] separators = new char[] { ' ', '\t' };
                        if (reader.ReadLine(out line))
                        {
                            string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                            string owner = tokens[0] + " " + tokens[1];
                            char type = char.Parse(tokens[2]);
                            int water = int.Parse(tokens[3]);

                            switch (type)
                            {
                                case 'P':
                                    areas.Add(new Plain(owner, type, water));
                                    break;
                                case 'G':
                                    areas.Add(new Grassland(owner, type, water));
                                    break;
                                case 'L':
                                    areas.Add(new LakesRegion(owner, type, water));
                                    break;
                            }
                        }
                    }

                    reader.ReadLine(out line);
                    int humidity = int.Parse(line);
                    int round = 1;

                    while (!Area.IsAllTypeSame(areas))
                    {
                        Area.Simulate(ref humidity, ref areas);
                        Console.WriteLine("Round " + round++);
                        foreach (var area in areas)
                        {
                            Console.WriteLine($"{area.Owner} {area.Type} {area.WaterAmount}");
                        }
                        Console.WriteLine(humidity + "\n");

                    }
                    Console.WriteLine("Simulation is finished!");

                    isFileExist = true;
                }
                catch(FileNotFoundException){
                    Console.WriteLine("The file doesn't exist!\n");
                }

            } while (!isFileExist);
        }
    }
}
