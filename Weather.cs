namespace Nazifa_Assignement_2;

public interface IWeather
{
    Area ChangeP(Plain plain);
    Area ChangeG(Grassland grassland);
    Area ChangeL(LakesRegion lakesRegion);

}

public class Rainy : IWeather
{
    private Rainy() { }

    private static Rainy _instance = null;
    public static Rainy Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Rainy();
            return _instance;
        }
    }
    public Area ChangeP(Plain plain)
    {
        plain.WaterAmount += 20;
        if(plain.WaterAmount < 0)
        {
            plain.WaterAmount = 0;
        }
        if (plain.WaterAmount > 15)
        {
            return new Grassland(plain.Owner, 'G', plain.WaterAmount);
        }
        return plain;
    }
    public Area ChangeG(Grassland grassland)
    {
        grassland.WaterAmount += 15;
        if (grassland.WaterAmount > 50)
        {
            return new LakesRegion(grassland.Owner, 'L', grassland.WaterAmount);
        }
        else if(grassland.WaterAmount < 15)
        {
            return new Plain(grassland.Owner, 'P', grassland.WaterAmount);
        }

        if (grassland.WaterAmount < 0)
        {
            grassland.WaterAmount = 0;
        }
        return grassland;
    }
    public Area ChangeL(LakesRegion lakesRegion)
    {
        lakesRegion.WaterAmount += 20;
        if (lakesRegion.WaterAmount > 50)
        {
            return new Grassland(lakesRegion.Owner, 'G', lakesRegion.WaterAmount);
        }
        if (lakesRegion.WaterAmount < 0)
        {
            lakesRegion.WaterAmount = 0;
        }
        return lakesRegion;
    }
}

public class Sunny : IWeather
{
    private Sunny() { }
    private static Sunny _instance = null;
    public static Sunny Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Sunny();
            return _instance;
        }
    }
    public Area ChangeP(Plain plain)
    {
        plain.WaterAmount -= 3;
        if (plain.WaterAmount > 15)
        {
            return new Grassland(plain.Owner, 'G', plain.WaterAmount);
        }
        if (plain.WaterAmount < 0)
        {
            plain.WaterAmount = 0;
        }
        return plain;
    }
    public Area ChangeG(Grassland grassland)
    {
        grassland.WaterAmount -= 6;
        if (grassland.WaterAmount > 50)
        {
            return new LakesRegion(grassland.Owner, 'L', grassland.WaterAmount);
        }
        else if (grassland.WaterAmount < 15)
        {
            return new Plain(grassland.Owner, 'P', grassland.WaterAmount);
        }

        if (grassland.WaterAmount < 0)
        {
            grassland.WaterAmount = 0;
        }
        return grassland;
    }
    public Area ChangeL(LakesRegion lakesRegion)
    {
        lakesRegion.WaterAmount -= 10;
        if (lakesRegion.WaterAmount > 50)
        {
            return new Grassland(lakesRegion.Owner, 'G', lakesRegion.WaterAmount);
        }
        if (lakesRegion.WaterAmount < 0)
        {
            lakesRegion.WaterAmount = 0;
        }
        return lakesRegion;
    }
}

public class Cloudy : IWeather
{
    private Cloudy() { }
    private static Cloudy _instance = null;
    public static Cloudy Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Cloudy();
            return _instance;
        }
    }
    public Area ChangeP(Plain plain)
    {
        plain.WaterAmount -= 1;
        if (plain.WaterAmount > 15)
        {
            return new Grassland(plain.Owner, 'G', plain.WaterAmount);
        }
        if (plain.WaterAmount < 0)
        {
            plain.WaterAmount = 0;
        }
        return plain;
    }
    public Area ChangeG(Grassland grassland)
    {
        grassland.WaterAmount -= 2;
        if (grassland.WaterAmount > 50)
        {
            return new LakesRegion(grassland.Owner, 'L', grassland.WaterAmount);
        }
        else if (grassland.WaterAmount < 15)
        {
            return new Plain(grassland.Owner, 'P', grassland.WaterAmount);
        }

        if (grassland.WaterAmount < 0)
        {
            grassland.WaterAmount = 0;
        }
        return grassland;
    }
    public Area ChangeL(LakesRegion lakesRegion)
    {
        lakesRegion.WaterAmount -= 3;
        if (lakesRegion.WaterAmount > 50)
        {
            return new Grassland(lakesRegion.Owner, 'G', lakesRegion.WaterAmount);
        }
        if (lakesRegion.WaterAmount < 0)
        {
            lakesRegion.WaterAmount = 0;
        }
        return lakesRegion;
    }
}