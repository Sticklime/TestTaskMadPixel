using CodeBase.Logic.WheelFortune;
using UnityEngine;

public interface IUIFactory
{
    void Load();
    SpinWheel CreateWheelFortune();
    GameObject CreateHud();
}