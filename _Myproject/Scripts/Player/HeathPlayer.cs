using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeathPlayer : MonoBehaviour
{
    [Header("Player Heath Amount")]
    [SerializeField] float _currentPlayerHeath = 100f;
    [SerializeField] float _maxPlayerHeath = 100f;
    [SerializeField] int _regenRate = 1;
    bool canRegen = false;

    [Header("Add the Splatter image here")]
    [SerializeField] Image _redSplatterImage;

    [Header("Heath Timer")]
    [SerializeField] float _heathCoolDown = 3f;
    [SerializeField] float _maxHeathCoolDown = 3f;
    [SerializeField] bool _StartCoolDown = false;

    [Header("Hurt Image Flash")]
    [SerializeField] Image _hurtImage;
    [SerializeField] float _hurtTime;

    public float CurrentPlayerHeath { get => _currentPlayerHeath; set => _currentPlayerHeath = value; }

    private void Update()
    {
        CoolDown();
    }
    void CoolDown()
    {
        if (_StartCoolDown)
        {
            // _heathCoolDown - thời gian => 0 
            _heathCoolDown -= Time.deltaTime;
            if (_heathCoolDown <= 0)
            {
                canRegen = true;
                _StartCoolDown = false;
            }
        }
        if (canRegen)
        {
            if (_currentPlayerHeath <= _maxPlayerHeath - 0.01)
            {
                // _currentPlayerHeath sẽ bằng = tốc độ hồi máu 
                _currentPlayerHeath += _regenRate * Time.deltaTime;
                UpDateHeath();
            }
            else
            {
                _currentPlayerHeath = _maxPlayerHeath;
                _heathCoolDown = _maxHeathCoolDown;
                canRegen = false;
            }
        }
    }
    void UpDateHeath()
    {
        Color splaterAlpha = _redSplatterImage.color;
        splaterAlpha.a = 1 - (CurrentPlayerHeath / _maxPlayerHeath);
        _redSplatterImage.color = splaterAlpha;
    }
    IEnumerator HurtFlash()
    {
        _hurtImage.enabled = true;
        yield return new WaitForSeconds(_hurtTime);
        _hurtImage.enabled = false;
    }
    public void TakeDamage()
    {
        if(CurrentPlayerHeath > 0 )
        {
            canRegen = true;
            StartCoroutine(HurtFlash());
            UpDateHeath();
            _heathCoolDown = _maxHeathCoolDown;
            _StartCoolDown = true;
        }
        else { canRegen = false; _StartCoolDown = false; }
    }
}
