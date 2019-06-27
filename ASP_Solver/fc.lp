card_on(freecell(4), card(d,k)).
card_on(freecell(1), card(s,3)).
card_on(freecell(2), card(h,a)).

can_move(freecell(F))  :- not -can_move(freecell(F)), freecell(F).
-can_move(freecell(F)) :- card_on(freecell(F), card(S,R)), freecell(F), card(S,R).


card_on(pos(1), card(c, k)).
card_on(pos(1), card(c, k), card(d, k)).
card_on(pos(1), card(d, k), card(h, k)).
card_on(pos(1), card(s, k), card(s, k)).

top(pos(P), card(S,R)) :- not -top(pos(P), card(S,R)), pos(P), card(S,R).

-top(pos(P),card(S,R)) :- card_on(pos(P), card(S,R), card(S2,R2)), 
    pos(P), card(S,R), card(S2,R2), S!=S2.
-top(pos(P),card(S,R)) :- card_on(pos(P), card(S,R), card(S2,R2)), 
    pos(P), card(S,R), card(S2,R2), R!=R2.


is_black(card(S,R)) :- card(S,R), S = c.
is_black(card(S,R)) :- card(S,R), S = s.
-is_black(card(S,R)) :- card(S,R), S = d.
-is_black(card(S,R)) :- card(S,R), S = h.

can_move(card(S,R), pos(P), pos(P2)) :- is_black(card(S,R)),
    top(pos(P), card(S, R)), card(S2,R2),
    top(pos(P2), card(S2, R2)), -is_black(card(S2,R2)), S != S2, P != P2.

can_move(card(S,R), pos(P), pos(P2)) :- card(S,R), is_black(card(S,R)),
    pos(P), top(pos(P), card(S, R)), pos(P2), card(S2,R2),
    top(pos(P2), card(S2, R2)), -is_black(card(S2,R2)), R != R2, P != P2.


%card_on(homecell(1), card(c,q)).
card_on(homecell(2), card(c,q)).
card_on(homecell(3), card(c,q)).
card_on(homecell(4), card(c,q)).

can_move(homecell(H), card(S,R)) :- not card_on(homecell(H), card(S2,R2)), 
    homecell(H), card(S,R), card(S2,R2), S != S2, R = a.
can_move(homecell(H), card(S,R)) :- not card_on(homecell(H), card(S2,R2)), 
    homecell(H), card(S,R), card(S2,R2), R != R2, R = a.

%can_move(homecell(H), card(S,R)) :- top(pos(P)), card(S2,R2)), pos(P)
