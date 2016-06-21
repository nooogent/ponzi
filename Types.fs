namespace Ponzi
    module Types =
        open System

        type Relationship<'Left,'Right> = 'Left * 'Right

        type Team = Team of string

        type Group = Group of string

        type Score = {
            HomeScore: int
            AwayScore: int
        }

        type Fixture = {
            Date: DateTime
            Home: Team
            Away: Team
            Score: Score
        }

        type FixtureResult =
            | Home = 0
            | Away = 1
            | Draw = 2

        type Player = Player of string

        type Position =
            | First = 0
            | Second = 1
            | Third = 2
            | Fourth = 3
            | Qtr = 4
            | R16 = 5
            | Group = 6


        type GroupWinnerQuestion = { Text: string; Group: Group }
        type TeamQuestion = { Text: string; Teams: Team list }
        type TeamPositionQuestion = { Text: string; Team: Team}
        type OptionQuestion = { Text: string; Options: string list }
        type PlayerQuestion = { Text: string; Players: Player list }
        type FixtureQuestion = { Text: string; Fixture: Fixture }
        type FreeTextQuestion = { Text: string; }

        type Question = 
            | GroupWinnerQuestion of GroupWinnerQuestion
            | TeamQuestion of TeamQuestion
            | TeamPositionQuestion of TeamPositionQuestion
            | OptionQuestion of OptionQuestion
            | PlayerQuestion of PlayerQuestion
            | FixtureQuestion of FixtureQuestion
            | FreeTextQuestion of FreeTextQuestion

        type GroupWinnerPrediction = {Question: GroupWinnerQuestion; Answer: Team}
        type TeamPrediction = {Question: TeamQuestion; Answer: Team}
        type TeamPositionPrediction = {Question: TeamPositionQuestion; Answer: Position}
        type OptionPrediction = {Question: OptionQuestion; Answer: string}
        type PlayerPrediction = {Question: PlayerQuestion; Answer: Player}
        type FixturePrediction = {Question: FixtureQuestion; Answer: FixtureResult}
        type FreeTextPrediction = {Question: FreeTextQuestion; Answer: string}

        type Prediction = 
            | GroupWinnerPrediction of GroupWinnerPrediction
            | TeamPrediction of TeamPrediction
            | TeamPositionPrediction of TeamPositionPrediction
            | OptionPrediction of OptionPrediction
            | PlayerPrediction of PlayerPrediction
            | FixturePrediction of FixturePrediction
            | FreeTextPrediction of FreeTextPrediction

        type Competition = { Groups: Group list; Questions: Question list; Players: Player list; Predictions: Prediction list}
        
    module Player =
        open Types

        let PlayerPredictions player relations =
            relations
            |> List.filter(fun (pre,pl) -> pl = player)
            |> List.map(fun (pre,pl) -> pl)

    module Group =
        open Types

        let addTeam group team groupTeams =
            groupTeams |> List.append [(group, team)]

        let GroupTeams group relations =
            relations
            |> List.filter(fun (grp,tm) -> grp = group)
            |> List.map(fun (grp,tm) -> tm)

    module Question =
        open Types

        let QuestionPredictions question relations =
            relations
            |> List.filter(fun (q,pre) -> q = question)
            |> List.map(fun (q,pre) -> pre)
