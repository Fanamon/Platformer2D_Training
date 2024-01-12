using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VampiricButton : MonoBehaviour
{
    private const float AbilityRadius = 2f;
    private const float CastDistance = 10f;
    private const float OneSecond = 1f;

    private const string EnemyLayer = "Enemy";

    [SerializeField] private float _abilityDuration;
    [SerializeField] private float _lifeStealValue;

    [SerializeField] private Player _player;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _timerText;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = _player.transform;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        RaycastHit2D hit = Physics2D.CircleCast(_playerTransform.position, AbilityRadius, Vector2.zero, 
            CastDistance, LayerMask.GetMask(EnemyLayer));

        if (hit)
        {
            StartCoroutine(CastVampirism(hit.transform.GetComponent<Enemy>()));
        }
    }

    private IEnumerator CastVampirism(Enemy enemy)
    {
        float timerCount = _abilityDuration;

        _button.interactable = false;
        _timerText.gameObject.SetActive(true);

        while (timerCount > 0)
        {
            _timerText.text = timerCount.ToString();

            enemy.TakeDamage(_lifeStealValue);
            _player.TakeHeal(_lifeStealValue);

            yield return new WaitForSecondsRealtime(OneSecond);

            timerCount--;
        }

        _button.interactable = true;
        _timerText.gameObject.SetActive(false);
    }
}
