using Data.ProgressData;

public class ProgressProvider : IProgressProvider
{
    public PlayerProgress PlayerProgress { get; set; } =
        new PlayerProgress(
            new PlayerStats(0, 0),
            new SpinData(5,5));
}