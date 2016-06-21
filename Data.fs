namespace Ponzi

    module Data = 

        open Ponzi.Types
        open Ponzi.Player
        open Ponzi.Group
        open Ponzi.Question

    
        //let predictions = 
        //    [
        //        TeamPrediction({Q})
        //    
        //    ]

        //let competition =
        //    { Groups = groups; Players = players; Questions = questions }

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

            let groups =  [groupA;groupB;groupC;groupD;groupE;groupF]

            let getByName name = List.find(fun item -> item = name)
            //let getTeamByName name = List.find(fun team -> team = name)
            //let getGroupByName name obj = getByName obj (Group name)

            let groupA = groups |> getByName (Group "Group A")

            let groupTeams =
                []
                |> Group.addTeam groupA teamFrance
                |> Group.addTeam groupA teamSwiterland
                |> Group.addTeam groupA teamAlbania
                |> Group.addTeam groupA teamRomania
                |> Group.addTeam groupB teamEngland
                |> Group.addTeam groupB teamRussia
                |> Group.addTeam groupB teamWales
                |> Group.addTeam groupB teamSlovakia
                |> Group.addTeam groupC teamGermany
                |> Group.addTeam groupC teamUkraine
                |> Group.addTeam groupC teamPoland
                |> Group.addTeam groupC teamNIreland
                |> Group.addTeam groupD teamSpain
                |> Group.addTeam groupD teamCzech
                |> Group.addTeam groupD teamTurkey
                |> Group.addTeam groupD teamCroatia
                |> Group.addTeam groupE teamBelgium
                |> Group.addTeam groupE teamItaly
                |> Group.addTeam groupE teamIreland
                |> Group.addTeam groupE teamSweden
                |> Group.addTeam groupF teamPortugal
                |> Group.addTeam groupF teamIceland
                |> Group.addTeam groupF teamAustria
                |> Group.addTeam groupF teamHungary

            let winnerQuestion = TeamQuestion({Text = "Winner"; Teams = teams})
            let runnerUpQuestion = TeamQuestion({Text = "Runner Up"; Teams = teams})
            let losingPlayerQuestion = PlayerQuestion({Text = "Who will lose"; Players = players})

            let questions = [winnerQuestion;runnerUpQuestion;losingPlayerQuestion]


            let predictions = []
            let competition = { Groups = groups; Players = players; Questions = questions; Predictions = predictions}
            competition

        let private instance = lazy(getData)
        let competition = instance.Value;


        let groups = competition.Groups

        let getGroup groupName =
            groups
            |> List.find(fun g -> g = groupName)

        let getGroupTeams groupName =
            GroupTeams groupName groups.Teams

        let getAllTeams = 
            groups
            |> Seq.map(fun g -> g.Teams)
            |> Seq.concat
            |> Seq.toList

        let getPlayer playerName =
            players
            |> List.find(fun g -> g.Name = playerName)

        let questions =
            [
                TeamQuestion({Id = 1; Text = "Winner"; Teams = getAllTeams})
                TeamQuestion({Id = 2; Text = "Runner Up"; Teams = getAllTeams})
                PlayerQuestion({Id = 3; Text = "Who will lose"; Players = players})
            ]

        //
        //let getSpendings id =
        //    Json.Load "Data.json"
        //    |> Seq.filter(fun c -> c.Id = id)
        //    |> Seq.collect(fun c -> c.Spendings)
        //    |> List.ofSeq
        //
        //
        //type Csv = CsvProvider<"Data.csv">
        //
        //let getCustomers () =
        //    let file = Csv.Load "Data.csv"
        //    file.Rows
        //    |> Seq.map(fun c->
        //        {
        //            Id = c.Id
        //            IsVip = c.IsVip
        //            Credit = c.Credit * 1M<USD>
        //            PersonalDetails = None
        //            Notifications = NoNotifications
        //        })

