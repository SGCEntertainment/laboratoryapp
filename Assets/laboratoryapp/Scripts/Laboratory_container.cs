using UnityEngine;

[CreateAssetMenu(fileName = "Новая лабораторная работа", menuName = "Новая лабораторная работа", order = 51)]
public class Laboratory_container : ScriptableObject
{
    [SerializeField] string laboratory_name;

    [SerializeField] string target_work;

    [SerializeField] string devices_materials;

    [SerializeField] string instructions_work;

    [SerializeField] AudioClip speech;

    public string Laboratory_name
    {
        get => laboratory_name;
    }

    public string Target_work
    {
        get => target_work;
    }

    public string Devices_materials
    {
        get => devices_materials;
    }

    public string Instructions_work
    {
        get => instructions_work;
    }

    public AudioClip Speech
    {
        get => speech;
    }
}
