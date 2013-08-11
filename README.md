NLE (Natural Language Engine)
=============================

The Natural Language Engine can handle anything that is related to natural language sentence. Spelling, grammar, conjugation and prediction.

Instead of a list, we could have a lexical tree. There are several advantages :
	-	We could quicly have all the words begining with the letters 'ato' for instance.
		we place the cursor at the node 'a', from there we continue to the no 't' if there is one, and then we continue to the node 'o' if there is one.
		Finally, we could retrieve all the possible words by finding the path to the leafs.		
			a
			|
			t
			|
			o
			├───────┐
			m   	n
		┌───┤	    |
		i	.	    e
		|   		|
		c   		.
		|
		.
		
		In the example below, we have three words : 'atom', 'atomic' and 'atone'. We browse the tree, recording each letter we pass, and when we encounter a '.', that means we have a word.
	
	-	We the tree method, we could easely guess several words if the user enter the begining of a wors, and therefor make a proposition
		For instance, if he enters 'ato', we can propose 'atom' (the shorter word), and if he enters 'atomi', we propose 'atomic'.
		
We could also have a sorted list with all the words in the tree (and have an hybrid system and use the most effective research)


Spelling :
---------

(A traduire) Prévoir une méthode permettant de déterminer si un mot est disponible dans le dictionnaire. Sinon proposer un ou plusieurs mots proches.


Grammar :
--------


Conjugaison :
------------



Prediction :
-----------

(A traduire) Fonctionnalité permettant de proposer une liste de mots en rapport avec un début de phrase.

