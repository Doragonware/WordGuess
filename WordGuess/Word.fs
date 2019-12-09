module Word
open System

let blank = ' '
let randomWord = Configuration.WORDS.[Random().Next(Configuration.WORDS.Length)] |> Seq.toList

let rec removeBlankWords word =
    if Configuration.ALLOW_BLANKS = true
    then randomWord
    else match word with
            |[] -> randomWord
            |elem::word' when elem <> blank -> removeBlankWords word'
            |_ -> removeBlankWords randomWord

let theWord = removeBlankWords randomWord |> String.Concat

let uppercase (x : string) = x.ToUpper()

let word =
    if Configuration.CASE_SENSITIVE = true
    then theWord
    else theWord |> uppercase

let wordToWorld (word:string) (used:char seq) =
    word |> String.map(fun elem -> 
        if Seq.exists((=) elem) used 
        then elem
        elif Seq.exists ((=) elem) [blank] && Configuration.ALLOW_BLANKS = true
        then blank
        else Configuration.HIDDEN)
