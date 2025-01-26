using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class TotalTimeToText : MonoBehaviour
{
    [SerializeField] Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _text.text =
            $"Your total time: {TotalTimeMemory.TotalTime.Minutes} minutes {TotalTimeMemory.TotalTime.Seconds} seconds";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
