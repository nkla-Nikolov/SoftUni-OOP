using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const string racingBehavior = "strict";
        private const int drivingExperience = 30;

        public ProfessionalRacer(string username, ICar car) : base(username, racingBehavior, drivingExperience, car)
        {
        }

        public override void Race()
        {
            this.DrivingExperience += 10;
            base.Race();
        }
    }
}
