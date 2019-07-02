%%%%%%%%%%%%
%% CARDS:

% clubs
card(c,a).
card(c,2).
card(c,3).
card(c,4).
card(c,5).
card(c,6).
card(c,7).
card(c,8).
card(c,9).
card(c,t).
card(c,j).
card(c,q).
card(c,k).

%% diamonds:
card(d,a).
card(d,2).
card(d,3).
card(d,4).
card(d,5).
card(d,6).
card(d,7).
card(d,8).
card(d,9).
card(d,t).
card(d,j).
card(d,q).
card(d,k).

%% hearts:
card(h,a).
card(h,2).
card(h,3).
card(h,4).
card(h,5).
card(h,6).
card(h,7).
card(h,8).
card(h,9).
card(h,t).
card(h,j).
card(h,q).
card(h,k).

%% spades:
card(s,a).
card(s,2).
card(s,3).
card(s,4).
card(s,5).
card(s,6).
card(s,7).
card(s,8).
card(s,9).
card(s,t).
card(s,j).
card(s,q).
card(s,k).


%%%%%%%%%%%%

%% POSITIONS:
freecell(f1).
freecell(f2).
freecell(f3).
freecell(f4).
homecell(h1).
homecell(h2).
homecell(h3).
homecell(h4).
pos(p1).
pos(p2).
pos(p3).
pos(p4).
pos(p5).
pos(p6).
pos(p7).
pos(p8).

%%      - A location can be a card or a position
location(X) :- freecell(X).
location(X) :- homecell(X).
location(X) :- pos(X).
location(S,R) :- card(S,R).


%%      - limit for number of steps no game should take more than 300 since games 
%%          average roughly around a 100 moves more or less
#const n = 200.
step(0..n).

%%      - "Card S, R is on location L | LS, LR" is a property that changes 
%%          with time.
fluent(on(S,R,L)) :- card(S,R), location(L).
fluent(on(S,R,LS,LR)) :- card(S,R), location(LS,LR).

%%      - "Move card S, R on location L | LS, LR" is a possible action provided
%%           we don't try to put a block onto itself
action(put(S,R,L)) :- card(S,R), location(L).
action(put(S,R,LS,LR)) :- card(S,R), location(LS,LR), S != LS.
action(put(S,R,LS,LR)) :- card(S,R), location(LS,LR), R != LR.

%% FreeCell World Theory Definition
%%      - Effect of action put(S,R,L) and put(S,R,LS,LR) (dynamic causal law)
holds(on(S,R,L), T+1) :- occurs(put(S,R,L),T), T < n.
holds(on(S,R,LS,LR), T+1) :- occurs(put(S,R,LS,LR),T), S != LS, T < n.
holds(on(S,R,LS,LR), T+1) :- occurs(put(S,R,LS,LR),T), R != LR, T < n.

%%      - Indirect effects
%%          "a card can only be in one loction" (state constraint)
-holds(on(S,R,L2),T) :- holds(on(S,R,L1),T), location(L2), L1 != L2.
-holds(on(S,R,LS2,LR2),T) :- holds(on(S,R,LS1,LR1),T), location(LS2,LR2), 
    LS1 != LS2.
-holds(on(S,R,LS2,LR2),T) :- holds(on(S,R,LS1,LR1),T), location(LS2,LR2), 
    LR1 != LR2.

%%          "a card cannot have more than one card directly on top" (state constraint)
-holds(on(S,R,LS2,LR2),T) :- card(S,R), holds(on(LS1,LR1,S,R),T), card(LS2,LR2),
    LS1 != LS2.
-holds(on(S,R,LS2,LR2),T) :- card(S,R), holds(on(LS1,LR1,S,R),T), card(LS2,LR2),
    LR1 != LR2.

%%      - Inertia Axioms (state constraint)
holds(F, T+1) :- holds(F,T), not -holds(F, T+1), T < n.
-holds(F, T+1) :- -holds(F,T), not holds(F, T+1), T < n.

%%      - (executability conditions)
%%          "impossible to move card to a location that is occupied"
:- occurs(put(S,R,L), T), location(L), holds(on(S,R,L), T).
%%          "impossible to move card onto occupied card"
:- occurs(put(S,R,LS,LR), T), card(S,R), card(LS,LR), holds(on(S2,R2,LS,LR), T).


