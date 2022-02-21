using UnityEngine.UI;
using UnityEngine;

public class LabManager : MonoBehaviour
{
    public Text outText;

    public AudioSource source;

    public Laboratory_container lab1;

    void SetText(int id)
    {
        outText.text = id switch
        {
            0 => lab1.Laboratory_name,

            1 => lab1.Target_work,

            2 => lab1.Devices_materials,

            3 => lab1.Instructions_work,

            _ => string.Empty
        };
    }
}
