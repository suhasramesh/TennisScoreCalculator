# TennisScoreCalculator

Instal Modules package
This is my ReadMe File
==============================
To use this library, add using statement for Models.

Execute "ViewModels.MatchStartCommand" to start the match.

Call "ViewModels.PushResult()" with selected set count parameter.

"ViewModels.SelectedServingPlayer" is called when we change the player who wants to serve.

"ViewModels.SelectedSetCount" is called when we change the setscount while starting the match.

"ViewModels.Players" property has the information like Performance, Name, MatchWon, CurrentServe, IsServe, SetWonCount, GameWin, SetPoints 




Example Demonstration as follows :

We have 2 Screens, Peferee Panel and Spectators Panel in the application.
As soon the application starts, initially only one screen will be displayed. Select the Set Count (3 or 5) and press Start match, then the 2 screens will be displayed
and the match will be start. Select the player who is serving and then select the point type, it can be Fault, Point, Ace and Fault on Serve. 
After the match is completed, Statistics will we be shown. Again match can be started by clicking Start Match.
