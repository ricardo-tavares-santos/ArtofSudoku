using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//???
using EasyMobile;

public class rwdesenv : MonoBehaviour {

    void Awake()
    {
        if (!RuntimeManager.IsInitialized()) {
            RuntimeManager.Init();
		}
    }
	

    public void OpenStore()
    {
		Application.OpenURL("https://play.google.com/store/apps/dev?id=...");		
    }
	
    public void LikeFacebookPage()
    {
	    Application.OpenURL("https://fb.me/...");
    }	
	
	
	
	string subject = "Art of Sudoku";
	string body = "Art of Sudoku\n\nhttps://play.google.com/store/apps/details?id=com.xxx.ArtofSudoku";	 
	public void shareText(){
		//execute the below lines if being run on a Android device
		#if UNITY_ANDROID
			  //Refernece of AndroidJavaClass class for intent
			  AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
			  //Refernece of AndroidJavaObject class for intent
			  AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
			  //call setAction method of the Intent object created
			  intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			  //set the type of sharing that is happening
			  intentObject.Call<AndroidJavaObject>("setType", "text/plain");
			  //add data to be passed to the other activity i.e., the data to be sent
			  intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
			  intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
			  //get the current activity
			  AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
			  AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			  //start the activity by sending the intent data
			  currentActivity.Call ("startActivity", intentObject);
		#endif
	}	
	public void abrirLeaderboard() {
		#if UNITY_ANDROID
		if (GameServices.IsInitialized()) {
			GameServices.ShowLeaderboardUI();
		} else {
			GameServices.Init();
			GameServices.ShowLeaderboardUI();
		} 
		#endif
	}	
	
	
	
	
	public void BuyNoAdsBt(){ 
		PlayerPrefs.SetInt("Purchase", 1);	
		InAppPurchasing.Purchase(EM_IAPConstants.Product_noads);
	}
	public void BuyHintsBt(){ 
		PlayerPrefs.SetInt("Purchase", 1);	
		InAppPurchasing.Purchase(EM_IAPConstants.Product_hint);
	}	
	
	
	void OnEnable()
	{      
		InAppPurchasing.PurchaseCompleted += PurchaseCompletedHandler;
		InAppPurchasing.PurchaseFailed += PurchaseFailedHandler;
	}
	void OnDisable()
	{            
		InAppPurchasing.PurchaseCompleted -= PurchaseCompletedHandler;
		InAppPurchasing.PurchaseFailed -= PurchaseFailedHandler;
	}
	void PurchaseCompletedHandler(IAPProduct product)
	{ 
		if(PlayerPrefs.GetInt("Purchase", 0) == 1) {
			switch (product.Name)
			{	
				case EM_IAPConstants.Product_noads:				
					CUtils.SetRemoveAds(true);
					PlayerPrefs.SetInt("noads", 1);	
					PlayerPrefs.SetInt("Purchase", 0);					
					break;
				case EM_IAPConstants.Product_hint:			
					GameManager.Hints += 10;
					PlayerPrefs.SetInt("Purchase", 0);	
					SudokuManager.intance.UpdateUI();
					break;	
			}
				
		} 
	}
	void PurchaseFailedHandler(IAPProduct product)
	{
		PlayerPrefs.SetInt("Purchase", 0);	
		Debug.Log("The purchase of product " + product.Name + " has failed.");
	}
	
		
	
}
