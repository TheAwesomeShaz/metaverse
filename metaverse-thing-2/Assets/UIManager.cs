using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject productPanel;
    [SerializeField] GameObject startScreen;
    // [SerializeField] GameObject closeBtn;
    [SerializeField] GameObject showProductsBtn;

    [SerializeField] public float[] products;


    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void EnableShowProducts()
    {
        showProductsBtn.SetActive(true);
    }
    public void DisableShowProducts()
    {
        showProductsBtn.SetActive(false);
    }

    public void IncreaseProduct(int productIndex)
    {
        if (products[productIndex] < 9)
        {
            products[productIndex] += 1;
        }
    }

    public void DecreaseProduct(int productIndex)
    {
        if (products[productIndex] > 0)
        {
            products[productIndex] -= 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        productPanel.SetActive(false);
        // closeBtn.SetActive(false);
        showProductsBtn.SetActive(false);
        startScreen.SetActive(true);

    }

    public void Explore()
    {
        startScreen.SetActive(false);
    }

    public void ShowProducts()
    {
        productPanel.SetActive(true);
        showProductsBtn.SetActive(false);

    }

    public void CloseProductPanel()
    {
        productPanel.SetActive(false);
        showProductsBtn.SetActive(true);

    }



}
