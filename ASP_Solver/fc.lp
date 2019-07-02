can_move(freecell(F))  :- not -can_move(freecell(F)), freecell(F).
-can_move(freecell(F)) :- card_on(freecell(F), card(S,R)), card(S,R).


top(pos(P), card(S,R)) :- not -top(pos(P), card(S,R)), pos(P), card(S,R).

-top(pos(P),card(S,R)) :- card_on(pos(P), card(S,R), card(S2,R2)), 
    pos(P), card(S,R), card(S2,R2), S!=S2.
-top(pos(P),card(S,R)) :- card_on(pos(P), card(S,R), card(S2,R2)), 
    pos(P), card(S,R), card(S2,R2), R!=R2.


is_black(card(S,R)) :- card(S,R), S = c.
is_black(card(S,R)) :- card(S,R), S = s.
-is_black(card(S,R)) :- card(S,R), S = d.
-is_black(card(S,R)) :- card(S,R), S = h.

can_move(card(S,R), card(S2,R2)) :- not -can_move(card(S,R),card(S2,R2)),
    card(S,R), card(S2,R2), S != S2.
can_move(card(S,R), card(S2,R2)) :- not -can_move(card(S,R),card(S2,R2)),
    card(S,R), card(S2,R2), R != R2.

-can_move(card(S,R), card(S2,R2)) :- is_black(card(S,R)), is_black(card(S2,R2)),
    S != S2.
-can_move(card(S,R), card(S2,R2)) :- is_black(card(S,R)), is_black(card(S2,R2)),
    R != R2.
-can_move(card(S,R), card(S2,R2)) :- -top(pos(P), card(S,R)), -top(pos(P2), card(S2,R2)),
    pos(P), pos(P2), card(S,R), card(S2,R2), P != P2, S != S2.
-can_move(card(S,R), card(S2,R2)) :- -top(pos(P), card(S,R)), -top(pos(P2), card(S2,R2)),
    pos(P), pos(P2), card(S,R), card(S2,R2), P != P2, R != R2.

%card_on(homecell(1), card(c,q)).
%ard_on(homecell(2), card(c,q)).
%ard_on(homecell(3), card(c,q)).
%ard_on(homecell(4), card(c,q)).
%
%an_move(homecell(H), card(S,R)) :- not card_on(homecell(H), card(S2,R2)), 
%   homecell(H), card(S,R), card(S2,R2), S != S2, R = a.
%an_move(homecell(H), card(S,R)) :- not card_on(homecell(H), card(S2,R2)), 
%   homecell(H), card(S,R), card(S2,R2), R != R2, R = a.

%can_move(homecell(H), card(S,R)) :- top(pos(P)), card(S2,R2)), pos(P)
