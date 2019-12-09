open System

let lengthOfWord = Word.word.Length

let rec play word used tries=
    let word' = Word.wordToWorld word used
    Console.Write(word')
    Console.Write(" USED: ")
    printfn "%A" used
    
    if word = word' then
        printfn "You won the game! Using only %i guesses!" tries
    else
        let guess = Guess.guess used

        let wordList = Seq.toList word
        if guess.Equals(Guess.helpChar) 
        then
            let help = Guess.getHelp(wordList,used)
            play word (help::used) (tries+1)
        else
            play word (guess::used) (tries+1)

// The presentations with do
do Console.WriteLine("Welcome to word guesser")
do Console.WriteLine()
do Console.Write("The length of the word is ")
do Console.WriteLine(lengthOfWord)  
do Console.WriteLine()
do play Word.word [] 0