using UnityEngine;

public class Brige : MonoBehaviour
{
    [SerializeField] private GameObject _grip;
    [SerializeField] private GameObject _brige;
    [SerializeField] private GameObject _hint;
    [SerializeField] private GameObject _light;
    private Animator _gripAnimator;
    private Animator _bridgeAnimator;
    private bool _inTrigger;

    private void Start()
    {
        _gripAnimator = _grip.GetComponent<Animator>();
        _bridgeAnimator = _brige.GetComponent<Animator>();
    }

    private void Update()
    {
        BridgeUse();
    }

    private void OnTriggerEnter(Collider arm)
    {
        if (arm.gameObject.name == "Arm")
        {
            _inTrigger = true;
            _hint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider arm)
    {
        if (arm.gameObject.name == "Arm")
        {
            _inTrigger = false;
            _hint.SetActive(false);
        }
    }

    private void BridgeUse()
    {
        if (_inTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _gripAnimator.SetTrigger("GripUse");
                _bridgeAnimator.SetTrigger("BrigdeUp");
                _light.gameObject.SetActive(true);
            }
        }
    }
}
