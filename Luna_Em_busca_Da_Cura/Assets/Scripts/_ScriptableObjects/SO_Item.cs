using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Item : MonoBehaviour
{
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public int Pontuation { get; set; }
}
