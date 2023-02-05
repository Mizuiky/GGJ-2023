using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public int Pontuation { get; set; }
}
