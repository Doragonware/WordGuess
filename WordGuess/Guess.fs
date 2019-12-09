module Guess

open System

let helpChar = '!'
let limitLetters = List.append ['a'..'z'] ['A'..'Z']
let limitChars = List.append [helpChar] limitLetters

let rec guess used =
    let key = Console.ReadKey(true)
    let guess' =
        if key.Modifiers = ConsoleModifiers.Control && key.Key = ConsoleKey.H && Configuration.HELP = true
        then helpChar
        elif Configuration.CASE_SENSITIVE = true 
        then key.KeyChar
        else key.KeyChar |> Char.ToUpper

    if Seq.exists ((=) guess') limitChars &&
       not (used |> Seq.exists ((=) guess'))
    then guess'
    else guess used

let rec getHelp (word: char list, used) = 
    match word with
        |c::word' when Seq.exists (fun elem -> elem.Equals(c)) used -> getHelp(word', used)
        |c::word' -> c
        |_ -> raise (new InvalidOperationException("Something is wrong with the code!")) //This should never accour.
