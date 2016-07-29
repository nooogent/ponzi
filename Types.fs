namespace Ponzi
    module Types =
        open System

        type Relationship<'Left,'Right> = 'Left * 'Right

        type Team = Team of string
        type Group = Group of string
        type Score = Score of int * int
        type Player = Player of string

        type Fixture = {
            Date: DateTime
            Home: Team
            Away: Team
        }
        
        type FixtureResult = FixtureResult of Score

        type FixtureResultEnum =
            | Home = 0
            | Away = 1
            | Draw = 2

        type Position =
            | First = 0
            | Second = 1
            | Third = 2
            | Fourth = 3
            | Qtr = 4
            | R16 = 5
            | Group = 6

//        type GroupWinnerQuestion = { Text: string; Group: Group }
//        type TeamQuestion = { Text: string; Teams: Team list }
//        type TeamPositionQuestion = { Text: string; Team: Team}
//        type OptionQuestion = { Text: string; Options: string list }
//        type PlayerQuestion = { Text: string; Players: Player list }
//        type FixtureQuestion = { Text: string; Fixture: Fixture }
//        type FreeTextQuestion = { Text: string; }

        type QuestionText = QuestionText of string

//        type Question = 
//            | GroupWinnerQuestion of GroupWinnerQuestion
//            | TeamQuestion of TeamQuestion
//            | TeamPositionQuestion of TeamPositionQuestion
//            | OptionQuestion of OptionQuestion
//            | PlayerQuestion of PlayerQuestion
//            | FixtureQuestion of FixtureQuestion
//            | FreeTextQuestion of FreeTextQuestion
            
        type OptionAnswer = OptionAnswer of string
        type FreeTextAnswer = FreeTextAnswer of string
        type CorrectAnswer<'a> = CorrectAnswer of 'a

        type Question = 
            | GroupWinnerQuestion of QuestionText * Group
            | TeamQuestion of QuestionText * Team list
            | TeamPositionQuestion of QuestionText * Team
            | OptionQuestion of QuestionText * OptionAnswer list
            | PlayerQuestion of QuestionText * Player list
            | FixtureQuestion of QuestionText * Fixture
            | FreeTextQuestion of QuestionText
        
        type Answer = 
            | TeamAnswer of Team
            | TeamPositionAnswer of Position
            | OptionAnswer of OptionAnswer
            | PlayerAnswer of Player
            | FixtureAnswer of Fixture
            | FreeTextAnswer of FreeTextAnswer

        type Prediction = 
            | PlayerPrediction of Player * Question * Answer
            | CorrectPrediction of Question * CorrectAnswer<Answer>

//        type GroupWinnerPrediction = {Question: GroupWinnerQuestion; Answer: Team}
//        type TeamPrediction = {Question: TeamQuestion; Answer: Team}
//        type TeamPositionPrediction = {Question: TeamPositionQuestion; Answer: Position}
//        type OptionPrediction = {Question: OptionQuestion; Answer: string}
//        type PlayerPrediction = {Question: PlayerQuestion; Answer: Player}
//        type FixturePrediction = {Question: FixtureQuestion; Answer: FixtureResult}
//        type FreeTextPrediction = {Question: FreeTextQuestion; Answer: string}

//        type Prediction = 
//            | GroupWinnerPrediction of Player * GroupWinnerPrediction
//            | TeamPrediction of Player * TeamPrediction
//            | TeamPositionPrediction of Player * TeamPositionPrediction
//            | OptionPrediction of Player * OptionPrediction
//            | PlayerPrediction of Player * PlayerPrediction
//            | FixturePrediction of Player * FixturePrediction
//            | FreeTextPrediction of Player * FreeTextPrediction

        type Competition = {
            Groups: Group list;  
            GroupTeams: (Group * Team list) list;
            Fixtures: Fixture list;
            Questions: Question list; 
            Players: Player list; 
            Predictions: Prediction list;
        }
        
    module Player =
        open Types

        let PlayerPredictions player relations =
            relations
            |> List.filter(fun (pre,pl) -> pl = player)
            |> List.map(fun (pre,pl) -> pl)

    module Group =
        open Types

        let addTeam group groupTeams team =
            groupTeams |> List.append [(group, team)]

        let addTeams group (teams:Team list) groupTeams =
            teams |> addTeam group groupTeams

        let GroupTeams group relations =
            relations
            |> List.filter(fun (grp,tms) -> grp = group)
            |> List.map(fun (grp,tms) -> tms)

    module Question =
        open Types

        let QuestionPredictions question relations =
            relations
            |> List.filter(fun (q,pre) -> q = question)
            |> List.map(fun (q,pre) -> pre)

    module Fixture =
        open Types

        let HomeAwayDraw fixtureResult =
            match fixtureResult with
            | (home,away) when home > away -> FixtureResultEnum.Home
            | (home,away) when home < away -> FixtureResultEnum.Away
            | _ -> FixtureResultEnum.Draw
    
    module Prediction =
        open Types

        let GetPoints results predictions =

            let getPlayerPredictionsForQuestion predictions question = 
                predictions
                |> List.filter(fun (pl,q,pre) -> q = question)
                
            let isPredictionCorrect playerPrediction correctPrediction = 
                match playerPrediction with
                | (_,question,answer) when question = fst correctPrediction && answer = snd correctPrediction -> true
                | _ -> false

            let points = 
                results
                |> List.map(fun res -> (getPlayerPredictionsForQuestion predictions res, res))
                |> List.sumBy(fun pre,res -> if isPredictionCorrect pre then 1 else 0)

            points
                    
    module Competition =
        open Types

        let calculatePoints results competition = 
            results 
            |>  
