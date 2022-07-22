# PMCCombineSimulator
This code is a creation of mine to simulate a feature in an MMO I enjoy playing. 
In the game, you can acquire Pets, Mounts, and Companions (PMC). You can combine
duplicate of each type to roll for a higher grade. The game has a pity system where
every 20 or 5 fails, you receive a higher grade PMC. I created a formula to estimate 
how many Rare PMC it would take to reach a mythic grade.

There's a 10% chance for a successful combine of a PMC from one rarity stage to the next. With these odds, you will need on average 30 of one rarity to succeed to get 1 of the next rarity (10 combines). 

We know that 20 Rare combines grants a pity Epic.
We know that 20 Epic combines grants a pity Legendary.
We know that 5 Legendary combines grants a pity Mythic.

Since you get 1 PMC of the same rarity returned on a failed combine, and you do not receive a combine counter on a successful combine, you need on average 47 Rare PMC to acquire 3 Epic PMC. This is because after 22 combines, you will on average succeed 2, and get 1 guaranteed from pity. 

Therefore 47 Rare = 3 Epic or 15.667 Rare = 1 Epic
Same applies for Epic to Legendary, since the pity is the same number.
15.667 Epic = 1 Legendary

Assuming you do not succeed any of the 5 Legendary combines, then you need 11 Legendary PMC to get a pity Mythic. 

Assuming you start with 0 Rare, Epic, and Legendary PMC, the formula to calculate how many (on average) PMC you need for a Mythic is then:

x = a + 15.667( b + 15.667( c + 11))

where 
x = # of Rare PMC needed for Mythic
a =  # of Rare PMC obtainable
b = # of Epic PMC obtainable
c = # of Legendary PMC obtainable

This formula assumes you will acquire every Rare, Epic, and Legendary PMC before reaching your pity Mythic. 

For example, there are 40 Rare Companions, 23 Epic Companions, and 9 Legendary Companions, so:

x = 40 + 15.667( 23 + 15.667( 9 + 11))
x = 40 + 15.667(23 + 15.667(20))
x = 40 + 15.667( 23 + 313.34)
x = 40 + 15.667(336.34)
x = 40 + 5269.44
x = 5309.44

Therefore, you need, on average, 5310 Rare Companions to acquire a pity Mythic Companion, assuming you don't succeed any of your legendary combinations and assuming you acquire every Rare, Epic, and Legendary companion on the way. 

