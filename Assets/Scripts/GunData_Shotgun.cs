namespace DefaultNamespace
{
	public class GunData_Shotgun : GunData
	{
		public GunData_Shotgun()
		{
			RPM = 120;
			semiAutomatic = true;
			pelletsPerShot = 9;
			shotgunSpread = 20;
		}
	}
}