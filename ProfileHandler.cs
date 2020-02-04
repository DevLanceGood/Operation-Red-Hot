using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]

public class ProfileHandler
{

    private List<Profile> masterList;
	public ProfileHandler()
	{
        loadProfiles();
	}

    public void saveProfiles()
    {
        try
        {
            foreach (Profile p in masterList)
            {
                Console.WriteLine(p.id);
            }
            using (Stream stream = File.Open("profiles.txt", FileMode.OpenOrCreate))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, masterList);
            }
        }
        catch
        {
            Console.WriteLine("AWFr");
        }
    }

    public void loadProfiles()
    {
        try
        {
            using (Stream stream = File.Open("profiles.txt", FileMode.OpenOrCreate))
            {
                BinaryFormatter bin = new BinaryFormatter();

                masterList = (List<Profile>)bin.Deserialize(stream);
                foreach (Profile profile in masterList)
                {
                    Console.WriteLine(profile.id);
                }
            }
        }
        catch
        {
            masterList = new List<Profile>();
        }
    }

    public List<Profile> getProfilesList()
    {
        return masterList;
    }
    public void createNewProfile(Profile newProfile)
    {
        if (getProfileFromID(newProfile.id) == null)
        {
            masterList.Add(newProfile);
            saveProfiles();
        }
    }
    public void editProfile(string id, string bulletSpeed, string playerSpeed, string alienFirerate, string alienColor)
    {
        if (getProfileFromID(id) != null)
        {
            for (int i = 0; i < masterList.Count; i++)
            {
                if (masterList[i].id == id)
                {
                    masterList[i].bulletSpeed = bulletSpeed;
                    masterList[i].playerSpeed = playerSpeed;
                    masterList[i].alienFirerate = alienFirerate;
                    masterList[i].alienColor = alienColor;
                    saveProfiles();
                }
            }
        }
    }
    public bool profileExists(string id)
    {
        return getProfileFromID(id) != null;
    }
    public Profile getProfileFromID(string id)
    {
        for (int i = 0; i < masterList.Count; i++)
        {
            if (masterList[i].id == id)
            {
                return masterList[i];
            }
        }
        return null;
    }
}