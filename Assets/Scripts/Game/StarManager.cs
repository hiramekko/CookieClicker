using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    [Serializable]
    class StarSetting
    {
        public int Id;
        public GameObject Prefab;
    }

    [SerializeField] List<StarSetting> _starSettings;

    List<StarData> _stars = new List<StarData>();

    float _rad = 0;
    int _createCount = 0;

    public void Setup(List<StarData> savedata)
    {
        _stars = savedata;

        foreach (var f in _stars)
        {
            for (int i = 0; i < f.Level; ++i)
            {
                Purchase(f.Id, true);
            }
        }
    }

    public void Save(SaveData data)
    {
        data.Star = _stars;
    }

    public void Purchase(int Id, bool isInit = false)
    {
        GameObject prefab = _starSettings.Where(s => s.Id == Id).Select(s => s.Prefab).Single();
        GameObject obj = Instantiate(prefab, this.transform);

        if (!isInit)
        {
            bool isFind = false;
            for (int i = 0; i < _stars.Count; ++i)
            {
                if (_stars[i].Id != Id)
                {
                    continue;
                }

                _stars[i].Level++;
                isFind = true;
                break;
            }
            if (!isFind)
            {
                _stars.Add(new StarData() { Id = Id, Level = 1 });
            }
        }

        float r = (float)_createCount / 10.0f;
        obj.transform.localPosition = new Vector3(r * Mathf.Cos(_rad), 0, r * Mathf.Sin(_rad));
        _rad += 0.1f;
        _createCount++;
    }

    public int GetLevel(int Id)
    {
        var data = _stars.Where(f => f.Id == Id);
        if (data.Count() > 0)
        {
            return data.Single().Level;
        }
        else
        {
            return 0;
        }
    }
}
