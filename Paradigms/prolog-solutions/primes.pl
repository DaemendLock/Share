composit(1) :- false.
composit(X):- X<2; composit(X, 2).
composit(X,Y) :- 0 is X mod Y, !.
composit(X,Y) :- sqrt(X)+1 > Y+1, Y1 is Y+1, composit(X, Y1).
prime(2) :- true,!.
prime(X) :- X < 2,!,false.
prime(X) :- not(composit(X)).
raw(Divisors, 1) :- length(Divisors, 1).
raw(Divisors, Ind) :- length(Divisors, Ind); IndPrev is Ind-1, nth0(IndPrev, Divisors, Div1),  nth0(Ind, Divisors, Div2), not(Div1 > Div2), IndNext is Ind+1, raw(Divisors, IndNext).
prime_divisors(X, Divisors, Ind) :- length(Divisors, Ind), X = 1;
    								not(length(Divisors, Ind)), IndNext is Ind+1,  nth0(Ind, Divisors, Elem), prime(Elem), 0 is X mod Elem, X1 is X / Elem, prime_divisors(X1, Divisors, IndNext).
prime_divisors(X, Divisors) :- raw(Divisors, 1),(  X = 1, length(Divisors, 0); prime_divisors(X, Divisors, 0)).
