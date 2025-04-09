namespace Nazifa_Assignement_2;
public abstract class Area
{
    public string Owner { get; set; }
    public char Type { get; set; }
    public int WaterAmount { get; set; }
    public Area(string owner, char type, int waterAmount)
    {
        Owner = owner;
        Type = type;
        WaterAmount = waterAmount;
    }
    public abstract Area ChangeWeather(IWeather weather);
    private static void ChangeHumidity(ref int humidity, Area area)
    {
        switch(area.Type){
            case 'P': humidity += 5; break;
            case 'G': humidity += 10; break;
            case 'L': humidity += 15; break;
        }
    }
    public static void Simulate(ref int humidity, ref List<Area> areas)
    {
        
        for(int i = 0; i < areas.Count; i++)
        {
            IWeather weather;
            if (humidity > 70)
            {
                weather = Rainy.Instance;
                humidity = 30;
            }
            else if (humidity < 40)
            {
                weather = Sunny.Instance;
            }
            else
            {
                double chanceOfRan = (humidity - 30) * 3.3;
                if (chanceOfRan > 70)
                {
                    weather = Rainy.Instance;
                }
                else
                {
                    weather = Cloudy.Instance;
                }
            }
            ChangeHumidity(ref humidity, areas[i]);
            areas[i] = areas[i].ChangeWeather(weather);           
        }         
    }
    
    public static bool IsAllTypeSame(List<Area> areas)
    {
        char firstType = areas[0].Type;
        for (int i = 1; i < areas.Count; i++)
        {
            if (areas[i].Type != firstType)
            {
                return false;
            }
        }
        return true;
    }
}

public class Plain : Area
{
    public Plain(string owner, char type, int water) : base(owner, type, water) { }

    public override Area ChangeWeather(IWeather weather)
    {
        return weather.ChangeP(this);
    }
}

public class Grassland : Area
{
    public Grassland(string owner, char type, int water) : base(owner, type, water) { }
    public override Area ChangeWeather(IWeather weather)
    {
        return weather.ChangeG(this);
    }
}

public class LakesRegion : Area
{
    public LakesRegion(string owner, char type, int water) : base(owner, type, water) { }
    public override Area ChangeWeather(IWeather weather)
    {
        return weather.ChangeL(this);
    }
}
