namespace DefaultNamespace
{
	public class GunData_Sniper : GunData
	{
		public GunData_Sniper()
		{
			RPM = 60;
			semiAutomatic = true;
			bulletDamage = 100;
			gunshotFolder = "Sounds/Gunshot/Sniper";
		}
	}
}