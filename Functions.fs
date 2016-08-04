namespace Ponzi

    module Functions =

        open Ponzi.Types
        open Ponzi.Data

        let getTeams = Ponzi.Data.competition.GroupTeams
                    |> Seq.map(snd)
                    |> Seq.toList
                    
        let getQuestions = Ponzi.Data.competition.Questions

        let getPredictions = Ponzi.Data.competition.Predictions

        let testFixtureResult home away = Fixture.HomeAwayDraw (home,away)

        let results = [(getQuestions.Item 0,TeamAnswer(Team "France"));(getQuestions.Item 1,TeamAnswer(Team "Portugal"));(getQuestions.Item 2,PlayerAnswer(Player "Simon"))]

        let getPoints = Competition.CalculatePoints results Ponzi.Data.competition
