﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CardStack))]
public class StackedZone : ExtensibleCardZone
{
    public CardStack DeckCardStack { get; private set; }

    public CardStack ExtensionCardStack { get; private set; }

    public bool isFaceup;

    private List<CardModel> _cardModels;

    public override void OnStart()
    {
        DeckCardStack = GetComponent<CardStack>();
        ExtensionCardStack = extensionContent.GetComponent<CardStack>();

        DeckCardStack.OnAddCardActions.Add(CardModel.ResetRotation);
        DeckCardStack.OnAddCardActions.Add(OnAddCardModel);
        DeckCardStack.OnRemoveCardActions.Add(OnRemoveCardModel);

        ExtensionCardStack.OnAddCardActions.Remove(CardModel.ShowCard);
        ExtensionCardStack.OnAddCardActions.Add(OnAddCardModel);
        ExtensionCardStack.OnRemoveCardActions.Add(OnRemoveCardModel);
    }

    public override void AddCard(Card card)
    {
        CardModel newCardModel = Instantiate(cardPrefab, IsExtended ? ExtensionCardStack.transform : DeckCardStack.transform).GetOrAddComponent<CardModel>();
        newCardModel.Value = card;
        newCardModel.IsFacedown = !isFaceup;
        OnAddCardModel(IsExtended ? ExtensionCardStack : DeckCardStack, newCardModel);
    }

    public override void OnAddCardModel(CardStack cardStack, CardModel cardModel)
    {
        if (cardStack == null || cardModel == null)
            return;
        
        cardModel.DoubleClickEvent = ToggleExtension;
        cardModel.SecondaryDragAction = Shuffle;

        int cardIndex = CardModels.Count;
        if (cardStack == ExtensionCardStack)
            cardIndex = cardModel.transform.GetSiblingIndex();
        CardModels.Insert(cardIndex, cardModel);
    }

    public void OnRemoveCardModel(CardStack cardStack, CardModel cardModel)
    {
        CardModels.Remove(cardModel);
    }

    public Card PopCard()
    {
        if (CardModels.Count < 1)
            return Card.Blank;

        CardModel cardModel = CardModels [CardModels.Count - 1];
        Card card = cardModel.Value;
        CardModels.Remove(cardModel);
        Destroy(cardModel.gameObject);
        return card;
    }

    public void ToggleExtension(CardModel cardModel)
    {
        ToggleExtension();
    }

    public override void ToggleExtension()
    {
        base.ToggleExtension();
        Display();
    }

    public void Shuffle(Vector2 unused, Vector2 unused2)
    {
        Shuffle();
    }

    public void Shuffle()
    {
        CardModels.Shuffle();
        Display();
    }

    public void Display()
    {
        Transform parent = DeckCardStack.transform;
        if (IsExtended)
            parent = ExtensionCardStack.transform;

        int siblingIndex = IsExtended ? 0 : 3;
        foreach (CardModel cardModel in CardModels) {
            cardModel.transform.SetParent(parent);
            cardModel.IsFacedown = !IsExtended && !isFaceup;
            if (!IsExtended) {
                ((RectTransform)cardModel.transform).anchorMin = new Vector2(0.5f, 0.5f);
                ((RectTransform)cardModel.transform).anchorMax = new Vector2(0.5f, 0.5f);
                ((RectTransform)cardModel.transform).anchoredPosition = Vector2.zero;
                cardModel.transform.SetSiblingIndex(siblingIndex);
                siblingIndex++;
            }
        }
    }

    public override void UpdateCountText()
    {
        countText.text = CardModels.Count.ToString();
    }

    private List<CardModel> CardModels {
        get {
            if (_cardModels == null)
                _cardModels = new List<CardModel>();
            return _cardModels;
        }
    }

    public int Count {
        get {
            return CardModels.Count; 
        }
    }
}
