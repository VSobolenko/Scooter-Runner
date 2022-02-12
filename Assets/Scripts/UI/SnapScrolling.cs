using Analytics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
    public GameObject lockVillage;
    public GameObject lockForest;
    public GameObject lockCity;

    public Color lockColor;
    public float sizeLock = 10;

    private int _unlockVillage;
    private int _unlockForest;
    private int _unlockCity;

    public TextMeshProUGUI score;

    [Range(1, 100)]
    [Header("Interval")]
    public int interval;

    [Header("Map")]
    public GameObject[] instMap;

    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(0f, 10f)]
    public float scaleOffset;
    [Range(1f, 20f)]
    public float scaleSpeed;

    public ScrollRect scrollRect;

    private GameObject[] _inst;
    private Vector2[] _positionMap;
    private Vector2[] pansScale;

    private float _distance;
    private RectTransform rectTransform;
    private Vector2 contentVector;

    private int selectedPanID;
    private bool isScrolling;

    private int _skull;

    private GameObject _lockVillage;
    private GameObject _lockForest;
    private GameObject _lockCity;

    private void Start()
    {
        bool restartSaveValue = false;
        if (restartSaveValue)
        {
            PlayerPrefs.SetInt("UnlVillage", 0);
            PlayerPrefs.SetInt("UnlForest", 0);
            PlayerPrefs.SetInt("UnlCity", 0);
            PlayerPrefs.SetInt("Skull", 50);
        }

        _unlockVillage = PlayerPrefs.GetInt("UnlVillage", 0);
        _unlockForest = PlayerPrefs.GetInt("UnlForest", 0);
        _unlockCity = PlayerPrefs.GetInt("UnlCity", 0);
        _skull = PlayerPrefs.GetInt("Skull", 0);

        foreach (var index in instMap)
        {
            index.GetComponent<Button>().enabled = true;
            index.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }

        if (_unlockVillage == 0)
        {
            instMap[1].GetComponent<Button>().enabled = false;
            instMap[1].GetComponent<Image>().color = lockColor;

            _lockVillage = Instantiate(lockVillage, instMap[1].transform.position, Quaternion.identity);
            _lockVillage.transform.localScale *= sizeLock;
            _lockVillage.transform.SetParent(instMap[1].transform);
        }

        if (_unlockForest == 0)
        {
            instMap[2].GetComponent<Button>().enabled = false;
            instMap[2].GetComponent<Image>().color = lockColor;

            _lockForest = Instantiate(lockForest, instMap[2].transform.position, Quaternion.identity);
            _lockForest.transform.localScale *= sizeLock;
            _lockForest.transform.SetParent(instMap[2].transform);
        }

        if (_unlockCity == 0)
        {
            instMap[3].GetComponent<Button>().enabled = false;
            instMap[3].GetComponent<Image>().color = lockColor;
            instMap[3].transform.SetParent(Instantiate(lockCity, instMap[3].transform.position, Quaternion.identity).transform);

            _lockCity = Instantiate(lockCity, instMap[3].transform.position, Quaternion.identity);
            _lockCity.transform.localScale *= sizeLock;
            _lockCity.transform.SetParent(instMap[3].transform);
        }

        rectTransform = GetComponent<RectTransform>();
        _inst = new GameObject[instMap.Length];
        _positionMap = new Vector2[instMap.Length];
        pansScale = new Vector2[instMap.Length];

        for (int i = 0; i < instMap.Length; i++)
        {

            _inst[i] = Instantiate(instMap[i], transform, false);
            _inst[i].SetActive(true);
            if (i == 0)
            {
                continue;
            }
            _inst[i].transform.localPosition = new Vector2(_inst[i - 1].transform.localPosition.x + instMap[i].GetComponent<RectTransform>().sizeDelta.x + interval, _inst[i].transform.localPosition.y);
            _positionMap[i] = -_inst[i].transform.localPosition;
        }

        score.text = _skull.ToString();
    }

    private void FixedUpdate()
    {
        if (rectTransform.anchoredPosition.x >= _positionMap[0].x && !isScrolling || rectTransform.anchoredPosition.x <= _positionMap[_positionMap.Length - 1].x && !isScrolling)
            scrollRect.inertia = false;

        float nearestPos = float.MaxValue;

        for (int i = 0; i < instMap.Length; i++)
        {
            _distance = Mathf.Abs(rectTransform.anchoredPosition.x - _positionMap[i].x);

            if (_distance < nearestPos)
            {
                nearestPos = _distance;
                selectedPanID = i;
            }

            float scale = Mathf.Clamp(1 / (_distance / interval) * scaleOffset, 0.5f, 1f);
            pansScale[i].x = Mathf.SmoothStep(_inst[i].transform.localScale.x, scale + 0.3f, scaleSpeed * Time.fixedDeltaTime);
            pansScale[i].y = Mathf.SmoothStep(_inst[i].transform.localScale.y, scale + 0.3f, scaleSpeed * Time.fixedDeltaTime);
            _inst[i].transform.localScale = pansScale[i];
        }

        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);

        if (scrollVelocity < 400 && !isScrolling) scrollRect.inertia = false;

        if (isScrolling || scrollVelocity > 400) return;

        contentVector.x = Mathf.SmoothStep(rectTransform.anchoredPosition.x, _positionMap[selectedPanID].x, snapSpeed * Time.fixedDeltaTime);
        rectTransform.anchoredPosition = contentVector;

    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
        if (scroll) scrollRect.inertia = true;
    }

    public void BuyVillage()
    {
        BuyMap(_inst[1], _lockVillage, "UnlVillage", 19);
    }

    public void BuyForest()
    {
        BuyMap(_inst[2], _lockForest, "UnlForest", 39);
    }

    public void BuyCity()
    {
        BuyMap(_inst[3], _lockCity, "UnlCity", 59);
    }

    private void BuyMap(GameObject buttonLoad, GameObject lockLoad, string nameSave, int cost)
    {
        _skull = PlayerPrefs.GetInt("Skull", 0);

        Debug.Log("Skull before buy: " + _skull);
        if (_skull >= cost)
        {
            _skull -= cost;
            PlayerPrefs.SetInt("Skull", _skull);

            buttonLoad.GetComponent<Button>().enabled = true;
            buttonLoad.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

            Destroy(buttonLoad.transform.GetChild(0).gameObject);
            PlayerPrefs.SetInt(nameSave, 1);
            AnalyticsController.ByNewLevel(nameSave.Substring(3), cost, _skull);
        }
        else
        {
            buttonLoad.transform.GetChild(0).gameObject.GetComponent<Animator>().Play(0);
        }
        Debug.Log("Skull after buy " + _skull);
        score.text = _skull.ToString();
    }
}
