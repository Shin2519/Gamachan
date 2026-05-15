using UnityEngine;

public class ComboCounter
{
    public int Current { get; private set; }

    public void Add() => Current++;
    public void Reset() => Current = 0;
}
