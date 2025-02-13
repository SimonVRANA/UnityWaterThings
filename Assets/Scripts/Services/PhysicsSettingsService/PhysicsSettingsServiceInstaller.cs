// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PhysicsSettingsServiceInstaller", menuName = "Installers/PhysicsSettingsServiceInstaller")]
public class PhysicsSettingsServiceInstaller : ScriptableObjectInstaller<PhysicsSettingsServiceInstaller>
{
	[SerializeField]
	private PhysicsSettings physicsSettings;

	public override void InstallBindings()
	{
		Container.BindInterfacesTo<PhysicsSettingsService>()
				 .AsSingle()
				 .WithArguments(physicsSettings);
	}
}