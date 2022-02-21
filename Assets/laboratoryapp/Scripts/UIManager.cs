using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    bool isPlay;

    string clipName = "lab1";

    public Text playBtnText;

    public Animation anim;

    public AudioSource source;

    public Slider slider;

    private void Start()
    {
        slider.minValue = 0;

        slider.maxValue = Mathf.FloorToInt(source.clip.length);

        slider.onValueChanged.AddListener((value) =>
        {
            source.time = value;
        });
    }

    private void Update()
    {
        if(!isPlay)
        {
            playBtnText.text = "Воспроизвести";

            return;
        }

        slider.value = source.time;

        isPlay = slider.value != slider.maxValue;
    }

    public void Play()
    {
        isPlay = !isPlay;

        playBtnText.text = isPlay ? "Пауза" : "Воспроизвести";

        anim[clipName].speed = isPlay ? 1 : 0;

        if(isPlay)
        {
            anim.Play();
        }

        if(isPlay)
        {
            source.Play();
        }
        else
        {
            source.Pause();
        }
    }

    public void AddSeconds(int seconds)
    {
        if(!isPlay)
        {
            return;
        }

        anim[clipName].time = anim[clipName].time + seconds;

        if (anim[clipName].time < 0)
        {
            anim[clipName].time = 0;
        }
        else if (anim[clipName].time > anim.clip.length)
        {
            anim[clipName].time = anim.clip.length;
        }

        source.time += Mathf.Min(seconds, source.clip.length);
    }
}
