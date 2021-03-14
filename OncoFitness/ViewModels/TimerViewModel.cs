using System;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class TimerViewModel : BaseViewModel
	{
		#region Fields

		private TimeSpan displayedTimerDateTime;
        private DateTime startDateTime;
        private bool stopTimer;
        private bool pauseTimer;

        #endregion

        #region Properties

        public TimeSpan DisplayedTimerDateTime
        {
            get
            {
                return displayedTimerDateTime;
            }

            set
            {
                if (value != displayedTimerDateTime)
                {
                    displayedTimerDateTime = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }
        public bool StopTimer
        {
            get { return stopTimer; }
            set { stopTimer = value; }
        }
        public bool PauseTimer
        {
            get { return pauseTimer; }
            set { pauseTimer = value; }
        }

		#endregion

		#region Constructor

		public TimerViewModel()
        {
            DisplayedTimerDateTime = new TimeSpan();
            stopTimer = false;
            pauseTimer = false;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (!StopTimer)
                {
                    if (!PauseTimer)
                    {
                        this.DisplayedTimerDateTime = DisplayedTimerDateTime.Add(new TimeSpan(0, 0, 1));
                    }

                    return true;
                }
                else return false;
            });
        }

		#endregion
    }
}
