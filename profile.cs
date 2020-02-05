using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]

public class Profile
{
    public string id;
    public string bulletSpeed;
    public string playerSpeed;
    public string alienFirerate;
    public string alienColor;
	public Profile(string id, string bulletSpeed, string playerSpeed, string alienFirerate, string alienColor)
	{
        saveProfileData(id, bulletSpeed, playerSpeed, alienFirerate, alienColor);
    }

    public void saveProfileData(string id, string bulletSpeed, string playerSpeed, string alienFirerate, string alienColor)
    {
        this.id = id;
        this.bulletSpeed = bulletSpeed;
        this.playerSpeed = playerSpeed;
        this.alienFirerate = alienFirerate;
        this.alienColor = alienColor;
    }
}
