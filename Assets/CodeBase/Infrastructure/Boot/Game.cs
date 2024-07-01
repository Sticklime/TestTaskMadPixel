using UnityEngine;

public class Game
{
    private readonly IUIFactory _uiFactory;
    private readonly ISceneLoader _sceneLoader;

    private const string WheelOfFortune = "WheelOfFortune";

    private SpinWheel _wheelFortune;
    private GameObject _hud;

    public Game(IUIFactory uiFactory, ISceneLoader sceneLoader)
    {
        _uiFactory = uiFactory;
        _sceneLoader = sceneLoader;
    }

    public void StartGame() =>
        _sceneLoader.Load(WheelOfFortune, InitLevel);

    private void InitLevel()
    {
        _wheelFortune = _uiFactory.CreateWheelFortune();
        _hud = _uiFactory.CreateHud();
    }
}