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

        type QuestionText = QuestionText of string

        type OptionAnswer = OptionAnswer of string
        type FreeTextAnswer = FreeTextAnswer of string

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

        type Prediction = Prediction of Player * Question * Answer

        type CorrectPrediction = CorrectPrediction of Question * Answer

        type Competition = {
            Groups: Group list;
            GroupTeams: (Group * Team list) list;
            Fixtures: Fixture list;
            Questions: Question list;
            Players: Player list;
            Predictions: Prediction list;
            CorrectPredictions: CorrectPrediction list;
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

        let GetPoints results playerPredictions =

            let getPlayerPredictionsForQuestion question playerPredictions = 
                playerPredictions
                |> List.filter(fun (Prediction (p,q,a)) -> question = q)
                
            let getPlayerPointsForQuestion correctPrediction playerPrediction = 
                match playerPrediction with
                | Prediction (p,q,a) when q = fst correctPrediction && a = snd correctPrediction -> (p, 1)
                | Prediction (p,_,_) -> (p, 0)
                
            let getPlayerPoints playerPredictions correctPrediction = 
                playerPredictions
                |> getPlayerPredictionsForQuestion (fst correctPrediction)
                |> List.map(getPlayerPointsForQuestion correctPrediction)
                
            results
            |> Seq.map(getPlayerPoints playerPredictions)
            |> Seq.concat
            |> Seq.groupBy fst
            |> Seq.map (fun (p,s) -> (p,Seq.sumBy snd s))
            |> Seq.toList
                    
    module Competition =
        open Types

        let CalculatePoints results competition = 
            Prediction.GetPoints results competition.Predictions  
