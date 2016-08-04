namespace Ponzi

    module Functions =

        open Ponzi.Types
        open Ponzi.Data

        let getTeams = Ponzi.Data.competition.GroupTeams
                    |> Seq.map(fun g -> snd g)
                    |> Seq.toList
                    
        let getQuestions = Ponzi.Data.competition.Questions

        let getPredictions = Ponzi.Data.competition.Predictions

        let testFixtureResult home away = Fixture.HomeAwayDraw (home,away)

        let results = [(getQuestions.[0],TeamAnswer(Team "France"));(getQuestions.[1],TeamAnswer(Team "Portugal"));(getQuestions.[2],PlayerAnswer(Player "Simon"))]

        let getPoints = Competition.CalculatePoints results Ponzi.Data.competition
