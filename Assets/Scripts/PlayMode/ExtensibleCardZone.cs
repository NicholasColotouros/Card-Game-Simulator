﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExtensibleCardZone : MonoBehaviour, ICardDropHandler
{
    public GameObject cardPrefab;
    public ZonesViewer zonesViewer;
    public List<CardDropZone> cardDropZones;
    public RectTransform extension;
    public RectTransform extensionContent;
    public Text labelText;
    public Text countText;

    public bool IsExtended { get; private set; }

    void Start()
    {
        foreach (CardDropZone dropZone in cardDropZones)
            dropZone.dropHandler = this;
        extensionContent.gameObject.GetOrAddComponent<CardStack>().OnAddCardActions.Add(OnAddCardModel);
        OnStart();
    }

    public virtual void OnStart()
    {
    }

    public virtual void OnDrop(CardModel cardModel)
    {
        AddCard(cardModel.Value);
    }

    public virtual void AddCard(Card card)
    {
        CardModel newCardModel = Instantiate(cardPrefab, extensionContent).GetOrAddComponent<CardModel>();
        newCardModel.Value = card;
        OnAddCardModel(null, newCardModel);
    }

    public virtual void OnAddCardModel(CardStack cardStack, CardModel cardModel)
    {
        if (cardModel == null)
            return;

        CardModel.ShowCard(cardStack, cardModel);
        CardModel.ResetRotation(cardStack, cardModel);
        cardModel.DoubleClickEvent = CardModel.ToggleFacedown;
        cardModel.SecondaryDragAction = null;
    }

    public virtual void ToggleExtension()
    {
        IsExtended = !IsExtended;
        RedetermineWidth();
        extension.gameObject.GetOrAddComponent<CanvasGroup>().alpha = IsExtended ? 1 : 0;
        extension.gameObject.GetOrAddComponent<CanvasGroup>().blocksRaycasts = IsExtended;
    }

    public void RedetermineWidth()
    {
        float width = ((RectTransform)this.transform.GetComponentInParent<Canvas>().transform).rect.width - ZonesViewer.TotalWidth + (zonesViewer.IsVisible ? 0 : ZonesViewer.HiddenWidth);
        extension.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, ZonesViewer.HiddenWidth, width);
    }

    void Update()
    {
        UpdateCountText();
    }

    public virtual void UpdateCountText()
    {
        countText.text = extensionContent.childCount.ToString();
    }
}
