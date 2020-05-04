using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
{
    public ConfigScriptable configScriptable;
    public Arena arena;
    public override void InstallBindings()
    {
        Container.BindInstance<ConfigScriptable>(configScriptable);
        Container.BindInstance<Arena>(arena);
    }
}