using System;
using System.Collections.Generic;

public enum ItemType
{
    Star,
    Upgrade
}

public enum BuildType
{
    UserInput,
    GreenStar,
    BlueStar,
    RedStar,
    PurpleStar
}

[Serializable]
public class ShopItemTable
{
    public ItemType Type;
    public int TargetId;
    public string Name;
    public int Cost;
}

public class GameData
{
    static public List<ShopItemTable> ShopItemTable = new List<ShopItemTable>()
    {
        new ShopItemTable(){ Type = ItemType.Star, TargetId = 1, Name = "緑星", Cost = 10 },
        new ShopItemTable(){ Type = ItemType.Star, TargetId = 2, Name = "青星", Cost = 100 },
        new ShopItemTable(){ Type = ItemType.Star, TargetId = 3, Name = "赤星", Cost = 1000 },
        new ShopItemTable(){ Type = ItemType.Star, TargetId = 4, Name = "紫星", Cost = 10000 },
        new ShopItemTable(){ Type = ItemType.Upgrade, TargetId = 1, Name = "緑星生産力2倍", Cost = 500 },
        new ShopItemTable(){ Type = ItemType.Upgrade, TargetId = 2, Name = "青星生産力2倍", Cost = 10000 },
        new ShopItemTable(){ Type = ItemType.Upgrade, TargetId = 3, Name = "全部生産力2倍", Cost = 100000 }
    };
}
