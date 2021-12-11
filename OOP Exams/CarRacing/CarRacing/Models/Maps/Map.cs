using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        private const double strictBehaviorMultiplier = 1.2;
        private const double aggressiveBehaviorMultiplier = 1.1;

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return "Race cannot be completed because both racers are not available!";
            }
            if (racerOne.IsAvailable() == false)
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            if (racerTwo.IsAvailable() == false)
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            racerOne.Race();
            racerTwo.Race();

            double firstRacerPoints = 0;
            double secondRacerPoints = 0;

            if (racerOne.RacingBehavior == "strict")
            {
                firstRacerPoints = racerOne.Car.HorsePower * racerOne.DrivingExperience * strictBehaviorMultiplier;
            }
            else
            {
                firstRacerPoints = racerOne.Car.HorsePower * racerOne.DrivingExperience * aggressiveBehaviorMultiplier;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                secondRacerPoints = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * strictBehaviorMultiplier;
            }
            else
            {
                secondRacerPoints = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * aggressiveBehaviorMultiplier;
            }

            if (firstRacerPoints > secondRacerPoints)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }

            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
        }
    }
}
