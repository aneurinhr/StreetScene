using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour {

    public int lootWorth;

    public int Looted()
    {
        return lootWorth;
    }
}
