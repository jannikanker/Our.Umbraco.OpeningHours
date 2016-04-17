﻿using System;
using System.Globalization;
using Our.Umbraco.OpeningHours.Extensions;

namespace Our.Umbraco.OpeningHours.Model {
    
    /// <summary>
    /// Class representing the opening hours of a day at a specific date.
    /// </summary>
    public class OpeningHoursDay {

        #region Properties

        /// <summary>
        /// Gets where the entity is open this day.
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// Gets whether the entity is closed this day.
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Gets the date of the day.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> representing the opening time of the entity.
        /// </summary>
        public DateTime Opens { get; set; }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> representing the closing time of the entity.
        /// </summary>
        public DateTime Closes { get; set; }

        /// <summary>
        /// Gets the weekday of the week.
        /// </summary>
        public DayOfWeek WeekDay {
            get { return Date.DayOfWeek; }
        }

        /// <summary>
        /// Gets whether the day is today.
        /// </summary>
        public bool IsToday {
            get { return Date.IsToday(); }
        }

        /// <summary>
        /// Gets whether the day is tomorrow.
        /// </summary>
        public bool IsTomorrow {
            get { return Date.IsTomorrow(); }
        }

        /// <summary>
        /// Gets whether current time is today and within the opening hours.
        /// </summary>
        public bool IsCurrentlyOpen {
            get { return IsToday && Opens <= DateTime.Now && DateTime.Now <= Closes; }
        }

        /// <summary>
        /// Gets whether entity is currently closed (AKA different day or not within the opening hours of this day).
        /// </summary>
        public bool IsCurrentlyClosed {
            get { return !IsCurrentlyOpen; }
        }

        /// <summary>
        /// Gets the name of the weekday according to <see cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        public string WeekDayName {
            get { return Date.ToString("dddd", CultureInfo.CurrentCulture); }
        }

        /// <summary>
        /// Gets the name of the weekday according to <see cref="CultureInfo.CurrentCulture"/>. The first character of
        /// the name will always be uppercase.
        /// </summary>
        public string WeekDayNameFirstCharToUpper {
            get {
                string name = Date.ToString("dddd", CultureInfo.CurrentCulture);
                return name.Substring(0, 1).ToUpper() + name.Substring(1);
            }
        }

        /// <summary>
        /// Gets the label of this day. Use <see cref="HasLabel"/> to check whether the day has a label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets whether this day has a label (AKA the <see cref="Label"/> has been specified).
        /// </summary>
        public bool HasLabel {
            get { return !String.IsNullOrEmpty(Label); }
        }

        #endregion

        #region Constructors

        internal OpeningHoursDay() { }

        #endregion

    }

}