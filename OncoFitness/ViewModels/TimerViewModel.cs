using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class TimerViewModel : BaseViewModel
	{
        private TimeSpan displayedTimerDateTime;
        private DateTime startDateTime;
        private bool stopTimer;
        
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

        public TimerViewModel()
        {
            DisplayedTimerDateTime = new TimeSpan();
            stopTimer = false;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (!StopTimer)
                {
                    //this.DisplayedTimerDateTime = DateTime.Now - StartDateTime;
                    this.DisplayedTimerDateTime.Add(new TimeSpan (0, 0, 1));
                    return true;
                }
                else return false;
            });
        }

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
    }
}
