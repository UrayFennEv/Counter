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
        if (Input.GetKeyDown(KeyCode.Mouse0) && _coroutine == null)
        {
            _isWork = true;
            Start();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && _coroutine != null)
        {
            Stop();
        }
    }

    private void Start()
    {
        _coroutine = StartCoroutine(NumberCount(_delay));
    }

    private void Stop()
    {

        StopCoroutine(_coroutine);
        _coroutine = null;
        _isWork = false;

    }

    private IEnumerator NumberCount(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_isWork)
        {
            _count++;
            DisplayCount(_count);
            yield return wait;
        }
    }

    private void DisplayCount(float number)
    {
        _text.text = number.ToString();
    }
}