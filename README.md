# RandomChess
It is a special chess game in which the winners of the battle between chess pieces are randomly determined, and each users has its own characteristics.<br>
 
https://github.com/raphy0316/RandomChess/assets/26518769/619d938a-8c94-4a63-98d5-f5c1082546eb

The game starts with a lobby screen where a left-click anywhere initiates the game. Player 1 and Player 2 take turns within a single game, moving their pieces similar to standard chess rules. Valid moves are highlighted on a yellow grid, and players can only move on their turn.

When a piece attempts to capture another, the game calculates the success and defense probabilities. If the attack succeeds, the opponent's piece is eliminated; otherwise, the attacker's piece is removed.

Players are assigned a random character trait: Hero(영웅), Strategist(전략가), or Tyrant(폭군). Heroes's king can move like knights and always win in attack positions and also have a higher chance of successful defense. Strategists have slightly higher probabilities of winning and blocking for all pieces. Tyrants have standard probabilities but can sacrifice their own pieces to guarantee a victory in the next battle via right-click.

The game concludes if a king is captured. Afterward, players can end the game with a left-click or restart with a right-click.

How to play the game
Click Chess-Chess.exe
