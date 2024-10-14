using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSound : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    [SerializeField] private Button _button;

    [SerializeField]
    private Sprite _spriteOn;
    [SerializeField]
    private Sprite _spriteOff;
    public static BtnSound instance;

    private void Start()
    {
        _image.sprite = AudioManager.instance.audioMusic.mute != true ? _spriteOn : _spriteOff;
    }
    private void Awake()
    {
        instance = this;
        _button.onClick.AddListener(ChangeVolume);
    }

    public void ChangeVolume()
    {
        AudioManager.instance.MuteSound();
        _image.sprite = AudioManager.instance.Mute ? _spriteOff : _spriteOn;
    }
}
