namespace Ponzi

    module Data = 

        open System
        open Ponzi.Types

        let private getData =

            let playerAndy = Player "Andy"
            let playerMark = Player "Mark"
            let playerNick = Player "Nick"
            let playerSimon = Player "Simon"
            let playerTuck = Player "Tuck"

            let players = [playerAndy;playerMark;playerNick;playerSimon;playerTuck]

            let teamFrance = Team "France"
            let teamSwiterland = Team "Switerland"
            let teamAlbania = Team "Albania"
            let teamRomania = Team "Romania"
            let teamEngland = Team "England"
            let teamRussia = Team "Russia"
            let teamWales = Team "Wales"
            let teamSlovakia = Team "Slovakia"
            let teamGermany = Team "Germany"
            let teamUkraine = Team "Ukraine"
            let teamPoland = Team "Poland"
            let teamNIreland = Team "Northern Ireland"
            let teamSpain = Team "Spain"
            let teamCzech = Team "Czech Republic"
            let teamTurkey = Team "Turkey"
            let teamCroatia = Team "Croatia"
            let teamBelgium = Team "Belgium"
            let teamItaly = Team "Italy"
            let teamIreland = Team "Ireland"
            let teamSweden = Team "Sweden"
            let teamPortugal = Team "Portugal"
            let teamIceland = Team "Iceland"
            let teamAustria = Team "Austria"
            let teamHungary = Team "Hungary"

            let teams = 
                [
                    teamFrance
                    teamSwiterland
                    teamAlbania
                    teamRomania
                    teamEngland
                    teamRussia
                    teamWales
                    teamSlovakia
                    teamGermany
                    teamUkraine
                    teamPoland
                    teamNIreland
                    teamSpain
                    teamCzech
                    teamTurkey
                    teamCroatia
                    teamBelgium
                    teamItaly
                    teamIreland
                    teamSweden
                    teamPortugal
                    teamIceland
                    teamAustria
                    teamHungary
                ]
    
            let groupA = Group "Group A"
            let groupB = Group "Group B"
            let groupC = Group "Group C"
            let groupD = Group "Group D"
            let groupE = Group "Group E"
            let groupF = Group "Group F"

            let groups = [groupA;groupB;groupC;groupD;groupE;groupF]

            let groupTeams =
                []
                |> Group.addTeams groupA [teamFrance;teamSwiterland;teamAlbania;teamRomania]
                |> Group.addTeams groupB [teamEngland;teamRussia;teamWales;teamSlovakia]
                |> Group.addTeams groupC [teamGermany;teamUkraine;teamPoland;teamNIreland]
                |> Group.addTeams groupD [teamSpain;teamCzech;teamTurkey;teamCroatia]
                |> Group.addTeams groupE [teamBelgium;teamItaly;teamIreland;teamSweden]
                |> Group.addTeams groupF [teamPortugal;teamIceland;teamAustria;teamHungary]

            let winnerQuestion = Question.TeamQuestion(QuestionText "Winner", teams)
            let runnerUpQuestion = Question.TeamQuestion(QuestionText "Runner Up", teams)
            let losingPlayerQuestion = Question.PlayerQuestion(QuestionText "Who will lose", players)

            let questions = [winnerQuestion;runnerUpQuestion;losingPlayerQuestion]

            let fixtureFranceVsRomania = { Date = new DateTime(2016, 6, 1, 20, 0, 0); Home = teamFrance; Away = teamRomania }
            let fixtureSwiterlandVsAlbania = { Date = new DateTime(2016, 6, 2, 17, 30, 0); Home = teamSwiterland; Away = teamAlbania }
            let fixtureEnglandVsRussia = { Date = new DateTime(2016, 6, 2, 20, 0, 0); Home = teamEngland; Away = teamRussia }

            let fixtures = [fixtureFranceVsRomania;fixtureSwiterlandVsAlbania;fixtureEnglandVsRussia]

            let andyWinnerQuestionPrediction = Prediction (playerAndy, winnerQuestion, TeamAnswer(teamFrance)) 
            let andyrunnerUpQuestionPrediction = Prediction (playerAndy, runnerUpQuestion, TeamAnswer(teamPortugal))
            let andylosingPlayerQuestionPrediction = Prediction (playerAndy, losingPlayerQuestion, PlayerAnswer(playerTuck))

            let nickWinnerQuestionPrediction = Prediction (playerNick, winnerQuestion, TeamAnswer(teamEngland)) 
            let nickrunnerUpQuestionPrediction = Prediction (playerNick, runnerUpQuestion, TeamAnswer(teamPortugal))
            let nicklosingPlayerQuestionPrediction = Prediction (playerNick, losingPlayerQuestion, PlayerAnswer(playerSimon))

            let predictions = 
                [
                    andyWinnerQuestionPrediction;
                    nickrunnerUpQuestionPrediction;
                    andyrunnerUpQuestionPrediction;
                    nicklosingPlayerQuestionPrediction;
                    andylosingPlayerQuestionPrediction;
                    nickWinnerQuestionPrediction
                ]
            
            let correctPredictions = [
                CorrectPrediction (winnerQuestion,TeamAnswer(Team "France"));
                CorrectPrediction (runnerUpQuestion,TeamAnswer(Team "Portugal"));
                CorrectPrediction (losingPlayerQuestion,PlayerAnswer(Player "Simon"))
            ]

            let competition = {
                Groups = groups;
                GroupTeams = groupTeams;
                Fixtures = fixtures;
                Players = players;
                Questions = questions;
                Predictions = predictions;
                CorrectPredictions = correctPredictions;
            }

            competition

        let private instance = lazy(getData)
        let competition = instance.Value;

