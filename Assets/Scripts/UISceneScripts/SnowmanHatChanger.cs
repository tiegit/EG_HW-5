using System.Collections.Generic;
using UnityEngine;

public class SnowmanHatChanger : MonoBehaviour
{
    [SerializeField] private List<GameObject> _allHats = new List<GameObject>();

    public void SetHat(int hatIndex)
    {
        for (int i = 0; i < _allHats.Count; i++)
        {
            if (i == hatIndex)
                _allHats[i].SetActive(true);
            else
                _allHats[i].SetActive(false);
        }
    }
}
