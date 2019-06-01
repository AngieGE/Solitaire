# Solitaire
Submitted by: Ariadna Angelica Guemes Estrada
Date: 6/1/2019
Link to repository: https://github.com/AngieGE/Solitaire
----------

### How far i got
Got the main machanics of the game as well as the scene transitions.
I include the Game mechanics that are implemented on this Build.
 ) Random deal to lay out cards in starting cascade columns
 ) The game must have at least 3 screens
 )  You can dragg the top card of a pile on the Tableau onto another Tableau pile, 
     if that pile's top card is one higher than the moved card and in a different color. 
 ) Free Cell's can only hold a single card at a time.
 ) You can move a Tableau card onto the Foundations. 

 Medium accomplish:
 ) Cannot move card to illegal position.
    ) I dont allow user to place illegal positions on free cells or Foundation cells.
    ) On tableau cells i always return true on the function that checks if its a legal movement 
      because i didnt had the time, and i prioritize to prohibit illegal movements on the foundation cells,
      since the winning condition depends on those piles.
 Blocker features
 ) Clicking on “open” card in a column, will move to open ‘freecell’ if one is available
    ) I spend time with this feauture, and now i would've rather having used it for the JSON I/O
    ) I commented the function that did that feauture since the logic is there, but it is not doing the right thing.

Improvements
) The Draggable and droppable is functional, it works smoothly when moving from tableau on to the tableau section.
  But, when moving to the free cell or foundation section it takes a couple of tryies before the card actually sticks to the pile.
  I notice, it helps to take a little time before dropping it and move the card slow. But if i has more time, i would definatelly look into that first.
  Since the smoothines in which the card sticks i consider is more important for the user experience. 
) I would also like to improve the UI 

Thank you ! :D
