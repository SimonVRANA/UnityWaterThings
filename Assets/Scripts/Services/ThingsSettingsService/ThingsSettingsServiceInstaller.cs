// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ThingsSettingsServiceInstaller", menuName = "Installers/ThingsSettingsServiceInstaller")]
public class ThingsSettingsServiceInstaller : ScriptableObjectInstaller<ThingsSettingsServiceInstaller>
{
	[SerializeField]
	private ThingsSettings thingsSettings;

	public override void InstallBindings()
	{
		Container.BindInterfacesTo<ThingsSettingsService>()
				 .AsSingle()
				 .WithArguments(thingsSettings);
	}
}