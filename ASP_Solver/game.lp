 %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%
%% GAME 1 with cards A - 6 already placed into homecells 1 - 4
%%
 %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%% holds(card_on(S,R,L), T): card S,R is on location L at step T.
%% holds(card_on(S,R,LS,LR), T): card S,R is on location LS,LR at step T.



% Column 1:
holds(on(d,j,p1), 0).
holds(on(c,q,d,j), 0).
holds(on(s,7,c,q), 0).
holds(on(s,q,s,7), 0).

% Column 2:
holds(on(card(h,9),p2), 0).
holds(on(card(h,k),card(h,9)), 0).
holds(on(card(d,t),card(h,k)), 0).
holds(on(card(c,8),card(d,t)), 0).

% Column 3:
holds(on(card(c,j),p3), 0).
holds(on(card(s,k),card(c,j)), 0).
holds(on(card(h,t),card(s,k)), 0).
holds(on(card(c,t),card(h,t)), 0).

% Column 4:
holds(on(card(h,7),p4), 0).
holds(on(card(d,9),card(h,7)), 0).
holds(on(card(h,8),card(d,9)), 0).
holds(on(card(c,9),card(h,8)), 0).

% Column 5:
holds(on(card(c,7),p5), 0).
holds(on(card(d,q),card(c,7)), 0).
holds(on(card(h,j),card(d,q)), 0).

% Column 6:
holds(on(card(d,k),p6), 0).
holds(on(card(s,j),card(d,k)), 0).
holds(on(card(d,7),card(s,j)), 0).

% Column 7:
holds(on(card(c,k),p7), 0).
holds(on(card(s,t),card(c,k)), 0).
holds(on(card(s,8),card(s,t)), 0).

% Column 8:
holds(on(card(s,9),p8), 0).
holds(on(card(h,q),card(s,9)), 0).
holds(on(card(d,8),card(h,q)), 0).

% Homecell values:
holds(on(card(c,6),h1), 0).
holds(on(card(d,6),h2), 0).
holds(on(card(h,6),h3), 0).
holds(on(card(s,6),h4), 0).



%% CWA (closed world assumption) 
%%      - If card S,R is not known to be on location L | LS,LR at step 0, then
%%           we assume it is not.

-holds(on(card(S,R),L),0) :- card(S,R), location(L), not holds(on(card(S,R),L),0).
-holds(on(card(S,R),card(LS,LR)),0) :- card(S,R), location(card(LS,LR)), 
    not holds(on(card(S,R),card(LS,LR)),0), S != LS.
-holds(on(card(S,R),card(LS,LR)),0) :- card(S,R), location(card(LS,LR)), 
    not holds(on(card(S,R),card(LS,LR)),0), R != LR.

