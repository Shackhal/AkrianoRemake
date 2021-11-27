using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class VideoAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsListener {
    [SerializeField] Button _showAdButton;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOsAdUnitId = "Rewarded_iOS";
    string _adUnitId;

    public Player player;
    public HUD_Control HUD;

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;

        //Disable button until ad is ready to show
        //_showAdButton.interactable = false;
    }

    private void Start()
    {
        LoadAd ();
        Advertisement.AddListener (this);
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log ("Loading Ad: " + _adUnitId);
        Advertisement.Load (_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log ("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals (_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            _showAdButton.onClick.AddListener (ShowAd);
            // Enable the button for users to click:
            //_showAdButton.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button.
    public void ShowAd()
    {
        // Disable the button: 
        //_showAdButton.interactable = false;
        // Then show the ad:
        Advertisement.Show (_adUnitId, this);

        //recargar el Ad
        LoadAd ();
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals (_adUnitId) && showCompletionState.Equals (UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log ("Unity Ads Rewarded Ad Completed");
            // Grant a reward.

            // Load another ad:
            Advertisement.Load (_adUnitId, this);
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log ($"Error loading Ad Unit {adUnitId}: {error.ToString ()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log ($"Error showing Ad Unit {adUnitId}: {error.ToString ()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        _showAdButton.onClick.RemoveAllListeners ();
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log ("Ad listo para salir!");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log ("Falló el Ad...");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log ("Mira este video!");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished && placementId == "Rewarded_Android")
        {
            //Aqui se debe brindar la recompensa al usuario
            //Revivir
                        
            player.enabled = true;
            player.health = player.maxHealth;
            //player.estaMuerto = false;
            player.GetComponent<BoxCollider2D> ().enabled = true;
            player.GetComponent<Animator> ().SetTrigger ("Revivir");
            player.GetComponent<DisparoAuto> ().enabled = true;

            HUD.adFinalizado ();

            Debug.Log ("RECOMPENSA!!");
        }
        if (showResult == ShowResult.Skipped)
        {
            Debug.Log ("NO HAY RECOMPENSA POR SER UN CHICO APURADO");
        }

    }
}
