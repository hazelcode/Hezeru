namespace Hezeru.ModdingAPI;

public interface IMod
{
    public string ModName { get; set; }
    
    public string ModId { get; set; }

    public Version ModVersion { get; set; }

    public Version APIVersion { get; set; }

    public void Load();

    public void Update(double deltaTime);

    public void Render(double deltaTime);
}
