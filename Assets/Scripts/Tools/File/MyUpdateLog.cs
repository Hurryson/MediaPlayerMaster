using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tools/MyUpdateLog")]
public class MyUpdateLog : ScriptableObject
{
    [System.Serializable]
    public class Log
    {
        public string date;

        public string[] bugs;

        public string[] news;
    }

    public List<Log> logs = new List<Log>();
}
