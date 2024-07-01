using DefaultNamespace;

public interface IConfigProvider
{
    void Load();
    WheelFortuneConfig GetWheelData();
}