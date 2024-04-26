using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Fish", menuName = "Fish/New Fish")]
public class FishBase : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] int level;
    [SerializeField] Sprite image;
}
