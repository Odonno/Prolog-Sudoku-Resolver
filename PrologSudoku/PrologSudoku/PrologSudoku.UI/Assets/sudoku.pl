:- use_module(library(clpfd)).

sudoku(Variables) :-
	Variables = [
	    C11, C12, C13, C14, C15, C16, C17, C18, C19,
	    C21, C22, C23, C24, C25, C26, C27, C28, C29,
	    C31, C32, C33, C34, C35, C36, C37, C38, C39,
	    C41, C42, C43, C44, C45, C46, C47, C48, C49,
	    C51, C52, C53, C54, C55, C56, C57, C58, C59,
	    C61, C62, C63, C64, C65, C66, C67, C68, C69,
	    C71, C72, C73, C74, C75, C76, C77, C78, C79,
	    C81, C82, C83, C84, C85, C86, C87, C88, C89,
	    C91, C92, C93, C94, C95, C96, C97, C98, C99
	],
	Row1 = [C11, C12, C13, C14, C15, C16, C17, C18, C19],
	Row2 = [C21, C22, C23, C24, C25, C26, C27, C28, C29],
	Row3 = [C31, C32, C33, C34, C35, C36, C37, C38, C39],
	Row4 = [C41, C42, C43, C44, C45, C46, C47, C48, C49],
	Row5 = [C51, C52, C53, C54, C55, C56, C57, C58, C59],
	Row6 = [C61, C62, C63, C64, C65, C66, C67, C68, C69],
	Row7 = [C71, C72, C73, C74, C75, C76, C77, C78, C79],
	Row8 = [C81, C82, C83, C84, C85, C86, C87, C88, C89],
	Row9 = [C91, C92, C93, C94, C95, C96, C97, C98, C99],
	Column1 = [C11, C21, C31, C41, C51, C61, C71, C81, C91],
	Column2 = [C12, C22, C32, C42, C52, C62, C72, C82, C92],
	Column3 = [C13, C23, C33, C43, C53, C63, C73, C83, C93],
	Column4 = [C14, C24, C34, C44, C54, C64, C74, C84, C94],
	Column5 = [C15, C25, C35, C45, C55, C65, C75, C85, C95],
	Column6 = [C16, C26, C36, C46, C56, C66, C76, C86, C96],
	Column7 = [C17, C27, C37, C47, C57, C67, C77, C87, C97],
	Column8 = [C18, C28, C38, C48, C58, C68, C78, C88, C98],
	Column9 = [C19, C29, C39, C49, C59, C69, C79, C89, C99],
	Square1 = [C11, C12, C13, C21, C22, C23, C31, C32, C33],
	Square2 = [C41, C42, C43, C51, C52, C53, C61, C62, C63],
	Square3 = [C71, C72, C73, C81, C82, C83, C91, C92, C93],
	Square4 = [C14, C15, C16, C24, C25, C26, C34, C35, C36],
	Square5 = [C44, C45, C46, C54, C55, C56, C64, C65, C66],
	Square6 = [C74, C75, C76, C84, C85, C86, C94, C95, C96],
	Square7 = [C17, C18, C19, C27, C28, C29, C37, C38, C39],
	Square8 = [C47, C48, C49, C57, C58, C59, C67, C68, C69],
	Square9 = [C77, C78, C79, C87, C88, C89, C97, C98, C99],
	Variables ins 1..9,
	all_different(Row1),
	all_different(Row2),
	all_different(Row3),
	all_different(Row4),
	all_different(Row5),
	all_different(Row6),
	all_different(Row7),
	all_different(Row8),
	all_different(Row9),
	all_different(Column1),
	all_different(Column2),
	all_different(Column3),
	all_different(Column4),
	all_different(Column5),
	all_different(Column6),
	all_different(Column7),
	all_different(Column8),
	all_different(Column9),
	all_different(Square1),
	all_different(Square2),
	all_different(Square3),
	all_different(Square4),
	all_different(Square5),
	all_different(Square6),
	all_different(Square7),
	all_different(Square8),
	all_different(Square9),
	label(Variables),
	print(Variables).

init_sudoku([], []) :- !.
init_sudoku([0|R1], [_|R2]) :- !,
	init_sudoku(R1, R2).
init_sudoku([V1|R1], [V2|R2]) :- !,
	V1 #= V2,
	init_sudoku(R1, R2).

/* Affichage du résultat */
printGrille([]).
printGrille(Xs) :- nl,
	printBand(Xs, Xs1),
	write('--------+--------+--------'), nl,
	printBand(Xs1, Xs2),
	write('--------+--------+--------'), nl,
	printBand(Xs2, _).

printBand(Xs, Xs3) :-
	printRow(Xs, Xs1), nl,
	printRow(Xs1, Xs2), nl,
	printRow(Xs2, Xs3), nl.

printRow(Xs, Xs3) :-
	printTriplet(Xs, Xs1), write(' | '),
	printTriplet(Xs1, Xs2), write(' | '),
	printTriplet(Xs2, Xs3).

printTriplet(Xs, Xs3) :-
	printElement(Xs, Xs1), write('   '),
	printElement(Xs1, Xs2), write('   '),
	printElement(Xs2, Xs3).

printElement([X|Xs], Xs) :- var(X), !, write('.').
printElement([X|Xs], Xs) :- write(X).

/* méthode d'exécution */
exec_sudoku(Init, Result) :-
	init_sudoku(Init, Result),
	sudoku(Result).

/* exemples */
sudoku_exemple(Init, Result) :-
	Init = [0, 5, 0, 0, 0, 0, 0, 7, 0, 8, 7, 6, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 5, 3, 8, 0, 4, 4, 2, 0, 0, 6, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 4, 0, 0, 3, 5, 5, 0, 7, 2, 8, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 7, 4, 6, 0, 4, 0, 0, 0, 0, 0, 2, 0],
	init_sudoku(Init, Result),
	sudoku(Result).

sudoku_escargot(Init, Result) :-
	Init = [1, 0, 0, 0, 0, 7, 0, 9, 0, 0, 3, 0, 0, 2, 0, 0, 0, 8, 0, 0, 9, 6, 0, 0, 5, 0, 0, 0, 0, 5, 3, 0, 0, 9, 0, 0, 0, 1, 0, 0, 8, 0, 0, 0, 2, 6, 0, 0, 0, 0, 4, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 1, 0, 0, 4, 0, 0, 0, 0, 0, 0, 7, 0, 0, 7, 0, 0 , 0, 3, 0, 0],
	init_sudoku(Init, Result),
	sudoku(Result).
