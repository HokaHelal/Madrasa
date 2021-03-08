import { Component, OnInit } from '@angular/core';
import { CalendarOptions, DateSelectArg, EventClickArg, EventApi } from '@fullcalendar/angular';

@Component({
  selector: 'app-calendar-main',
  templateUrl: './calendar-main.component.html',
  styleUrls: ['./calendar-main.component.scss']
})
export class CalendarMainComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  weekcalendarOptions: CalendarOptions = {
    initialView: 'listWeek',
    dateClick: this.handleDateClick.bind(this), // bind is important!
  };

  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    weekends: true,
    headerToolbar: {
      left: 'prev,next today',
      center: 'title',
      right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
    },
    dateClick: this.handleDateClick.bind(this), // bind is important!
    events: [
      { title: 'event 1', date: '2021-01-01', color: '#ff5599', end: '2021-01-03' },
      { title: 'event 2', date: '2021-01-02' }
    ]
  };

  handleDateClick(arg) {
    alert('date click! ' + arg.dateStr);
    this.weekcalendarOptions.events =[
      {
        title: 'Meeting',
        start: '2021-01-12T14:30:00',
        extendedProps: {
          status: 'done'
        }
      },
      {
        title: 'Birthday Party',
        start: '2021-01-13T07:00:00',
        backgroundColor: 'green',
        borderColor: 'green'
      }
    ];
  }


}
