SELECT Actors.IDActor, Actors.Name, Actors.VacationDate, STRING_AGG(Perf.Name, ',')
AS Perfomances FROM Actors
INNER JOIN ActorPerf ON Actors.IDActor = ActorPerf.IDActor
inner join Perf ON Perf.NumPerf = ActorPerf.NumPerf
GROUP BY Actors.IDActor, Actors.Name, Actors.VacationDate