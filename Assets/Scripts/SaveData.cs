using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class StarData
{
    public int Id;
    public int Level;
}

[Serializable]
public class UpgradeData
{
    public int Id;
}

[Serializable]
public class SaveData
{
    public int GameVersion = 1;
    public long CookieNum = 0;
    public List<StarData> Star = new List<StarData>();
    public List<UpgradeData> Upgrade = new List<UpgradeData>();
}
