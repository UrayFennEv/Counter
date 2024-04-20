using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    private float _count = 0;
    private float _delay = 0.5f;
    private bool _isWork = false;

    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine == null)
            {
                _isWork = true;
                Start();
            }
            else if (_coroutine != null)
            {
                Stop();
            }
        }
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Count(_delay));
    }

    private void Stop()
    {

        StopCoroutine(_coroutine);
        _coroutine = null;
        _isWork = false;

    }

    private IEnumerator Count(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_isWork)
        {
            _count++;
            DisplayCounter(_count);
            yield return wait;
        }
    }

    private void DisplayCounter(float number)
    {
        _text.text = number.ToString();
    }
}