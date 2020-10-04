using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Links : MonoBehaviour
{
    public void YoutubeLink()
    {
        System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCCz2e3IlOhZQEKCaZysGzdA?view_as=subscriber");
    }

    public void BoosttyLink()
    {
        System.Diagnostics.Process.Start("https://boosty.to/nyaumi");
    }
    public void VKLink()
    {
        System.Diagnostics.Process.Start("https://vk.com/nyaumi_group");
    }

}
