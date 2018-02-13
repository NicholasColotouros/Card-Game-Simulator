# Roadmap

## Bugs
- Fix: Connection in *Play Mode* randomly drops. Debug statements are currently displayed to try to resolve
- Fix: Moving a card with two fingers in *Play Mode* can cause the card to snap based off where you remove one of your fingers
- Fix: Dragging a card in *Play Mode* does not cause it to go on top of other cards
- Fix: Rotating the screen orientation in *Play Mode* can cause the card zone extensions to go off-center
- Fix: Clicking on card images that have transparency does not register clicks in the correct location
- Fix: Red highlight that warns when a card will be destroyed does not appear consistently
- Fix: *Card Search/Filter Menu* in landscape mode does not use entire horizontal space
- Fix: *Card Search/Filter Menu* does not filter on cards that have 0 values for a given enum property
- Fix: *Card Search/Filter Menu* does not filter on cards that have >1 values for a given enum property
- Fix: *Card Search/Filter Menu* toggles selected enum value when you press enter
- Fix: Dragging cards from the search results in the *Deck Editor* sometimes causes the card image to get "stuck" on the screen

## Features
- Show loading bar when loading/downloading a card game in the *Game Selection Menu*. Currently, a "cards loaded" message appears after the game finishes loading
- Resize cards based off \<cardSize\>
- Support multiple card backs
- Support decimal card property data type
- Support object card property data type
- Show connected players in the bottom-left corner of *Play Mode*
- Synchronize dice across all connected players in *Play Mode*
- Synchronize points across all connected players in *Play Mode*
- Show indication of when a deck is shuffled in *Play Mode*
- Support zooming in/out in *Play Mode*
- Allow cards to snap to each other when moving them in *Play Mode*
- Allow automatic deletion of empty decks in *Play Mode*
- Allow players to share a deck in *Play Mode*
- Allow card zones to be defined within certain spaces of the play area in *Play Mode*
- Allow for setting different double-click actions in *Play Mode*
- Press and hold (or right-click) to bring up card actions in *Play Mode*
- Allow rolling multiple dice at once from the *Dice Menu* in *Play Mode*
- Allow different colored dice in *Play Mode*
- Support special action buttons in *Play Mode* (i.e. Reset rotation for all cards)
- Add keyboard shortcuts for *Play Mode*
- Track each card's specific set/id as necessary when saving a deck in the *Deck Editor*
- Create *Sort Menu* when you click on the sort button in the *Deck Editor*
- Allow PgUp and PgDn to control scrolling, as per [Keyboard Shortcuts](KEYBOARD.md)
- New Mahjong tile set
- Add *Settings/Help*:
  - Include a link to a card game's rules from within CGS
  - Display keyboard shortcuts
  - Allow pre-fetching of card images
  - Set card image cache limit

## Stretch
- Fix: Vertical Input is sometimes ignored on the *Main Menu*
- Fix: Creating dice in *Play Mode* places dice in the center of the play area instead of the center of the player's view
- Clear the background once a card enters the play area in *Play Mode*
- Support different formats/game-types for custom card games
- Support sideboards
- Support multiple languages (Spanish,Chinese)
