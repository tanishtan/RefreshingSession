using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefreshingCourseConsole
{
    public interface IClock
    {
        void SetAlarm();
        void ReadTemperatures();
        void TuneRadio();
    }


    //Wrong approach since the TuneRadio implementation is not present 
    public class AnalogClock : IClock
    {
        public void ReadTemperatures()
        {
            Console.WriteLine("Current temp is: 24.5C");
        }

        public void SetAlarm()
        {
            Console.WriteLine("Chime");
        }

        public void TuneRadio()
        {
            throw new NotImplementedException();
        }
    }

    public class DigitalClock : IClock
    {
        public void ReadTemperatures()
        {
            
        }

        public void SetAlarm()
        {
            
        }

        public void TuneRadio()
        {
            
        }
    }

    // Correct way
    interface IThermometer
    {
        void ReadTemperatures();
    }
    interface IRadio
    {
        void TuneRadio();
    }
    interface IAlarm
    {
        void SetAlarm();
        void PlaySound();
        void Configure();
    }

    public class AncientClock : IAlarm, IRadio
    {
        public void Configure()
        {
            throw new NotImplementedException();
        }

        public void PlaySound()
        {
            throw new NotImplementedException();
        }

        public void setAlarm()
        {
            throw new NotImplementedException();
        }

        public void SetAlarm()
        {
            throw new NotImplementedException();
        }

        public void TuneRadio()
        {
            throw new NotImplementedException();
        }
    }

    public class BatteryClock : IAlarm, IThermometer
    {
        public void Configure()
        {
            throw new NotImplementedException();
        }

        public void PlaySound()
        {
            throw new NotImplementedException();
        }

        public void ReadTemperatures()
        {
            throw new NotImplementedException();
        }

        public void setAlarm()
        {
            throw new NotImplementedException();
        }

        public void SetAlarm()
        {
            throw new NotImplementedException();
        }
    }

    internal class ISP
    {

    }
}
